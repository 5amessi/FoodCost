using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Food_Cost
{
    /// <summary>
    /// Interaction logic for Store_Sertup.xaml
    /// </summary>
    public partial class Store_Sertup : UserControl
    {
        public Store_Sertup()
        {
            InitializeComponent();

            FillDGV();
            MainUiFormat();
        }

        //functions
        private void FillDGV()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Code,Name,Name2,IsMain,IsActive from Store_Setup";
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), Name2 = reader["Name2"].ToString(), IsMain = reader["IsMain"].ToString(), IsActive = reader["IsActive"].ToString() };
                    Stores_DGV.Items.Add(data);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }
        public void MainUiFormat()
        {
            Code_txt.IsEnabled = false;
            Name_txt.IsEnabled = false;
            Name2_txt.IsEnabled = false;
            Active_chbx.IsEnabled = false;
            SaveBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            UndoBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
            NewBtn.IsEnabled = true;
            KitchenBtn.IsEnabled = false;

        }
        public void EnableUI()
        {
            Code_txt.IsEnabled = true;
            Name_txt.IsEnabled = true;
            Name2_txt.IsEnabled = true;
            Active_chbx.IsEnabled = true;
            SaveBtn.IsEnabled = true;
            UpdateBtn.IsEnabled = true;
            UndoBtn.IsEnabled = true;
            DeleteBtn.IsEnabled = true;
            NewBtn.IsEnabled = true;
            KitchenBtn.IsEnabled = true;
        }
        private void ClearUIFields()
        {
            Code_txt.Text = "";
            Name_txt.Text = "";
            Name2_txt.Text = "";
            Active_chbx.IsChecked = false;
            IsMain.IsChecked = false;
        }

        private void NewButtonClicked(object sender, RoutedEventArgs e)
        {
            EnableUI();
            ClearUIFields();
            KitchenBtn.IsEnabled = false;
            NewBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Code_txt.Text == "")
            {
                MessageBox.Show("Code Field Can't Be Empty");
                return;
            }

            foreach (DgvData item in Stores_DGV.Items)
            {
                if (item.Code.Equals(Code_txt.Text))
                {
                    MessageBox.Show("This Code Is Not Avaliable");
                    return;
                }
            }

            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = "insert into Store_Setup(Code,Name,Name2,IsMain,IsActive) values (" + Code_txt.Text +  ",'" + Name_txt.Text + "','" +
                    Name2_txt.Text  + "','" + IsMain.IsChecked + "','" + Active_chbx.IsChecked + "')";

                SqlCommand cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                MainUiFormat();

                Stores_DGV.Items.Clear();
                FillDGV();
            }
            MessageBox.Show("Saved Successfully");
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = "Update Store_Setup SET " + "Name = '" + Name_txt.Text + "', Name2 = '" + Name2_txt.Text  + "', IsMain = '" + IsMain.IsChecked  + "', IsActive = '" + Active_chbx.IsChecked + "' Where Code = " + Code_txt.Text;
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                MainUiFormat();

                Stores_DGV.Items.Clear();
                FillDGV();
            }
            MessageBox.Show("Updated Successfully");
        }

        private void UndoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUiFormat();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = "delete from Store_Setup where Code = " + Code_txt.Text;
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                MainUiFormat();

                Stores_DGV.Items.Clear();
                FillDGV();
            }
            MessageBox.Show("Deleted Successfully");
        }

        private void RowClicked(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid data = sender as DataGrid;

                if (data != null && data.SelectedItems != null && data.SelectedItems.Count == 1)
                {
                    DgvData dgvData = (DgvData)data.SelectedItem;

                    Code_txt.Text = dgvData.Code;
                    Name_txt.Text = dgvData.Name;
                    Name2_txt.Text = dgvData.Name2;
                    Active_chbx.IsChecked = dgvData.IsActive.ToLower().Equals("true");
                    IsMain.IsChecked = dgvData.IsMain.ToLower().Equals("true");

                    EnableUI();
                    Code_txt.IsEnabled = false;
                    NewBtn.IsEnabled = false;
                    SaveBtn.IsEnabled = false;
                    KitchenBtn.IsEnabled = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Code_txt.Text == "")
            {
                MessageBox.Show("select store");
                return;
            }
            Kitchens_Setup kitchens_Setup = new Kitchens_Setup(this);
            kitchens_Setup.ShowDialog();
        }
    }
}
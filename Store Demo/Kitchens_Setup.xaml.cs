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
using System.Windows.Shapes;
using Food_Cost.Classes;

namespace Food_Cost
{
    /// <summary>
    /// Interaction logic for Kitchens_Setup.xaml
    /// </summary>
    public partial class Kitchens_Setup : Window
    {
        string code;
        public Kitchens_Setup(Store_Sertup _this)
        {
            InitializeComponent();

            code = _this.Code_txt.Text;

            ParentStore();
            FillDGV(code);
            MainUiFormat();
        }

        private void ParentStore()
        {
            SqlConnection con = new SqlConnection(Conn.DataConnString);
            try
            {
                con.Open();
                string s = string.Format("select Name from Store_Setup where Code = {0}", code);
                SqlCommand cmd = new SqlCommand(s, con);
                ParentStore_cbx.Text = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }

        private void FillDGV(string code)
        {
            SqlConnection con = new SqlConnection(Conn.DataConnString);
            SqlDataReader reader = null;

            try
            {
                con.Open();
                string s = string.Format("select Code,Name,Name2,IsMain,IsOutlet,IsActive from Kitchens_Setup where RestaurantID = {0} order by Code", code);
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), Name2 = reader["Name2"].ToString(), IsMain = reader["IsMain"].ToString(), IsOutlet = reader["IsOutlet"].ToString(), IsActive = reader["IsActive"].ToString() };
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

        private void MainUiFormat()
        {
            Code_txt.IsEnabled = false;
            Name_txt.IsEnabled = false;
            Name2_txt.IsEnabled = false;
            Active_chbx.IsEnabled = false;
            IsMain.IsEnabled = false;
            IsOutlet.IsEnabled = false;
            SaveBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            UndoBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
            NewBtn.IsEnabled = true;
        }
        public void EnableUI()
        {
            Code_txt.IsEnabled = true;
            Name_txt.IsEnabled = true;
            Name2_txt.IsEnabled = true;
            Active_chbx.IsEnabled = true;
            IsMain.IsEnabled = true;
            IsOutlet.IsEnabled = true;
            SaveBtn.IsEnabled = true;
            UpdateBtn.IsEnabled = true;
            UndoBtn.IsEnabled = true;
            DeleteBtn.IsEnabled = true;
            NewBtn.IsEnabled = true;
        }
        private void ClearUIFields()
        {
            Code_txt.Text = "";
            Name_txt.Text = "";
            Name2_txt.Text = "";
            Active_chbx.IsChecked = false;
            IsMain.IsChecked = false;
            IsOutlet.IsChecked = false;
        }
        private void NewButtonClicked(object sender, RoutedEventArgs e)
        {
            EnableUI();
            ClearUIFields();
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

            SqlConnection con = new SqlConnection(Conn.DataConnString);
            SqlConnection con2 = new SqlConnection(Conn.DataConnString);

            try
            {
                con.Open();

                string s = "insert into Kitchens_Setup(Code,Name,Name2,IsMain,IsOutlet,IsActive,RestaurantID) values (" + Code_txt.Text + ",'" + Name_txt.Text + "','" +
                    Name2_txt.Text + "','" + IsMain.IsChecked + "','" + IsOutlet.IsChecked + "','" + Active_chbx.IsChecked + "',(" + string.Format("select Code from Store_Setup where Name = '{0}'",ParentStore_cbx.Text) + "))";
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
                FillDGV(code);
            }
            if(IsMain.IsChecked == true)
            {
                try
                {
                    con.Open();
                    string s = "SELECT Code,Unit FROM Setup_Items";
                    SqlCommand cmd = new SqlCommand(s, con);
                    SqlDataReader reader = cmd.ExecuteReader();
                    con2.Open();
                    while (reader.Read())
                    {
                        string w = "INSERT INTO Setup_KitchenItems(KitchenID,ItemID,RestaurantID) values (" + Code_txt.Text + ",'" + reader["Code"] + "',(" + string.Format("select Code from Store_Setup where Name = '{0}'", ParentStore_cbx.Text) + "))";
                        SqlCommand cmd2 = new SqlCommand(w, con2);
                        cmd2.ExecuteNonQuery();
                        
                        w = "INSERT INTO Items(KitchenID,ItemID,RestaurantID,Qty,Units,Last_Cost,Current_Cost,Net_Cost) values (" + Code_txt.Text + ",'" + reader["Code"] + "',(" + string.Format("select Code from Store_Setup where Name = '{0}'", ParentStore_cbx.Text) + ")," + "0,'" + reader["Unit"] + "',0," + "0," + "0" + ")";
                        cmd2 = new SqlCommand(w, con2);
                        cmd2.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                    con2.Close();
                }
            }
            MessageBox.Show("Saved Successfully");
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Conn.DataConnString);

            try
            {
                con.Open();
                string s = "Update Kitchens_Setup SET " + "Name = '" + Name_txt.Text + "', Name2 = '" + Name2_txt.Text + "', IsMain = '" + IsMain.IsChecked + "', IsOutlet = '" + IsOutlet.IsChecked + "', IsActive = '" + Active_chbx.IsChecked + "', RestaurantID = " + string.Format("(select Code from Store_Setup where Name = '{0}')", ParentStore_cbx.Text) + " Where Code = " + Code_txt.Text + " and RestaurantID = " + string.Format("(select Code from Store_Setup where Name = '{0}')", ParentStore_cbx.Text);
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
                FillDGV(code);
            }
            MessageBox.Show("Updated Successfully");
        }

        private void UndoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUiFormat();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Conn.DataConnString);
            try
            {
                con.Open();
                string s = "delete from Kitchens_Setup where Code = " + Code_txt.Text;
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
                FillDGV(code);
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
                    IsOutlet.IsChecked = dgvData.IsOutlet.ToLower().Equals("true");

                    EnableUI();
                    Code_txt.IsEnabled = false;
                    NewBtn.IsEnabled = false;
                    SaveBtn.IsEnabled = false;
                }
            }
        }
    }
}

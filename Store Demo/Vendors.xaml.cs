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
    /// Interaction logic for Vendors.xaml
    /// </summary>
    public partial class Vendors : UserControl
    {
        List<string> Authenticated = new List<string>();
        public Vendors()
        {
            if (MainWindow.AuthenticationData.Count != 0)
            {
                if (MainWindow.AuthenticationData.ContainsKey("Vendors"))
                {
                    Authenticated = MainWindow.AuthenticationData["Vendors"];
                    if (Authenticated.Count == 0)
                    {
                        MessageBox.Show("You Havent a Privilage to Open this Page");
                        LogIn logIn = new LogIn();
                        logIn.ShowDialog();
                    }
                    else
                    {
                        InitializeComponent();
                        FillDGV();
                        MainUiFormat();
                    }
                }
            }
            else { MessageBox.Show("You Should Logined First !"); LogIn logIn = new LogIn();  logIn.ShowDialog(); }
        }

        //Functions
        private void FillDGV()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;

            try
            {
                con.Open();

                string s = "select Code,Name,IsActive from Vendors";

                SqlCommand cmd = new SqlCommand(s, con);

                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), IsActive = reader["IsActive"].ToString() };
                    Vendors_DGV.Items.Add(data);
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
            Active_chbx.IsEnabled = false;
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
            Active_chbx.IsEnabled = true;
            SaveBtn.IsEnabled = true;
            NewBtn.IsEnabled = true;
            UpdateBtn.IsEnabled = true;
            UndoBtn.IsEnabled = true;
            DeleteBtn.IsEnabled = true;
        }
        private void ClearUIFields()
        {
            Code_txt.Text = "";
            Name_txt.Text = "";
            Active_chbx.IsChecked = false;
        }

        //Events
        private void NewButtonClicked(object sender, RoutedEventArgs e)
        {
            EnableUI();
            ClearUIFields();
            Active_chbx.IsChecked = true;
            NewBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("SaveVendors") == -1 && Authenticated.IndexOf("CheckAllVendors") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                if (Code_txt.Text == "")
                {
                    MessageBox.Show("Code Field Can't Be Empty");
                    return;
                }

                foreach (DgvData item in Vendors_DGV.Items)
                {
                    if (item.Code.Equals(Code_txt.Text))
                    {
                        MessageBox.Show("This Code Is Not Avaliable");
                        return;
                    }
                }

                string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);

                try
                {
                    con.Open();

                    string s = "insert into Vendors(Code,Name,IsActive) values (" + Code_txt.Text + ",N'" + Name_txt.Text +
                        "','" + Active_chbx.IsChecked.ToString() + "')";

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

                    Vendors_DGV.Items.Clear();
                    FillDGV();
                }
                MessageBox.Show("Saved Successfully");
            }
        }
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("UpdateVendors") == -1 && Authenticated.IndexOf("CheckAllVendors") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);

                try
                {
                    con.Open();

                    string s = "Update Vendors SET " + "Name = N'" + Name_txt.Text + "', IsActive = '" + Active_chbx.IsChecked + "' Where Code = " + Code_txt.Text;

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

                    Vendors_DGV.Items.Clear();
                    FillDGV();
                }
                MessageBox.Show("Updated Successfully");
            }
        }
        private void UndoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUiFormat();
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("DeleteVendors") == -1 && Authenticated.IndexOf("CheckAllVendors") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);

                try
                {
                    con.Open();

                    string s = "delete from Vendors where Code = " + Code_txt.Text;

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

                    Vendors_DGV.Items.Clear();
                    FillDGV();
                }
                MessageBox.Show("Deleted Successfully");
            }
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
                    Active_chbx.IsChecked = dgvData.IsActive.ToLower().Equals("true");

                    EnableUI();
                    Code_txt.IsEnabled = false;
                    NewBtn.IsEnabled = false;
                    SaveBtn.IsEnabled = false;
                }
            }
        }
    }
}
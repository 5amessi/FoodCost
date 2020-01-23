using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Food_Cost
{
    /// <summary>
    /// Interaction logic for Users.xaml
    /// </summary>
    public partial class Users : UserControl
    {
        public Users()
        {
            InitializeComponent();
            FillDGV();
            MainUiFormat();
        }

        private void FillDGV()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                string s = string.Format("select ID,Name,UserName,(select Name FROM UserClass_tbl Where Users.UserClass_ID=UserClass_tbl.UserClass_ID) as Tital,Active from Users");
                SqlDataAdapter da = new SqlDataAdapter(s, con);
                da.Fill(dt);
                UsersDGV.DataContext = dt;
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
        public void MainUiFormat()
        {
            userIDtxt.IsEnabled = false;
            Nametxt.IsEnabled = false;
            passwordtxt.IsEnabled = false;
            Active_chbx.IsEnabled = false;
            jobTitle.IsEnabled = false;
            phone.IsEnabled = false;
            saveBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            UndoBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
            newBtn.IsEnabled = true;
            UserNametxt.IsEnabled = false;
            Addresstxt.IsEnabled = false;
            Mailtxt.IsEnabled = false;

        }
        public void EnableUI()
        {
            userIDtxt.IsEnabled = true;
            Nametxt.IsEnabled = true;
            passwordtxt.IsEnabled = true;
            Active_chbx.IsEnabled = true;
            jobTitle.IsEnabled = true;
            phone.IsEnabled = true;
            saveBtn.IsEnabled = true;
            UpdateBtn.IsEnabled = true;
            UndoBtn.IsEnabled = true;
            DeleteBtn.IsEnabled = true;
            newBtn.IsEnabled = true;
            UserNametxt.IsEnabled = true;
            Addresstxt.IsEnabled = true;
            Mailtxt.IsEnabled = true;
        }
        private void ClearUIFields()
        {
            userIDtxt.Text = "";
            Nametxt.Text = "";
            passwordtxt.Password = "";
            Active_chbx.IsChecked = false;
            jobTitle.Text = "";
            phone.Text = "";
            UserNametxt.Text = "";
            Addresstxt.Text = "";
            Mailtxt.Text = "";
        }
        private void LoadAllJobs()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
                string s = string.Format("select Name from UserClass_tbl");
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    jobTitle.Items.Add(reader["Name"]);
                }
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

        private bool DoSomeChecks()
        {
            bool Val = true;
            if (userIDtxt.Text == "")
            {
                MessageBox.Show("Code Field Can't Be Empty");
                return Val=false;
            }
            else if (Nametxt.Text == "")
            {
                MessageBox.Show("Code Field Can't Be Empty");
                return Val = false;
            }
            else if (UserNametxt.Text == "")
            {
                MessageBox.Show("Code Field Can't Be Empty");
                return Val = false;
            }
            else if (passwordtxt.Password == "")
            {
                MessageBox.Show("Code Field Can't Be Empty");
                return Val = false;
            }
            else if (jobTitle.Text == "")
            {
                MessageBox.Show("Code Field Can't Be Empty");
                return Val = false;
            }
            return Val;
        }

        //events
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            EnableUI();
            ClearUIFields();
            LoadAllJobs();
            newBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
        }
        private void UndoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUiFormat();
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DoSomeChecks() == false)
                return;

            foreach (DgvData item in UsersDGV.Items)
            {
                if (item.User_ID.Equals(userIDtxt.Text))
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
                string s = string.Format("insert into Users(ID,Name,UserName,Password,UserClass_ID,Mobile,Adress,Email,Active,CreateDate) values('{0}','{1}','{2}','{3}',(select UserClass_ID FROM UserClass_tbl Where Name='{4}'),'{5}','{6}','{7}','{8}',GETDATE())",userIDtxt.Text, Nametxt.Text, UserNametxt.Text, passwordtxt.Password, jobTitle.Text, phone.Text, Addresstxt.Text, Mailtxt.Text, Active_chbx.IsChecked.ToString()) ;
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

                UsersDGV.DataContext=null;
                FillDGV();
            }
            MessageBox.Show("Saved Successfully");
        }
        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();
                string s = string.Format("UPDATE Users Set Name='{0}',UserName='{1}',Password='{2}',UserClass_ID=(select UserClass_ID FROM UserClass_tbl Where Name='{3}'),Mobile='{4}',Adress='{5}',Email='{6}',Active='{7}',ModifiedDate=GETDATE() Where ID={8}",
                    Nametxt.Text, UserNametxt.Text, passwordtxt.Password, jobTitle.Text, phone.Text, Addresstxt.Text, Mailtxt.Text, Active_chbx.IsChecked.ToString(), userIDtxt.Text);
                
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

                UsersDGV.DataContext = null;
                FillDGV();
            }
            MessageBox.Show("Updated Successfully");
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();

                string s = "delete from Users where ID = " + userIDtxt.Text;

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

                UsersDGV.Items.Clear();
                FillDGV();
            }
            MessageBox.Show("Deleted Successfully");
        }
        private void RowClicked(object sender, MouseButtonEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;
            if (sender != null)
            {
                DataGrid data = sender as DataGrid;

                if (data != null && data.SelectedItems != null && data.SelectedItems.Count == 1)
                {
                    try
                    {
                        con.Open();
                        string s = string.Format("select ID,Name,Password,UserName,(Select Name From UserClass_tbl where UserClass_tbl.UserClass_ID=Users.UserClass_ID) as Tital,Adress,Phone,Email,Active from Users where ID={0}", ((DataRowView)UsersDGV.SelectedItem).Row.ItemArray[0]);
                        SqlCommand cmd = new SqlCommand(s, con);
                        reader = cmd.ExecuteReader();
                        reader.Read();
                    }
                    catch { }

                    userIDtxt.Text = reader["ID"].ToString();
                    Nametxt.Text = reader["Name"].ToString();
                    UserNametxt.Text = reader["UserName"].ToString();
                    passwordtxt.Password = reader["Password"].ToString();
                    jobTitle.Text = reader["Tital"].ToString();
                    phone.Text = reader["Phone"].ToString(); ;
                    Addresstxt.Text=reader["Adress"].ToString();
                    Mailtxt.Text = reader["Email"].ToString();
                    Active_chbx.IsChecked =Convert.ToBoolean(reader["Active"]);

                    EnableUI();
                    userIDtxt.IsEnabled = false;
                    newBtn.IsEnabled = false;
                    saveBtn.IsEnabled = false;
                }
            }
        }
        private void PackIcon_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            UserAuth w = new UserAuth();
            w.ShowDialog();
        }
    }
}

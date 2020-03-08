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

namespace Food_Cost
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        bool checkofCheckToLogin =false;
        public static bool CheckToLogin;
        MainWindow mainWindow;
        string userName = "";
        string Password = "";
        string Job = "";
        public LogIn()
        {
            InitializeComponent();
            UserNametxt.Focus();
        }
        private void SplitAuthentication()
        {
            string authonty = MainWindow.Authentication;
            MainWindow.ArrAuthenctication = authonty.Split('.');
            string [] oneAuthent =new string[2];
            string key = "";
            string[] Valuo = new string[20];
            List<string> Values = new List<string>();
            //
            oneAuthent = MainWindow.ArrAuthenctication[0].Split(':');
            key = oneAuthent[0];
            if(oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[1].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[2].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[3].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[4].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[5].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[6].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[7].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[8].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[9].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[10].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[11].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            oneAuthent = MainWindow.ArrAuthenctication[12].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            //
            oneAuthent = MainWindow.ArrAuthenctication[13].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            //
            oneAuthent = MainWindow.ArrAuthenctication[14].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            //
            oneAuthent = MainWindow.ArrAuthenctication[15].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            //
            oneAuthent = MainWindow.ArrAuthenctication[16].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            //
            oneAuthent = MainWindow.ArrAuthenctication[17].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            //
            oneAuthent = MainWindow.ArrAuthenctication[18].Split(':');
            key = oneAuthent[0];
            Values = new List<string>();
            if (oneAuthent[1] != "")
            {
                Valuo = oneAuthent[1].Split(',');
                Values.AddRange(Valuo);
            }
            MainWindow.AuthenticationData.Add(key, Values);
            //
            //
            //oneAuthent = MainWindow.ArrAuthenctication[19].Split(':');
            //key = oneAuthent[0];
            //Values = new List<string>();
            //if (oneAuthent[1] != "")
            //{
            //    Valuo = oneAuthent[1].Split(',');
            //    Values.AddRange(Valuo);
            //}
            //MainWindow.AuthenticationData.Add(key, Values);
            ////
            ////
            //oneAuthent = MainWindow.ArrAuthenctication[20].Split(':');
            //key = oneAuthent[0];
            //Values = new List<string>();
            //if (oneAuthent[1] != "")
            //{
            //    Valuo = oneAuthent[1].Split(',');
            //    Values.AddRange(Valuo);
            //}
            //MainWindow.AuthenticationData.Add(key, Values);
            ////
            ////
            //oneAuthent = MainWindow.ArrAuthenctication[21].Split(':');
            //key = oneAuthent[0];
            //Values = new List<string>();
            //if (oneAuthent[1] != "")
            //{
            //    Valuo = oneAuthent[1].Split(',');
            //    Values.AddRange(Valuo);
            //}
            //MainWindow.AuthenticationData.Add(key, Values);
            ////
            //oneAuthent = MainWindow.ArrAuthenctication[22].Split(':');
            //key = oneAuthent[0];
            //Values = new List<string>();
            //if (oneAuthent[1] != "")
            //{
            //    Valuo = oneAuthent[1].Split(',');
            //    Values.AddRange(Valuo);
            //}
            //MainWindow.AuthenticationData.Add(key, Values);
        }

        private void Logined()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlConnection con2 = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = string.Format("select ID,Name,UserName,UserClass_ID,Password FROM Users Where UserName='{0}' and Password='{1}'", UserNametxt.Text, Passwordtxt.Password);
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader.HasRows == true)
                {
                    if (MainWindow.UserID == reader["ID"].ToString())
                    {
                        MessageBox.Show("You Are Already Logined");
                        this.Close();
                        return;
                    }
                    MainWindow.UserName = reader["Name"].ToString();
                    MainWindow.JobID = reader["UserClass_ID"].ToString();
                    MainWindow.UserID = reader["ID"].ToString();
                    //MainWindow.ThetLogin.Add(Convert.ToInt32(MainWindow.UserID));
                    MessageBox.Show("Welcome " + reader["Name"].ToString());
                    try
                    {
                        con2.Open();
                        s = string.Format("select ClassPrv from UserPrivilages_tbl where UserClass_ID='{0}'", reader["UserClass_ID"]);
                        SqlCommand cmd2 = new SqlCommand(s, con2);
                        if (cmd2.ExecuteScalar() != null)
                        {
                            MainWindow.Authentication = cmd2.ExecuteScalar().ToString();
                            checkofCheckToLogin = true;
                            MainWindow.AuthenticationData.Clear();
                            SplitAuthentication();
                            this.Close();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    con.Close();
                    this.Close();
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Please Enter The Correct UserName And Password");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)      
        {
            Logined();
        }
      
        /*private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MainWindow.ThetLogin.Count>0)
            {
                SqlConnection con = new SqlConnection(Classes.DataConnString);
                SqlCommand cmd = new SqlCommand();
                SqlCommand cmd2 = new SqlCommand();
                SqlDataReader reader = null;
                con.Open();
                con2.Open();

                for (int i = 0; i < MainWindow.ThetLogin.Count; i++)
                {
                    try
                    {
                        string s = string.Format("select Password,UserClass_ID From Users Where ID={0}", MainWindow.ThetLogin[i]);
                        cmd = new SqlCommand(s, con);
                        reader = cmd.ExecuteReader();
                        reader.Read();
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    if (reader["Password"].ToString() == PasswordPrivtxt.Password)
                    {
                       
                    }
                    reader.Close();
                }
                con.Close();
                con.Open();
                MessageBox.Show("Enter The Correct Password");
            }
            else
            {
                MessageBox.Show("Please LOGin First ");
                CheckPass.Visibility = Visibility.Hidden;
                Login.Visibility = Visibility.Visible;
            }
        }*/

        private void Window_Closed(object sender, EventArgs e)
        {
            if (checkofCheckToLogin == true)
                CheckToLogin = true;

            else
                CheckToLogin = false;
        }


        private void myTextBox_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter) return;

            LoginBtn.Focus();
            Logined();
        }
    }
}

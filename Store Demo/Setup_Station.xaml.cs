using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Interaction logic for Setup_station.xaml
    /// </summary>
    public partial class Setup_Station : Window
    {
        public Setup_Station()
        {
            InitializeComponent();
            LoadAllResturant();
        }
        
        private void LoadAllResturant()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Name from Setup_Restaurant";
                DataTable Resturant = Classes.RetrieveData(s);
                for(int i=0;i<Resturant.Rows.Count;i++)
                {
                    Restaurant_cbx.Items.Add(Resturant.Rows[i].ItemArray[0].ToString());
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

        private void Restaurant_cbx_Selected(object sender, SelectionChangedEventArgs e)
        {
            string ResturantName = "";
            ResturantName = Restaurant_cbx.SelectedItem.ToString();
            Kitchen_cbx.Items.Clear();
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            try
            {
                con.Open();

                string s = string.Format("select Name From Setup_Kitchens where RestaurantID=(select Code From Setup_Restaurant where Name='{0}')", ResturantName);
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = reader["Name"].ToString();
                    Kitchen_cbx.Items.Add(data);
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
 
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (WorkStation_no.Text == "" || Restaurant_cbx.Text == "" || Kitchen_cbx.Text == "")
            {
                MessageBox.Show("Null Fields");
                return;
            }
            
            SqlConnection con = new SqlConnection(Classes.DataConnString);

            con.Open();
            SqlCommand cmd = new SqlCommand(string.Format("select Code from Setup_Restaurant where Name = '{0}'", Restaurant_cbx.Text), con);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            string RestaurantID = reader[0].ToString();
            con.Close();

            con.Open();
            cmd = new SqlCommand(string.Format("select Code from Setup_Kitchens where Name = '{0}' and RestaurantID = (select Code from Setup_Restaurant where Name = '{1}')", Kitchen_cbx.Text, Restaurant_cbx.Text), con);
            reader = cmd.ExecuteReader();
            reader.Read();
            string kitchenID = reader[0].ToString();
            con.Close();


            if (WorkStation_no.Text.Length == 1)
                WorkStation_no.Text = "0" + WorkStation_no.Text;
            if (RestaurantID.Length == 1)
                RestaurantID = "0" + RestaurantID;
            if (kitchenID.Length == 1)
                kitchenID = "0" + kitchenID;

            string WorkStationInfo = WorkStation_no.Text + "," + RestaurantID + "," + kitchenID;
            File.WriteAllText("Workstation.dll", WorkStationInfo);

            MessageBox.Show("Saved");
            Classes.GetWS();
        }
    }
}

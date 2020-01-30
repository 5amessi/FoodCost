using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
    /// Interaction logic for KitcheItemsn.xaml
    /// </summary>
    public partial class KitcheItemsn : UserControl
    {
        DataTable dt = new DataTable();
       
        string ValtoDelete = "";
        string ValOfResturant = "";
        string ValOfKitchen = "";
        int Count = 0;
        public KitcheItemsn()
        {
            InitializeComponent();
            LoadAllOutlet();
            SaveBtn.IsEnabled = false;
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("Name2");
            dt.Columns.Add("ShufledID");
            dt.Columns.Add("MinQty");
            dt.Columns.Add("MaxQty");
        }

        private void LoadAllOutlet()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Name from Store_Setup";
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = reader["Name"].ToString();
                    Outletcbx.Items.Add(data);
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string b = "";
            if(Kitchencbx.SelectedItem !=null)
            {
                string v = Kitchencbx.SelectedItem.ToString();
                if (Outletcbx.SelectedItem != null)
                {
                    LoadDatatoGrid();
                    SaveBtn.IsEnabled = true;
                }
            }
           
        }

        public void LoadDatatoGrid()
        {
            dt.Rows.Clear();
            ItemsDGV.DataContext = null;
            Count = 0;
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            SqlDataReader reader2 = null;
            string valuoOfKitchen = Kitchencbx.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlConnection con2 = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = "select Code from Kitchens_Setup WHERE Name='" + Kitchencbx.SelectedItem.ToString() + "'";
                cmd = new SqlCommand(s, con);
                ValOfKitchen = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            try
            {
                con.Open();
                string s = "Select ItemID,ShulfID,MinQty,MaxQty From Setup_KitchenItems Where RestaurantID=" + ValOfResturant+ " and KitchenID=" + ValOfKitchen;
                cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while(reader.Read())
                {
                    con2.Open();
                    string W = "select Name,Name2 from Setup_Items Where Code=" + reader["ItemID"].ToString();
                    SqlCommand _cmd = new SqlCommand(W, con2);
                    reader2 = _cmd.ExecuteReader();
                    while(reader2.Read())
                    {
                        dt.Rows.Add(reader["ItemID"], reader2["Name"], reader2["Name2"], reader["ShulfID"], reader["MinQty"], reader["MaxQty"]);
                        Count++;
                    }
                    con2.Close();
                }
                                
                ItemsDGV.DataContext = dt;

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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Items items = new Items(this);
            items.ShowDialog();
            //SaveBtn.IsEnabled = true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            if (Outletcbx.Text == "" || Kitchencbx.Text == "")
            {
                MessageBox.Show("Choose Restaurant and Kitchen");
                return;
            }
            DataTable table = ItemsDGV.DataContext as DataTable;
            for (int i = 0; i < table.Rows.Count; i++)
                if(table.Rows[i].ItemArray.Contains(""))
                {
                    ItemsDGV.Focus();
                    ItemsDGV.SelectedIndex = i;
                    MessageBox.Show(string.Format("item no {0} has empty fields",i + 1));
                    return;
                }

            SqlConnection con = new SqlConnection(Classes.DataConnString);
            for (int i = 0; i < ItemsDGV.Items.Count; i++)
            {
                try
                {
                    con.Open();
                    string H = string.Format("update Setup_KitchenItems set ShulfID = '{0}',MinQty = '{1}',MaxQty = '{2}' where ItemID = '{3}' and RestaurantID = '{4}' and KitchenID = '{5}'",((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[3].ToString(), ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4].ToString(), ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[5].ToString(),((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0].ToString(), ValOfResturant, ValOfKitchen);
                    SqlCommand cmd = new SqlCommand(H, con);
                    int UpdatedRowsNo = cmd.ExecuteNonQuery();

                    if (UpdatedRowsNo == 0)
                    {
                        H = "Insert into Setup_KitchenItems (RestaurantID,KitchenID,ItemID,ShulfID,MinQty,MaxQty) Values('" + ValOfResturant + "','" + ValOfKitchen + "','" + ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0].ToString() + "','" + ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[3].ToString() + "','" + ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4].ToString() + "','" + ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[5].ToString() + "')";
                        cmd = new SqlCommand(H, con);
                        cmd.ExecuteNonQuery();

                        H = string.Format("insert into Items(ItemID,RestaurantID,KitchenID,Qty,Units,Last_Cost,Current_Cost,ShufledID,MinNumber,MaxNumber,Net_Cost) values('{0}','{4}','{5}','0',(select Unit from Setup_Items where Code = '{0}'),'0','0','{1}','{2}','{3}','0')", ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0].ToString(), ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[3].ToString(), ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4].ToString(), ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[5].ToString(),ValOfResturant,ValOfKitchen);
                        cmd = new SqlCommand(H, con);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    return;
                }
                finally { con.Close(); }
            }
               
            con.Close();
            MessageBox.Show("Items Are saved ");    
            LoadDatatoGrid();
        }

        private void RowClicked(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid data = sender as DataGrid;

                if (data != null && data.SelectedItems != null && data.SelectedItems.Count == 1)
                {
                    ValtoDelete = ((DataRowView)data.SelectedItem).Row.ItemArray[0].ToString();
                }
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string H= "SELECT Item_Code FROM Setup_RecipeItems WHere Item_Code='"+ ValtoDelete +"'";
                SqlCommand cmd = new SqlCommand(H, con);
                if(cmd.ExecuteScalar() == null)
                {
                    try
                    {
                        H = "Delete Setup_KitchenItems Where ItemID=" + ValtoDelete + " And RestaurantID=" + ValOfResturant+ " AND KitchenID="+ValOfKitchen;
                        cmd = new SqlCommand(H, con);
                        cmd.ExecuteNonQuery();

                        H = "Delete Items Where ItemID=" + ValtoDelete + " And RestaurantID=" + ValOfResturant + " AND KitchenID=" + ValOfKitchen;
                        cmd = new SqlCommand(H, con);
                        cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        LoadDatatoGrid();
                        MessageBox.Show("Items are deleteed  ");
                    }
                }
                else
                {
                    MessageBox.Show("Can't Delete this Item");
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
        } //el mafrood ntcheck lw el item da m4 equal 0 yb2a can not delete

        private void OutletComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Kitchencbx.Items.Clear();
            ValOfResturant = "";
            string v = Outletcbx.SelectedItem.ToString();
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = "select Code from Store_Setup WHERE Name='" + v + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                ValOfResturant = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }


            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Name from Kitchens_Setup WHERE RestaurantID=" + ValOfResturant ;
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = reader["Name"].ToString();
                    Kitchencbx.Items.Add(data);
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
    }
}
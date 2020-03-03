using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ProcessBulkItem.xaml
    /// </summary>
    public partial class ProcessBulkItem : UserControl
    {
        string CodeOfResturant = "";
        string CodeOfKitchens = "";
        public ProcessBulkItem()
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
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = reader["Name"].ToString();
                    StoreIDcbx.Items.Add(data);
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

        private void ResturantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Kitchencbx.Items.Clear();
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = "select Code from Setup_Restaurant Where Name='" + StoreIDcbx.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                CodeOfResturant = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            LoadAllKitchen();
        }
        private void LoadAllKitchen()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Name from Setup_Kitchens Where RestaurantID=" + CodeOfResturant;
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

        private void kitchenComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Code from Setup_Kitchens Where Name='" + Kitchencbx.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                CodeOfKitchens = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            LoadAllBulkItems();
            Details.Visibility = Visibility.Hidden;
            ItemsDetails.Visibility = Visibility.Visible;
        }

        private void LoadAllBulkItems()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Checked",typeof(bool));
            dt.Columns.Add("Code");
            dt.Columns.Add("Manual Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Unit");
            dt.Columns.Add("Cost");
            
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            SqlConnection con2 = new SqlConnection(Classes.DataConnString);
            SqlCommand cmd2 = new SqlCommand();
            SqlDataReader reader2 = null;
            try
            {
                con.Open();
                string s = "select Code,[Manual Code],Name,Unit,weight FROM Setup_Items where Is_BulkItem='true'";
                cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        con2.Open();
                        string q = string.Format("select Qty,Current_Cost FROM Items Where ItemID='{0}' and RestaurantID='{1}' and KitchenID='{2}'", reader["Code"].ToString(), CodeOfResturant, CodeOfKitchens);
                        cmd2 = new SqlCommand(q, con2);
                        reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        if(reader2.HasRows == true)
                        {
                            if(reader2["Qty"] !="")
                            {
                                dt.Rows.Add(false, reader["Code"], reader.GetValue(1), reader["Name"], (Convert.ToDouble(reader2["Qty"]) * Convert.ToDouble(reader["weight"])).ToString(),reader["Unit"],reader2["Current_Cost"]);

                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        con2.Close();
                    }
                }
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Columns[i].ReadOnly = true;
                }
                dt.Columns["Checked"].ReadOnly = false;
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

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }  //Done
        private void NeglectWhiteSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }  //Done

        private void ItemsDGV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataTable Dat = new DataTable();
            Dat.Columns.Add("Code");
            Dat.Columns.Add("Manual Code");
            Dat.Columns.Add("Name");
            Dat.Columns.Add("Weight Precentage");
            Dat.Columns.Add("Cost Precentage");  

            ItemsofBulkItemsDGV.Visibility = Visibility.Visible;
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            SqlConnection con2 = new SqlConnection(Classes.DataConnString);
            SqlCommand cmd2 = new SqlCommand();
            SqlDataReader reader2 = null;
            DataTable dt = new DataTable();
            DataGrid grid = sender as DataGrid;
            if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            {
                try
                {
                    con.Open();
                    string s = string.Format("select Code,WeightPrecentage,CostPrecentage from Setup_BulkItems where Item_Code='{0}'", ((DataRowView)grid.SelectedItem).Row.ItemArray[1]);
                    cmd = new SqlCommand(s, con);
                    reader = cmd.ExecuteReader();
                    con2.Open();
                    while(reader.Read())
                    {
                        s = string.Format("select [Manual Code],Name From Setup_Items Where Code='{0}'", reader["Code"]);
                        cmd2 = new SqlCommand(s, con2);
                        reader2 = cmd2.ExecuteReader();
                        reader2.Read();
                        {
                            Dat.Rows.Add(reader["Code"], reader2["Manual Code"], reader2["Name"], reader["WeightPrecentage"] +"  %", reader["CostPrecentage"]+"  %");
                        }
                        reader2.Close();
                    }
                    ItemsofBulkItemsDGV.DataContext = Dat;
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
        }
        private string GetID()
        {
            string TheID = "";
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = string.Format("select Top(1)ProcessBulk_ID from Process_BulkItems where ProcessBulk_ID like '{0}%' order by ProcessBulk_ID DESC",Classes.DataConnString);
                SqlCommand cmd = new SqlCommand(s, con);
                if(cmd.ExecuteScalar() == null)
                {
                    TheID = Classes.IDs + "0000001";
                }
                else
                {
                    TheID = "0" + (Int64.Parse(cmd.ExecuteScalar().ToString()) + 1).ToString();
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
            return TheID;
        }

        private void BulkItemsBtn_Click(object sender, RoutedEventArgs e)
        {
            string ID = GetID();
            string BaseCode = "";
            string BaseQty = "";
            string SUBQty = "";
            double BaseCost = 0;
            string BaseWeight = "";
            double CalcQty = 0; double CalcCost = 0;
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlCommand cmd = new SqlCommand();
            SqlConnection con2 = new SqlConnection(Classes.DataConnString);
            SqlCommand cmd2 = new SqlCommand();
            SqlDataReader reader = null;
            for (int i = 0; i < ItemsDGV.Items.Count; i++)
            {
                if (((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0].ToString() == "True")
                {
                    BaseCode = ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[1].ToString();
                    BaseQty = ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4].ToString();
                    SUBQty = BaseQty;
                    BaseCost = Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[6].ToString());
                    con.Open();
                    try
                    {
                        string s = string.Format("select Weight FROM Setup_Items where Code='{0}'", BaseCode);
                        cmd = new SqlCommand(s, con);
                        BaseWeight = cmd.ExecuteScalar().ToString();
                    }
                    catch(Exception ex) { MessageBox.Show(ex.ToString()); }

                    try
                    {
                        string s = string.Format("select * from Setup_BulkItems where Item_Code='{0}'", BaseCode);
                        cmd = new SqlCommand(s, con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            CalcQty = (((Convert.ToDouble(reader["WeightPrecentage"]) / 100) * Convert.ToDouble(BaseQty)) / Convert.ToDouble(BaseWeight));
                            CalcCost = (((Convert.ToDouble(reader["CostPrecentage"]) / 100) * Convert.ToDouble(BaseCost)) / Convert.ToDouble(BaseWeight));
                            try
                            {
                                con2.Open();
                                string w = string.Format("UPDATE Items set Qty=Qty+{0},Last_Cost=Current_Cost,Current_Cost=(((Qty*Current_Cost)+({0}*{4}))/(Qty+{0})) where ItemID='{1}' and RestaurantID={2} and KitchenID={3}", CalcQty, reader["Code"], CodeOfResturant, CodeOfKitchens, CalcCost);
                                cmd2 = new SqlCommand(w, con2);
                                int n = cmd2.ExecuteNonQuery();

                                if (n == 0)
                                {
                                    w = string.Format("insert into Items(RestaurantID,KitchenID,ItemID,Qty,Current_Cost,Net_Cost) values({0},{1},'{2}',{3},{4},{5})", CodeOfResturant, CodeOfKitchens, reader["Code"], CalcQty, CalcCost, CalcCost*CalcQty);
                                    cmd2 = new SqlCommand(w, con2);
                                    cmd2.ExecuteNonQuery();
                                }
                            }
                            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                            SUBQty = (Convert.ToDouble(SUBQty) - CalcQty).ToString();
                            
                            try
                            {
                                string w = string.Format("insert into Process_BulkItems_Items(ProcessBulk_ID,ParentItem_ID,ParentQty,ParentCost,ChiledItem_ID,ChiledQty,ChiledCost) values('{0}','{1}',{2},{3},{4},{5},{6})", ID, BaseCode, ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4].ToString(), ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[6].ToString(), reader["Code"], BaseCost, BaseCost);
                                cmd2 = new SqlCommand(w, con2);
                                cmd2.ExecuteNonQuery();
                            }
                            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                            con2.Close();

                        }
                        try
                        {
                            con2.Open();
                            string w = string.Format("update Items set Qty={0} where RestaurantID={1} and KitchenID={2} and ItemID='{3}' ", SUBQty, CodeOfResturant, CodeOfKitchens, BaseCode);
                            cmd2 = new SqlCommand(w, con2);
                            cmd2.ExecuteNonQuery();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                        try
                        {
                            string w = string.Format("insert into Process_BulkItems(ProcessBulk_ID,Process_Date,User_ID,Resturant_ID,KitchenID,Post_Date) values('{0}',GETDATE(),'{1}',{2},{3},GETDATE())", ID, MainWindow.UserID,CodeOfResturant,CodeOfKitchens);
                            cmd2 = new SqlCommand(w, con2);
                            cmd2.ExecuteNonQuery();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    con2.Close();


                }
            }
            MessageBox.Show("Done");

        }

        
    }
}

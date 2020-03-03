using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
    /// Interaction logic for PurchaseOrder.xaml
    /// </summary>
    public partial class PurchaseOrder : UserControl
    {
        string RestaurantCode = "";string KitchenCode = "";
        List<string> Authenticated = new List<string>();
        int IndexOfRecord = 0;
        public PurchaseOrder()
        {
            if (MainWindow.AuthenticationData.ContainsKey("Purchase"))
            {
                Authenticated = MainWindow.AuthenticationData["Purchase"];
                if (Authenticated.Count == 0)
                {
                    MessageBox.Show("You Havent a Privilage to Open this Page");
                    LogIn logIn = new LogIn();
                    logIn.ShowDialog();
                }
                else
                {
                    InitializeComponent();
                    LoadVendorFromSQL();
                    LoadTheMainRestaurant();
                    DateTime now = DateTime.Now;
                    MainUiFormat();
                }
            }
        }
        private void LoadTheMainRestaurant()                
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Code,Name from Setup_Restaurant where IsMain='True'";
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                reader.Read();
                RestaurantCode = reader["Code"].ToString();
                ShipTo.Text= reader["Name"].ToString();
            }
            catch
            {
                MessageBox.Show("First You should create Main Restaurant");
            }
            reader.Close();
            reader = null;

            try
            {
                string s = string.Format("select Code from Setup_Kitchens where RestaurantID='{0}' and IsMain='True'", RestaurantCode);
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                reader.Read();
                KitchenCode = reader["Code"].ToString();
            }
            catch
            {
                MessageBox.Show("First You should create Main Kitchen as Main Restaurant");
            }
        }
        private void LoadVendorFromSQL()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Name from Vendors";
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = reader["Name"].ToString();
                    Vendor.Items.Add(data);
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
            MainGrid.IsEnabled = false;
            SaveBtn.IsEnabled = false;
            UndoBtn.IsEnabled = false;
            NewBtn.IsEnabled = true;
            searchBtn.IsEnabled = true;
        }
        public void EnableUI()
        {
            MainGrid.IsEnabled = true;
            RemoveItemBtn.IsEnabled = true;
            AddItemsBtn.IsEnabled = true;
            Vendor.IsEnabled = true;
            Delivery_dt.IsEnabled = true;
            SaveBtn.IsEnabled = true;
            UndoBtn.IsEnabled = true;
            NewBtn.IsEnabled = true;
            CopyBtn.IsEnabled = true;
        }
        private bool DoSomeChecks()
        {
            if (PO_NO.Text.Equals(""))
            {
                MessageBox.Show("P.O # Can't Be Empty");
            }

            else if (ShipTo.Text.Equals(""))
            {
                MessageBox.Show("ShipTo Can't Be Empty");
            }
            else if (Vendor.Text.Equals(""))
            {
                MessageBox.Show("Vendor Can't Be Empty");
            }
            else if (Delivery_dt.Text.Equals(""))
            {
                MessageBox.Show("Delivery Date Can't Be Empty");
            }
            //else if (Delivery_time.Text ==null)
            //{
            //    MessageBox.Show("Delivery Time Can't Be Empty");
            //}

            else if (ItemsDGV.Items.Count == 0)
            {
                MessageBox.Show("Items can not be empty");
            }
            else
            {
                for (int i = 0; i < ItemsDGV.Items.Count; i++)
                {
                    try
                    {
                        float.Parse((ItemsDGV.Items[i] as DataRowView).Row["Qty"].ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Qty input error");

                        ItemsDGV.CurrentCell = new DataGridCellInfo(ItemsDGV.Items[i], ItemsDGV.Columns[5]);  //nb2a n3dl el index kol mara nezawd column
                        ItemsDGV.BeginEdit();

                        return false;
                    }

                    try
                    {
                        float.Parse((ItemsDGV.Items[i] as DataRowView).Row["Price"].ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Price input error");

                        ItemsDGV.CurrentCell = new DataGridCellInfo(ItemsDGV.Items[i], ItemsDGV.Columns[6]);  //nb2a n3dl el index kol mara nezawd column
                        ItemsDGV.BeginEdit();

                        return false;
                    }

                }

                return true;
            }
            return false;
        }
        private string IncrementPoNo()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s =string.Format("select Top(1) PO_Serial from PO where PO_Serial like '{0}%' order by  PO_Serial desc",Classes.IDs);
                SqlCommand cmd = new SqlCommand(s, con);
                if (cmd.ExecuteScalar() == null)
                {
                    Serial_PO_NO.Text = Classes.IDs + "0000001";
                }
                else
                {
                    Serial_PO_NO.Text = "0"+(Int64.Parse(cmd.ExecuteScalar().ToString()) + 1).ToString();
                }
            }
            catch
            {
                con.Close();
            }
            return "-1";
        }
        private void ClearFields()
        {
            PO_NO.Text = "";
            Total_Price_Without_Tax.Text = "0";
            Total_Price_With_Tax.Text = "0";
            Serial_PO_NO.Text = "";
            Vendor.Text = "";
            Delivery_dt.Text = "";
            commenttxt.Text = "";
            ItemsDGV.DataContext = null;
        }
        private void Save_PO_Details(SqlConnection con)
        {
            try
            {
                con.Open();
                string FiledSelection = "PO_Serial,PO_No,Ship_To,Vendor_ID,Create_Date,Delivery_Date,WS,Comment,Total_Price,Restaurant_ID,Kitchen_ID,UserID,Status";
                string values = string.Format("'{0}','{1}',{2},(select VendorID from Vendors where Name = '{3}'),GETDATE(),'{4}','{5}','{6}','{7}',{2},{8},'{9}','{10}'", Serial_PO_NO.Text, PO_NO.Text, RestaurantCode, Vendor.Text,Convert.ToDateTime(Delivery_dt.Text).ToString("MM-dd-yyyy"), Classes.WS, commenttxt.Text, Total_Price_With_Tax.Text, KitchenCode, MainWindow.UserID, Statustxt.Text);
                Classes.InsertRow("PO", FiledSelection, values);
                //string s = string.Format("insert into PO(PO_Serial,PO_No,Ship_To,Vendor_ID,Create_Date,Delivery_Date,WS,Comment,Total_Price,Restaurant_ID,Kitchen_ID,UserID,Status) values('{0}','{1}',(select Code from Setup_Restaurant where Name = '{2}'),(select VendorID from Vendors where Name = '{3}'),GETDATE(),'{4}','{5}','{6}',{7},1,1,{8},'{9}')", Serial_PO_NO.Text, PO_NO.Text, ShipTo.Text, Vendor.Text, Delivery_dt.Text+" "+Delivery_time.Text, WorkstationId, commenttxt.Text, Total_Price_With_Tax.Text, MainWindow.UserID, Statustxt.Text);
                //SqlCommand cmd = new SqlCommand(s, con);
                //int record_no = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { con.Close(); }
        }
        private void Save_PO_Items(SqlConnection con)
        {
            try
            {
                con.Open();
                DataTable Dat = ItemsDGV.DataContext as DataTable;
                for (int i = 0; i < ItemsDGV.Items.Count; i++)
                {
                    string FiledSelection = "Item_ID,PO_Serial,Qty,Serial,Price_Without_Tax,Tax,Price_With_Tax,Net_Price,Tax_Included";
                    string Values = "'"+Dat.Rows[i]["Code"] +"','"+ Serial_PO_NO.Text+"',"+ Dat.Rows[i]["Qty"]+","+ i+","+ Dat.Rows[i]["Unit Price Without Tax"] + "," + Dat.Rows[i]["Tax"].ToString().Substring(0, Dat.Rows[i]["Tax"].ToString().Length - 1) + "," + Dat.Rows[i]["Unit Price With Tax"] + "," + Dat.Rows[i]["Total Price With Tax"] + ",'" + Dat.Rows[i]["Tax Included"].ToString()+"'";
                    Classes.InsertRow("PO_Items", FiledSelection, Values);
                    //string s = string.Format("insert into PO_Items(Item_ID,PO_Serial,Qty,Serial,Price_Without_Tax,Tax,Price_With_Tax,Net_Price,Tax_Included) values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')", dt.Rows[i]["Code"], Serial_PO_NO.Text, dt.Rows[i]["Qty"].ToString(), i, dt.Rows[i]["Unit Price Without Tax"], dt.Rows[i]["Tax"].ToString().Substring(0, dt.Rows[i]["Tax"].ToString().Length - 1), dt.Rows[i]["Unit Price With Tax"], dt.Rows[i]["Total Price With Tax"], dt.Rows[i]["Tax Included"].ToString());
                    //SqlCommand cmd = new SqlCommand(s, con);
                    //cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { con.Close(); }
        }

        //events
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("NewPO") == -1 && Authenticated.IndexOf("CheckAllPO") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                EnableUI();
                ClearFields();
                IncrementPoNo();
                PO_NO.IsReadOnly = false;
                commenttxt.IsReadOnly = false;
                ItemsDGV.IsReadOnly = false;
                CopyBtn.IsEnabled = false;
                searchBtn.IsEnabled = false;
                NewBtn.IsEnabled = false;
                Total_Price_With_Tax.Text = "0";
            }
        }
        private void Edit_PO_Details(SqlConnection con)
        {
            try
            {
                con.Open();
                string FiledSelection = "PO_No,Ship_To,Vendor_ID,Delivery_Date,Last_Modified_Date,Comment,Total_Price,Status";
                string Values = string.Format("'{0}',(select Code from Setup_Restaurant where Name = '{1}'),(select VendorID from Vendors where Name = '{2}'),'{3}',GETDATE(),'{4}','{5}','{6}'", PO_NO.Text, ShipTo.Text, Vendor.Text,Convert.ToDateTime(Delivery_dt.Text).ToString("MM-dd-yyyy") , commenttxt.Text, Total_Price_With_Tax.Text, Statustxt.Text);
                string where = string.Format("PO_Serial={0}", Serial_PO_NO.Text);
                Classes.UpdateRow(FiledSelection, Values, where, "PO");
                //string s = string.Format("update PO Set PO_No='{0}',Ship_To=(select Code from Setup_Restaurant where Name = '{1}'),Vendor_ID=(select VendorID from Vendors where Name = '{2}'),Delivery_Date='{3}',Last_Modified_Date=GETDATE(),Comment='{4}',Total_Price='{5}',Status='{6}' Where PO_Serial={7}", PO_NO.Text, ShipTo.Text, Vendor.Text, Delivery_dt.Text+" "+Delivery_time.Text, commenttxt.Text, Total_Price_With_Tax.Text,Statustxt.Text ,Serial_PO_NO.Text);
                //SqlCommand cmd = new SqlCommand(s, con);
                //cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { con.Close(); }
        }
        private void SaveBtn_Click(object sender, RoutedEventArgs e)        //nb2a n3dl el index kol mara nezawd column
        {
            if (Authenticated.IndexOf("OrderPO") == -1 && Authenticated.IndexOf("CheckAllPO") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                if (!DoSomeChecks())
                    return;

                SqlConnection con = new SqlConnection(Classes.DataConnString);
                SqlConnection con2 = new SqlConnection(Classes.DataConnString);

                try
                {
                    con2.Open();
                    string s = string.Format("select PO_Serial From PO WHere PO_Serial='{0}'", Serial_PO_NO.Text);
                    SqlCommand cmd = new SqlCommand(s, con2);
                    if (cmd.ExecuteScalar() == null)
                    {
                        try
                        {
                            Save_PO_Items(con);
                            Save_PO_Details(con);
                        }
                        catch { return; }
                    }
                    else
                    {
                        try
                        {
                            s = string.Format("delete From PO_Items where PO_Serial='{0}'", Serial_PO_NO.Text);
                            cmd = new SqlCommand(s, con2);
                            cmd.ExecuteNonQuery();
                            try
                            {
                                Save_PO_Items(con);
                                Edit_PO_Details(con);
                            }
                            catch { return; }
                        }
                        catch { return; }
                    }
                }
                catch { }
                MainUiFormat();
                ClearFields();
                MessageBox.Show("Saved Successfully");
            }
        }
        private void UndoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUiFormat();
            CopyBtn.IsEnabled = false;
        }
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not Implmented, In Progress");
            //string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            //SqlConnection con = new SqlConnection(connString);
            //try
            //{
            //    con.Open();
            //    string s = "delete from PurchaseOrder_tbl where Code = " + PO_NO.Text;
            //    SqlCommand cmd = new SqlCommand(s, con);
            //    cmd.ExecuteNonQuery();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}
            //finally
            //{
            //    con.Close();
            //    MainUiFormat();
            //}
            //MessageBox.Show("Deleted Successfully");
        }
        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("AddItemPO") == -1 && Authenticated.IndexOf("CheckAllPO") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                Items itemswindow = new Items(this);
                itemswindow.ShowDialog();
            }
        }
        private void CopyBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("CopyPO") == -1 && Authenticated.IndexOf("CheckAllPO") == -1)
            {
                MainWindow.UserID2 = MainWindow.UserID;
                MainWindow.AuthenticationData2 = MainWindow.AuthenticationData;
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                EnableUI();
                IncrementPoNo();
                PO_NO.Text = "";

                NewBtn.IsEnabled = false;
                CopyBtn.IsEnabled = false;
                if(MainWindow.AuthenticationData2.Count>0)
                {
                    MainWindow.AuthenticationData = MainWindow.AuthenticationData2;
                    MainWindow.UserID = MainWindow.UserID2;
                }
            }
        }
        private void auto_tansfer_chbx(object sender, RoutedEventArgs e)
        {
            if ((sender as CheckBox).IsChecked == true)
                ShipTo.IsEnabled = true;
            else
                ShipTo.IsEnabled = false;

        }
        private void RemoveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("RemoveItemPO") == -1 && Authenticated.IndexOf("CheckAllPO") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                DataTable dt = ItemsDGV.DataContext as DataTable;
                dt.Rows.RemoveAt(IndexOfRecord);
                ItemsDGV.DataContext = dt;
                RemoveItemBtn.IsEnabled = false;
            }

        }
        private void ItemsDGV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null)
            {
                DataGrid data = sender as DataGrid;

                if (data != null && data.SelectedItems != null && data.SelectedItems.Count == 1)
                {
                    RemoveItemBtn.IsEnabled = true;
                }
            }
        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("SearchPO") == -1 && Authenticated.IndexOf("CheckAllPO") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                EnableUI();
                NewBtn.IsEnabled = false;
                searchBtn.IsEnabled = false;
                SaveBtn.IsEnabled = false;

                All_Purchase_Orders all_Purchase_Orders = new All_Purchase_Orders(this);
                all_Purchase_Orders.ShowDialog();
            }
        }
        private void ItemsDGV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            {
                IndexOfRecord = grid.SelectedIndex;
            }
        }
        private void ItemDgv_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataTable dt = ItemsDGV.DataContext as DataTable;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ReadOnly = false;
            }
            try
            {
                SqlConnection con = new SqlConnection(Classes.DataConnString);

                if (e.Column.Header.ToString() == "Price")
                {
                    CalculatePrices(e,dt);
                }
                else if (e.Column.Header.ToString() == "Tax Included")
                {
                    if ((e.EditingElement as CheckBox).IsChecked == true)
                    {
                        con.Open();
                        try
                        {
                            using (SqlCommand cmd = new SqlCommand(string.Format("select TaxableValue from Setup_Items where Code = '{0}'", (e.Row.Item as DataRowView).Row["Code"]), con))
                            {
                                string tax = cmd.ExecuteScalar().ToString();
                                if (tax == "")
                                    tax = "0";
                                dt.Rows[e.Row.GetIndex()]["Tax"] = tax + "%";
                            }
                        }
                        catch { }
                        finally { con.Close(); }
                    }
                    else
                    {
                        (e.Row.Item as DataRowView).Row["Tax"] = "0%";
                    }
                    CalculatePrices(e,dt);
                }
                else if (e.Column.Header.ToString() == "Qty")
                {
                    CalculatePrices(e,dt);
                }
            }
            catch { }
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].ReadOnly = true;
            }       
            dt.Columns["Price"].ReadOnly = false;
            dt.Columns["Qty"].ReadOnly = false;
            dt.Columns["Tax Included"].ReadOnly = false;
            ItemsDGV.DataContext = dt;
        }

        //private void CalculateQty(DataGridCellEditEndingEventArgs e)
        //{
        //    Serial_PO_NO.Focus();
        //    string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
        //    SqlConnection con = new SqlConnection(connString);
        //    string s = string.Format("select Weight from Setup_Items where Code='{0}'", (e.Row.Item as DataRowView).Row["Code"].ToString());
        //    using (SqlCommand cmd = new SqlCommand(s, con))
        //    {
        //        con.Open();
        //        float weight = float.Parse(cmd.ExecuteScalar().ToString());
        //        float eachQty = float.Parse((e.Row.Item as DataRowView).Row["Qty_Unit3"].ToString());

        //        float QtyOredered = eachQty * weight;
        //        (e.Row.Item as DataRowView).Row["Qty"] = QtyOredered.ToString();

        //    }
        //}

        //private void CalculateQty3(DataGridCellEditEndingEventArgs e)
        //{
        //    Serial_PO_NO.Focus();
        //    string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
        //    SqlConnection con = new SqlConnection(connString);
        //    string s = string.Format("select Weight from Setup_Items where Code='{0}'", (e.Row.Item as DataRowView).Row["Code"].ToString());
        //    using (SqlCommand cmd = new SqlCommand(s, con))
        //    {
        //        con.Open();
        //        float weight = float.Parse(cmd.ExecuteScalar().ToString());
        //        float QtyOredered = float.Parse((e.Row.Item as DataRowView).Row["Qty"].ToString());

        //        float eachQty = QtyOredered / weight;
        //        (e.Row.Item as DataRowView).Row["Qty_Unit3"] = eachQty.ToString();

        //    }

        //}

        private void CalculatePrices(DataGridCellEditEndingEventArgs e, DataTable dt)
        {
            //Serial_PO_NO.Focus();
            float Price,Qty,TaxPrec;
            try
            {
                if (e.Column.Header.ToString() == "Price")
                {
                    Price = float.Parse((e.EditingElement as TextBox).Text);
                    dt.Rows[e.Row.GetIndex()]["Price"] = Price;
                }
                else
                    try
                    {
                        Price = float.Parse((dt.Rows[e.Row.GetIndex()]["Price"]).ToString());
                    }
                    catch { Price = 0; }


                if (e.Column.Header.ToString() == "Qty")
                {
                    Qty = float.Parse((e.EditingElement as TextBox).Text);
                    dt.Rows[e.Row.GetIndex()]["Qty"] = Qty;
                }
                else
                    try
                    {
                        Qty = float.Parse((dt.Rows[e.Row.GetIndex()]["Qty"]).ToString());
                    }
                    catch { Qty = 0; }

                TaxPrec = float.Parse(dt.Rows[e.Row.GetIndex()]["Tax"].ToString().Substring(0, (e.Row.Item as DataRowView).Row["Tax"].ToString().Length - 1)) / 100;

                if ((e.Row.Item as DataRowView).Row["Tax Included"].ToString() == "True")
                {
                    dt.Rows[e.Row.GetIndex()]["Total Price With Tax"] = (Price * Qty).ToString();
                    dt.Rows[e.Row.GetIndex()]["Total Price Without Tax"] = ((Price - Price * TaxPrec) * Qty).ToString();

                    if ((e.Row.Item as DataRowView).Row["Qty"].ToString() != "0")
                    {
                        dt.Rows[e.Row.GetIndex()]["Unit Price With Tax"] = Price.ToString();
                        dt.Rows[e.Row.GetIndex()]["Unit Price Without Tax"] = (Price - Price * TaxPrec).ToString();
                    }
                }
                else
                {
                    dt.Rows[e.Row.GetIndex()]["Total Price With Tax"] = (Price * Qty).ToString();
                    dt.Rows[e.Row.GetIndex()]["Total Price Without Tax"] = (Price * Qty).ToString();
                    
                    dt.Rows[e.Row.GetIndex()]["Unit Price With Tax"] = Price.ToString();
                    dt.Rows[e.Row.GetIndex()]["Unit Price Without Tax"] = Price.ToString();

                }

                float totalPriceWithoutTax = 0;
                float totalPriceWithTax = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    totalPriceWithoutTax += float.Parse(dt.Rows[i]["Total Price Without Tax"].ToString());
                    Total_Price_Without_Tax.Text = totalPriceWithoutTax.ToString();

                    totalPriceWithTax += float.Parse(dt.Rows[i]["Total Price With Tax"].ToString());
                    Total_Price_With_Tax.Text = totalPriceWithTax.ToString();
                }
            }
            catch { }
            
        }

        private void NeglectWhiteSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
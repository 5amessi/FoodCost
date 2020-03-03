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
    /// Interaction logic for AdjacmentInventory.xaml
    /// </summary>
    public partial class AdjacmentInventory : UserControl
    {
        public string ValOfResturant = "";
        public string ValOfKitchen = "";
        string physicalinventoryID = "";
        bool Blind = false;

        //Adjacment Coming from Physcial Inventory
        public AdjacmentInventory(string ValofRest,string valofKit,string valofOPhiID)
        {
            InitializeComponent();
            ValOfResturant = ValofRest;
            ValOfKitchen = valofKit;
            Adjact.Visibility = Visibility.Visible;
            NumberOfItemText.Visibility = Visibility.Visible;
            TotalofItems.Visibility = Visibility.Visible;
            NUmberOfItems.Visibility = Visibility.Visible;
            Total_Price.Visibility = Visibility.Visible;
            Adjact.IsEnabled = true;
            adjacChose.Visibility = Visibility.Hidden;
            AdjacInfo.Visibility = Visibility.Visible;
            ItemsDGV.IsReadOnly = true;
            GetAdjacmentID();
            LoadPhysicalInventory(ValofRest,valofKit,valofOPhiID);
        }
        private void LoadPhysicalInventory(string valofResturant,string valofKitchen,string PhiID)
        {
            physicalinventoryID = PhiID;
            int NumOfItems = 0; double totalCost = 0;
            DataTable dt = new DataTable();
            DataTable Dat = new DataTable();
            string FirstName = ""; string SeconName = "";
            SqlDataReader reader = null;
            SqlDataReader reader2 = null;
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlConnection con2 = new SqlConnection(Classes.DataConnString);
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd2 = new SqlCommand();
            //
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("select Inventory_Date,Comment,Blind,Resturant_ID,KitchenID from PhysicalInventory_tbl Where Inventory_ID='{0}'", PhiID), con);
                Dat = new DataTable();
                adapter.Fill(Dat);

                DataRow row = Dat.Rows[0];
                ValOfResturant = row["Resturant_ID"].ToString();
                ValOfKitchen = row["KitchenID"].ToString();
                Reasoncbx.Items.Add("Physical Inventory");
                Reasoncbx.Text = "Physical Inventory";
                Reasoncbx.IsEnabled = false;
                Adjacment_Date.Text = row["Inventory_Date"].ToString();
                commenttxt.Text = row["Comment"].ToString();
                Blind = Convert.ToBoolean(row["Blind"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            if (Blind == false)
            {
                dt.Columns.Add("Code");
                dt.Columns.Add("Name");
                dt.Columns.Add("Name2");
                dt.Columns.Add("Qty");
                dt.Columns.Add("Cost");
                try
                {
                    con.Open();
                    string s = "select Item_ID,Qty,Cost from PhysicalInventory_Items Where  Inventory_ID=" + PhiID;
                    cmd = new SqlCommand(s, con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            con2.Open();
                            string q = "SELECT Name,Name2 From Setup_Items Where Code='" + reader["Item_ID"].ToString() + "'";
                            cmd2 = new SqlCommand(q, con2);
                            reader2 = cmd2.ExecuteReader();
                            while (reader2.Read())
                            {
                                FirstName = reader2["Name"].ToString();
                                SeconName = reader2["Name2"].ToString();
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
                        NumOfItems++;
                        totalCost += Convert.ToDouble(reader["Cost"].ToString());
                        dt.Rows.Add(reader["Item_ID"].ToString(), FirstName, SeconName, reader["Qty"].ToString(), reader["Cost"]);
                    }
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dt.Columns[i].ReadOnly = true;
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
                NUmberOfItems.Text = NumOfItems.ToString();
                Total_Price.Text = totalCost.ToString();
            }
            else
            {
                dt.Columns.Add("Code");
                dt.Columns.Add("Name");
                dt.Columns.Add("Name2");
                dt.Columns.Add("Qty");
                dt.Columns.Add("Phsycal Qty");
                dt.Columns.Add("Variance");
                dt.Columns.Add("Cost");
                try
                {
                    con.Open();
                    string s = "select Item_ID,Qty,InventoryQty,Variance,Cost from PhysicalInventory_Items Where  Inventory_ID=" + PhiID;
                    cmd = new SqlCommand(s, con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        try
                        {
                            con2.Open();
                            string q = "SELECT Name,Name2 From Setup_Items Where Code='" + reader["Item_ID"].ToString() + "'";
                            cmd2 = new SqlCommand(q, con2);
                            reader2 = cmd2.ExecuteReader();
                            while (reader2.Read())
                            {
                                FirstName = reader2["Name"].ToString();
                                SeconName = reader2["Name2"].ToString();
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
                        NumOfItems++;
                        totalCost += Convert.ToDouble(reader["Cost"].ToString());
                        dt.Rows.Add(reader["Item_ID"].ToString(), FirstName, SeconName, reader["Qty"].ToString(), reader["InventoryQty"].ToString(), reader["Variance"].ToString(), reader["Cost"]);
                    }
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        dt.Columns[i].ReadOnly = true;
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
                NUmberOfItems.Text = NumOfItems.ToString();
                Total_Price.Text = totalCost.ToString();
            }
          
            con.Close();
        }

        // Normal Adjacment 
        DataTable dt = new DataTable();
        public AdjacmentInventory()
        {
            InitializeComponent();
            LoadAllResturant();
        }
        public void LoadAllResturant()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            con.Open();
            try
            {
                string s = "select Name from Setup_Restaurant where IsActive='True'";
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
        private void ResturantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Kitchencbx.Items.Clear();
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            con.Open();
            try
            {
                string s = "select Name from Setup_Kitchens Where RestaurantID=(select Code From Setup_Restaurant Where Name='" + Outletcbx.SelectedItem.ToString() + "') and IsActive='True'";
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
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetCodeofResturantAndKitchen();
            Adjact.Visibility = Visibility.Visible;
            NumberOfItemText.Visibility = Visibility.Visible;
            TotalofItems.Visibility = Visibility.Visible;
            NUmberOfItems.Visibility = Visibility.Visible;
            Total_Price.Visibility = Visibility.Visible;
            Adjact.IsEnabled = true;
            adjacChose.Visibility = Visibility.Hidden;
            AdjacInfo.Visibility = Visibility.Visible;
            addItemBtn.Visibility = Visibility.Visible;
            RemoveItemBtn.Visibility = Visibility.Visible;
            LoadAllReasons();
            GetAdjacmentID();
        }
        private void LoadAllReasons()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Name from Setup_AdjacmentReasons_tbl where Active='True'";
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = reader["Name"].ToString();
                    Reasoncbx.Items.Add(data);
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
        private void GetAdjacmentID()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = string.Format("Select TOP(1) Adjacment_ID From Adjacment_tbl where Adjacment_ID like '{0}%' ORDER BY Adjacment_ID DESC", Classes.IDs);
                SqlCommand cmd = new SqlCommand(s, con);
                if (cmd.ExecuteScalar() == null)
                {
                    Serial_Adjacment_NO.Text = Classes.IDs + "0000001";
                }
                else
                {
                    Serial_Adjacment_NO.Text = "0" + (Int64.Parse(cmd.ExecuteScalar().ToString()) + 1).ToString();
                }
                con.Close();
            }
            catch { }
        }
        private void GetCodeofResturantAndKitchen()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlCommand cmd = new SqlCommand();
            try
            {
               con.Open();
                string s = "SELECT Code FROM Setup_Restaurant Where Name='" + Outletcbx.SelectedItem.ToString() + "'";
                cmd = new SqlCommand(s, con);
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


            try
            {
                con.Open();
                string s = "SELECT Code FROM Setup_Kitchens Where Name='" + Kitchencbx.SelectedItem.ToString() +"'";
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
        }       
        private void ItemsDGV_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            dt = ItemsDGV.DataContext as DataTable;
            try
            {
                dt.Columns["Variance"].ReadOnly = false;
                dt = ((DataView)ItemsDGV.ItemsSource).ToTable();
                if (e.Column.Header == "Adjacmentable Qty")
                {
                    try
                    {
                        (ItemsDGV.SelectedItem as DataRowView).Row[5] = (Double.Parse(((e.EditingElement as TextBox).Text).ToString()) - Convert.ToDouble((ItemsDGV.SelectedItem as DataRowView).Row.ItemArray[3]));
                    }
                    catch { }
                }
                    dt.Columns["Adjacmentable Qty"].ReadOnly = false;
                    dt.Columns["Variance"].ReadOnly = true;
            }
            catch { }

            try
            {

                double totalPrice = 0;
                for (int i = 0; i < ItemsDGV.Items.Count; i++)
                {
                    try
                    {
                        totalPrice += Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[6]);
                    }
                    catch
                    {

                    }
                }
                NUmberOfItems.Text = (ItemsDGV.Items.Count).ToString();
                Total_Price.Text = (totalPrice).ToString();
            }
            catch { }
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        private void NeglectWhiteSpace(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void AddItemBtn_Click(object sender, RoutedEventArgs e)
        {
            ValOfResturant = ValOfResturant;
            ValOfKitchen = ValOfKitchen;
            Items itemswindow = new Items(this);
            itemswindow.ShowDialog();
        }

        private void RemoveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            //DataGrid grid = sender as DataGrid;
            //int codeTodelete = grid.SelectedIndex;
            //if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            //{
            //    DataTable dt = new DataTable();
            //    dt = ((DataView)ItemsDGV.ItemsSource).ToTable();
            //    dt.Rows.RemoveAt(codeTodelete);
            //    ItemsDGV.DataContext = dt;
            //}
        }

        private void Adjact_Click(object sender, RoutedEventArgs e)
        {
            if (Reasoncbx.Text != "Physical Inventory")
            {
                if (ItemsDGV.Items.Count == 0)
                {
                    MessageBox.Show("First You should Select Items !");
                    return;
                }
                if (Serial_Adjacment_NO.Text.Equals(""))
                {
                    MessageBox.Show("First You should Enter The Serial !");
                    return;
                }
                if (Adjacment_NO.Text.Equals(""))
                {
                    MessageBox.Show("First You should Enter The Manual Number !");
                    return;
                }
                if (Reasoncbx.Text.Equals(""))
                {
                    MessageBox.Show("First You should Choose The Reason !");
                    return;
                }
                if (Adjacment_Date.Text.Equals(""))
                {
                    MessageBox.Show("First You should Enter The Date !");
                    return;
                }

                SqlConnection con = new SqlConnection(Classes.DataConnString);
                con.Open();
                try
                {
                    string FiledSelection = "Adjacment_ID,Adjacment_Num,Adjacment_Reason,Adjacment_Date,Comment,Resturant_ID,KitchenID,Create_Date,Post_Date,User_ID,WS,Total_Cost";
                    string Values = string.Format("'{0}',{1},(select Code From Setup_AdjacmentReasons_tbl where Name='{2}'),'{3}','{4}',{5},{6},GETDATE(),GETDATE(),'{7}','{8}','{9}'", Serial_Adjacment_NO.Text, Adjacment_NO.Text, Reasoncbx.Text, Convert.ToDateTime(Adjacment_Date.Text).ToString("MM-dd-yyyy"), commenttxt.Text, ValOfResturant, ValOfKitchen, MainWindow.UserID, Classes.WS, Total_Price.Text);
                    Classes.InsertRow("Adjacment_tbl", FiledSelection, Values);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    for (int i = 0; i < ItemsDGV.Items.Count; i++)
                    {
                        string FiledSelection = "Adjacment_ID,Item_ID,Qty,AdjacmentableQty,Variance,Cost";
                        string Values = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}'", Serial_Adjacment_NO.Text, (((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0]), Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[3]), Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4]), Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[5]), Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[6]));
                        Classes.InsertRow("Adjacment_Items", FiledSelection, Values);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    for (int i = 0; i < ItemsDGV.Items.Count; i++)
                    {
                        string H = string.Format("Update Items set Qty={0}, Current_Cost={4}, Net_Cost=({4} * {0}) where ItemID = '{1}' and RestaurantID ={2} and KitchenID={3}", Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4]), (((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0]), ValOfResturant, ValOfKitchen, Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[6]));
                        SqlCommand cmd = new SqlCommand(H, con);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    MessageBox.Show("Edited Successfully");
                }
            }
            else
            {
                SaveThePhyscialAdjacment();
            }
            Adjact.IsEnabled = false;
        }

        private void SaveThePhyscialAdjacment()
        {
            if (ItemsDGV.Items.Count == 0)
            {
                MessageBox.Show("First You should Select Items !");
                return;
            }
            if (Serial_Adjacment_NO.Text.Equals(""))
            {
                MessageBox.Show("First You should Enter The Serial !");
                return;
            }
            if (Adjacment_NO.Text.Equals(""))
            {
                MessageBox.Show("First You should Enter The Manual Number !");
                return;
            }
            if (Reasoncbx.Text.Equals(""))
            {
                MessageBox.Show("First You should Choose The Reason !");
                return;
            }
            if (Adjacment_Date.Text.Equals(""))
            {
                MessageBox.Show("First You should Enter The Date !");
                return;
            }

            SqlConnection con = new SqlConnection(Classes.DataConnString);
            con.Open();
            if (Blind == false)
            {
                try
                {
                    string FiledSelection = "Adjacment_ID,Adjacment_Num,Adjacment_Reason,Adjacment_Date,Comment,Resturant_ID,KitchenID,Create_Date,Post_Date,User_ID,WS,Total_Cost";
                    string Values = string.Format("'{0}',{1},(select Code From Setup_AdjacmentReasons_tbl where Name='{2}'),'{3}','{4}',{5},{6},GETDATE(),GETDATE(),'{7}','{8}','{9}'", Serial_Adjacment_NO.Text, Adjacment_NO.Text, Reasoncbx.Text, Convert.ToDateTime(Adjacment_Date.Text).ToString("MM-dd-yyyy"), commenttxt.Text, ValOfResturant, ValOfKitchen, MainWindow.UserID, Classes.WS,Total_Price.Text);
                    Classes.InsertRow("Adjacment_tbl", FiledSelection, Values);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    for (int i = 0; i < ItemsDGV.Items.Count; i++)
                    {
                        string FiledSelection = "Adjacment_ID,Item_ID,Qty,Cost";
                        string Values = string.Format("'{0}','{1}','{2}','{3}'", Serial_Adjacment_NO.Text, (((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0]), Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[3]), Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4]));
                        Classes.InsertRow("Adjacment_Items", FiledSelection, Values);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    for (int i = 0; i < ItemsDGV.Items.Count; i++)
                    {
                        string H = string.Format("Update Items set Qty={0}, Current_Cost={4}, Net_Cost=({4} * {0}) where ItemID = '{1}' and RestaurantID ={2} and KitchenID={3}", Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[3]), (((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0]), ValOfResturant, ValOfKitchen, Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4]));
                        SqlCommand cmd = new SqlCommand(H, con);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    MessageBox.Show("Edited Successfully");
                }
            }
            else
            {
                try
                {
                    string FiledSelection = "Adjacment_ID,Adjacment_Num,Adjacment_Reason,Adjacment_Date,Comment,Resturant_ID,KitchenID,Create_Date,Post_Date,User_ID,WS,Total_Cost";
                    string Values = string.Format("'{0}',{1},(select Code From Setup_AdjacmentReasons_tbl where Name='{2}'),'{3}','{4}',{5},{6},GETDATE(),GETDATE(),'{7}','{8}','{9}'", Serial_Adjacment_NO.Text, Adjacment_NO.Text, Reasoncbx.Text, Convert.ToDateTime(Adjacment_Date.Text).ToString("MM-dd-yyyy"), commenttxt.Text, ValOfResturant, ValOfKitchen, MainWindow.UserID, Classes.WS,Total_Price.Text);
                    Classes.InsertRow("Adjacment_tbl", FiledSelection, Values);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    for (int i = 0; i < ItemsDGV.Items.Count; i++)
                    {
                        string FiledSelection = "Adjacment_ID,Item_ID,Qty,AdjacmentableQty,Variance,Cost";
                        string Values = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}'", Serial_Adjacment_NO.Text, (((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0]), Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[3]), ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4], ((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[5], Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[6]));
                        Classes.InsertRow("Adjacment_Items", FiledSelection, Values);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                try
                {
                    for (int i = 0; i < ItemsDGV.Items.Count; i++)
                    {
                        string H = string.Format("Update Items set Qty={0}, Current_Cost={4}, Net_Cost=({4} * {0}) where ItemID = '{1}' and RestaurantID ={2} and KitchenID={3}", Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[4]), (((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0]), ValOfResturant, ValOfKitchen, Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[6]));
                        SqlCommand cmd = new SqlCommand(H, con);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    MessageBox.Show("Edited Successfully");
                }
            }


            try
            {
                string s = string.Format("update PhysicalInventory_tbl set Inventory_Type='Closed' where Inventory_ID={0}", physicalinventoryID);
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

    }
}

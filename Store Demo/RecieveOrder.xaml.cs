﻿using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace Food_Cost
{
    /// <summary>
    /// Interaction logic for RecieveOrder.xaml
    /// </summary>
    public partial class RecieveOrder : UserControl
    {
        public static string TransferResturantID = "";
        public static string TransferKitchenID = "";
        string RestaurantId, KitchenId = "";
        int IndexOfRecord = 0;
        public RecieveOrder()
        {
            InitializeComponent();

            LoadToDGV();
            IncrementPoNo();
            LoadTheResturant();
        }
        private void MainUiFormat()
        {
            if (TabControl.SelectedIndex == 0)
            {
                MainGrid.IsEnabled = false;
                RecieveOrderDGV.IsEnabled = true;
                Recieve.IsEnabled = false;
            }
            else if (TabControl.SelectedIndex == 1)
            {
                ManualROKitchen.IsEnabled = false;
                DeliveryROKitchen.IsEnabled = false;
                DeliveryROKitchenTime.IsEnabled = false;
                CommentKitchen.IsEnabled = false;
                recieveTransfer.IsEnabled = false;
            }
            else if (TabControl.SelectedIndex == 2)
            {
                ManualROInter.IsEnabled = false;
                DeliveryROInter.IsEnabled = false;
                DeliveryROInterTime.IsEnabled = false;
                CommentRoInter.IsEnabled = false;
                recieveTransferInter.IsEnabled = false;
            }
            else if (TabControl.SelectedIndex == 3)
            {
                KitchenCbx.IsEnabled = false;
                ResturantCbx.IsEnabled = false;
                Manual_Recieve_NoWithout.IsEnabled = false;
                commentWithouttxt.IsEnabled = false;
                AddItemBtn.IsEnabled = false;
                DeleteItemBtn.IsEnabled = false;
                _NewBtn.IsEnabled = true;
                REcivedWithoutBtn_Click.IsEnabled = false;
                MainGrid.IsEnabled = false;
                WithoutPoUndoBtn.IsEnabled = true;
            }
            else if(TabControl.SelectedIndex==4)
            {
                Serial_Request_NO.IsEnabled = false;
                Request_NO.IsEnabled = false;
                TypeCbx.IsEnabled = false;
                RequestsItemsDGV.DataContext = null;
                RequestssDGV.Visibility = Visibility.Visible;
                RequestsItemsDGV.Visibility = Visibility.Hidden;
            }
        }
        public void EnableUI()
        {
            if (TabControl.SelectedIndex == 0)
            {
                MainGrid.IsEnabled = true;

                Recieve.IsEnabled = true;

                codetxt.IsEnabled = false;
                PO.IsEnabled = false;
                Manual_Recieve_No.IsEnabled = true;
                vendortxt.IsEnabled = false;
                Delivery_dt.IsEnabled = false;
                commenttxt.IsEnabled = true;
                Delivery_time.IsEnabled = false;
            }
            else if (TabControl.SelectedIndex == 1)
            {
                ManualROKitchen.IsEnabled = true;
                CommentKitchen.IsEnabled = true;
                recieveTransfer.IsEnabled = true;
            }
            else if (TabControl.SelectedIndex == 2)
            {
                ManualROInter.IsEnabled = true;
                CommentRoInter.IsEnabled = true;
                recieveTransferInter.IsEnabled = true;
            }
            else if (TabControl.SelectedIndex == 3)
            {
                _NewBtn.IsEnabled = false;
                Manual_Recieve_NoWithout.IsEnabled = true;
                commentWithouttxt.IsEnabled = true;
                AddItemBtn.IsEnabled = true;
                DeleteItemBtn.IsEnabled = true;
                REcivedWithoutBtn_Click.IsEnabled = true;
                ResturantCbx.IsEnabled = true;
                KitchenCbx.IsEnabled = true;
            }
        }
        private void ClearFields()
        {
            if (TabControl.SelectedIndex == 0)
            {
                codetxt.Text = "";

                Manual_Recieve_No.Text = "";
                PO.Text = "";
                Delivery_time.Text = "";
                vendortxt.Text = "";
                Delivery_dt.Text = "";
                commenttxt.Text = "";
                Total_Price_Without_Tax_Purchase.Text = "";
                Total_Price_With_Tax_Purchase.Text = "";

                ItemsDGV.DataContext = null;
            }
            else if (TabControl.SelectedIndex == 1)
            {
                RoTransferKitchen.Text = "";
                ManualROKitchen.Text = "";
                TransferNumberKitchenTxt.Text = "";
                DeliveryROKitchen.Text = "";
                DeliveryROKitchenTime.Text = "";
                CommentKitchen.Text = "";
                FromResturanKitchenttxt.Text = "";
                FromKitchenKitchentxt.Text = "";
                ToResturantKitchentxt.Text = "";
                ToKitchenKitchentxt.Text = "";
                NumberOfItemsKitchen.Text = "0";
                Total_Price_With_Tax_Kitchen.Text = "0";

                ItemKitchenTransferDGV.DataContext = null;
            }
            else if (TabControl.SelectedIndex == 2)
            {
                RoInter.Text = "";
                ManualROInter.Text = "";
                TransferNumberInterTxt.Text = "";
                DeliveryROInter.Text = "";
                DeliveryROInterTime.Text = "";
                CommentRoInter.Text = "";
                FromResturantIntertxt.Text = "";
                FromKitchenIntertxt.Text = "";
                ToKitchenIntertxt.Text = "";
                NumberOfItemsInter.Text = "0";
                Total_Price_With_Tax_InterKitchen.Text = "0";

                ItemRoInterDGV.DataContext = null;
            }
            else if (TabControl.SelectedIndex == 3)
            {
                codeWithouttxt.Text = "";
                Manual_Recieve_NoWithout.Text = "";
                ResturantCbx.Text = "";
                KitchenCbx.Text = "";
                commentWithouttxt.Text = "";
                Total_Price_Without_Tax.Text = "";
                Total_Price_With_Tax.Text = "";
                ItemsWithoutDGV.DataContext = null;
            }

        }
        private bool DoSomeChecks()
        {
            int Count = 0;
            if (TabControl.SelectedIndex == 0)
            {
                if (codetxt.Text.Equals(""))
                {
                    MessageBox.Show("R.O# Can't Be Empty");
                    return false;
                }
                else if (Manual_Recieve_No.Text.Equals(""))
                {
                    MessageBox.Show("Manual R.O# Can't Be Empty");
                    return false;
                }
                else if (PO.Text.Equals(""))
                {
                    MessageBox.Show("P.O Reference# Can't Be Empty");
                    return false;
                }
                else if (Delivery_dt.Text.Equals(""))
                {
                    MessageBox.Show("Delivery Date Can't Be Empty");
                    return false;
                }
                else if (Delivery_time.Text == null)
                {
                    MessageBox.Show("Delivery Time Can't Be Empty");
                    return false;
                }
                else if (vendortxt.Text.Equals(""))
                {
                    MessageBox.Show("Vendor can not be empty");
                    return false;
                }
                else if (ItemsDGV.Items.Count == 0)
                {
                    MessageBox.Show("Items can not be empty");
                    return false;
                }
                for (int i = 0; i < ItemsDGV.Items.Count; i++)
                {
                    if (((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[0].ToString() == "False")
                    {
                        Count++;
                    }
                }
                if (Count == ItemsDGV.Items.Count)
                {
                    MessageBox.Show("Choose Items That You will Recieve");
                    return false;
                }
            }
            else if (TabControl.SelectedIndex == 3)
            {
                if (codeWithouttxt.Text.Equals(""))
                {
                    MessageBox.Show("R.O# Can't Be Empty");
                    return false;
                }
                else if (Manual_Recieve_NoWithout.Text.Equals(""))
                {
                    MessageBox.Show("Manual R.O# Can't Be Empty");
                    return false;
                }
                else if (ResturantCbx.Text.Equals(""))
                {
                    MessageBox.Show("Resturant R.O# Can't Be Empty");
                    return false;
                }
                else if (KitchenCbx.Text.Equals(""))
                {
                    MessageBox.Show("Kitchen R.O# Can't Be Empty");
                    return false;
                }
                else if (ItemsWithoutDGV.Items.Count == 0)
                {
                    MessageBox.Show("Items can not be empty");
                    return false;
                }
                else
                {
                    for (int i = 0; i < ItemsWithoutDGV.Items.Count; i++)
                    {

                        try
                        {
                            int.Parse((ItemsWithoutDGV.Items[i] as DataRowView).Row["Price"].ToString());
                        }
                        catch
                        {
                            MessageBox.Show("Price input error");
                            //ItemsWithoutDGV.CurrentCell = new DataGridCellInfo(ItemsWithoutDGV.Items[i], ItemsWithoutDGV.Columns[13]);  //nb2a n3dl el index kol mara nezawd column
                            //ItemsWithoutDGV.BeginEdit();
                            return false;
                        }
                    }
                }
            }

            return true;

        }
        private void IncrementPoNo()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();

                //if (IsReceived == "Receivied")
                //{
                //    codetxt.Text = Ro_No;
                //    return;
                //}

                SqlCommand cmd = new SqlCommand(string.Format("select Top(1) RO_Serial from Ro where RO_Serial like '{0}%' order by  RO_Serial desc", Classes.IDs), con);
                codetxt.Text = "0" + (Int64.Parse(cmd.ExecuteScalar().ToString()) + 1).ToString();
                RoTransferKitchen.Text = "0" + (Int64.Parse(cmd.ExecuteScalar().ToString()) + 1).ToString();
                RoInter.Text = "0" + (Int64.Parse(cmd.ExecuteScalar().ToString()) + 1).ToString();
                codeWithouttxt.Text = "0" + (Int64.Parse(cmd.ExecuteScalar().ToString()) + 1).ToString();
            }
            catch
            {
                codetxt.Text = Classes.IDs + "0000001";
                RoTransferKitchen.Text = Classes.IDs + "0000001";
                RoInter.Text = Classes.IDs + "0000001";
                codeWithouttxt.Text = Classes.IDs + "0000001";
                con.Close();
                return;
            }
        }


        //Recive Purshace 
        private void LoadToDGV()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT PO_Serial AS Number, (Select Name From Vendors Where Code = Vendor_ID)AS Vendor,Delivery_Date as 'Delivery Date' FROM PO where Status='Post' and PO_Serial not in (select Transactions_No from RO where Type='Recieve_Purchase') ORDER BY PO_Serial DESC", con);
                da.Fill(dt);
                RecieveOrderDGV.DataContext = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }    //Done
        private void RecieveOrderDGV_Click(object sender, MouseButtonEventArgs e)
        {
            IncrementPoNo();
            Recieve.IsEnabled = true;
            bool IfItemRecieved = true;
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    string code = (grid.SelectedItem as DataRowView).Row[0].ToString();
                    if (code == "") return;
                    string valuoSerial = "";
                    string valuoNumber = "";
                    SqlConnection con2 = new SqlConnection(Classes.DataConnString); SqlConnection con = new SqlConnection(Classes.DataConnString);
                    DataTable dt = new DataTable(); DataTable Dat = new DataTable();
                    Dat.Columns.Add(new DataColumn("Received", typeof(bool)));
                    Dat.Columns.Add("Code");
                    Dat.Columns.Add("Manual Code");
                    Dat.Columns.Add("Name");
                    Dat.Columns.Add("Name2");
                    Dat.Columns.Add("Is_TaxableItem", typeof(bool));
                    Dat.Columns.Add("Qty");
                    Dat.Columns.Add("Price Without Tax");
                    Dat.Columns.Add("Tax");
                    Dat.Columns.Add("Price_With_Tax");
                    Dat.Columns.Add("Net_Price");
                    try
                    {
                        con.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(string.Format("select PO_Serial,PO_NO," + string.Format("(select Name from Vendors where VendorID = {0}) as Vendor", "Vendor_ID") + ",Delivery_Date,Comment,Restaurant_ID,Kitchen_ID,WS from PO where PO_Serial = {0}", code), con);
                        adapter.Fill(dt);

                        DataRow row = dt.Rows[0];
                        PO.Text = row["PO_NO"].ToString();
                        valuoSerial = row["PO_Serial"].ToString();
                        valuoNumber = row["PO_NO"].ToString();
                        vendortxt.Text = row["Vendor"].ToString();
                        commenttxt.Text = row["Comment"].ToString();
                    }
                    finally { con.Close(); }

                    try
                    {
                        con.Open();
                        string M = "SELECT Item_ID,Qty,Price_Without_Tax,Tax,Price_With_Tax,Net_Price,Tax_Included  FROM PO_Items Where PO_Serial='" + valuoSerial + "'";
                        SqlCommand cmd = new SqlCommand(M, con);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            try
                            {
                                con2.Open();
                                string s = string.Format("SELECT Item_ID FROM RO_Items Where Item_ID={1} AND RO_No = (select RO_Serial from RO where Transactions_No = '{0}' and Type='Recieve_Purchase')", valuoSerial, reader["Item_ID"]);
                                SqlCommand cmd2 = new SqlCommand(s, con2);
                                if (cmd2.ExecuteScalar() != null)
                                {
                                    IfItemRecieved = true;
                                }
                                else { IfItemRecieved = false; }

                            }
                            catch { }
                            finally { con2.Close(); }
                            try
                            {
                                con2.Open();
                                string S = "SELECT Name,Name2,[Manual Code] FROM Setup_Items where Code='" + reader["Item_ID"].ToString() + "'";
                                SqlCommand cmd2 = new SqlCommand(S, con2);
                                SqlDataReader reader2 = cmd2.ExecuteReader();
                                while (reader2.Read())
                                {
                                    Dat.Rows.Add(IfItemRecieved, reader["Item_ID"], reader2["Manual Code"], reader2["Name"], reader2["Name2"], reader["Tax_Included"], reader["Qty"], reader["Price_Without_Tax"], reader["Tax"], reader["Price_With_Tax"], reader["Net_Price"]);
                                }
                                reader2.Close();
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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally
                    {
                        con.Close();
                    }
                    for (int i = 0; i < Dat.Columns.Count; i++)
                    {
                        Dat.Columns[i].ReadOnly = true;
                    }
                    Dat.Columns["Received"].ReadOnly = false;
                    Dat.Columns["Qty"].ReadOnly = false;
                    ItemsDGV.DataContext = Dat;
                    float Price_With_Tax_Purchase = 0; float Price_Without_Tax_Purchase = 0;
                    for (int i = 0; i < ItemsDGV.Items.Count; i++)
                    {
                        Price_With_Tax_Purchase += float.Parse(Dat.Rows[i]["Net_Price"].ToString());
                        Price_Without_Tax_Purchase += (float.Parse(Dat.Rows[i]["Qty"].ToString()) * float.Parse(Dat.Rows[i]["Price Without Tax"].ToString()));
                    }
                    Total_Price_Without_Tax_Purchase.Text = Price_Without_Tax_Purchase.ToString();
                    Total_Price_With_Tax_Purchase.Text = Price_With_Tax_Purchase.ToString();
                }
            }
            MainGrid.IsEnabled = true;
        }  //Done
        private void Row_Changed(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Classes.DataConnString);
                DataTable Dat = new DataTable();
                Dat = (ItemsDGV.DataContext as DataTable);
                Dat.Columns["Net_Price"].ReadOnly = false;

                float Qty = float.Parse((e.Row.Item as DataRowView).Row["Qty"].ToString());
                float Price = float.Parse((e.Row.Item as DataRowView).Row["Price_With_Tax"].ToString());
                if (e.Column.Header.ToString() == "Qty")
                {
                    (e.Row.Item as DataRowView).Row["Net_Price"] = (double.Parse((e.EditingElement as TextBox).Text) * Convert.ToDouble(((DataRowView)ItemsDGV.SelectedItem).Row.ItemArray[9])).ToString();
                }
                Dat.Columns["Net_Price"].ReadOnly = true;
            }
            catch { }
        }   //Done
        private void RecievedBtn_Click(object sender, RoutedEventArgs e)
        {
            string QTyonHand = ""; string CostOfItemsOnHand = ""; string QtyOnHandMultipleCost = "";
            string FiledSelection = ""; string Values = "";

            if (!DoSomeChecks())
                return;
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlConnection con2 = new SqlConnection(Classes.DataConnString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();

                DataTable dt = ItemsDGV.DataContext as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Received"].ToString() == "False")
                    {
                        //reader.Close();
                        continue;
                    }
                    // Ana Hena h get al Qty on Hand aly Mawgoda f Items_tbl
                    con2.Open();
                    string s = string.Format("select Qty,Current_Cost From Items where RestaurantID=1 and KitchenID=1 and ItemID={0}", dt.Rows[i]["Code"].ToString());
                    SqlCommand _CMD = new SqlCommand(s, con2);
                    SqlDataReader _reader = _CMD.ExecuteReader();
                    while (_reader.Read())
                    {
                        QTyonHand = (Convert.ToDouble(_reader["Qty"].ToString())).ToString();
                        CostOfItemsOnHand = _reader["Current_Cost"].ToString();
                    }
                    con2.Close();
                    try
                    {
                        QtyOnHandMultipleCost = (Convert.ToDouble(QTyonHand) * Convert.ToDouble(CostOfItemsOnHand)).ToString();
                        QTyonHand = (Convert.ToDouble(QTyonHand) + Convert.ToDouble(dt.Rows[i]["Qty"].ToString())).ToString();
                        CostOfItemsOnHand = ((Convert.ToDouble(QtyOnHandMultipleCost) + (Convert.ToDouble(dt.Rows[i]["Qty"].ToString()) * Convert.ToDouble(dt.Rows[i]["Price_With_Tax"]))) / Convert.ToDouble(QTyonHand)).ToString();
                    }
                    catch { }
                    //
                    FiledSelection = "Item_ID,RO_No,Qty,Unit,Price_Without_Tax,Tax,Price_With_Tax,Net_Price,QtyOnHand_To,Cost_To";
                    Values = "'" + dt.Rows[i]["Code"].ToString() + "','" + codetxt.Text + "'," + dt.Rows[i]["Qty"] + ",'" + "" + "'," + dt.Rows[i]["Price Without Tax"] + "," + dt.Rows[i]["Tax"] + "," + dt.Rows[i]["Price_With_Tax"] + "," + dt.Rows[i]["Net_Price"] + ",'" + QTyonHand + "','" + CostOfItemsOnHand + "'";
                    Classes.InsertRow("RO_Items", FiledSelection, Values);
                    //s = "insert into RO_Items (Item_ID,RO_No,Qty,Unit,Price_Without_Tax,Tax,Price_With_Tax,Net_Price,QtyOnHand_To,Cost_To) values ('" + dt.Rows[i]["Code"].ToString() + "','" + codetxt.Text + "'," + dt.Rows[i]["Qty"] + ",'" + "" + "'," + dt.Rows[i]["Price Without Tax"] + "," + dt.Rows[i]["Tax"] + "," + dt.Rows[i]["Price_With_Tax"] + "," + dt.Rows[i]["Net_Price"] + ",'" + QTyonHand + "','" + CostOfItemsOnHand + "')";
                    //_CMD = new SqlCommand(s, con);
                    ////reader.Close();
                    //_CMD.ExecuteNonQuery();

                    s = string.Format("Update Items set Qty = Qty + {1},Last_Cost = Current_Cost,Current_Cost = ((Current_Cost * Qty)+({1} * {3}))/(Qty+{1}),Units = '{4}',Net_Cost=((((Current_Cost * Qty)+({1} * {3}))/(Qty+{1})) * (Qty+{5})) where ItemID = '{0}' and RestaurantID ='{2}' and KitchenID = 1", dt.Rows[i]["Code"], dt.Rows[i]["QTy"], "1", dt.Rows[i]["Price_With_Tax"], "", dt.Rows[i]["Qty"]);
                    SqlCommand _cmd = new SqlCommand(s, con);
                    int n = _cmd.ExecuteNonQuery();

                    if (n == 0)
                    {
                        FiledSelection = "RestaurantID,KitchenID,ItemID,Qty,Units,Last_Cost,Current_Cost,Net_Cost";
                        Values = string.Format("'{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}'", "1", "1", dt.Rows[i]["Code"], dt.Rows[i]["Qty"], "", dt.Rows[i]["Price_With_Tax"], dt.Rows[i]["Price_With_Tax"], dt.Rows[i]["Net_Price"]);
                        Classes.InsertRow("Items", FiledSelection, Values);
                        //s = string.Format("insert into Items(RestaurantID,KitchenID,ItemID,Qty,Units,Last_Cost,Current_Cost,Net_Cost) Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", "1", "1", dt.Rows[i]["Code"], dt.Rows[i]["Qty"], "", dt.Rows[i]["Price_With_Tax"], dt.Rows[i]["Price_With_Tax"], dt.Rows[i]["Net_Price"]);
                        //_cmd = new SqlCommand(s, con);
                        //_cmd.ExecuteNonQuery();
                    }
                }

                FiledSelection = "RO_Serial,RO_No,Transactions_No,Status,Receiving_Date,Resturant_ID,Kitchen_ID,WS,Type,Comment,UserID,Create_Date";
                Values = string.Format("'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}',GETDATE()", codetxt.Text, Manual_Recieve_No.Text, (RecieveOrderDGV.SelectedItem as DataRowView).Row.ItemArray[0].ToString(), "Recieved", Delivery_dt.Text + " " + Delivery_time.Text, "1", "1", Classes.WS, "Recieve_Purchase", commenttxt.Text, MainWindow.UserID);
                Classes.InsertRow("RO", FiledSelection, Values);
                //cmd = new SqlCommand(string.Format("Insert into RO(RO_Serial,RO_No,Transactions_No,Status,Receiving_Date,Resturant_ID,Kitchen_ID,WS,Type,Comment,UserID)Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", codetxt.Text, Manual_Recieve_No.Text, (RecieveOrderDGV.SelectedItem as DataRowView).Row.ItemArray[0].ToString(), "Recieved", Delivery_dt.Text, "1", "1", Classes.WS, "Recieve_Purchase", commenttxt.Text,MainWindow.UserID), con);
                //cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            finally
            {
                MessageBox.Show("Order Recived Succesfully");
                con.Close();
            }
            EnableUI();
            ClearFields();
            MainUiFormat();
            LoadToDGV();
        }


        //Transfer Restaurant 

        private void recieveTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (ManualROKitchen.Text.Equals(""))
            {
                MessageBox.Show("R.O# Can't Be Empty");
                return;
            }
            DataTable dt = ItemKitchenTransferDGV.DataContext as DataTable;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString);

            try
            {
                con.Open();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Received"].ToString() == "False")
                        break;
                    float netCost = float.Parse(dt.Rows[i][FromKitchenKitchentxt.Text + " Qty"].ToString()) * float.Parse(dt.Rows[i][FromKitchenKitchentxt.Text + " Unit Cost"].ToString());
                    string s = "insert RO_Items (Item_ID,RO_No,Qty,Unit,Price_Without_Tax,Tax,Price_With_Tax,Net_Price,QtyOnHand_To,Cost_To,QtyOnHand_From,Cost_From) values ('" + dt.Rows[i]["ItemID"].ToString() + "','" + RoTransferKitchen.Text + "'," + dt.Rows[i]["Qty"] + ",'" + " " + "'," + dt.Rows[i][FromKitchenKitchentxt.Text + " Unit Cost"] + ",0 ," + dt.Rows[i][FromKitchenKitchentxt.Text + " Unit Cost"] + "," + netCost + "," + dt.Rows[i][ToKitchenKitchentxt.Text + " Unit Cost"] + "," + dt.Rows[i][ToKitchenKitchentxt.Text + " Qty"] + "," + dt.Rows[i][FromKitchenKitchentxt.Text + " Qty"] + "," + dt.Rows[i][FromKitchenKitchentxt.Text + " Unit Cost"] + ")";
                    SqlCommand _CMD = new SqlCommand(s, con);
                    _CMD.ExecuteNonQuery();


                    s = string.Format("Update Items set Qty= {1},Net_Cost={4} where ItemID = '{0}' and RestaurantID =(select Code From Store_Setup where Name='{2}') and KitchenID=(Select Code from Kitchens_Setup Where Name='{3}')", dt.Rows[i]["ItemID"], dt.Rows[i][FromKitchenKitchentxt.Text + " Qty"], FromResturanKitchenttxt.Text, FromKitchenKitchentxt.Text, dt.Rows[i][FromKitchenKitchentxt.Text + " total Cost"]);
                    SqlCommand _cmd = new SqlCommand(s, con);
                    _cmd.ExecuteNonQuery();

                    s = string.Format("Update Items set Qty= {1},Last_Cost = Current_Cost,Current_Cost = '{4}',Net_Cost='{5}' where ItemID = '{0}' and RestaurantID =(select Code From Store_Setup Where Name='{2}') and KitchenID=(select Code From Kitchens_Setup Where Name='{3}')", dt.Rows[i]["ItemID"], dt.Rows[i][ToKitchenKitchentxt.Text + " Qty"], ToResturantKitchentxt.Text, ToKitchenKitchentxt.Text, dt.Rows[i][ToKitchenKitchentxt.Text + " Unit Cost"], dt.Rows[i][ToKitchenKitchentxt.Text + " total Cost"]);
                    _cmd = new SqlCommand(s, con);
                    int n = _cmd.ExecuteNonQuery();

                    if (n == 0)
                    {
                        s = string.Format("insert into Items(RestaurantID,KitchenID,ItemID,Qty,Units,Last_Cost,Current_Cost,Net_Cost) Values ((select Code From Store_Setup WHere Name='{0}'),(	select Code From Kitchens_Setup WHere Name='{1}'),'{2}','{3}','{4}','{5}','{6}','{7}')", ToResturantKitchentxt.Text, ToKitchenKitchentxt.Text, dt.Rows[i]["ItemID"], dt.Rows[i]["Qty"], "", dt.Rows[i][ToKitchenKitchentxt.Text + " Unit Cost"], dt.Rows[i][ToKitchenKitchentxt.Text + " Unit Cost"], dt.Rows[i][ToKitchenKitchentxt.Text + " total Cost"]);
                        _cmd = new SqlCommand(s, con);
                        _cmd.ExecuteNonQuery();
                    }

                }

                SqlCommand cmd = new SqlCommand(string.Format("Insert into RO(RO_Serial,RO_No,Transactions_No,Status,Create_Date,Receiving_Date,Resturant_ID,Kitchen_ID,WS,Type,Comment,UserID)Values ('{0}','{1}','{2}','{3}',GETDATE(),'{4}',(select Code From Store_Setup WHere Name='{5}'),(select Code From Kitchens_Setup WHere Name='{6}'),'{7}','{8}','{9}','{10}')", RoTransferKitchen.Text, ManualROKitchen.Text, TransferResturantID, "Recieved", DeliveryROKitchen.Text +" "+ DeliveryROKitchenTime.Text, ToResturantKitchentxt.Text, ToKitchenKitchentxt.Text, Classes.WS, "Transfer_Resturant", commenttxt.Text,MainWindow.UserID), con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            finally
            {
                MessageBox.Show("Order Recived saved Succesful");
                con.Close();
            }
            ClearFields();
            MainUiFormat();
        }
        private void SearchKitchen_Click(object sender, RoutedEventArgs e)
        {
            IncrementPoNo();
            All_Purchase_Orders all_Purchase_Orders = new All_Purchase_Orders(this);
            all_Purchase_Orders.ShowDialog();
        }

        private void Recieve_Restaurant_Transfer_Change(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.Column.Header == "Qty")
            {
                DataTable Dat = ItemKitchenTransferDGV.DataContext as DataTable;
                for (int i = 0; i < Dat.Columns.Count; i++)
                {
                    Dat.Columns[i].ReadOnly = false;
                }
                SqlConnection con = new SqlConnection(Classes.DataConnString);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string ItemCode = (e.Row.Item as DataRowView).Row["ItemID"].ToString();
                //string Qty = (e.EditingElement as TextBox).Text;

                try
                {
                    using (cmd = new SqlCommand(string.Format("select Qty,Current_Cost from Items where ItemID = '{0}' and RestaurantID = (select Code from Store_Setup where Name = '{1}') and KitchenID = (select Code from Kitchens_Setup where Name = '{2}') union all select Qty, Current_Cost from Items where ItemID = '{0}' and RestaurantID = (select Code from Store_Setup where Name = '{4}') and KitchenID = (select Code from Kitchens_Setup where Name = '{3}')", ItemCode, FromResturanKitchenttxt.Text, FromKitchenKitchentxt.Text, ToKitchenKitchentxt.Text, ToResturantKitchentxt.Text), con))
                    {
                        try
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            float from_rest_Qty = 0; float from_rest_Cost = 0;
                            try
                            {
                                from_rest_Qty = float.Parse(reader["Qty"].ToString());
                                from_rest_Cost = float.Parse(reader["Current_Cost"].ToString());
                            }
                            catch
                            {

                                from_rest_Qty = 0;
                                from_rest_Cost = 0;
                            }

                            reader.Read();
                            float to_rest_Qty = 0; float to_rest_Cost = 0;
                            try
                            {
                                to_rest_Qty = float.Parse(reader["Qty"].ToString());
                                to_rest_Cost = float.Parse(reader["Current_Cost"].ToString());
                            }
                            catch
                            {
                                to_rest_Qty = 0;
                                to_rest_Cost = 0;
                            }

                            Dat.Rows[e.Row.GetIndex()]["Qty"] = (float.Parse((e.EditingElement as TextBox).Text)).ToString();
                            Dat.Rows[e.Row.GetIndex()][FromKitchenKitchentxt.Text + " Qty"] = (from_rest_Qty - float.Parse((e.EditingElement as TextBox).Text)).ToString();
                            Dat.Rows[e.Row.GetIndex()][FromKitchenKitchentxt.Text + " Unit Cost"] = from_rest_Cost.ToString();
                            Dat.Rows[e.Row.GetIndex()][FromKitchenKitchentxt.Text + " Total Cost"] = (from_rest_Cost * (from_rest_Qty - float.Parse((e.EditingElement as TextBox).Text))).ToString();

                            Dat.Rows[e.Row.GetIndex()][ToKitchenKitchentxt.Text + " Qty"] = (to_rest_Qty + float.Parse((e.EditingElement as TextBox).Text)).ToString();
                            Dat.Rows[e.Row.GetIndex()][ToKitchenKitchentxt.Text + " Unit Cost"] = (((to_rest_Cost * to_rest_Qty) + (float.Parse((e.EditingElement as TextBox).Text) * from_rest_Cost)) / (to_rest_Qty + (float.Parse((e.EditingElement as TextBox).Text)))).ToString();
                            Dat.Rows[e.Row.GetIndex()][ToKitchenKitchentxt.Text + " Total Cost"] = (((to_rest_Cost * to_rest_Qty) + (float.Parse((e.EditingElement as TextBox).Text) * from_rest_Cost)) / (to_rest_Qty + (float.Parse((e.EditingElement as TextBox).Text))) * (to_rest_Qty + float.Parse((e.EditingElement as TextBox).Text))).ToString();
                        }
                        catch { }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    (e.EditingElement as TextBox).Text = "";
                }
                finally { con.Close(); }

                try
                {

                    double totalPrice = 0;
                    for (int i = 0; i < ItemKitchenTransferDGV.Items.Count; i++)
                    {
                        try
                        {
                            totalPrice += Convert.ToDouble(((DataRowView)ItemKitchenTransferDGV.Items[i]).Row.ItemArray[10]);
                        }
                        catch
                        {

                        }
                    }
                    NumberOfItemsInter.Text = (ItemKitchenTransferDGV.Items.Count).ToString();
                    Total_Price_With_Tax_InterKitchen.Text = (totalPrice).ToString();
                }
                catch { }
                for (int i = 0; i < Dat.Columns.Count; i++)
                {
                    Dat.Columns[i].ReadOnly = true;
                }
                Dat.Columns["Received"].ReadOnly = false;
                Dat.Columns["Qty"].ReadOnly = false;
                ItemKitchenTransferDGV.DataContext = null;
                ItemKitchenTransferDGV.DataContext = Dat;
            }

            
        }


        //Transfer Kitchen

        private void Recieve_Kitchen_Transfer_Change(object sender, DataGridCellEditEndingEventArgs e)
        {
            if(e.Column.Header=="Qty")
            {
                DataTable Dat = ItemRoInterDGV.DataContext as DataTable;
                for (int i = 0; i < Dat.Columns.Count; i++)
                {
                    Dat.Columns[i].ReadOnly = false;
                }
                SqlConnection con = new SqlConnection(Classes.DataConnString);
                con.Open();
                string ItemCode = (e.Row.Item as DataRowView).Row["ItemID"].ToString();
                try
                {
                    using (SqlCommand cmd = new SqlCommand(string.Format("select Qty,Current_Cost from Items where ItemID = '{0}' and RestaurantID = (select Code from Store_Setup where Name = '{1}') and KitchenID = (select Code from Kitchens_Setup where Name = '{2}') union all select Qty, Current_Cost from Items where ItemID = '{0}' and RestaurantID = (select Code from Store_Setup where Name = '{1}') and KitchenID = (select Code from Kitchens_Setup where Name = '{3}')", ItemCode, FromResturantIntertxt.Text, FromKitchenIntertxt.Text, ToKitchenIntertxt.Text), con))
                    {
                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();
                        float from_rest_Qty = 0; float from_rest_Cost = 0;
                        try
                        {
                            from_rest_Qty = float.Parse(reader["Qty"].ToString());
                            from_rest_Cost = float.Parse(reader["Current_Cost"].ToString());
                        }
                        catch
                        {

                            from_rest_Qty = 0;
                            from_rest_Cost = 0;
                        }

                        reader.Read();
                        float to_rest_Qty = 0; float to_rest_Cost = 0;
                        try
                        {
                            to_rest_Qty = float.Parse(reader["Qty"].ToString());
                            to_rest_Cost = float.Parse(reader["Current_Cost"].ToString());
                        }
                        catch
                        {
                            to_rest_Qty = 0;
                            to_rest_Cost = 0;
                        }

                        Dat.Rows[e.Row.GetIndex()]["Qty"] = (float.Parse((e.EditingElement as TextBox).Text)).ToString();
                        Dat.Rows[e.Row.GetIndex()][FromKitchenIntertxt.Text + " Qty"] = (from_rest_Qty - float.Parse((e.EditingElement as TextBox).Text)).ToString();
                        Dat.Rows[e.Row.GetIndex()][FromKitchenIntertxt.Text + " Unit Cost"] = from_rest_Cost.ToString();
                        Dat.Rows[e.Row.GetIndex()][FromKitchenIntertxt.Text + " Total Cost"] = (from_rest_Cost * (from_rest_Qty - float.Parse((e.EditingElement as TextBox).Text))).ToString();
                        Dat.Rows[e.Row.GetIndex()][ToKitchenIntertxt.Text + " Qty"] = (to_rest_Qty + float.Parse((e.EditingElement as TextBox).Text)).ToString();
                        Dat.Rows[e.Row.GetIndex()][ToKitchenIntertxt.Text + " Unit Cost"] = (((to_rest_Cost * to_rest_Qty) + (float.Parse((e.EditingElement as TextBox).Text) * from_rest_Cost)) / (to_rest_Qty + (float.Parse((e.EditingElement as TextBox).Text)))).ToString();
                        Dat.Rows[e.Row.GetIndex()][ToKitchenIntertxt.Text + " Total Cost"] = (((to_rest_Cost * to_rest_Qty) + (float.Parse((e.EditingElement as TextBox).Text) * from_rest_Cost)) / (to_rest_Qty + (float.Parse((e.EditingElement as TextBox).Text))) * (to_rest_Qty + float.Parse((e.EditingElement as TextBox).Text))).ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    (e.EditingElement as TextBox).Text = "";
                }
                finally { con.Close(); }

                try
                {

                    double totalPrice = 0;
                    for (int i = 0; i < ItemRoInterDGV.Items.Count; i++)
                    {
                        try
                        {
                            totalPrice += Convert.ToDouble(((DataRowView)ItemRoInterDGV.Items[i]).Row.ItemArray[10]);
                        }
                        catch
                        {

                        }
                    }
                    NumberOfItemsInter.Text = (ItemRoInterDGV.Items.Count).ToString();
                    Total_Price_With_Tax_InterKitchen.Text = (totalPrice).ToString();
                }
                catch { }
                for (int i = 0; i < Dat.Columns.Count; i++)
                {
                    Dat.Columns[i].ReadOnly = true;
                }
                Dat.Columns["Qty"].ReadOnly = false;
                Dat.Columns["Received"].ReadOnly = false;
            }
            
        }
        private void recieveInterTransfer_Click(object sender, RoutedEventArgs e)
        {
            if (ManualROInter.Text.Equals(""))
            {
                MessageBox.Show("R.O# Can't Be Empty");
                return;
            }
            DataTable dt = ItemRoInterDGV.DataContext as DataTable;
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString);

            try
            {
                con.Open();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Received"].ToString() == "False")
                        break;

                    float netCost = float.Parse(dt.Rows[i][FromKitchenIntertxt.Text + " Qty"].ToString()) * float.Parse(dt.Rows[i][FromKitchenIntertxt.Text + " Unit Cost"].ToString());
                    string s = "insert RO_Items (Item_ID,RO_No,Qty,Unit,Price_Without_Tax,Tax,Price_With_Tax,Net_Price,QtyOnHand_To,Cost_To,QtyOnHand_From,Cost_From) values ('" + dt.Rows[i]["ItemID"].ToString() + "','" + RoInter.Text + "'," + dt.Rows[i]["Qty"] + ",'" + " " + "'," + dt.Rows[i][FromKitchenIntertxt.Text + " Unit Cost"] + ",0 ," + dt.Rows[i][FromKitchenIntertxt.Text + " Unit Cost"] + "," + netCost + "," + dt.Rows[i][ToKitchenIntertxt.Text + " Unit Cost"] + "," + dt.Rows[i][ToKitchenIntertxt.Text + " Qty"] + "," + dt.Rows[i][FromKitchenIntertxt.Text + " Qty"] + "," + dt.Rows[i][FromKitchenIntertxt.Text + " Unit Cost"] + ")";
                    SqlCommand _CMD = new SqlCommand(s, con);
                    _CMD.ExecuteNonQuery();


                    s = string.Format("Update Items set Qty= {1},Net_Cost={4} where ItemID = '{0}' and RestaurantID =(select Code From Store_Setup where Name='{2}') and KitchenID=(Select Code from Kitchens_Setup Where Name='{3}')", dt.Rows[i]["ItemID"], dt.Rows[i][FromKitchenIntertxt.Text + " Qty"], FromResturantIntertxt.Text, FromKitchenIntertxt.Text, dt.Rows[i][FromKitchenIntertxt.Text + " total Cost"]);
                    SqlCommand _cmd = new SqlCommand(s, con);
                    _cmd.ExecuteNonQuery();

                    s = string.Format("Update Items set Qty= {1},Last_Cost = Current_Cost,Current_Cost = '{4}',Net_Cost='{5}' where ItemID = '{0}' and RestaurantID =(select Code From Store_Setup Where Name='{2}') and KitchenID=(select Code From Kitchens_Setup Where Name='{3}')", dt.Rows[i]["ItemID"], dt.Rows[i][ToKitchenIntertxt.Text + " Qty"], FromResturantIntertxt.Text, ToKitchenIntertxt.Text, dt.Rows[i][ToKitchenIntertxt.Text + " Unit Cost"], dt.Rows[i][ToKitchenIntertxt.Text + " total Cost"]);
                    _cmd = new SqlCommand(s, con);
                    int n = _cmd.ExecuteNonQuery();

                    if (n == 0)
                    {
                        s = string.Format("insert into Items(RestaurantID,KitchenID,ItemID,Qty,Units,Last_Cost,Current_Cost,Net_Cost) Values ((select Code From Store_Setup WHere Name='{0}'),(	select Code From Kitchens_Setup WHere Name='{1}'),'{2}','{3}','{4}','{5}','{6}','{7}')", FromResturantIntertxt.Text, ToKitchenIntertxt.Text, dt.Rows[i]["ItemID"], dt.Rows[i]["Qty"], "", dt.Rows[i][ToKitchenIntertxt.Text + " Unit Cost"], dt.Rows[i][ToKitchenIntertxt.Text + " Unit Cost"], dt.Rows[i][ToKitchenIntertxt.Text + " total Cost"]);
                        _cmd = new SqlCommand(s, con);
                        _cmd.ExecuteNonQuery();
                    }

                }

                SqlCommand cmd = new SqlCommand(string.Format("Insert into RO(RO_Serial,RO_No,Transactions_No,Status,Create_Date,Receiving_Date,Resturant_ID,Kitchen_ID,WS,Type,Comment,UserID)Values ('{0}','{1}','{2}','{3}',GETDATE(),'{4}',(select Code From Store_Setup WHere Name='{5}'),(select Code From Kitchens_Setup WHere Name='{6}'),'{7}','{8}','{9}','{10}')", RoInter.Text, ManualROInter.Text, TransferKitchenID, "Recieved", DeliveryROInter.Text+" "+ DeliveryROInterTime.Text, FromResturantIntertxt.Text, ToKitchenIntertxt.Text, Classes.WS, "Transfer_Kitchen", CommentRoInter.Text,MainWindow.UserID), con);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }

            finally
            {
                MessageBox.Show("Order Recived saved Succesful");
                con.Close();
            }

            ClearFields();
            MainUiFormat();
        }
        private void SearchVoucharBn(object sender, RoutedEventArgs e)
        {
            IncrementPoNo();
            All_Purchase_Orders items = new All_Purchase_Orders(this);
            items.ShowDialog();
        }



        //Transfer Without Purshace 
        private void ItemDgv_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(Classes.DataConnString);

                if (e.Column.Header.ToString() == "Price")
                {
                    CalculatePrices(e);
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
                                (e.Row.Item as DataRowView).Row["Tax"] = tax + "%";
                            }
                        }
                        catch { }
                        finally { con.Close(); }
                    }
                    else
                    {
                        (e.Row.Item as DataRowView).Row["Tax"] = "0%";
                    }
                    CalculatePrices(e);
                }
                else if (e.Column.Header.ToString() == "Qty")
                {
                    //CalculateQty3(e);
                    CalculatePrices(e);
                }
                else if (e.Column.Header.ToString() == "Qty_Unit3")
                {
                    //CalculateQty(e);
                    CalculatePrices(e);

                }
            }
            catch { }
        }
        private void RecievedWithoutBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DoSomeChecks() == false)
                return;

            string QTyonHand = ""; string CostOfItemsOnHand = ""; string QtyOnHandMultipleCost = "";
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlConnection con2 = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();

                string s = string.Format("select * from RO where RO_Serial = {0}", codeWithouttxt.Text);
                SqlCommand cmd = new SqlCommand(s, con);
                int record_no = cmd.ExecuteNonQuery();
                if (record_no > 0)
                {
                    MessageBox.Show("Another Work station save at the saame time");
                    codeWithouttxt.Text = (int.Parse(codeWithouttxt.Text) + 1).ToString();
                }

                DataTable dt = ItemsWithoutDGV.DataContext as DataTable;
                cmd = new SqlCommand();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    con2.Open();
                    s = string.Format("select Qty,Current_Cost From Items where RestaurantID={1} and KitchenID={2} and ItemID={0}", dt.Rows[i]["Code"].ToString(), RestaurantId, KitchenId);
                    SqlCommand _CMD = new SqlCommand(s, con2);
                    SqlDataReader _reader = _CMD.ExecuteReader();
                    while (_reader.Read())
                    {
                        QTyonHand = (Convert.ToDouble(_reader["Qty"].ToString())).ToString();
                        CostOfItemsOnHand = _reader["Current_Cost"].ToString();
                    }
                    con2.Close();
                    try
                    {
                        QtyOnHandMultipleCost = (Convert.ToDouble(QTyonHand) * Convert.ToDouble(CostOfItemsOnHand)).ToString();
                        QTyonHand = (Convert.ToDouble(QTyonHand) + Convert.ToDouble(dt.Rows[i]["Qty"].ToString())).ToString();
                        CostOfItemsOnHand = ((Convert.ToDouble(QtyOnHandMultipleCost) + (Convert.ToDouble(dt.Rows[i]["Qty"].ToString()) * Convert.ToDouble(dt.Rows[i]["Unit Price With Tax"]))) / Convert.ToDouble(QTyonHand)).ToString();
                    }
                    catch { }
                    _reader.Close();

                    s = "insert into RO_Items (Item_ID,RO_No,Qty,Unit,Price_Without_Tax,Tax,Price_With_Tax,Net_Price,QtyOnHand_To,Cost_To) values ('" + dt.Rows[i]["Code"].ToString() + "','" + codetxt.Text + "'," + dt.Rows[i]["Qty"] + ",'" + " " + "'," + dt.Rows[i]["Unit Price Without Tax"] + "," + dt.Rows[i]["Tax"].ToString().Substring(0, dt.Rows[i]["Tax"].ToString().Length - 1) + "," + dt.Rows[i]["Unit Price With Tax"] + "," + dt.Rows[i]["Total Price With Tax"] + ",'" + QTyonHand + "','" + CostOfItemsOnHand + "')";
                    _CMD = new SqlCommand(s, con);
                    //reader.Close();
                    _CMD.ExecuteNonQuery();


                    s = string.Format("Update Items set Qty = Qty + {1},Last_Cost = Current_Cost,Current_Cost = ((Current_Cost * Qty)+({1} * {3}))/(Qty+{1}),Units = '{4}',Net_Cost=(((Current_Cost * Qty)+({1} * {3}))/(Qty+{1})*({1}+Qty)) where ItemID = '{0}' and RestaurantID ='{2}' and KitchenID ='{5}'", dt.Rows[i]["Code"], dt.Rows[i]["Qty"], RestaurantId, dt.Rows[i]["Unit Price With Tax"], " ", KitchenId);
                    SqlCommand _cmd = new SqlCommand(s, con);
                    int n = _cmd.ExecuteNonQuery();

                    if (n == 0)
                    {
                        s = string.Format("insert into Items(RestaurantID,KitchenID,ItemID,Qty,Units,Last_Cost,Current_Cost,Net_Cost) Values ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", RestaurantId, KitchenId, dt.Rows[i]["Code"], dt.Rows[i]["Qty"], " ", dt.Rows[i]["Unit Price With Tax"], dt.Rows[i]["Unit Price With Tax"], dt.Rows[i]["Total Price With Tax"]);
                        _cmd = new SqlCommand(s, con);
                        _cmd.ExecuteNonQuery();
                    }
                }


                cmd = new SqlCommand(string.Format("Insert into RO(RO_Serial,RO_No,Transactions_No,Status,Create_Date,Receiving_Date,Resturant_ID,Kitchen_ID,WS,Type,Comment,UserID)Values ('{0}','{1}','{2}','{3}',GETDATE(),'{4}','{5}','{6}','{7}','{8}','{9}','{10}')", codetxt.Text, Manual_Recieve_No.Text, PO.Text, "Recieved", Delivery_dt.Text, RestaurantId, KitchenId, Classes.WS, "Auto_Recieve", commenttxt.Text, MainWindow.UserID), con);
                cmd.ExecuteNonQuery();

                MainUiFormat();
                MessageBox.Show("Order Recived Succesfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                con.Close();
            }
            ClearFields();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Items itemswindow = new Items(this);
            itemswindow.ShowDialog();
        }
        private void DeleteItemBtn_Click(object sender, RoutedEventArgs e)
        {
            DataTable dt = ItemsWithoutDGV.DataContext as DataTable;
            dt.Rows.RemoveAt(ItemsWithoutDGV.SelectedIndex);
            ItemsWithoutDGV.DataContext = dt;
        }
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            EnableUI();
            ClearFields();
            IncrementPoNo();
            Manual_Recieve_No.IsEnabled = true;
        }
        private void NewWithoutBn_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            IncrementPoNo();
            LoadTheResturant();
            EnableUI();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainUiFormat();
            ClearFields();
        }

        private void ItemsWithoutDGV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            {
                IndexOfRecord = grid.SelectedIndex;
            }
        }

        private void ResturantCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString);
            //KitchenCbx.Text = "";
            KitchenCbx.Items.Clear();
            string b = "";
            if (ResturantCbx.SelectedItem != null)
            {
                string v = ResturantCbx.SelectedItem.ToString();
                try
                {
                    con.Open();
                    string s = "select Code from Store_Setup WHERE Name='" + v + "'";
                    SqlCommand cmd = new SqlCommand(s, con);
                    RestaurantId = cmd.ExecuteScalar().ToString();
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
                    string s = "select Name from Kitchens_Setup WHERE RestaurantID=" + RestaurantId ;
                    SqlCommand cmd = new SqlCommand(s, con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var data = reader["Name"].ToString();
                        KitchenCbx.Items.Add(data);
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

        private void KitchenCbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString);
            try
            {
                con.Open();
                string s = "select Code from Kitchens_Setup WHERE Name='" + KitchenCbx.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                KitchenId = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
        }


        //requested Tab 

        private void LoadAllRequests()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Transfer Serial");
            dt.Columns.Add("Manul Transfer Number");
            dt.Columns.Add("Transfer Date");
            dt.Columns.Add("To Resturant");
            dt.Columns.Add("To Kitchen");
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = string.Format("SELECT Transfer_Serial,Manual_Transfer_No,Transfer_Date,(select Name From Store_Setup where Code=To_Resturant_ID) as 'TO Resturant',(select Name From Kitchens_Setup where Code=To_Kitchen_ID  and RestaurantID=To_Resturant_ID) as 'TO Kitchen' FROM Transfer_Kitchens where From_Resturant_ID={0} and From_Kitchen_ID={1} and Status='Post' and Transfer_Serial not in (select Request_serial from Requests_tbl where Status='Post')", RestaurantId, KitchenId);
                SqlCommand cmd = new SqlCommand(s, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dt.Rows.Add(reader["Transfer_Serial"], reader["Manual_Transfer_No"], reader["Transfer_Date"], reader["TO Resturant"], reader["TO Kitchen"]);
                }
                RequestssDGV.DataContext = dt;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            finally
            {
                con.Close();
            }
        }
        private void ResturantReqcbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            KitchenReqcbx.Items.Clear();
            string b = "";
            if (ResturantReqcbx.SelectedItem != null)
            {
                string v = ResturantReqcbx.SelectedItem.ToString();
                try
                {
                    con.Open();
                    string s = "select Code from Store_Setup WHERE Name='" + v + "'";
                    SqlCommand cmd = new SqlCommand(s, con);
                    RestaurantId = cmd.ExecuteScalar().ToString();
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
                    string s = "select Name from Kitchens_Setup WHERE RestaurantID=" + RestaurantId;
                    SqlCommand cmd = new SqlCommand(s, con);
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var data = reader["Name"].ToString();
                        KitchenReqcbx.Items.Add(data);
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
        private void KitchenReqcbx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = "select Code from Kitchens_Setup WHERE Name='" + KitchenReqcbx.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                KitchenId = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex) { }
            finally
            {
                con.Close();
            }
            RequestChose.Visibility = Visibility.Hidden;
            RequestInfo.Visibility = Visibility.Visible;
            LoadAllRequests();
            SearchReq.Visibility = Visibility.Visible;
        }
        private void RequestssDGV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SqlConnection con2 = new SqlConnection(Classes.DataConnString);
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            float from_rest_Qty = 0; float from_rest_Cost = 0; float to_rest_Qty = 0; float to_rest_Cost = 0;
            DataTable dt = new DataTable();
            recieveTransfer.IsEnabled = true;
            ManualROKitchen.IsEnabled = true;
            DeliveryROKitchen.IsEnabled = true;
            CommentKitchen.IsEnabled = true;

            DataTable Dat = new DataTable();
            try
            {
                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(string.Format("select Transfer_Serial,Manual_Transfer_No,Comment,(select Name From Store_Setup where Code=From_Resturant_ID) as From_Resturat,(select Name From Store_Setup where Code = To_Resturant_ID) as To_Resturat, (select Name from Kitchens_Setup where Code = From_Kitchen_ID and RestaurantID = From_Resturant_ID) as From_Kitchen,(select Name from Kitchens_Setup where Code = To_Kitchen_ID  and RestaurantID = To_Resturant_ID) as To_Kitchen,Type from Transfer_Kitchens Where Transfer_Serial='{0}'", ((DataRowView)RequestssDGV.SelectedItem).Row.ItemArray[0]), con);
                dt = new DataTable();
                adapter.Fill(dt);

                DataRow row = dt.Rows[0];
                Serial_Request_NO.Text = row["Transfer_Serial"].ToString();
                Request_NO.Text = row["Manual_Transfer_No"].ToString();
                TypeCbx.Text = row["Type"].ToString();
                RequestCommenttxt.Text = row["Comment"].ToString();
                TOResturantReq.Text = row["To_Resturat"].ToString();
                TOKitchenReq.Text = row["To_Kitchen"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            toKItchenAndResturant.Visibility = Visibility.Visible;
            NUmberOfItemsReq.Visibility = Visibility.Visible;
            NumberOfItemTextReq.Visibility = Visibility.Visible;
            Total_PriceReq.Visibility = Visibility.Visible;
            TotalofItemsReq.Visibility = Visibility.Visible;
            Reply.Visibility = Visibility.Visible;
            Reply.IsEnabled = true;


            Dat.Columns.Add("Received", typeof(bool));
            Dat.Columns.Add("Code");
            Dat.Columns.Add("Manual Code");
            Dat.Columns.Add("Name");
            Dat.Columns.Add("Name2");
            Dat.Columns.Add("Qty");
            Dat.Columns.Add(KitchenReqcbx.Text + " Qty");
            Dat.Columns.Add(KitchenReqcbx.Text + " Unit Cost");
            Dat.Columns.Add(KitchenReqcbx.Text + " total Cost");
            Dat.Columns.Add(TOKitchenReq.Text + " Qty");
            Dat.Columns.Add(TOKitchenReq.Text + " Unit Cost");
            Dat.Columns.Add(TOKitchenReq.Text + " total Cost");
            try
            {
                con.Open();
                string M = "SELECT Item_ID,Qty,Cost FROM Transfer_Kitchens_Items where Transfer_ID=" + Serial_Request_NO.Text;
                SqlCommand cmd = new SqlCommand(M, con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        con2.Open();
                        using (SqlCommand cmd2 = new SqlCommand(string.Format("select Qty,Current_Cost from Items where ItemID = '{0}' and RestaurantID = (select Code from Store_Setup where Name = '{1}') and KitchenID = (select Code from Kitchens_Setup where Name = '{2}') union all select Qty, Current_Cost from Items where ItemID = '{0}' and RestaurantID = (select Code from Store_Setup where Name = '{3}') and KitchenID = (select Code from Kitchens_Setup where Name = '{4}')", reader["Item_ID"], ResturantReqcbx.Text, KitchenReqcbx.Text, TOResturantReq.Text, TOKitchenReq.Text), con2))
                        {
                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            reader2.Read();
                            try
                            {
                                from_rest_Qty = (float.Parse(reader2["Qty"].ToString()) - float.Parse(reader["Qty"].ToString()));
                                from_rest_Cost = float.Parse(reader2["Current_Cost"].ToString());

                                reader2.Read();
                                to_rest_Qty = (float.Parse(reader2["Qty"].ToString()) + float.Parse(reader["Qty"].ToString()));
                                to_rest_Cost = (((float.Parse(reader["Qty"].ToString()) * float.Parse(reader["Cost"].ToString())) + (float.Parse(reader2["Qty"].ToString()) * float.Parse(reader2["Current_Cost"].ToString()))) / to_rest_Qty);
                            }
                            catch { }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    finally { con2.Close(); }
                    //
                    double NetCostFrom = from_rest_Qty * from_rest_Cost;
                    double NetCostTo = to_rest_Qty * to_rest_Cost;
                    try
                    {
                        con2.Open();
                        string S = "SELECT [Manual Code],Name,Name2 FROM Setup_Items where Code='" + reader["Item_ID"].ToString() + "'";
                        SqlCommand cmd2 = new SqlCommand(S, con2);
                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            Dat.Rows.Add(false, reader["Item_ID"], reader2["Manual Code"], reader2["Name"], reader2["Name2"], reader["Qty"], from_rest_Qty, from_rest_Cost, NetCostFrom, to_rest_Qty, to_rest_Cost, NetCostTo);
                        }

                        reader2.Close();
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

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            Dat.Columns["Received"].ReadOnly = false;
            Dat.Columns["Qty"].ReadOnly = false;
            RequestsItemsDGV.DataContext = Dat;
            float Total_Price = 0;
            for (int i = 0; i < RequestsItemsDGV.Items.Count; i++)
            {
                Total_Price += float.Parse(Dat.Rows[i][TOKitchenReq.Text + " total Cost"].ToString());
            }
            NUmberOfItemsReq.Text = RequestsItemsDGV.Items.Count.ToString();
            Total_PriceReq.Text = Total_Price.ToString();
            RequestssDGV.Visibility = Visibility.Hidden;
            RequestsItemsDGV.Visibility = Visibility.Visible;
        }

        private void RequestsItemsDGV_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            float from_rest_Qty = 0; float from_rest_Cost = 0; float to_rest_Qty = 0; float to_rest_Cost = 0;
            if (e.Column.Header.ToString() != "Received")
            {
                SqlConnection con = new SqlConnection(Classes.DataConnString);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                string ItemCode = (e.Row.Item as DataRowView).Row["Code"].ToString();
                //string Qty = (e.EditingElement as TextBox).Text;

                try
                {
                    using (cmd = new SqlCommand(string.Format("select Qty,Current_Cost from Items where ItemID = '{0}' and RestaurantID = (select Code from Store_Setup where Name = '{1}') and KitchenID = (select Code from Kitchens_Setup where Name = '{2}') union all select Qty, Current_Cost from Items where ItemID = '{0}' and RestaurantID = (select Code from Store_Setup where Name = '{4}') and KitchenID = (select Code from Kitchens_Setup where Name = '{3}')", ItemCode, ResturantReqcbx.Text, KitchenReqcbx.Text, TOKitchenReq.Text, TOResturantReq.Text), con))
                    {
                        try
                        {
                            SqlDataReader reader = cmd.ExecuteReader();
                            try
                            {
                                reader.Read();
                                from_rest_Qty = float.Parse(reader["Qty"].ToString());
                                from_rest_Cost = float.Parse(reader["Current_Cost"].ToString());

                                reader.Read();
                                to_rest_Qty = float.Parse(reader["Qty"].ToString());
                                to_rest_Cost = float.Parse(reader["Current_Cost"].ToString());
                            }
                            catch { }
                            (e.Row.Item as DataRowView).Row[KitchenReqcbx.Text + " Qty"] = (from_rest_Qty - float.Parse((e.EditingElement as TextBox).Text)).ToString();
                            (e.Row.Item as DataRowView).Row[KitchenReqcbx.Text + " Unit Cost"] = from_rest_Cost.ToString();
                            (e.Row.Item as DataRowView).Row[KitchenReqcbx.Text + " Total Cost"] = (from_rest_Cost * (from_rest_Qty - float.Parse((e.EditingElement as TextBox).Text))).ToString();

                            (e.Row.Item as DataRowView).Row[TOKitchenReq.Text + " Qty"] = (to_rest_Qty + float.Parse((e.EditingElement as TextBox).Text)).ToString();
                            (e.Row.Item as DataRowView).Row[TOKitchenReq.Text + " Unit Cost"] = (((to_rest_Cost * to_rest_Qty) + (float.Parse((e.EditingElement as TextBox).Text) * from_rest_Cost)) / (to_rest_Qty + (float.Parse((e.EditingElement as TextBox).Text)))).ToString();
                            (e.Row.Item as DataRowView).Row[TOKitchenReq.Text + " Total Cost"] = (((to_rest_Cost * to_rest_Qty) + (float.Parse((e.EditingElement as TextBox).Text) * from_rest_Cost)) / (to_rest_Qty + (float.Parse((e.EditingElement as TextBox).Text))) * (to_rest_Qty + float.Parse((e.EditingElement as TextBox).Text))).ToString();
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    (e.EditingElement as TextBox).Text = "";
                }
                finally { con.Close(); }

                try
                {

                    double totalPrice = 0;
                    for (int i = 0; i < RequestsItemsDGV.Items.Count; i++)
                    {
                        try
                        {
                            totalPrice += Convert.ToDouble(((DataRowView)RequestsItemsDGV.Items[i]).Row.ItemArray[11]);
                        }
                        catch
                        {

                        }
                    }
                    NUmberOfItemsReq.Text = (RequestsItemsDGV.Items.Count).ToString();
                    Total_PriceReq.Text = (totalPrice).ToString();
                }
                catch { }
            }
        }

        private void Reply_Click(object sender, RoutedEventArgs e)
        {
            int Count = 0;
            if (Request_Date.Text == "")
            {
                MessageBox.Show("Plese Enter the Date !");
                return;
            }
            else if (Request_Time.Text ==null)
            {
                MessageBox.Show("Please Enter the Time !");
                return;
            }

            for (int i = 0; i < RequestsItemsDGV.Items.Count; i++)
            {
                if (((DataRowView)RequestsItemsDGV.Items[i]).Row.ItemArray[0].ToString() == "False")
                {
                    Count++;
                }
            }
            if (Count == RequestsItemsDGV.Items.Count)
            {
                MessageBox.Show("Please Select The Items !");
                return;
            }

            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlConnection con2 = new SqlConnection(Classes.DataConnString);
            try
            {
                con2.Open();
                string s = string.Format("select Request_Serial From Requests_tbl Where Request_Serial='{0}'", Serial_Request_NO.Text);
                SqlCommand cmd = new SqlCommand(s, con2);
                if (cmd.ExecuteScalar() == null)
                {
                    try
                    {
                        con.Open();

                        Save_Req_Items(con);
                        Save_Req(con);
                        MessageBox.Show("Transfer saved Sucssfully");
                        //MainGrid.IsEnabled = false;
                        //TransferBtn.IsEnabled = false;
                        //NewBtn.IsEnabled = true;
                    }
                    catch { }
                    finally
                    {
                        con.Close();
                    }
                }
                else
                {

                    con.Open();
                    string W = string.Format("delete Requests_Items where Request_ID={0}", Serial_Request_NO.Text);
                    SqlCommand cmd2 = new SqlCommand(W, con);
                    cmd2.ExecuteNonQuery();
                    Save_Req_Items(con);
                    Edit_Req(con);
                    MessageBox.Show("Transfer Edited Sussesfully");
                }
            }
            catch { }
        }
        private void Edit_Req(SqlConnection con)
        {
            try
            {
                string FiledSelection = "Request_Date,Comment,Status";
                string Values = string.Format("'{0}','{1}','{2}'", Request_Date.Text+" "+ Request_Time.Text,commenttxt.Text,StatusReq.Text);
                string where = string.Format("Request_Serial={0}", Serial_Request_NO.Text);
                Classes.UpdateRow(FiledSelection, Values, where, "Requests_tbl");
                //string s = string.Format("update PO Set PO_No='{0}',Ship_To=(select Code from Store_Setup where Name = '{1}'),Vendor_ID=(select VendorID from Vendors where Name = '{2}'),Delivery_Date='{3}',Last_Modified_Date=GETDATE(),Comment='{4}',Total_Price='{5}',Status='{6}' Where PO_Serial={7}", PO_NO.Text, ShipTo.Text, Vendor.Text, Delivery_dt.Text+" "+Delivery_time.Text, commenttxt.Text, Total_Price_With_Tax.Text,Statustxt.Text ,Serial_PO_NO.Text);
                //SqlCommand cmd = new SqlCommand(s, con);
                //cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally { con.Close(); }
        }

        private void Save_Req_Items(SqlConnection con)
        {
            string To_QTyonHand = ""; string To_CostOfItemsOnHand = ""; string To_QtyOnHandMultipleCost = "";
            string From_QTyonHand = ""; string From_CostOfItemsOnHand = "";

            try
            {
                DataTable dt = RequestsItemsDGV.DataContext as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s = string.Format("select Qty,Current_Cost From Items where RestaurantID = (select code from Store_Setup where Name = '{1}') and KitchenID = (select code from Kitchens_Setup where Name = '{2}') and ItemID={0}", dt.Rows[i]["Code"].ToString(), ResturantReqcbx.Text, KitchenReqcbx.Text);
                    SqlCommand _CMD = new SqlCommand(s, con);
                    SqlDataReader _reader = _CMD.ExecuteReader();
                    while (_reader.Read())
                    {
                        From_QTyonHand = (Convert.ToDouble(_reader["Qty"].ToString())).ToString();
                        From_CostOfItemsOnHand = _reader["Current_Cost"].ToString();
                    }
                    From_QTyonHand = (Convert.ToDouble(From_QTyonHand) - Convert.ToDouble(dt.Rows[i]["Qty"].ToString())).ToString();
                    _reader.Close();
                    //
                    s = string.Format("select Qty, Current_Cost From Items where RestaurantID = (select code from Store_Setup where Name = '{1}') and KitchenID = (select code from Kitchens_Setup where Name = '{2}') and ItemID={0}", dt.Rows[i]["Code"].ToString(), TOResturantReq.Text, TOKitchenReq.Text);
                    _CMD = new SqlCommand(s, con);
                    _reader = _CMD.ExecuteReader();
                    while (_reader.Read())
                    {
                        To_QTyonHand = (Convert.ToDouble(_reader["Qty"].ToString())).ToString();
                        To_CostOfItemsOnHand = _reader["Current_Cost"].ToString();
                    }
                    To_QtyOnHandMultipleCost = (Convert.ToDouble(To_QTyonHand) * Convert.ToDouble(To_CostOfItemsOnHand)).ToString();
                    To_QTyonHand = (Convert.ToDouble(To_QTyonHand) + Convert.ToDouble(dt.Rows[i]["Qty"].ToString())).ToString();
                    To_CostOfItemsOnHand = ((Convert.ToDouble(To_QtyOnHandMultipleCost) + (Convert.ToDouble(dt.Rows[i]["Qty"].ToString()) * Convert.ToDouble(dt.Rows[i][KitchenReqcbx.Text + " Unit Cost"]))) / Convert.ToDouble(To_QTyonHand)).ToString();
                    _reader.Close();
                    //
                    

                    float NetCost = float.Parse(dt.Rows[i]["Qty"].ToString()) * float.Parse(dt.Rows[i][6].ToString());
                    s = string.Format("insert into Requests_Items values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", dt.Rows[i]["Code"], Serial_Request_NO.Text, dt.Rows[i]["Qty"], " ", i, dt.Rows[i][7], NetCost.ToString(), To_QTyonHand, To_CostOfItemsOnHand, From_QTyonHand, From_CostOfItemsOnHand);
                    SqlCommand cmd = new SqlCommand(s, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Items Input Error");
            }
        }
        private void Save_Req(SqlConnection con)
        {
            try
            {
                string s = string.Format("insert into Requests_tbl(Request_Serial,Manual_Request_No,Request_Date,Comment,From_Resturant_ID,To_Resturant_ID,From_Kitchen_ID,To_Kitchen_ID,Post_Date,Type,UserID,WS,Status) values('{0}','{1}','{2}','{3}',(select Code from Store_Setup where Name = '{4}'),(select Code from Store_Setup where Name = '{5}'),(select Code from Kitchens_Setup where Name = '{6}'),(select Code from Kitchens_Setup where Name = '{7}'),GETDATE(),'{8}','{9}','{10}','{11}')", Serial_Request_NO.Text, Request_NO.Text, Request_Date.Text + " " + Request_Time.Text, commenttxt.Text, ResturantReqcbx.Text, TOResturantReq.Text, KitchenReqcbx.Text, TOKitchenReq.Text, TypeCbx.Text, MainWindow.UserID, Classes.WS, StatusReq.Text);
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }


        //events

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!DoSomeChecks())
                return;

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString);

            try
            {
                con.Open();
                DataTable dt = ItemsDGV.DataContext as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Received"].ToString() == "False")
                        break;

                    string s = "Update RO_Items SET Qty='" + dt.Rows[i]["Qty"] +
                                               "',Unit='" + dt.Rows[i]["Units"].ToString() +
                                               "',Serial='" + dt.Rows[i]["Serial"].ToString() +
                                               "',Price='" + dt.Rows[i]["Prices"] +
                                               "',Tax_Price='" + dt.Rows[i]["Tax Prec%"] +
                                               "',Net_Price='" + dt.Rows[i]["Final Price"] +
                                               "'Where RO_Serial =" + codetxt.Text + "AND Item_ID='" + dt.Rows[i]["Code"].ToString() + "'";
                    SqlCommand _CMD = new SqlCommand(s, con);
                    int w = _CMD.ExecuteNonQuery();

                    if (w == 0)
                    {

                        s = "insert into RO_Items (Item_ID,RO_Serial,Qty,Unit,Serial,Price,Tax_Price,Net_Price) values ('" + dt.Rows[i]["Code"].ToString() + "','" + codetxt.Text + "'," + dt.Rows[i]["Qty"] + ",'" + dt.Rows[i]["Units"].ToString() + "','" + dt.Rows[i]["Serial"].ToString() + "'," + dt.Rows[i]["Prices"] + "," + dt.Rows[i]["Tax Prec%"] + "," + dt.Rows[i]["Final Price"] + ")";
                        _CMD = new SqlCommand(s, con);
                        _CMD.ExecuteNonQuery();
                    }

                    //s = string.Format("Update Stores_Items set Qty= Qty + {1} where ItemID = '{0}'", dt.Rows[i]["Code"], dt.Rows[i]["Qty"]);
                    //SqlCommand _cmd = new SqlCommand(s, con);
                    //int n = _cmd.ExecuteNonQuery();

                    //if (n == 0)
                    //{
                    //    s = string.Format("insert into Stores_Items(StoreID,ItemID,Qty) values((select Top(1) Code from Store_Setup) ,'{0}','{1}')", dt.Rows[i]["Code"], dt.Rows[i]["Qty"]);
                    //    _cmd = new SqlCommand(s, con);
                    //    _cmd.ExecuteNonQuery();
                    //}
                    ///eah da ysta ?
                    //if (i + 1 < dt.Rows.Count)
                    //    items_recieved += dt.Rows[i]["Code"].ToString() + ",";
                    //else
                    //    items_recieved += dt.Rows[i]["Code"].ToString();

                    //total_Price += float.Parse(dt.Rows[i]["Final Price"].ToString());
                }

                SqlCommand cmd = new SqlCommand(string.Format("Update RO SET RO_Number='" + Manual_Recieve_No.Text +
                                               "',PO_ID='" + PO.Text +
                                               "',Status='" + "Recieved" +
                                               "',Receiving_Date='" + Delivery_dt.Text +
                                               "',Comment='" + commenttxt.Text +
                                               "'Where RO_Serial =" + codetxt.Text), con);
                cmd.ExecuteNonQuery();


            }
            catch { }

            finally
            {
                MessageBox.Show("changes saved");
                con.Close();
            }
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
                string s = "delete from PurchaseOrder_tbl where Code = " + codetxt.Text;
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
            }
            MessageBox.Show("Deleted Successfully");
        }

        private void CopyBtn_Click(object sender, RoutedEventArgs e)
        {
            EnableUI();
            IncrementPoNo();
            Manual_Recieve_No.IsEnabled = true;
        }

        private void Row_Changed(object sender, EventArgs e)
        {
            DataRowView drv = ((e as DataGridCellEditEndingEventArgs).Row as DataGridRow).Item as DataRowView;

            //if (((e as DataGridCellEditEndingEventArgs).EditingElement as CheckBox).IsChecked == true && bool.Parse(drv.Row["Has_ExpDate"].ToString()) == true)
            //{
            //    //ItemDependencies itemDependencies = new ItemDependencies(this, drv);
            //    //itemDependencies.ShowDialog();
            //}
        }

        private void LoadTheResturant()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString);
            SqlDataReader reader = null;
            ResturantCbx.Items.Clear();
            ResturantReqcbx.Items.Clear();
            try
            {
                con.Open();
                string s = "select Name from Store_Setup";
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = reader["Name"].ToString();
                    ResturantCbx.Items.Add(data);
                    ResturantReqcbx.Items.Add(data);
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

        private void CalculatePrices(DataGridCellEditEndingEventArgs e)
        {
            commentWithouttxt.Focus();
            try
            {
                DataTable dt = ItemsWithoutDGV.DataContext as DataTable;

                float Qty;
                try
                {
                    Qty = float.Parse((e.Row.Item as DataRowView).Row["Qty"].ToString());
                }
                catch { Qty = float.Parse((e.EditingElement as TextBox).Text); }


                float Price = float.Parse((e.Row.Item as DataRowView).Row["Price"].ToString());
                float TaxPrec = float.Parse((e.Row.Item as DataRowView).Row["Tax"].ToString().Substring(0, (e.Row.Item as DataRowView).Row["Tax"].ToString().Length - 1)) / 100;

                if ((e.Row.Item as DataRowView).Row["Tax Included"].ToString() == "True")
                {
                    (e.Row.Item as DataRowView).Row["Total Price With Tax"] = (Price * Qty).ToString();
                    (e.Row.Item as DataRowView).Row["Total Price Without Tax"] = ((Price - Price * TaxPrec) * Qty).ToString();

                    if ((e.Row.Item as DataRowView).Row["Qty"].ToString() != "0")
                    {
                        (e.Row.Item as DataRowView).Row["Unit Price With Tax"] = Price.ToString();
                        (e.Row.Item as DataRowView).Row["Unit Price Without Tax"] = (Price - Price * TaxPrec).ToString();
                    }
                }
                else
                {
                    (e.Row.Item as DataRowView).Row["Total Price With Tax"] = (Price * Qty).ToString();
                    (e.Row.Item as DataRowView).Row["Total Price Without Tax"] = (Price * Qty).ToString();

                    //if ((e.Row.Item as DataRowView).Row["Qty"].ToString() != "0")
                    //{
                    (e.Row.Item as DataRowView).Row["Unit Price With Tax"] = Price.ToString();
                    (e.Row.Item as DataRowView).Row["Unit Price Without Tax"] = Price.ToString();
                    //}
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

        private void UndoResturant_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            MainUiFormat();
        }

        private void KitchenUndo_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            MainUiFormat();
        }

        private void NewKitchenBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
            MainUiFormat();
            EnableUI();
        }

        private void SearchReq_Click(object sender, RoutedEventArgs e)
        {

            All_Purchase_Orders items = new All_Purchase_Orders(this);
            items.ShowDialog();
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
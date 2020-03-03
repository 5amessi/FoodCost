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
    /// Interaction logic for Transfer_Resturant.xaml
    /// </summary>
    public partial class Transfer_Resturant : UserControl
    {
        int codeTodelete = 0;
        public static string IsRecived = "";
        List<string> Authenticated = new List<string>();

        public Transfer_Resturant()
        {
            if (MainWindow.AuthenticationData.ContainsKey("TransferResturant"))
            {
                Authenticated = MainWindow.AuthenticationData["TransferResturant"];
                if (Authenticated.Count == 0)
                {
                    MessageBox.Show("You Havent a Privilage to Open this Page");
                    LogIn logIn = new LogIn();
                    logIn.ShowDialog();
                }
                else
                {
                    InitializeComponent();
                    increment_transferNO();
                }
            }     
        }
        private bool DoSomeChecks()
        {
            if (transfer_No.Text.Equals(""))
            {
                MessageBox.Show("Transfer No. Can't Be Empty");
            }
            else if (Manual_transfer_No.Text.Equals(""))
            {
                MessageBox.Show("Manual Transfer No. Can't Be Empty");
            }
            else if (Transfer_dt.Text.Equals(""))
            {
                MessageBox.Show("Transfer Date Can't Be Empty");
            }
            //else if (Transfer_TIme.Text == null)
            //{
            //    MessageBox.Show("Transfer Time Can't Be Empty");
            //}
            else if (Statustxt.Text.Equals(""))
            {
                MessageBox.Show("Status Can't Be Empty");
            }
            else if (From_Kitchen.Text.Equals(""))
            {
                MessageBox.Show("Choose a Resturant To Transfer From");
            }
            else if (To_Kitchen.Text.Equals(""))
            {
                MessageBox.Show("Choose a Resturant To Transfer To");
            }
            else if (ItemsDGV.Items.Count == 0)
            {
                MessageBox.Show("Items can not be empty");
            }
            else
            {
                DataTable dt = ItemsDGV.DataContext as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Qty"].ToString() == "")
                    {
                        ItemsDGV.CurrentCell = new DataGridCellInfo(ItemsDGV.Items[i], ItemsDGV.Columns[4]);
                        ItemsDGV.BeginEdit();
                        MessageBox.Show(string.Format("Qty Input of Item {0} is Null", i + 1));
                        return false;
                    }
                }

                return true;
            }
            return false;
        }
        private void increment_transferNO()
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                SqlCommand command = new SqlCommand(string.Format("select Top(1) Transfer_Serial from Transfer_Kitchens where Transfer_Serial like '{0}%' order by  Transfer_Serial desc", Classes.IDs), con);
                if (command.ExecuteScalar() == null)
                {
                    transfer_No.Text = Classes.IDs + "0000001";
                }
                else
                {
                    transfer_No.Text = "0" + (Int64.Parse(command.ExecuteScalar().ToString()) + 1).ToString();
                }
            }
            catch { }
        }
        private void From_Resturant_Clicked(object sender, RoutedEventArgs e)
        {
            All_Resturants resturants = new All_Resturants(this, "From_Resturant");
            resturants.ShowDialog();
        }  //Done
        private void To_Resturant_Clicked(object sender, RoutedEventArgs e)
        {
            All_Resturants resturants = new All_Resturants(this, "To_Resturant");
            resturants.ShowDialog();
        }  //Done
        private void From_Kitchen_Clicked(object sender, RoutedEventArgs e)
        {
            All_Kitchens resturants = new All_Kitchens(this, "From_Kitchen", From_Resturant.Text);
            resturants.ShowDialog();
        }  //Done
        private void To_Kitchen_Clicked(object sender, RoutedEventArgs e)
        {

            All_Kitchens resturants = new All_Kitchens(this, "To_Kitchen", ToResturant.Text);
            resturants.ShowDialog();
        }  //Done
        private void Row_Changed(object sender, DataGridCellEditEndingEventArgs e)
        {
            DataTable Dat = ItemsDGV.DataContext as DataTable;
            for(int i=0;i<Dat.Columns.Count;i++)
            {
                Dat.Columns[i].ReadOnly = false;
            }
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlCommand cmd = new SqlCommand();
            con.Open();
            string ItemCode = (e.Row.Item as DataRowView).Row["Code"].ToString();
            //string Qty = (e.EditingElement as TextBox).Text;

            try
            {
                using (cmd = new SqlCommand(string.Format("select Qty,Current_Cost from Items where ItemID = '{0}' and RestaurantID = (select Code from Setup_Restaurant where Name = '{1}') and KitchenID = (select Code from Setup_Kitchens where Name = '{2}') union all select Qty, Current_Cost from Items where ItemID = '{0}' and RestaurantID = (select Code from Setup_Restaurant where Name = '{4}') and KitchenID = (select Code from Setup_Kitchens where Name = '{3}')", ItemCode, From_Resturant.Text, From_Kitchen.Text, To_Kitchen.Text, ToResturant.Text), con))
                {
                    transfer_No.Focus();

                    string s = string.Format("select Weight from Setup_Items where Code = '{0}'", (ItemsDGV.SelectedItem as DataRowView).Row["Code"]);
                    SqlCommand cmd2 = new SqlCommand(s, con);
                    float weight = float.Parse(cmd2.ExecuteScalar().ToString());
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

                        Dat.Rows[e.Row.GetIndex()][From_Resturant.Text + " Qty"] = (from_rest_Qty - float.Parse((e.EditingElement as TextBox).Text)).ToString();
                        Dat.Rows[e.Row.GetIndex()][From_Resturant.Text + " Unit Cost"] = from_rest_Cost.ToString();
                        Dat.Rows[e.Row.GetIndex()][From_Resturant.Text + " Total Cost"] = (from_rest_Cost * (from_rest_Qty - float.Parse((e.EditingElement as TextBox).Text))).ToString();
                        
                        Dat.Rows[e.Row.GetIndex()][ToResturant.Text + " Qty"] = (to_rest_Qty + float.Parse((e.EditingElement as TextBox).Text)).ToString();
                        Dat.Rows[e.Row.GetIndex()][ToResturant.Text + " Unit Cost"] = (((to_rest_Cost * to_rest_Qty) + (float.Parse((e.EditingElement as TextBox).Text) * from_rest_Cost)) / (to_rest_Qty + (float.Parse((e.EditingElement as TextBox).Text)))).ToString();
                        Dat.Rows[e.Row.GetIndex()][ToResturant.Text + " Total Cost"] = (((to_rest_Cost * to_rest_Qty) + (float.Parse((e.EditingElement as TextBox).Text) * from_rest_Cost)) / (to_rest_Qty + (float.Parse((e.EditingElement as TextBox).Text))) * (to_rest_Qty + float.Parse((e.EditingElement as TextBox).Text))).ToString();
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
                for (int i = 0; i < ItemsDGV.Items.Count; i++)
                {
                    try
                    {
                        totalPrice += Convert.ToDouble(((DataRowView)ItemsDGV.Items[i]).Row.ItemArray[10]);
                    }
                    catch
                    {

                    }
                }
                NUmberOfItems.Text = (ItemsDGV.Items.Count).ToString();
                Total_Price.Text = (totalPrice).ToString();
            }
            catch { }
            for(int i=0;i<Dat.Columns.Count;i++)
            {
                Dat.Columns[i].ReadOnly = true;
            }
            Dat.Columns["Qty"].ReadOnly = false;
            ItemsDGV.DataContext = Dat;


        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("AddItemTransferReasturant") == -1 && Authenticated.IndexOf("CheckAllTransferResturant") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                Items itemswindow = new Items(this);
                itemswindow.ShowDialog();
            }
        }    //Done
        private void NewBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
            increment_transferNO();
            MainGrid.IsEnabled = true;
            TransferBtn.IsEnabled = true;
            NewBtn.IsEnabled = false;
            DetailsView.IsEnabled = true;
            ItemsView.IsEnabled = true;
            NewBtn.IsEnabled = false;
            UndoBtn.IsEnabled = true;

            TransferBtn.IsEnabled = true;
        }
        private void TransferBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("TransferTrnsferResturant") == -1 && Authenticated.IndexOf("CheckAllTransferResturant") == -1)
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
                    string s = string.Format("select Transfer_Serial From Transfer_Kitchens Where Transfer_Serial='{0}'", transfer_No.Text);
                    SqlCommand cmd = new SqlCommand(s, con2);
                    if (cmd.ExecuteScalar() == null)
                    {
                        try
                        {
                            con.Open();

                            Save_TIK_Items(con);
                            Save_TIK(con);
                            MessageBox.Show("Transfer saved Sucssfully");
                            MainGrid.IsEnabled = false;
                            TransferBtn.IsEnabled = false;
                            NewBtn.IsEnabled = true;
                        }
                        finally
                        {
                            con.Close();
                        }
                    }
                    else
                    {

                        con.Open();
                        string W = string.Format("delete from Transfer_Kitchens_Items where Transfer_ID={0}", transfer_No.Text);
                        SqlCommand cmd2 = new SqlCommand(W, con);
                        cmd2.ExecuteNonQuery();
                        con.Close();
                        con.Open();
                        Save_TIK_Items(con);
                        Edit_TIK(con);
                        MessageBox.Show("Transfer Edited Sussesfully");
                        MainGrid.IsEnabled = false;
                        TransferBtn.IsEnabled = false;
                        NewBtn.IsEnabled = true;
                    }
                }
                catch { }
                ClearData();
            }
        }

        private void Edit_TIK(SqlConnection con)
        {
            try
            {
                string FiledSlection = "Manual_Transfer_No,Transfer_Date,Comment,From_Resturant_ID,To_Resturant_ID,From_Kitchen_ID,To_Kitchen_ID,Type,Status,Modifiled_Date";
                string Values = string.Format("'{0}','{1}','{2}',(select Code From Setup_Restaurant where Name='{3}'),(select Code From Setup_Restaurant where Name='{4}'),(select Code From Setup_Kitchens where Name='{5}' and RestaurantID=(select Code From Setup_Restaurant where Name='{3}')),(select Code From Setup_Kitchens where Name='{6}' and RestaurantID=(select Code From Setup_Restaurant where Name='{4}')),'{7}','{8}',GETDATE()", Manual_transfer_No.Text,Convert.ToDateTime(Transfer_dt.Text).ToString("MM-dd-yyyy") , commenttxt.Text, From_Resturant.Text, ToResturant.Text, From_Kitchen.Text, To_Kitchen.Text ,"Transfer_Resturant", Statustxt.Text);
                string Where = string.Format("Transfer_Serial={0}", transfer_No.Text);
                Classes.UpdateRow(FiledSlection, Values, Where, "Transfer_Kitchens");
                //string s = string.Format("update Transfer_Kitchens set {7}", Manual_transfer_No.Text, Transfer_dt.Text+" "+Transfer_TIme.Text, commenttxt.Text, From_Resturant.Text, ToResturant.Text, From_Kitchen.Text, To_Kitchen.Text, transfer_No.Text);
                //SqlCommand cmd = new SqlCommand(s, con);
                //cmd.ExecuteNonQuery();
                //string s = string.Format("update Transfer_Kitchens set Manual_Transfer_No='{0}',Transfer_Date='{1}',Comment='{2}',From_Resturant_ID = (select Code From Setup_Restaurant where Name = '{3}'),To_Resturant_ID = (select Code From Setup_Restaurant where Name = '{4}'),From_Kitchen_ID = (select Code From Setup_Kitchens where Name = '{5}' and RestaurantID = (select Code From Setup_Restaurant where Name = '{3}')),To_Kitchen_ID = (select Code From Setup_Kitchens where Name = '{6}' and RestaurantID = (select Code From Setup_Restaurant where Name = '{4}')),Type = 'Transfer_Resturant' Where Transfer_Serial = {7}", Manual_transfer_No.Text, Transfer_dt.Text, commenttxt.Text, From_Resturant.Text, ToResturant.Text, From_Kitchen.Text,To_Kitchen.Text, transfer_No.Text);
                //SqlCommand cmd = new SqlCommand(s, con);
                //cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void Save_TIK(SqlConnection con)
        {
            try
            {
                string FiledSelection = "Transfer_Serial,Manual_Transfer_No,Transfer_Date,Comment,From_Resturant_ID,To_Resturant_ID,From_Kitchen_ID,To_Kitchen_ID,Create_Date,Type,UserID,WS,Status";
                string values = string.Format("'{0}', '{1}', '{2}', '{3}', (select Code from Setup_Restaurant where Name = '{4}'),(select Code from Setup_Restaurant where Name = '{5}'),(select Code from Setup_Kitchens where Name = '{6}' and RestaurantID=(select Code From Setup_Restaurant where Name='{4}')),(select Code from Setup_Kitchens where Name = '{7}' and RestaurantID=(select Code From Setup_Restaurant where Name='{5}')), GETDATE(),'{8}','{9}','{10}','{11}'", transfer_No.Text, Manual_transfer_No.Text,Convert.ToDateTime(Transfer_dt.Text).ToString("MM-dd-yyyy"), commenttxt.Text, From_Resturant.Text, ToResturant.Text, From_Kitchen.Text, To_Kitchen.Text, "Transfer_Resturant", MainWindow.UserID,Classes.WS,Statustxt.Text);
                Classes.InsertRow("Transfer_Kitchens", FiledSelection, values);
            }
            catch (Exception ex){ MessageBox.Show(ex.ToString()); }
            //string s = string.Format("insert into Transfer_Kitchens(Transfer_Serial,Manual_Transfer_No,Transfer_Date,Comment,From_Resturant_ID,To_Resturant_ID,From_Kitchen_ID,To_Kitchen_ID,Post_Date,Type,UserID) values('{0}','{1}',{2},'{3}',(select Code from Setup_Restaurant where Name = '{4}'),(select Code from Setup_Restaurant where Name = '{5}'),(select Code from Setup_Kitchens where Name = '{6}'),(select Code from Setup_Kitchens where Name = '{7}'),GETDATE(),'{8}','{9}')", transfer_No.Text, Manual_transfer_No.Text, Transfer_dt.Text, commenttxt.Text, From_Resturant.Text, ToResturant.Text, From_Kitchen.Text, To_Kitchen.Text,"Transfer_Resturant",MainWindow.UserID);
            //SqlCommand cmd = new SqlCommand(s, con);
            //cmd.ExecuteNonQuery();
        } 
        private void Save_TIK_Items(SqlConnection con)
        {
            string To_QTyonHand = ""; string To_CostOfItemsOnHand = ""; string To_QtyOnHandMultipleCost = "";
            string From_QTyonHand = ""; string From_CostOfItemsOnHand = "";
            try
            {
                DataTable dt = ItemsDGV.DataContext as DataTable;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string s = string.Format("select Qty,Current_Cost From Items where RestaurantID = (select code from Setup_Restaurant where Name = '{1}') and KitchenID = (select code from Setup_Kitchens where Name = '{2}') and ItemID={0}", dt.Rows[i]["Code"].ToString(), From_Resturant.Text, From_Kitchen.Text);
                    SqlCommand _CMD = new SqlCommand(s, con);
                    SqlDataReader _reader = _CMD.ExecuteReader();
                    _reader.Read();
                    try
                    {
                        From_QTyonHand = (Convert.ToDouble(_reader["Qty"].ToString())).ToString();
                        From_CostOfItemsOnHand = _reader["Current_Cost"].ToString();
                    }
                    catch
                    {
                        From_QTyonHand = "0";
                        From_CostOfItemsOnHand = "0";
                    }
                    From_QTyonHand = (Convert.ToDouble(From_QTyonHand) - Convert.ToDouble(dt.Rows[i]["Qty"].ToString())).ToString();
                    _reader.Close();

                    s = string.Format("select Qty, Current_Cost From Items where RestaurantID = (select code from Setup_Restaurant where Name = '{1}') and KitchenID = (select code from Setup_Kitchens where Name = '{2}') and ItemID={0}", dt.Rows[i]["Code"].ToString(), ToResturant.Text, To_Kitchen.Text);
                    _CMD = new SqlCommand(s, con);
                    _reader = _CMD.ExecuteReader();
                    while (_reader.Read())
                    {
                        To_QTyonHand = (Convert.ToDouble(_reader["Qty"].ToString())).ToString();
                        To_CostOfItemsOnHand = _reader["Current_Cost"].ToString();
                    }
                    try
                    {
                        To_QtyOnHandMultipleCost = (Convert.ToDouble(To_QTyonHand) * Convert.ToDouble(To_CostOfItemsOnHand)).ToString();
                        To_QTyonHand = (Convert.ToDouble(To_QTyonHand) + Convert.ToDouble(dt.Rows[i]["Qty"].ToString())).ToString();
                        To_CostOfItemsOnHand = ((Convert.ToDouble(To_QtyOnHandMultipleCost) + (Convert.ToDouble(dt.Rows[i]["Qty"].ToString()) * Convert.ToDouble(dt.Rows[i][From_Resturant.Text + " Unit Cost"]))) / Convert.ToDouble(To_QTyonHand)).ToString();
                        _reader.Close();
                    }
                    catch
                    {
                        To_QTyonHand = Convert.ToDouble(dt.Rows[i]["Qty"].ToString()).ToString();
                        To_CostOfItemsOnHand = "0";
                        To_QtyOnHandMultipleCost = "0";
                    }
                    //
                    float NetCost = float.Parse(dt.Rows[i]["Qty"].ToString()) * float.Parse(dt.Rows[i][5].ToString());

                    string Values = "'" + dt.Rows[i]["Code"] + "','" + transfer_No.Text + "','" + dt.Rows[i]["Qty"] + "'," + "' '" + ",'" + i + "','" + dt.Rows[i][6] + "','" + NetCost + "','" + To_QTyonHand + "','" + To_CostOfItemsOnHand + "','" + From_QTyonHand + "','" + From_CostOfItemsOnHand + "'";
                    Classes.InsertRow("Transfer_Kitchens_Items", Values);
                    //s = string.Format("insert into Transfer_Kitchens_Items values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}')", dt.Rows[i]["Code"], transfer_No.Text, dt.Rows[i]["Qty"], " ", i, dt.Rows[i][6], NetCost.ToString(), To_QTyonHand, To_CostOfItemsOnHand, From_QTyonHand, From_CostOfItemsOnHand);
                    //SqlCommand cmd = new SqlCommand(s, con);
                    //cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                MessageBox.Show("Items Input Error");
            }
        }
        private void UndoBtn_Click(object sender, RoutedEventArgs e)
        {
            ClearData();
        }
        private void ClearData()
        {
            transfer_No.Text = "";
            Manual_transfer_No.Text = "";
            Transfer_dt.Text = "";
            Transfer_TIme.Text = "";
            commenttxt.Text = "";
            From_Resturant.Text = "";
            ToResturant.Text = "";
            From_Kitchen.Text = "";
            To_Kitchen.Text = "";
            NUmberOfItems.Text = "0";
            Total_Price.Text = "0";
            ItemsDGV.DataContext = null;
        }

        private void ItemsDGV_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataGrid grid = sender as DataGrid;
            if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
            {
                codeTodelete = grid.SelectedIndex;
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("RemoveItemTransferResturant") == -1 && Authenticated.IndexOf("CheckAllTransferResturant") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                DataTable dt = ItemsDGV.DataContext as DataTable;
                dt.Rows.RemoveAt(codeTodelete);
                ItemsDGV.DataContext = dt;
            }
        }  //Done

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Authenticated.IndexOf("SearchTransferResturant") == -1 && Authenticated.IndexOf("CheckAllTransferResturant") == -1)
            {
                LogIn logIn = new LogIn();
                logIn.ShowDialog();
            }
            else
            {
                IsRecived = "";
                NewBtn.IsEnabled = false;
                SearchBtn.IsEnabled = true;

                All_Purchase_Orders all_Purchase_Orders = new All_Purchase_Orders(this);
                all_Purchase_Orders.ShowDialog();
            }
        }
    }
}

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
using System.Windows.Shapes;

namespace Food_Cost
{
    /// <summary>
    /// Interaction logic for Items.xaml
    /// </summary>
    public partial class Items : Window
    {
        PurchaseOrder PO;
        Transfer_Kitchens Transfer_Kitchens;
        RecieveOrder RO;
        Recipes recipes;
        AdjacmentInventory adjacmentInventory;
        PhysicalInventory PhysicalInventory;
        KitcheItemsn kitchenItems;
        Transfer_Resturant Transfer_Resturant;
        StockInventory stockInventory;
        public Items(PhysicalInventory _PhysicalInventory)
        {
            PhysicalInventory = _PhysicalInventory;
            InitializeComponent();
            LoadItems("PhysicalInventory");
        }

        public Items(Transfer_Resturant _Transfer_Resturant)
        {
            Transfer_Resturant = _Transfer_Resturant;
            InitializeComponent();
            LoadItems("Transfer_Resturant");
        }

        public Items(StockInventory _StockInventory)
        {
            stockInventory = _StockInventory;
            InitializeComponent();
            LoadItems("StockInventory");
        }
        public Items(AdjacmentInventory _AdjacmentInventory)
        {
            adjacmentInventory = _AdjacmentInventory;
            InitializeComponent();
            LoadItems("AdjacmentInventory");
        }

        public Items(Recipes _recipes)
        {
            recipes = _recipes;
            InitializeComponent();
            LoadItems("Recipe");
        }

        public Items(PurchaseOrder _this)
        {
            InitializeComponent();
            LoadItems("Purchase");
            PO = _this;
        }

       
        public Items(Transfer_Kitchens _this)
        {
            InitializeComponent();
            Transfer_Kitchens = _this;
            LoadItems("Transfer_Kit");
        }

        public Items(RecieveOrder _this)
        {
            InitializeComponent();
            LoadItems("Receieve");
            RO = _this;
        }

        public Items(KitcheItemsn _kitchenItems)
        {
            kitchenItems = _kitchenItems;
            InitializeComponent();
            LoadItems("KitchenItem");
        }
        private void LoadItems(string ItemsFor)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();

                string s = "";
                if (ItemsFor == "Purchase" || ItemsFor == "Receieve")
                    s = "select Code,[Manual Code],Name,Name2 from Setup_Items where Is_ParentItem = 0";
                //s = "select Code,Name,Name2,Is_MultiUnitTrack,Unit,Weight as Qty,Unit3,ConvUnit3 as Qty_Unit3 from Setup_Items where Is_ParentItem = 0";
               else if (ItemsFor == "Transfer_Resturant")
                    s = string.Format(" select Code,[Manual Code],Name,Name2 from Setup_Items where Code in (select ItemID from setup_KitchenItems where RestaurantID = (select Code from Store_Setup where Name = '{0}') and KitchenID = (select Code from Kitchens_Setup where Name = '{1}') ) and Code in (select ItemID from setup_KitchenItems where RestaurantID = (select Code from Store_Setup where Name = '{3}') and KitchenID = (select Code from Kitchens_Setup where Name = '{2}'))", Transfer_Resturant.From_Resturant.Text, Transfer_Resturant.From_Kitchen.Text, Transfer_Resturant.To_Kitchen.Text, Transfer_Resturant.ToResturant.Text);
                else if (ItemsFor == "Transfer_Kit")
                    s = string.Format(" select Code,[Manual Code],Name,Name2 from Setup_Items where Code in (select ItemID from setup_KitchenItems where RestaurantID = (select Code from Store_Setup where Name = '{0}') and KitchenID = (select Code from Kitchens_Setup where Name = '{1}') ) and Code in (select ItemID from setup_KitchenItems where RestaurantID = (select Code from Store_Setup where Name = '{0}') and KitchenID = (select Code from Kitchens_Setup where Name = '{2}'))", Transfer_Kitchens.Resturant.Text, Transfer_Kitchens.From_Kitchen.Text, Transfer_Kitchens.To_Kitchen.Text);
                else if (ItemsFor == "Recipe")
                    s = "select Code,[Manual Code],BarCode,Name,Name2,Category,Department,Class,SUBClass,Unit,ExpDate,Is_TaxableItem as [Tax Included],Yield,Unit from Setup_Items";
                else if (ItemsFor == "KitchenItem")
                    s = "select Code,[Manual Code],Name,Name2,Category,Department,Class,SUBClass,Weight,Unit from Setup_Items";
                else if(ItemsFor == "AdjacmentInventory" || ItemsFor == "StockInventory" || ItemsFor == "PhysicalInventory")
                    s = "select Code,[Manual Code],Name,Name2,Category,Department,Class,SUBClass,Weight,Unit from Setup_Items";

                DataTable dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter(s, con))
                    da.Fill(dt);

                ReciveOrdersOrderDGV.DataContext = dt;
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

        public void ReciveOrderDGV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataTable dt = new DataTable();
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    MainWindow main = Application.Current.MainWindow as MainWindow;
                    
                    if (main.GridMain.Children[0].GetType().Name == "PurchaseOrder")
                    {
                        dt = PO.ItemsDGV.DataContext as DataTable;
                        DataRowView drv = grid.SelectedItem as DataRowView;

                        try
                        {
                            DataRow[] foundInstance = dt.Select("Code = " + drv.Row.ItemArray[0]);
                            if (foundInstance.Length != 0)
                            {
                                MessageBox.Show("this Item Is Existed");
                                return;
                            }
                        }
                        catch { }

                        if (PO.ItemsDGV.DataContext == null)
                        {
                            dt = drv.DataView.ToTable().Clone();
                            dt.Columns.Add("Tax Included", typeof(bool));
                            dt.Columns.Add("Qty");
                            dt.Columns.Add("Price");
                            dt.Columns.Add("Tax");  
                            dt.Columns.Add("Unit Price With Tax");
                            dt.Columns.Add("Unit Price Without Tax");
                            dt.Columns.Add("Total Price With Tax");
                            dt.Columns.Add("Total Price Without Tax");
                        }
                        else
                        {
                            dt = PO.ItemsDGV.DataContext as DataTable;
                            dt.Columns["Tax"].ReadOnly = false;
                        }

                        dt.ImportRow(drv.Row);
                        dt.Rows[dt.Rows.Count - 1]["Qty"] = 0;

                        dt = LoadTaxValue(dt);
                        //dt = MultiTatackUnit_Update(dt);

                        try
                        {
                            dt.Columns.Remove("Is_MultiUnitTrack");
                        }
                        catch { }
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt.Columns[i].ReadOnly = true;
                        }
                        dt.Columns["Tax Included"].ReadOnly = false;
                        dt.Columns["Qty"].ReadOnly = false;
                        dt.Columns["Price"].ReadOnly = false;
                        PO.ItemsDGV.DataContext = dt;
                        this.Close();
                    }

                    else if (main.GridMain.Children[0].GetType().Name == "RecieveOrder")
                    {
                        dt = RO.ItemsWithoutDGV.DataContext as DataTable;
                        DataRowView drv = grid.SelectedItem as DataRowView;

                        try
                        {
                            DataRow[] foundInstance = dt.Select("Code = " + drv.Row.ItemArray[0]);
                            if (foundInstance.Length != 0)
                            {
                                MessageBox.Show("this Item Is Existed");
                                return;
                            }
                        }
                        catch { }

                        if (RO.ItemsWithoutDGV.DataContext == null)
                        {
                            dt = drv.DataView.ToTable().Clone();
                            dt.Columns.Add("Tax Included", typeof(bool));
                            dt.Columns.Add("Qty");
                            dt.Columns.Add("Price");
                            dt.Columns.Add("Tax");
                            dt.Columns.Add("Unit Price With Tax");
                            dt.Columns.Add("Unit Price Without Tax");
                            dt.Columns.Add("Total Price With Tax");
                            dt.Columns.Add("Total Price Without Tax");
                        }
                        else
                        {
                            dt = RO.ItemsWithoutDGV.DataContext as DataTable;
                        }

                        dt.ImportRow(drv.Row);
                        dt.Rows[dt.Rows.Count - 1]["Qty"] = 0;

                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            if (dt.Columns[i] == dt.Columns["Tax Included"])
                                break;

                            dt.Columns[i].ReadOnly = true;
                        }

                        //dt.Rows[dt.Rows.Count - 1]["Tax Included"] = true;

                        dt = LoadTaxValue(dt);
                        //dt = MultiTatackUnit_Update(dt);

                        try
                        {
                            dt.Columns.Remove("Is_MultiUnitTrack");
                        }
                        catch { }
                        RO.ItemsWithoutDGV.DataContext = dt;
                        this.Close();
                    }

                    else if (main.GridMain.Children[0].GetType().Name == "Transfer_Resturant")
                    {
                        DataRowView drv = grid.SelectedItem as DataRowView;

                        if (Transfer_Resturant.ItemsDGV.DataContext == null)
                        {
                            dt = drv.DataView.ToTable().Clone();
                            dt.Columns.Add("Qty");
                            dt.Columns.Add(Transfer_Resturant.From_Resturant.Text + " Qty");
                            dt.Columns.Add(Transfer_Resturant.From_Resturant.Text + " Unit Cost");
                            dt.Columns.Add(Transfer_Resturant.From_Resturant.Text + " total Cost");
                            dt.Columns.Add(Transfer_Resturant.ToResturant.Text + " Qty");
                            dt.Columns.Add(Transfer_Resturant.ToResturant.Text + " Unit Cost");
                            dt.Columns.Add(Transfer_Resturant.ToResturant.Text + " total Cost");
                        }
                        else
                            dt = Transfer_Resturant.ItemsDGV.DataContext as DataTable;

                        for (int i = 0; i < dt.Rows.Count; i++)
                            if (dt.Rows[i]["Code"].ToString() == drv.Row["Code"].ToString())
                            {
                                MessageBox.Show("This Item Already Exist");
                                return;
                            }

                        dt.ImportRow(drv.Row);

                        for(int i=0;i<dt.Columns.Count;i++)
                        {
                            dt.Columns[i].ReadOnly = true;
                        }
                        dt.Columns["Qty"].ReadOnly = false;

                        Transfer_Resturant.ItemsDGV.DataContext = dt;

                        this.Close();
                    }

                    else if (main.GridMain.Children[0].GetType().Name == "Transfer_Kitchens")
                    {
                        DataRowView drv = grid.SelectedItem as DataRowView;

                        if (Transfer_Kitchens.ItemsDGV.DataContext == null)
                        {
                            dt = drv.DataView.ToTable().Clone();
                            dt.Columns.Add("Qty");
                            dt.Columns.Add(Transfer_Kitchens.From_Kitchen.Text + " Qty");
                            dt.Columns.Add(Transfer_Kitchens.From_Kitchen.Text + " Unit Cost");
                            dt.Columns.Add(Transfer_Kitchens.From_Kitchen.Text + " total Cost");
                            dt.Columns.Add(Transfer_Kitchens.To_Kitchen.Text + " Qty");
                            dt.Columns.Add(Transfer_Kitchens.To_Kitchen.Text + " Unit Cost");
                            dt.Columns.Add(Transfer_Kitchens.To_Kitchen.Text + " total Cost");
                        }
                        else
                            dt = Transfer_Kitchens.ItemsDGV.DataContext as DataTable;

                        for (int i = 0; i < dt.Rows.Count; i++)
                            if (dt.Rows[i]["Code"].ToString() == drv.Row["Code"].ToString())
                            {
                                MessageBox.Show("This Item Already Exist");
                                return;
                            }

                        dt.ImportRow(drv.Row);
                        for(int i=0;i<dt.Columns.Count;i++)
                        {
                            dt.Columns[i].ReadOnly = true;
                        }
                        dt.Columns["Qty"].ReadOnly = false;

                        Transfer_Kitchens.ItemsDGV.DataContext = dt;

                        this.Close();
                    }

                    else if (main.GridMain.Children[0].GetType().Name == "AdjacmentInventory")
                    {
                        if (adjacmentInventory.ItemsDGV.DataContext == null)
                        {
                            dt.Columns.Add("Code");
                            dt.Columns.Add("Name");
                            dt.Columns.Add("Name2");
                            dt.Columns.Add("Qty");
                            dt.Columns.Add("Adjacmentable Qty");
                            dt.Columns.Add("Variance");
                            dt.Columns.Add("Cost");
                        }
                        else
                        {
                            dt = adjacmentInventory.ItemsDGV.DataContext as DataTable;
                            for (int i = 0; i < dt.Rows.Count; i++)
                                if (dt.Rows[i]["Code"].ToString() == (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString())
                                {
                                    MessageBox.Show("Item Existed");
                                    return;
                                }
                        }

                            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
                        string FirstName = ""; string SeconName = "";
                        SqlDataReader reader = null;
                        SqlDataReader reader2 = null;
                        SqlConnection con = new SqlConnection(connString);
                        SqlConnection con2 = new SqlConnection(connString);
                        SqlCommand cmd = new SqlCommand();
                        SqlCommand cmd2 = new SqlCommand();
                        try
                        {
                            con.Open();
                            string s = "select ItemID,Qty,Current_Cost from Items Where ItemID="+ (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString() + " AND RestaurantID=" + adjacmentInventory.ValOfResturant + " and KitchenID=" + adjacmentInventory.ValOfKitchen;
                            cmd = new SqlCommand(s, con);
                            reader = cmd.ExecuteReader();
                            int Qount = 0;
                            while (reader.Read() && Qount == 0)
                            {
                                try
                                {
                                    con2.Open();
                                    string q = "SELECT Name,Name2 From Setup_Items Where Code='" + reader["ItemID"].ToString() + "'";
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
                                dt.Rows.Add(reader["ItemID"].ToString(), FirstName, SeconName, reader["Qty"].ToString(), "", "", reader["Current_Cost"]);
                                Qount++;
                            }
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                dt.Columns[i].ReadOnly = true;
                            }
                            dt.Columns["Adjacmentable Qty"].ReadOnly = false;
                            dt.Columns["Cost"].ReadOnly = false;

                            adjacmentInventory.ItemsDGV.DataContext = dt;
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

                    else if (main.GridMain.Children[0].GetType().Name == "StockInventory")
                    {
                        if (stockInventory.ItemsDGV.DataContext == null)
                        {
                            dt.Columns.Add("ItemsID");
                            dt.Columns.Add("Name");
                            dt.Columns.Add("Name2");
                            dt.Columns.Add("Qty");
                            dt.Columns.Add("OriginalQty");
                            dt.Columns.Add("Variance");
                            dt.Columns.Add("Cost");
                        }
                        else
                        {
                            dt = stockInventory.ItemsDGV.DataContext as DataTable;
                            for (int i = 0; i < dt.Rows.Count; i++)
                                if (dt.Rows[i]["ItemsID"].ToString() == (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString())
                                {
                                    MessageBox.Show("Item Existed");
                                    return;
                                }
                        }

                        string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
                        string FirstName = ""; string SeconName = "";
                        SqlDataReader reader = null;
                        SqlDataReader reader2 = null;
                        SqlConnection con = new SqlConnection(connString);
                        SqlConnection con2 = new SqlConnection(connString);
                        SqlCommand cmd = new SqlCommand();
                        SqlCommand cmd2 = new SqlCommand();
                        try
                        {
                            con.Open();
                            string s = "select ItemID,Qty,Current_Cost from Items Where ItemID=" + (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString() + " AND RestaurantID=" + stockInventory.ValOfResturant + " and KitchenID=" + stockInventory.ValOfKitchen;
                            cmd = new SqlCommand(s, con);
                            reader = cmd.ExecuteReader();
                            int Qount = 0;
                            while (reader.Read() && Qount == 0)
                            {
                                try
                                {
                                    con2.Open();
                                    string q = "SELECT Name,Name2 From Setup_Items Where Code='" + reader["ItemID"].ToString() + "'";
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
                                dt.Rows.Add(reader["ItemID"].ToString(), FirstName, SeconName, reader["Qty"].ToString(), "", "", reader["Current_Cost"]);
                                Qount++;
                            }
                            for (int i = 0; i < dt.Columns.Count; i++)
                            {
                                dt.Columns[i].ReadOnly = true;
                            }
                            dt.Columns["OriginalQty"].ReadOnly = false;

                            stockInventory.ItemsDGV.DataContext = dt;
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

                    else if (main.GridMain.Children[0].GetType().Name == "PhysicalInventory")
                    {
                        /*if(PhysicalInventory.BInd.IsChecked==true)
                        {
                            if (PhysicalInventory.ItemsDGV.DataContext == null)
                            {
                                dt.Columns.Add("ItemsID");
                                dt.Columns.Add("Name");
                                dt.Columns.Add("Name2");
                                dt.Columns.Add("Qty");
                                dt.Columns.Add("OriginalQty");
                                dt.Columns.Add("Variance");
                                dt.Columns.Add("Cost");
                            }
                            else
                            {
                                dt = PhysicalInventory.ItemsDGV.DataContext as DataTable;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                    if (dt.Rows[i]["ItemsID"].ToString() == (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString())
                                    {
                                        MessageBox.Show("Item Existed");
                                        return;
                                    }
                            }

                            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
                            string FirstName = ""; string SeconName = "";
                            SqlDataReader reader = null;
                            SqlDataReader reader2 = null;
                            SqlConnection con = new SqlConnection(connString);
                            SqlConnection con2 = new SqlConnection(connString);
                            SqlCommand cmd = new SqlCommand();
                            SqlCommand cmd2 = new SqlCommand();
                            try
                            {
                                con.Open();
                                string s = "select ItemID,Qty,Current_Cost from Items Where ItemID=" + (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString() + " AND RestaurantID=" + PhysicalInventory.ValOfResturant + " and KitchenID=" + PhysicalInventory.ValOfKitchen;
                                cmd = new SqlCommand(s, con);
                                reader = cmd.ExecuteReader();
                                int Qount = 0;
                                while (reader.Read() && Qount == 0)
                                {
                                    try
                                    {
                                        con2.Open();
                                        string q = "SELECT Name,Name2 From Setup_Items Where Code='" + reader["ItemID"].ToString() + "'";
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
                                    dt.Rows.Add(reader["ItemID"].ToString(), FirstName, SeconName, reader["Qty"].ToString(), "", "", reader["Current_Cost"]);
                                    Qount++;
                                }
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    dt.Columns[i].ReadOnly = true;
                                }
                                dt.Columns["OriginalQty"].ReadOnly = false;

                                PhysicalInventory.ItemsDGV.DataContext = dt;
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
                        else if(PhysicalInventory.Not_Bind.IsChecked == true)
                        {
                            if (PhysicalInventory.ItemsDGV.DataContext == null)
                            {
                                dt.Columns.Add("ItemsID");
                                dt.Columns.Add("Name");
                                dt.Columns.Add("Name2");
                                dt.Columns.Add("Qty");
                                dt.Columns.Add("Cost");
                                dt.Columns.Add("Checked", typeof(bool));
                                dt.Columns.Add("Comment");
                            }
                            else
                            {
                                dt = PhysicalInventory.ItemsDGV.DataContext as DataTable;
                                for (int i = 0; i < dt.Rows.Count; i++)
                                    if (dt.Rows[i]["ItemsID"].ToString() == (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString())
                                    {
                                        MessageBox.Show("Item Existed");
                                        return;
                                    }
                            }

                            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
                            string FirstName = ""; string SeconName = "";
                            SqlDataReader reader = null;
                            SqlDataReader reader2 = null;
                            SqlConnection con = new SqlConnection(connString);
                            SqlConnection con2 = new SqlConnection(connString);
                            SqlCommand cmd = new SqlCommand();
                            SqlCommand cmd2 = new SqlCommand();
                            try
                            {
                                con.Open();
                                string s = "select ItemID,Qty,Current_Cost from Items Where ItemID=" + (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString() + " AND RestaurantID=" + PhysicalInventory.ValOfResturant + " and KitchenID=" + PhysicalInventory.ValOfKitchen;
                                cmd = new SqlCommand(s, con);
                                reader = cmd.ExecuteReader();
                                int Qount = 0;
                                while (reader.Read() && Qount == 0)
                                {
                                    try
                                    {
                                        con2.Open();
                                        string q = "SELECT Name,Name2 From Setup_Items Where Code='" + reader["ItemID"].ToString() + "'";
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
                                    dt.Rows.Add(reader["ItemID"].ToString(), FirstName, SeconName, reader["Qty"].ToString(), reader["Current_Cost"],false," ");
                                    Qount++;
                                }
                                for (int i = 0; i < dt.Columns.Count; i++)
                                {
                                    dt.Columns[i].ReadOnly = true;
                                }
                                dt.Columns["Checked"].ReadOnly = false;
                                dt.Columns["Comment"].ReadOnly = false;

                                PhysicalInventory.ItemsDGV.DataContext = dt;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                con.Close();
                            }
                        }*/
                    }

                    else if (main.GridMain.Children[0].GetType().Name == "Recipes")
                    {
                        string CostOfItem = "";
                        string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
                        SqlConnection con = new SqlConnection(connString);
                        SqlCommand cmd = new SqlCommand();
                        dt = new DataTable();
                        dt.Columns.Add("Item_Code");
                        dt.Columns.Add("Recipe_Code");
                        dt.Columns.Add("Name");
                        dt.Columns.Add("Name2");
                        dt.Columns.Add("Qty");
                        dt.Columns.Add("Recipe_Unit");
                        dt.Columns.Add("Cost");
                        dt.Columns.Add("Total_Cost");
                        dt.Columns.Add("Cost_Precentage");

                        if (recipes.RecipesDGV.DataContext != null)
                        {
                            dt = recipes.RecipesDGV.DataContext as DataTable;
                            for (int i = 0; i < dt.Rows.Count; i++)
                                if (dt.Rows[i]["Item_Code"].ToString() == (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString())
                                {
                                    MessageBox.Show("Item Existed");
                                    return;
                                }
                        }
                       
                        try
                        {
                            con.Open();
                            string s = string.Format("select Current_Cost from Items where RestaurantID=1 and KitchenID=1 and ItemID={0}", (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString());
                            cmd = new SqlCommand(s, con);
                            if (cmd.ExecuteScalar() == null)
                            {
                                CostOfItem = "0";
                            }
                            else
                            {
                                CostOfItem = cmd.ExecuteScalar().ToString();
                            }
                        }
                        catch { }

                        dt.Rows.Add( (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString(), "", (((DataRowView)grid.SelectedItem).Row.ItemArray[3]).ToString(), (((DataRowView)grid.SelectedItem).Row.ItemArray[4]).ToString(),"1", (((DataRowView)grid.SelectedItem).Row.ItemArray[9]).ToString(), CostOfItem, CostOfItem, "");
                        double sum = 0;
                        double totalCost = 0;
                        dt.Columns["Cost_Precentage"].ReadOnly = false;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            sum += Convert.ToDouble(dt.Rows[i]["Total_Cost"]);
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        { 
                            dt.Rows[i]["Cost_Precentage"] = ((Convert.ToDouble(dt.Rows[i]["Total_Cost"])) / (sum) * 100).ToString() + " %";
                            totalCost += (Convert.ToDouble(dt.Rows[i]["Total_Cost"]));

                        }
                       
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            dt.Columns[i].ReadOnly = true;
                        }
                        dt.Columns["Qty"].ReadOnly = false;
                        recipes.Tottaltxt.Text = totalCost.ToString();
                        recipes.RecipesDGV.DataContext = dt;


                        this.Close();
                    }

                    else
                    {
                        DataTable table =  kitchenItems.ItemsDGV.DataContext as DataTable;
                        if (table != null)
                            for (int i = 0; i < table.Rows.Count; i++)
                                if (table.Rows[i]["Code"].ToString() == (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString())
                                {
                                    MessageBox.Show("Item Existed");
                                    return;
                                }

                        dt = new DataTable();
                        dt.Columns.Add("Code");
                        dt.Columns.Add("Name");
                        dt.Columns.Add("Name2");
                        dt.Columns.Add("ShulfID");
                        dt.Columns.Add("MinQty");
                        dt.Columns.Add("MaxQty");

                        if (kitchenItems != null && kitchenItems.ItemsDGV.DataContext != null)
                            dt = kitchenItems.ItemsDGV.DataContext as DataTable;

                        dt.Rows.Add((((DataRowView)grid.SelectedItem).Row.ItemArray[0]), (((DataRowView)grid.SelectedItem).Row.ItemArray[1]), (((DataRowView)grid.SelectedItem).Row.ItemArray[2]), "", "", "");
                        kitchenItems.ItemsDGV.DataContext = dt;
                        this.Close();
                    }

                    return;
               }
            }
        }

        private DataTable LoadTaxValue(DataTable dt)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            using (SqlCommand cmd = new SqlCommand(string.Format("select Is_TaxableItem,TaxableValue from Setup_Items where Code = '{0}'", dt.Rows[dt.Rows.Count - 1]["Code"].ToString()), con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                if (reader["Is_TaxableItem"].ToString() == "False")
                {
                    dt.Rows[dt.Rows.Count - 1]["Tax"] = "0%";

                    dt.Columns["Tax Included"].ReadOnly = false;
                    dt.Rows[dt.Rows.Count - 1]["Tax Included"] = false;
                }
                else
                {
                    dt.Rows[dt.Rows.Count - 1]["Tax"] = reader["TaxableValue"] + "%";
                    dt.Columns["Tax Included"].ReadOnly = false;
                    dt.Rows[dt.Rows.Count - 1]["Tax Included"] = true;
                }
            }

            return dt;
        }

        //private DataTable MultiTatackUnit_Update(DataTable dt)
        //{
        //    if (dt.Rows[dt.Rows.Count - 1]["Is_MultiUnitTrack"].ToString() == "False")
        //        return dt;

        //    string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
        //    SqlConnection con = new SqlConnection(connString);

        //    using (SqlCommand cmd = new SqlCommand( string.Format("select Weight,Unit3, ConvUnit3 from Setup_Items where Code = '{0}'", dt.Rows[dt.Rows.Count - 1]["Code"].ToString()), con) )
        //    {
        //        con.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();
        //        reader.Read();
        //        dt.Rows[dt.Rows.Count - 1]["Unit3"] = reader["Unit3"];
        //        dt.Rows[dt.Rows.Count - 1]["Qty(Unit3)"] = float.Parse(reader["Weight"].ToString()) / float.Parse(reader["ConvUnit3"].ToString());
        //    }

        //    return dt;
        //}

        private void TextDataChange(object sender, TextChangedEventArgs e)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            if ((RadioByCode.IsChecked == true || RadioByName.IsChecked == true) && SearchTxt.Text != "")
            {
                ReciveOrdersOrderDGV.DataContext = null;
                if (RadioByCode.IsChecked == true && RadioByName.IsChecked == false)
                {
                    try
                    {
                        con.Open();
                        string s = "";
                        if (main.GridMain.Children[0].GetType().Name == "RecieveOrder" || main.GridMain.Children[0].GetType().Name == "PurchaseOrder")
                            s = "select Code,[Manual Code],Name,Name2,Is_MultiUnitTrack from Setup_Items Where (Code Like '%" + SearchTxt.Text + "%' OR [Manual Code] Like '%" + SearchTxt.Text + "%')";
                        else if (main.GridMain.Children[0].GetType().Name == "Transfer_Kitchens")
                            s = string.Format(" select Code,[Manual Code],Name,Name2 from Setup_Items where Code in (select ItemID from setup_KitchenItems where RestaurantID = (select Code from Store_Setup where Name = '{0}') and KitchenID = (select Code from Kitchens_Setup where Name = '{1}') ) and Code in (select ItemID from setup_KitchenItems where RestaurantID = (select Code from Store_Setup where Name = '{0}') and KitchenID = (select Code from Kitchens_Setup where Name = '{2}'))  and  (Code Like '%{3}%' OR [Manual Code] Like '%{3}%')", Transfer_Kitchens.Resturant.Text, Transfer_Kitchens.From_Kitchen.Text, Transfer_Kitchens.To_Kitchen.Text, SearchTxt.Text);
                        else if (main.GridMain.Children[0].GetType().Name == "Recipes")
                            s = "select Code,[Manual Code],BarCode,Name,Name2,Category,Department,Class,SUBClass,ExpDate,Is_TaxableItem as [Tax Included],Yield,Unit from Setup_Items Where (Code Like '%" + SearchTxt.Text + "%' OR [Manual Code] Like '%" + SearchTxt.Text + "%')";
                        else if (main.GridMain.Children[0].GetType().Name == "KitcheItemsn")
                            s = "select Code,[Manual Code],Name,Name2,Category,Department,Class,SUBClass,Weight,Unit from Setup_Items Where (Code Like '%" + SearchTxt.Text + "%' OR [Manual Code] Like '%" + SearchTxt.Text + "%')";
                        else if (main.GridMain.Children[0].GetType().Name == "AdjacmentInventory" || main.GridMain.Children[0].GetType().Name == "StockInventory"|| main.GridMain.Children[0].GetType().Name == "PhysicalInventory")
                            s = "select Code,[Manual Code],Name,Name2,Category,Department,Class,SUBClass,Weight,Unit from Setup_Items where (Code Like '%" + SearchTxt.Text + "%' OR [Manual Code] Like '%" + SearchTxt.Text + "%')";

                        DataTable dt = new DataTable();

                        using (SqlDataAdapter da = new SqlDataAdapter(s, con))
                            da.Fill(dt);

                        ReciveOrdersOrderDGV.DataContext = dt;
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
                else if (RadioByName.IsChecked == true && RadioByCode.IsChecked == false)
                {
                    try
                    {
                        con.Open();
                        string s = "";
                        if (main.GridMain.Children[0].GetType().Name == "RecieveOrder" || main.GridMain.Children[0].GetType().Name == "PurchaseOrder")
                            s = "select Code,[Manual Code],Name,Name2,Is_MultiUnitTrack from Setup_Items Where Name Like '%" + SearchTxt.Text + "%'";
                        else if (main.GridMain.Children[0].GetType().Name == "Transfer_Kitchens")
                            s = string.Format(" select Code,[Manual Code],Name,Name2 from Setup_Items where Code in (select ItemID from setup_KitchenItems where RestaurantID = (select Code from Store_Setup where Name = '{0}') and KitchenID = (select Code from Kitchens_Setup where Name = '{1}') ) and Code in (select ItemID from setup_KitchenItems where RestaurantID = (select Code from Store_Setup where Name = '{0}') and KitchenID = (select Code from Kitchens_Setup where Name = '{2}'))  and  Name Like '%{3}%'", Transfer_Kitchens.Resturant.Text, Transfer_Kitchens.From_Kitchen.Text, Transfer_Kitchens.To_Kitchen.Text, SearchTxt.Text);
                        else if (main.GridMain.Children[0].GetType().Name == "Recipes")
                            s = "select Code,[Manual Code],BarCode,Name,Name2,Category,Department,Class,SUBClass,ExpDate,Is_TaxableItem as [Tax Included],Yield,Unit from Setup_Items Where Name Like '%" + SearchTxt.Text + "%'";
                        else if (main.GridMain.Children[0].GetType().Name == "KitcheItemsn")
                            s = "select Code,[Manual Code],Name,Name2,Category,Department,Class,SUBClass,Weight,Unit from Setup_Items Where Name Like '%" + SearchTxt.Text + "%'";
                        else if (main.GridMain.Children[0].GetType().Name == "AdjacmentInventory" || main.GridMain.Children[0].GetType().Name == "StockInventory" || main.GridMain.Children[0].GetType().Name == "PhysicalInventory")
                            s = "select Code,[Manual Code],Name,Name2,Category,Department,Class,SUBClass,Weight,Unit from Setup_Items where  Name Like '%" + SearchTxt.Text + "%'";

                        DataTable dt = new DataTable();

                        using (SqlDataAdapter da = new SqlDataAdapter(s, con))
                            da.Fill(dt);

                        ReciveOrdersOrderDGV.DataContext = dt;
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
            else
            {
                try
                {
                    con.Open();
                    string s = "";
                    if (main.GridMain.Children[0].GetType().Name == "RecieveOrder" || main.GridMain.Children[0].GetType().Name == "PurchaseOrder")
                        s = "select Code,[Manual Code],Name,Name2,Is_MultiUnitTrack from Setup_Items";
                    else if (main.GridMain.Children[0].GetType().Name == "Transfer_Kitchens")
                        s = string.Format(" select Code,[Manual Code],Name,Name2 from Setup_Items where Code in (select ItemID from setup_KitchenItems where RestaurantID = (select Code from Store_Setup where Name = '{0}') and KitchenID = (select Code from Kitchens_Setup where Name = '{1}') ) and Code in (select ItemID from setup_KitchenItems where RestaurantID = (select Code from Store_Setup where Name = '{0}') and KitchenID = (select Code from Kitchens_Setup where Name = '{2}') )", Transfer_Kitchens.Resturant.Text, Transfer_Kitchens.From_Kitchen.Text, Transfer_Kitchens.To_Kitchen.Text);
                    else if (main.GridMain.Children[0].GetType().Name == "Recipes")
                        s = "select Code,[Manual Code],BarCode,Name,Name2,Category,Department,Class,SUBClass,ExpDate,Is_TaxableItem as [Tax Included],Yield,Unit from Setup_Items";
                    else if (main.GridMain.Children[0].GetType().Name == "KitcheItemsn")
                        s = "select Code,[Manual Code],Name,Name2,Category,Department,Class,SUBClass,Weight,Unit from Setup_Items";
                    else if (main.GridMain.Children[0].GetType().Name == "AdjacmentInventory" || main.GridMain.Children[0].GetType().Name == "StockInventory" || main.GridMain.Children[0].GetType().Name == "PhysicalInventory")
                        s = "select Code,[Manual Code],Name,Name2,Category,Department,Class,SUBClass,Weight,Unit from Setup_Items";
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(s, con))
                        da.Fill(dt);

                    ReciveOrdersOrderDGV.DataContext = dt;
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
    }
}   
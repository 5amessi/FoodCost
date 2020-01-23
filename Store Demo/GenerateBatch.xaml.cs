using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for GenerateBatch.xaml
    /// </summary>
    public partial class GenerateBatch : UserControl
    {
        bool isParent = false;
        public string[,] RecipeItemDData = new string[100, 3];
        public bool checksofParent = true;
        public bool ToFinishFunction = true; public bool ToCloseFunction = true;
        string[,] RecipesData = new string[100, 3];
        public int CountofRecipeItemData = 0;
        int CountofRecipesData = 0;
        int CountOfItemInTable = 0;
        int CountOfItemInCode = 0;
        int NumofMinItems = 0;
        string valofStore = "";
        string valofRecipe = "";
        string ValOfKitchen = "";
        DataTable Data = new DataTable();
        string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
        public GenerateBatch()
        {
            InitializeComponent();
            LoadAllOutlet();
        }
        public void LoadAllOutlet()
        {
            SqlConnection con = new SqlConnection(connString);
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
        }   // Done 
        private void ResturantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Kitchencbx.Items.Clear();
            Recipecbx.Items.Clear();
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
                string s = "select Code from Store_Setup Where Name='" + StoreIDcbx.SelectedItem + "'";
                SqlCommand cmd = new SqlCommand(s, con);
                valofStore = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            LoadAllKitchen(valofStore);
        }  //Done
        public void LoadAllKitchen(string CodeOfResturant)
        {
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Name from Kitchens_Setup Where RestaurantID=" + CodeOfResturant;
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
        }  //Done
        private void kitchenComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Recipecbx.Items.Clear();
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Code from Kitchens_Setup Where Name='" + Kitchencbx.SelectedItem.ToString() + "'";
                SqlCommand cmd = new SqlCommand(s, con);
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
            LoadAllRecipes();
            ReqBtn.IsEnabled = true;

        }  //Done
        public void LoadAllRecipes()
        {
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Name from Setup_Recipes";
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = reader["Name"].ToString();
                    Recipecbx.Items.Add(data);
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
        }  //Done
        private void RecipeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string UnitofRecipe = "";
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                string s = "SELECT Unit FROM Setup_Recipes Where Code=(select Code From Setup_Recipes Where Name='" + Recipecbx.SelectedItem.ToString() + "')";
                cmd = new SqlCommand(s, con);
                UnitofRecipe = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            GenerateBtn.IsEnabled = true;
            QtyofRecipetxt.IsEnabled = true;
            UnitofRecipelbl.Visibility = Visibility.Visible;
            UnitofRecipelbl.Content = UnitofRecipe;
            RecipesDGV.Visibility = Visibility.Visible;
            NameoftotalCost.Visibility = Visibility.Visible;
            TotalCosttxt.Visibility = Visibility.Visible;
            LoadtoDataGrid();

        }  //Done
        private void LoadtoDataGrid()
            {
            double summationofQTyValuo = 0;
            double totalCost = 0;
            double CostVlue = 0;
            string CodeOfRecipe = "";
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlConnection con2 = new SqlConnection(connString);
            SqlCommand cmd2 = new SqlCommand();
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "SELECT Code From Setup_Recipes Where Name='"+ Recipecbx.SelectedItem.ToString() + "'";
                cmd = new SqlCommand(s, con);
                CodeOfRecipe = cmd.ExecuteScalar().ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            /////.
            DataTable dt = new DataTable();
            dt.Columns.Add("Item_Code");
            dt.Columns.Add("Recipe_Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("Name2");
            dt.Columns.Add("Qty");
            dt.Columns.Add("Recipe_Unit");
            dt.Columns.Add("Cost");
            dt.Columns.Add("Total_Cost");
            dt.Columns.Add("Cost_Precentage");
            try
            {
                con.Open();
                string q = "SELECT Recipe_ID,Item_Code,Name,Name2,Qty,Recipe_Unit,Cost,Total_Cost,Cost_Precentage FROM Setup_RecipeItems WHERE Recipe_Code=" + CodeOfRecipe;
                cmd = new SqlCommand(q, con);
                reader = cmd.ExecuteReader();
                con2.Open();
                while (reader.Read())
                {
                    if (reader["Item_Code"].ToString() != "")
                    {
                        try
                        {
                            string W = string.Format("select Current_Cost from Items Where ItemID={0} and RestaurantID={1} and KitchenID={2} ", reader["Item_Code"], valofStore, ValOfKitchen);
                            cmd2 = new SqlCommand(W, con2);
                            if (cmd2.ExecuteScalar() == null)
                            {
                                CostVlue = 0;
                            }
                            else
                            {
                                CostVlue = Convert.ToDouble(cmd2.ExecuteScalar().ToString());
                            }
                        }
                        catch { }
                        summationofQTyValuo += CostVlue * Convert.ToDouble(reader["Qty"].ToString());
                    }
                    else
                    {
                        string W = string.Format("	select Price from RecipeQty Where Recipe_ID={0} and Resturant_ID={1} and Kitchen_ID={2}", reader["Recipe_ID"], valofStore, ValOfKitchen);
                        cmd2 = new SqlCommand(W, con2);
                        if (cmd2.ExecuteScalar() == null)
                        {
                            CostVlue = 0;
                        }
                        else
                        {
                            CostVlue = Convert.ToDouble(cmd2.ExecuteScalar().ToString());
                        }
                        summationofQTyValuo += CostVlue * Convert.ToDouble(reader["Qty"].ToString());

                    }
                    dt.Rows.Add(reader["Item_Code"], reader["Recipe_ID"].ToString(), reader["Name"].ToString(), reader["Name2"].ToString(), reader["Qty"].ToString(), reader["Recipe_Unit"].ToString(), CostVlue, reader["Total_Cost"].ToString(), reader["Cost_Precentage"].ToString());
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["Total_Cost"] = ((Convert.ToDouble(dt.Rows[i]["Qty"])) * (Convert.ToDouble(dt.Rows[i]["Cost"]))).ToString();
                    dt.Rows[i]["Cost_Precentage"] = ((Convert.ToDouble(dt.Rows[i]["Total_Cost"])) / (summationofQTyValuo)*100).ToString()+" %";
                    totalCost += (Convert.ToDouble(dt.Rows[i]["Total_Cost"]));

                }
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    dt.Columns[i].ReadOnly = true;
                } 
                RecipesDGV.DataContext = dt;
                TotalCosttxt.Text = totalCost.ToString();
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
        }   //Done 
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
        private void OrderReq_Click(object sender, RoutedEventArgs e)
        {
            UserControl usc = new Food_Cost.OrderRequesation(valofStore, ValOfKitchen);
            Parent.Children.Clear();
            Parent.Children.Add(usc);
        }   //Done
         
        private void GenerateBtn_Click(object sender, RoutedEventArgs e)
        {
            CountofRecipeItemData = 0;
            CountofRecipesData = 0;
            if (QtyofRecipetxt.Text == "")
            {
                MessageBox.Show("Please Enter Qty of Recipe");
                return;
            }

            string UnitQty = "";
            string Unit = "";
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                string s = "select Code from Setup_Recipes WHERE Name='" + Recipecbx.SelectedItem.ToString() + "'";
                cmd = new SqlCommand(s, con);
                valofRecipe = cmd.ExecuteScalar().ToString();
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
                string s = "SELECT UnitQty,Unit FROM Setup_Recipes WHERE Code=" + valofRecipe;
                cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    UnitQty = reader["UnitQty"].ToString();
                    Unit = reader["Unit"].ToString();
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
            bool boolianCheck = ItsRecipe(valofRecipe, UnitQty, Unit);
            if (boolianCheck == true && ToFinishFunction ==false)
            {
                UpddateQty();
                MessageBox.Show("Recipe Generated Succesfuly");
            }
            else if((boolianCheck == false && ToFinishFunction == true) && isParent==false)
            {
                MessageBoxResult result = MessageBox.Show("Can't Genertare this Recipe Because Item Can't Complete It , You wan't to Order ?", "Confirmation",
                              MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                if (result == MessageBoxResult.OK)
                {
                    UserControl usc = new Food_Cost.OrderRequesation(valofStore, ValOfKitchen);
                    Parent.Children.Clear();
                    Parent.Children.Add(usc);
                }
            }

            UserControl us = new Food_Cost.GenerateBatch();
            Parent.Children.Clear();
            Parent.Children.Add(us);
        }           //Done

        private bool CheckIfParent(string Item_Code)
        {
            bool check = true;
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                string s = "SELECT Parent_Item FROM Setup_ParentItems Where Parent_Item='" + Item_Code + "'";
                cmd = new SqlCommand(s, con);
                if (cmd.ExecuteScalar() != null)
                {
                    check = true;
                }
                else
                {
                    check = false;
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
            return check;
        }

     /*   private bool UpdateParent(string Item_Code, string ItemQty, string UnitQty, string RecipeQty)
        {
            bool valuoofboolFunction = true;
            double valueOfQtyOfItem = Convert.ToDouble(ItemQty);
            double Qty = 0;
            string BaseWeight = ""; string BaseUnit = ""; string secondWeight = ""; string SecondUnit = ""; string YeildofQty = "";
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;
            SqlConnection con2 = new SqlConnection(connString);
            SqlCommand cmd2 = new SqlCommand();
            SqlDataReader reader2 = null;
            try
            {
                con.Open();
                string s = "SELECT Code FROM Setup_ParentItems Where Parent_Item='" + Item_Code + "'";
                cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                con2.Open();
                while (reader.Read())
                {
                    string W = "SELECT Weight,Unit,Unit2,ConvUnit2,Yield FROM Setup_Items WHERE Code=" + reader["Code"].ToString();
                    cmd2 = new SqlCommand(W, con2);
                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        YeildofQty = reader2["Yield"].ToString();
                        BaseWeight = reader2["Weight"].ToString();
                        BaseUnit = reader2["Unit"].ToString();
                        SecondUnit = reader2["Unit2"].ToString();
                        secondWeight = reader2["ConvUnit2"].ToString();
                    }
                    reader2.Close();
                    string w = "SELECT Qty,MinNumber,MaxNumber,Units FROM Items WHERE RestaurantID=" + valofStore + " AND ItemID=" + reader["Code"].ToString() + " AND KitchenID=" + ValOfKitchen;
                    cmd2 = new SqlCommand(w, con2);
                    reader2 = cmd2.ExecuteReader();

                    while (reader2.Read())
                    {
                        if (valueOfQtyOfItem > 0)
                        {
                            if (UnitQty == BaseUnit)
                            {
                                Qty = (((Convert.ToDouble(reader2["Qty"])) - ((Convert.ToDouble(RecipeQty)) * (Convert.ToDouble(QtyofRecipetxt.Text)) * (Convert.ToDouble(ItemQty)))) * Convert.ToDouble(YeildofQty) / 100);
                                if (Qty < 0)
                                {
                                    valueOfQtyOfItem -= ((Convert.ToDouble(reader2["Qty"])) * Convert.ToDouble(YeildofQty) / 100);
                                    RecipeItemDData[CountofRecipeItemData, 0] = reader["Code"].ToString();
                                    RecipeItemDData[CountofRecipeItemData, 1] = "0";
                                    CountofRecipeItemData++;
                                }
                                else
                                {
                                    RecipeItemDData[CountofRecipeItemData, 0] = reader["Code"].ToString();
                                    RecipeItemDData[CountofRecipeItemData, 1] = Qty.ToString();
                                    valueOfQtyOfItem = 0;
                                    CountofRecipeItemData++;
                                    break;
                                }
                            }
                            else if (UnitQty == SecondUnit)
                            {
                                Qty = (((Convert.ToDouble(reader2["Qty"])) - ((Convert.ToDouble(RecipeQty)) * (Convert.ToDouble(QtyofRecipetxt.Text)) * (Convert.ToDouble(reader2["Qty"]) * Convert.ToDouble(secondWeight)))) * Convert.ToDouble(YeildofQty) / 100);
                                if (Qty < 0)
                                {
                                    valueOfQtyOfItem -= ((Convert.ToDouble(reader2["Qty"]) * Convert.ToDouble(secondWeight)) * Convert.ToDouble(YeildofQty) / 100);
                                    RecipeItemDData[CountofRecipeItemData, 0] = reader["Code"].ToString();
                                    RecipeItemDData[CountofRecipeItemData, 1] = "0";
                                    CountofRecipeItemData++;
                                }
                                else
                                {
                                    RecipeItemDData[CountofRecipeItemData, 0] = reader["Code"].ToString();
                                    RecipeItemDData[CountofRecipeItemData, 1] = Qty.ToString();
                                    CountofRecipeItemData++;
                                    valueOfQtyOfItem = 0;
                                    break;
                                }
                            }
                        }
                    }
                    reader2.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                con2.Close();
            }
            if(valueOfQtyOfItem >0 || valueOfQtyOfItem < 0)
            {
                valuoofboolFunction= false;
            }
            else
            {
                valuoofboolFunction = true;
            }
            return valuoofboolFunction;
        }  //Done*/

        public bool Dochecks(string valofRecipee,string RecipeQty,string Unit)
        {
            checksofParent = true;
            ToFinishFunction = true;
            string BaseWeight = "";string BaseUnit = ""; string secondWeight = ""; string SecondUnit = "";string YeildofQty = "";
            bool boooolCHeck = true; bool CheckIfParentVal = true;
            double Qty = 0;
            SqlConnection con = new SqlConnection(connString);
            SqlConnection con2 = new SqlConnection(connString);
            SqlDataReader reader = null;
            SqlDataReader reader2 = null;
            try
            {
                con.Open();
                string q = "SELECT Item_Code,Qty,Recipe_Unit FROM Setup_RecipeItems Where Item_Code <> '' AND Recipe_Code=" + valofRecipee;
                SqlCommand cmd = new SqlCommand(q, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CheckIfParentVal = CheckIfParent(reader["Item_Code"].ToString());
                    if (CheckIfParentVal == true)
                    {
                        ParentItemInRecipe parentItem = new ParentItemInRecipe(reader["Item_Code"].ToString(),reader["Qty"].ToString(),reader["Recipe_Unit"].ToString(),RecipeQty,Unit, QtyofRecipetxt.Text,valofStore,ValOfKitchen,this);
                         parentItem.ShowDialog();
                        isParent = true;
                        if(ToFinishFunction==true)
                        {
                            boooolCHeck = false;
                        }
                    }
                    else
                    {
                        con2.Open();
                        string W = "SELECT Weight,Unit,Unit2,ConvUnit2,Yield FROM Setup_Items WHERE Code=" + reader["Item_Code"].ToString();
                        SqlCommand cmd2 = new SqlCommand(W, con2);
                        reader2 = cmd2.ExecuteReader();
                        while (reader2.Read())
                        {
                            YeildofQty = reader2["Yield"].ToString();
                            BaseWeight = reader2["Weight"].ToString();
                            BaseUnit = reader2["Unit"].ToString();
                            SecondUnit = reader2["Unit2"].ToString();
                            secondWeight = reader2["ConvUnit2"].ToString();
                        }
                        reader2.Close();
                        string w = "SELECT Qty,MinNumber,MaxNumber,Units,Current_Cost FROM Items WHERE RestaurantID=" + valofStore + " AND ItemID=" + reader["Item_Code"].ToString() + " AND KitchenID=" + ValOfKitchen;
                        cmd2 = new SqlCommand(w, con2);
                        reader2 = cmd2.ExecuteReader();
                        if (reader2.HasRows ==true )
                        {
                            while (reader2.Read())
                            {
                                if (reader["Recipe_Unit"].ToString() == BaseUnit)
                                {
                                    Qty = (((Convert.ToDouble(reader2["Qty"])) - (((Convert.ToDouble(RecipeQty)) * (Convert.ToDouble(QtyofRecipetxt.Text)) * (Convert.ToDouble(reader["Qty"]))) / Convert.ToDouble(BaseWeight))) * Convert.ToDouble(YeildofQty) / 100);
                                    if (Qty < 0)
                                    {
                                        boooolCHeck = false;
                                    }
                                    else
                                    {
                                        RecipeItemDData[CountofRecipeItemData, 0] = reader["Item_Code"].ToString();
                                        RecipeItemDData[CountofRecipeItemData, 1] = reader["Qty"].ToString();
                                        RecipeItemDData[CountofRecipeItemData, 2] = ((Convert.ToDouble(RecipeQty)) * (Convert.ToDouble(QtyofRecipetxt.Text)) * (Convert.ToDouble(reader["Qty"])) * (Convert.ToDouble(YeildofQty) / 100) * (Convert.ToDouble(reader2["Current_Cost"]))).ToString();
                                        CountofRecipeItemData++;
                                    }
                                }
                                else if (reader["Recipe_Unit"].ToString() == SecondUnit)
                                {
                                    Qty = (((Convert.ToDouble(reader2["Qty"])) - (((Convert.ToDouble(RecipeQty)) * (Convert.ToDouble(QtyofRecipetxt.Text)) * (Convert.ToDouble(reader["Qty"]) / Convert.ToDouble(secondWeight))) / Convert.ToDouble(BaseWeight))) * Convert.ToDouble(YeildofQty) / 100);
                                    if (Qty < 0)
                                    {
                                        boooolCHeck = false;
                                    }
                                    else
                                    {
                                        RecipeItemDData[CountofRecipeItemData, 0] = reader["Item_Code"].ToString();
                                        RecipeItemDData[CountofRecipeItemData, 1] = reader["Qty"].ToString();
                                        RecipeItemDData[CountofRecipeItemData, 2] = ((Convert.ToDouble(RecipeQty)) * (Convert.ToDouble(QtyofRecipetxt.Text)) * (Convert.ToDouble(reader["Qty"])) * (Convert.ToDouble(secondWeight)) * (Convert.ToDouble(YeildofQty) / 100) * (Convert.ToDouble(reader2["Current_Cost"]))).ToString();
                                        CountofRecipeItemData++;
                                    }
                                }
                            }
                        }
                        else
                            boooolCHeck = false;
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
                reader.Close();
                con.Close();
            }
            if(boooolCHeck == true)
            {
                ToFinishFunction = false;
            }


            return boooolCHeck;
        }   //Done
        public void UpddateQty()
        {
            string valOfGenerate = "";
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                con.Open();
                string E = "Select Top(1)Generate_ID From GenerateRecipe_tbl ORDER BY Generate_ID DESC";
                cmd = new SqlCommand(E, con);
                if (cmd.ExecuteScalar() == null)
                {
                    valOfGenerate = "1";
                }
                else
                {
                    valOfGenerate = (int.Parse(cmd.ExecuteScalar().ToString()) + 1).ToString();
                }
                con.Close();
            }
            catch { }


            try
            {
                con.Open();
                string s = string.Format("Insert into GenerateRecipe_tbl(Generate_ID,Generate_Date,Resturant_ID,Kitchen_ID,Recipe_ID,Qty) Values ({0},GETDATE(),{1},{2},{3},{4})",valOfGenerate,valofStore,ValOfKitchen,valofRecipe, QtyofRecipetxt.Text);
                cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
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
                for(int i=0;i<CountofRecipesData;i++)
                {
                    string s = string.Format("Update RecipeQty SEt Qty=Qty-{1} Where Recipe_ID='{0}' AND Resturant_ID={2} AND Kitchen_ID={3}", RecipesData[i,0], Convert.ToDouble(RecipesData[i,1]),valofStore,ValOfKitchen);
                    cmd = new SqlCommand(s, con);
                    cmd.ExecuteNonQuery();
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
            double CostOfrecipe = 0;
            for (int i = 0; i < CountofRecipeItemData; i++)
            {
                CostOfrecipe += Convert.ToDouble(RecipeItemDData[i, 2]);
            }
                try
            {
                con.Open();
                string s = "SELECT Recipe_ID FROM RecipeQty WHERE Recipe_ID=" + valofRecipe;
                cmd = new SqlCommand(s, con);
                if(cmd.ExecuteScalar() == null)
                {
                    s = string.Format("INSERT INTO RecipeQty Values({0},{1},{2},{3},{4})", valofRecipe, Convert.ToDouble(QtyofRecipetxt.Text),valofStore,ValOfKitchen, CostOfrecipe);
                    cmd = new SqlCommand(s, con);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    s = string.Format("Update RecipeQty SEt Qty=Qty+{1},Price={4} Where Recipe_ID={0} AND Resturant_ID={2} AND Kitchen_ID={3}", valofRecipe, Convert.ToDouble(QtyofRecipetxt.Text),valofStore,ValOfKitchen,CostOfrecipe);
                    cmd = new SqlCommand(s, con);
                    cmd.ExecuteNonQuery();
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
            ////////////////////////
            try
            {
                con.Open();
                for(int i=0;i< CountofRecipeItemData;i++)
                {
                    string s = string.Format("Insert into GenerateRecipe_Items(Generate_ID,Item_ID,ItemQty) Values ({0},'{1}',{2})", valOfGenerate, RecipeItemDData[i,0], RecipeItemDData[i,1]);
                    cmd = new SqlCommand(s, con);
                    cmd.ExecuteNonQuery();
                }
                for (int i = 0; i <CountofRecipesData; i++)
                {
                    string s = string.Format("Insert into GenerateRecipe_Items(Generate_ID,reccipe_ID,RecipeQty) Values ({0},'{1}',{2})", valOfGenerate, RecipesData[i, 0], RecipesData[i, 1]);
                    cmd = new SqlCommand(s, con);
                    cmd.ExecuteNonQuery();
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

            try
            {
                con.Open();
                for(int i=0;i< CountofRecipeItemData;i++)
                {
                    string w = "Update Items set Qty=Qty-" + RecipeItemDData[i,1] + " Where RestaurantID=" + valofStore + "AND ItemID=" + RecipeItemDData[i,0] + "And KitchenID=" + ValOfKitchen;
                    cmd = new SqlCommand(w, con);
                    cmd.ExecuteNonQuery();

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
        }   //Done
        public bool ItsRecipe(string Recipe, string RecipeQTy,string Unit)
        {
            bool DoneRecipe = true;
            bool boolianCheck;
            SqlDataReader reader2 = null;
            SqlConnection con2 = new SqlConnection(connString);
            SqlCommand cmd2 = new SqlCommand();
             boolianCheck = Dochecks(Recipe, RecipeQTy, Unit);
            if (boolianCheck == true)
            {
                try
                {
                    con2.Open();
                    string w = "SELECT Recipe_ID,Item_Code,Qty,Recipe_Unit FROM Setup_RecipeItems WHERE Recipe_Code=" + Recipe;
                    cmd2 = new SqlCommand(w, con2);
                    reader2 = cmd2.ExecuteReader();
                    while (reader2.Read())
                    {
                        if (reader2["Recipe_ID"].ToString() != "" && reader2["Item_Code"].ToString() == "")
                        {
                            RecipesData[CountofRecipesData, 0] = reader2["Recipe_ID"].ToString();
                            RecipesData[CountofRecipesData, 1] = reader2["Qty"].ToString();
                            CountofRecipesData++;
                            ItsRecipe(reader2["Recipe_ID"].ToString(), reader2["Qty"].ToString(),reader2["Recipe_Unit"].ToString());
                        }
                    }
                }
            catch { }
            }
            else
            {
                DoneRecipe = false;
            }
            return DoneRecipe;
        }    //Done
    }
}

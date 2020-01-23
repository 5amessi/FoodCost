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
    /// Interaction logic for AllRecipes.xaml
    /// </summary>
    public partial class AllRecipes : Window
    {
        public AllRecipes()
        {
            InitializeComponent();
        }
        Recipes recipes;
        public AllRecipes(Recipes _recipes)
        {
            InitializeComponent();
            LoadToGrid();
            recipes = _recipes;
        }

        public void LoadToGrid()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
                DataTable dt = new DataTable();

                using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Setup_Recipes", con))
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

        private void AllRecipesDGV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string cost = "";
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            DataRowView drv = ReciveOrdersOrderDGV.SelectedItem as DataRowView;
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
            //dt = recipes.RecipesDGV.DataContext as DataTable;

            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    if (recipes.RecipesDGV.DataContext != null)
                    {
                        dt = recipes.RecipesDGV.DataContext as DataTable;
                        for (int i = 0; i < dt.Rows.Count; i++)
                            if (dt.Rows[i]["Recipe_Code"].ToString() == drv.Row.ItemArray[0].ToString())
                            {
                                MessageBox.Show("Item Existed");
                                return;
                            }
                    }
                    
                    //if (recipes.RecipesDGV.DataContext != null)
                    //    dt = recipes.RecipesDGV.DataContext as DataTable;

                    try
                    {
                        con.Open();
                        string s = string.Format("select Price from RecipeQty where Recipe_ID={0}", drv.Row.ItemArray[0].ToString());
                        cmd = new SqlCommand(s, con);
                        if (cmd.ExecuteScalar() == null)
                        {
                            cost = "0";
                        }
                        else
                        {
                            cost = cmd.ExecuteScalar().ToString();

                        }
                    }
                    catch { }
                    dt.Rows.Add( "", (((DataRowView)grid.SelectedItem).Row.ItemArray[0]).ToString(), (((DataRowView)grid.SelectedItem).Row.ItemArray[2]).ToString(), (((DataRowView)grid.SelectedItem).Row.ItemArray[3]).ToString(), "1", (((DataRowView)grid.SelectedItem).Row.ItemArray[8]).ToString(),cost,cost,"");
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
                }
                recipes.RecipesDGV.DataContext = dt;

                //if (recipes.RecipesDGV.Items.Count != 0)
                //{
                //    (recipes.RecipesDGV.Items[recipes.RecipesDGV.Items.Count - 1] as DataRowView).Row[7] = (recipes.RecipesDGV.Items[recipes.RecipesDGV.Items.Count - 1] as DataRowView).Row[6];
                //    double sum = 0;
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        sum += Convert.ToDouble((recipes.RecipesDGV.Items[i] as DataRowView).Row.ItemArray[7]);
                //    }

                //    double _sum = 0;
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        _sum = (Convert.ToDouble((recipes.RecipesDGV.Items[i] as DataRowView).Row.ItemArray[7]) / sum) * 100;
                //        (recipes.RecipesDGV.Items[i] as DataRowView).Row[8] = _sum.ToString() + " %";
                //    }
                //}
            }

            this.Close();
        }

        private void TextDataChange(object sender, TextChangedEventArgs e)
        {
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
                        //lsa 7etet el weight fe el select
                        string Q = "SELECT * FROM Setup_Recipes Where Code Like '%" + SearchTxt.Text + "%'";
                        DataTable dt = new DataTable();

                        using (SqlDataAdapter da = new SqlDataAdapter(Q, con))
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
                        //lsa 7etet el weight fe el select
                        string Q = "SELECT * FROM Setup_Recipes Where Name Like '%" + SearchTxt.Text + "%'";
                        DataTable dt = new DataTable();

                        using (SqlDataAdapter da = new SqlDataAdapter(Q, con))
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
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Setup_Recipes", con))
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
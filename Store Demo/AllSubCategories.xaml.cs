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
    /// Interaction logic for AllSubCategories.xaml
    /// </summary>
    public partial class AllSubCategories : Window
    {
        Recipes recipe;
        string vaal;
        string v = "";
        public AllSubCategories(Recipes _Recipe, string val)
        {
            InitializeComponent();
            vaal = val;
            LoadAllCategories(vaal);
            recipe = _Recipe;

        }

        public void LoadAllCategories(string val)
        {
            v = val;
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;

            try
            {
                con.Open();
                string q = "SELECT Code,Name,Name2,IsActive From  Setup_RecipeSubCategories Where Category_ID=" + val;
                SqlCommand cmd = new SqlCommand(q, con);
                //SqlCommand cmd = new SqlCommand("GetSubCategorieswithCategory", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Code", val);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), Name2 = reader["Name2"].ToString(), IsActive = reader["IsActive"].ToString() };
                    SubCategories.Items.Add(data);
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


        private void MouseDoubleClick_click(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    this.Close();
                    recipe.SUBCategorytxt.Text = ((DgvData)grid.SelectedItem).Name;
                    recipe.SUBCategtxt.Text = ((DgvData)grid.SelectedItem).Code;
                    return;
                }


            }
        }

        private void TextDataChange(object sender, TextChangedEventArgs e)
        {
            SqlDataReader reader = null;
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            if ((RadioByCode.IsChecked == true || RadioByName.IsChecked == true) && SearchTxt.Text != "")
            {
                if (RadioByCode.IsChecked == true && RadioByName.IsChecked == false)
                {
                    SubCategories.Items.Clear();
                    try
                    {
                        con.Open();
                        string q = "SELECT Code,Name,Name2,IsActive From  Setup_RecipeSubCategories Where Category_ID=" + v+" AND Code Like '%" + SearchTxt.Text + "%'";
                        SqlCommand cmd = new SqlCommand(q, con);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), Name2 = reader["Name2"].ToString(), IsActive = reader["IsActive"].ToString() };
                            SubCategories.Items.Add(data);
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
                }
                else if (RadioByName.IsChecked == true && RadioByCode.IsChecked == false)
                {
                    SubCategories.Items.Clear();
                    try
                    {
                        con.Open();
                        string q = "SELECT Code,Name,Name2,IsActive From  Setup_RecipeSubCategories Where Category_ID = " + v+" AND Name Like '%" + SearchTxt.Text + "%'";
                        SqlCommand cmd = new SqlCommand(q, con);
                        //SqlCommand cmd = new SqlCommand("GetCategory", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), Name2 = reader["Name2"].ToString(), IsActive = reader["IsActive"].ToString() };
                            SubCategories.Items.Add(data);
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
                }                
            }
            else
            {
                SubCategories.Items.Clear();
                try
                {
                    con.Open();
                    string q = "SELECT Code,Name,Name2,IsActive From  Setup_RecipeSubCategories Where Category_ID=" + v;
                    SqlCommand cmd = new SqlCommand(q, con);
                    //SqlCommand cmd = new SqlCommand("GetCategory", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), Name2 = reader["Name2"].ToString(), IsActive = reader["IsActive"].ToString() };
                        SubCategories.Items.Add(data);
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
            }
        }
    }
}

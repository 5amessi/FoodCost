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
    /// Interaction logic for AllCategories.xaml
    /// </summary>
    public partial class AllCategories : Window
    {
        Recipes recipe;
        CategoriesAndSub _categoriesAndSub;
        bool val = true;
        public AllCategories(CategoriesAndSub categoriesAndSub)
        {
            InitializeComponent();
            LoadAllCategories();
            _categoriesAndSub = categoriesAndSub;
            val = false;
        }
        public AllCategories(Recipes _Recipes)
        {
            InitializeComponent();
            LoadAllCategories();
            recipe = _Recipes;
        }

        public void LoadAllCategories()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;

            try
            {
                con.Open();
                string q = "select Code, Name, Name2, IsActive from Setup_RecipeCategory";
                SqlCommand cmd = new SqlCommand(q, con);
                //SqlCommand cmd = new SqlCommand("GetCategory", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), Name2 = reader["Name2"].ToString(), IsActive = reader["IsActive"].ToString() };
                    CategoryDGV.Items.Add(data);
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

        private void Newbtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            UserControl UC = new CategoriesAndSub();
            parentdrid.Children.Clear();
            parentdrid.Children.Add(UC);
        }

        private void MouseDoubleClick_click(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    this.Close();
                    if (val == false)
                        _categoriesAndSub.Categorycbx.Text = ((DgvData)grid.SelectedItem).Name;
                    else
                    {
                        recipe.Categorytxt.Text = ((DgvData)grid.SelectedItem).Name;
                        recipe.Categtxt.Text = ((DgvData)grid.SelectedItem).Code;
                    }
                    val = true;
                    return;

                }


            }
        }

        private void TextDataChange(object sender, TextChangedEventArgs e)
        {
            SqlDataReader reader = null;
            //CategoryDGV.DataContext = null;
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            if ((RadioByCode.IsChecked == true || RadioByName.IsChecked == true) && SearchTxt.Text != "")
            {
                
                //CategoryDGV.ItemsSource = null;
                if (RadioByCode.IsChecked == true && RadioByName.IsChecked == false)
                {
                    CategoryDGV.Items.Clear();
                    try
                    {
                        con.Open();
                        string q = "select Code, Name, Name2, IsActive from Setup_RecipeCategory Where Code Like '%" + SearchTxt.Text + "%'";
                        SqlCommand cmd = new SqlCommand(q, con);
                        //SqlCommand cmd = new SqlCommand("GetCategory", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), Name2 = reader["Name2"].ToString(), IsActive = reader["IsActive"].ToString() };
                            CategoryDGV.Items.Add(data);
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
                    CategoryDGV.Items.Clear();
                    try
                    {
                        con.Open();
                        string q = "select Code, Name, Name2, IsActive from Setup_RecipeCategory Where Name Like '%" + SearchTxt.Text + "%'";
                        SqlCommand cmd = new SqlCommand(q, con);
                        //SqlCommand cmd = new SqlCommand("GetCategory", con);
                        //cmd.CommandType = CommandType.StoredProcedure;
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), Name2 = reader["Name2"].ToString(), IsActive = reader["IsActive"].ToString() };
                            CategoryDGV.Items.Add(data);
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
                CategoryDGV.Items.Clear();
                try
                {
                    con.Open();
                    string q = "select Code, Name, Name2, IsActive from Setup_RecipeCategory";
                    SqlCommand cmd = new SqlCommand(q, con);
                    //SqlCommand cmd = new SqlCommand("GetCategory", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var data = new DgvData { Code = reader["Code"].ToString(), Name = reader["Name"].ToString(), Name2 = reader["Name2"].ToString(), IsActive = reader["IsActive"].ToString() };
                        CategoryDGV.Items.Add(data);
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

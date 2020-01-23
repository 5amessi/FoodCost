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
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Food_Cost
{
    /// <summary>
    /// Interaction logic for CategoriesAndSub.xaml
    /// </summary>
    public partial class CategoriesAndSub : UserControl
    {
        public CategoriesAndSub()
        {
            InitializeComponent();
            FillDGV();
            //LoadAllCategories();
            MainUiFormat();
            FillSubDGV();
            MainUiSubFormat();
        }

        public CategoriesAndSub(string Name)
        {
            this.Categorycbx.Text = Name;
        }

        //functions of Caategories 
        private void FillDGV()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;

            try
            {
                con.Open();
                string s = "select Code,Name,Name2,IsActive from Setup_RecipeCategory";
                SqlCommand cmd = new SqlCommand(s, con);
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

        public void MainUiFormat()
        {
            Code_txt.IsEnabled = false;
            Name_txt.IsEnabled = false;
            Name2_txt.IsEnabled = false;
            Active_chbx.IsEnabled = false;
            SaveBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            UndoBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
            NewBtn.IsEnabled = true;

        }

        public void EnableUI()
        {
            Code_txt.IsEnabled = true;
            Name_txt.IsEnabled = true;
            Name2_txt.IsEnabled = true;
            Active_chbx.IsEnabled = true;
            SaveBtn.IsEnabled = true;
            UpdateBtn.IsEnabled = true;
            UndoBtn.IsEnabled = true;
            DeleteBtn.IsEnabled = true;
            NewBtn.IsEnabled = true;
            Categorycbx.IsEnabled = true;
        }

        private void ClearUIFields()
        {
            Code_txt.Text = "";
            Name_txt.Text = "";
            Name2_txt.Text = "";
            Active_chbx.IsChecked = false;
        }

        private void NewButtonClicked(object sender, RoutedEventArgs e)
        {
            EnableUI();
            ClearUIFields();
            NewBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Code_txt.Text == "")
            {
                MessageBox.Show("Code Field Can't Be Empty");
                return;
            }

            foreach (DgvData item in CategoryDGV.Items)
            {
                if (item.Code.Equals(Code_txt.Text))
                {
                    MessageBox.Show("This Code Is Not Avaliable");
                    return;
                }
            }

            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();
                string s = "insert into Setup_RecipeCategory(Code, Name, Name2, IsActive) values (" + Code_txt.Text + ",'" + Name_txt.Text +"','" + Name2_txt.Text + "','" + Active_chbx.IsChecked +"')";
                SqlCommand cmd = new SqlCommand(s, con);
                //SqlCommand cmd = new SqlCommand("InsertSetup_Category", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Code", Code_txt.Text);
                //cmd.Parameters.AddWithValue("@Name", Name_txt.Text);
                //cmd.Parameters.AddWithValue("@Name2", Name2_txt.Text);
                //cmd.Parameters.AddWithValue("@IsActive", Active_chbx.IsChecked);
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

                CategoryDGV.Items.Clear();
                FillDGV();
            }
            MessageBox.Show("Saved Successfully");
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();
                string s = "Update Setup_RecipeCategory SET Name='" + Name_txt.Text +
                                               "',Name2='" + Name2_txt.Text +
                                               "',IsActive='" + Active_chbx.IsChecked +
                                               "'Where Code =" + Code_txt.Text;
                SqlCommand cmd = new SqlCommand(s, con);

                //SqlCommand cmd = new SqlCommand("UpdateSetup_Category", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Code", Code_txt.Text);
                //cmd.Parameters.AddWithValue("@Name", Name_txt.Text);
                //cmd.Parameters.AddWithValue("@Name2", Name2_txt.Text);
                //cmd.Parameters.AddWithValue("@IsActive", Active_chbx.IsChecked);

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

                CategoryDGV.Items.Clear();
                FillDGV();
            }
            MessageBox.Show("Updated Successfully");
        }

        private void UndoBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUiFormat();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            string checkRecipe = ""; string checkSubCat = "";
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
                string s = "SELECT Category_ID FROM Setup_Recipes Where Category_ID=" + Code_txt.Text;
                SqlCommand cmd = new SqlCommand(s, con);
                if(cmd.ExecuteScalar() != null)
                    checkRecipe = cmd.ExecuteScalar().ToString();
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
                string s = "SELECT Category_ID FROM Setup_RecipeSubCategories Where Category_ID=" + Code_txt.Text;
                SqlCommand cmd = new SqlCommand(s, con);
                if (cmd.ExecuteScalar() != null)
                    checkSubCat = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
 
            if (checkRecipe != Code_txt.Text && checkSubCat != Code_txt.Text)
            {
                try
                {
                    con.Open();
                    string s = "Delete Setup_RecipeCategory Where Code =" + Code_txt.Text;
                    SqlCommand cmd = new SqlCommand(s, con);
                    //SqlCommand cmd = new SqlCommand("DeleteSetup_Category", con);
                    //cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@Code", Code_txt.Text);
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

                    CategoryDGV.Items.Clear();
                    FillDGV();
                }
                MessageBox.Show("Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Can't Delete this Category");
                checkRecipe = "";
                checkSubCat = "";
            }
            
        }

        private void RowClicked(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid data = sender as DataGrid;

                if (data != null && data.SelectedItems != null && data.SelectedItems.Count == 1)
                {
                    DgvData dgvData = (DgvData)data.SelectedItem;

                    Code_txt.Text = dgvData.Code;
                    Name_txt.Text = dgvData.Name;
                    Name2_txt.Text = dgvData.Name2;
                    Active_chbx.IsChecked = dgvData.IsActive.ToLower().Equals("true");

                    EnableUI();
                    Code_txt.IsEnabled = false;
                    NewBtn.IsEnabled = false;
                    SaveBtn.IsEnabled = false;
                }
            }
        }

        // Functions Of sub Categories 

        private void FillSubDGV()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlConnection con2 = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            SqlDataReader reader = null;

            DataTable dt = new DataTable();
            dt.Columns.Add("Code");
            dt.Columns.Add("Name");
            dt.Columns.Add("Name2");
            dt.Columns.Add("Active");
            dt.Columns.Add("Category");


            try
            {
                con.Open();
                string s = "SELECT* FROM Setup_RecipeSubCategories";
                cmd = new SqlCommand(s, con);
                //cmd = new SqlCommand("GetSubCategory", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                reader = cmd.ExecuteReader();

                List<DgvData> SubCatData = new List<DgvData>();
                while (reader.Read())
                {
                    string category = "";
                    try
                    {
                        con2.Open();
                        string s1 = "SELECT Name From Setup_RecipeCategory Where Code =" + int.Parse(reader["Category_ID"].ToString());
                        cmd1 = new SqlCommand(s1, con2);
                        category = (cmd1.ExecuteScalar()).ToString();
                        con2.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        con2.Close();
                    }

                    dt.Rows.Add(reader["Code"].ToString(), reader["Name"].ToString(), reader["Name2"].ToString(), reader["IsActive"].ToString(), category);
                }
                SubCategoryDGV.DataContext = dt;
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

        public void MainUiSubFormat()
        {
            CodeSub_txt.IsEnabled = false;
            NameSub_txt.IsEnabled = false;
            Name2Sub_txt.IsEnabled = false;
            Categorycbx.IsEnabled = false;
            ActiveSub_chbx.IsEnabled = false;
            SaveSubBtn.IsEnabled = false;
            UpdateSubBtn.IsEnabled = false;
            UndoSubBtn.IsEnabled = false;
            DeleteSubBtn.IsEnabled = false;
            NewSubBtn.IsEnabled = true;
            GetCategoryBtn.IsEnabled = false;

        }

        public void EnableSubUI()
        {
            CodeSub_txt.IsEnabled = true;
            NameSub_txt.IsEnabled = true;
            Name2Sub_txt.IsEnabled = true;
            Categorycbx.IsEnabled = true;
            ActiveSub_chbx.IsEnabled = true;
            SaveSubBtn.IsEnabled = true;
            UpdateSubBtn.IsEnabled = true;
            UndoSubBtn.IsEnabled = true;
            DeleteSubBtn.IsEnabled = true;
            NewSubBtn.IsEnabled = true;
            GetCategoryBtn.IsEnabled = true;

        }

        private void ClearSubUIFields()
        {
            CodeSub_txt.Text = "";
            NameSub_txt.Text = "";
            Name2Sub_txt.Text = "";
            Categorycbx.Text = "";
            ActiveSub_chbx.IsChecked = false;
        }

        private void NewButtonSubClicked(object sender, RoutedEventArgs e)
        {
            EnableSubUI();
            ClearSubUIFields();
            NewSubBtn.IsEnabled = false;
            UpdateSubBtn.IsEnabled = false;
            DeleteSubBtn.IsEnabled = false;
        }

        private void SaveSubBtn_Click(object sender, RoutedEventArgs e)
        {
            int val = 0;
            if (CodeSub_txt.Text == "")
            {
                MessageBox.Show("Code Field Can't Be Empty");
                return;
            }
            if (Categorycbx.Text == "")
            {
                MessageBox.Show("Category Field Can't Be Empty");
                return;
            }

            foreach (DataRowView item in SubCategoryDGV.Items)
            {
                if (item.Row["Code"].Equals(CodeSub_txt.Text))
                {
                    MessageBox.Show("This Code Is Not Avaliable");
                    return;
                }
            }

            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            try
            {
                string s = "Select Code From Setup_RecipeCategory Where Name='" + Categorycbx.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(s, con);
                val = int.Parse(cmd.ExecuteScalar().ToString());
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
                string q = "Insert into Setup_RecipeSubCategories (Code,Name,Name2,IsActive,Category_ID) values (" + CodeSub_txt.Text + ",'" + NameSub_txt.Text + "','" + Name2Sub_txt.Text + "','" + ActiveSub_chbx.IsChecked + "','" + val+ "')";
                SqlCommand cmd = new SqlCommand(q, con);
                //SqlCommand cmd = new SqlCommand("InsertSetup_SubCategory", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Code", CodeSub_txt.Text);
                //cmd.Parameters.AddWithValue("@Name", NameSub_txt.Text);
                //cmd.Parameters.AddWithValue("@Name2", Name2Sub_txt.Text);
                //cmd.Parameters.AddWithValue("@IsActive", ActiveSub_chbx.IsChecked);
                //cmd.Parameters.AddWithValue("@Category", val);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                MainUiSubFormat();
                //SubCategoryDGV.ItemsSource = null;
                FillSubDGV();
            }
            MessageBox.Show("Saved Successfully");
        }

        private void UpdateSubBtn_Click(object sender, RoutedEventArgs e)
        {
            int val = 0;
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                string s = "Select Code From Setup_RecipeCategory Where Name='" + Categorycbx.Text + "'";
                con.Open();
                SqlCommand cmd = new SqlCommand(s, con);
                val = int.Parse(cmd.ExecuteScalar().ToString());
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
                string q = "Update Setup_RecipeSubCategories SET Name='" + NameSub_txt.Text +
                                               "',Name2='" + Name2Sub_txt.Text +
                                               "',IsActive='" + ActiveSub_chbx.IsChecked +
                                               "',Category_ID='" + val +
                                               "' Where Code =" + CodeSub_txt.Text; ;

                SqlCommand cmd = new SqlCommand(q, con);
                //SqlCommand cmd = new SqlCommand("UpdateSetup_SubCategory", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@Code", CodeSub_txt.Text);
                //cmd.Parameters.AddWithValue("@Name", NameSub_txt.Text);
                //cmd.Parameters.AddWithValue("@Name2", Name2Sub_txt.Text);
                //cmd.Parameters.AddWithValue("@IsActive", ActiveSub_chbx.IsChecked);
                //cmd.Parameters.AddWithValue("@Category", val);

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                MainUiSubFormat();

                //SubCategoryDGV.ItemsSource = null;
                FillSubDGV();
            }
            MessageBox.Show("Updated Successfully");
        }

        private void UndoSubBtn_Click(object sender, RoutedEventArgs e)
        {
            MainUiSubFormat();
        }

        private void DeleteSubBtn_Click(object sender, RoutedEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            string checkRecipe = "";
            try
            {
                con.Open();
                string s = "SELECT SubCategory_ID FROM Setup_Recipes Where SubCategory_ID=" + CodeSub_txt.Text;
                SqlCommand cmd = new SqlCommand(s, con);
                if(cmd.ExecuteScalar() != null)
                    checkRecipe = cmd.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            if (checkRecipe != CodeSub_txt.Text)
            {
                try
                {
                    con.Open();
                    string q = "Delete Setup_RecipeSubCategories Where Code=" + CodeSub_txt.Text;
                    SqlCommand cmd = new SqlCommand(q, con);
                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    con.Close();
                    MainUiSubFormat();
                    FillSubDGV();
                }
                MessageBox.Show("Deleted Successfully");
            }
            else
            {
                MessageBox.Show("Can't delete this Sub Category");
                checkRecipe = "";
            }
        }

        private void SubRowClicked(object sender, MouseButtonEventArgs e)
        {

            if (sender != null)
            {
                DataGrid data = sender as DataGrid;

                try
                {
                    if (data != null && data.SelectedItems != null && data.SelectedItems.Count == 1)
                    {
                        DataRow dr = ((e.Source as DataGrid).CurrentItem as DataRowView).Row;


                        //DataTable dgvData = data.SelectedItem;

                        CodeSub_txt.Text = dr["Code"].ToString();
                        NameSub_txt.Text = dr["Name"].ToString();
                        Name2Sub_txt.Text = dr["Name2"].ToString();
                        ActiveSub_chbx.IsChecked = dr["Active"].ToString() != "False";
                        Categorycbx.Text = dr["Category"].ToString();


                        EnableSubUI();
                        CodeSub_txt.IsEnabled = false;
                        NewSubBtn.IsEnabled = false;
                        SaveSubBtn.IsEnabled = false;
                    }
                }
                catch { }
            }

        }

        private void CategoryBtn(object sender, RoutedEventArgs e)
        {
            AllCategories allCategories = new AllCategories(this);
            allCategories.ShowDialog();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        //public void LoadAllCategories()
        //{
        //    string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
        //    SqlConnection con = new SqlConnection(connString);
        //    SqlDataReader reader = null;
        //    try
        //    {
        //        con.Open();
        //        string s = "select Name from Setup_RecipeCategory";
        //        SqlCommand cmd = new SqlCommand(s, con);
        //        reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {
        //            var data = reader["Name"].ToString();
        //            Categorycbx.Text = data;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        reader.Close();
        //        con.Close();
        //    }
        //}
    }
}

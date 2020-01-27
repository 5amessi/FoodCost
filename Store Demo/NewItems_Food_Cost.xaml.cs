using Microsoft.Win32;
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
    /// Interaction logic for NewItems_Food_Cost_.xaml
    /// 
    /// setup code not implemented yet
    /// </summary>
    public partial class NewItems_Food_Cost : UserControl
    {
        TreeViewItem UndifinedExists = null;


        public NewItems_Food_Cost()
        {
            InitializeComponent();

            LoadCategoryinTreeView();
            List<TreeViewItem> classNodes = LoadDepartmentinTreeView();
            List<TreeViewItem> subclassNodes = LoadClassesinTreeView(classNodes);
            List<TreeViewItem> ItemsNodes = LoadSubClassesinTreeView(subclassNodes);
            LoadItemsinTreeView(ItemsNodes);
        }

        private void LoadItemsinTreeView(List<TreeViewItem> itemsNodes)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            try
            {
                con.Open();
                
                string s;
                for (int i = 0; i < itemsNodes.Count; i++)
                {
                    s = string.Format(@"SELECT dbo.Setup_Items.Name FROM Setup_Items WHERE Setup_Items.SUBClass = '{0}'", (itemsNodes[i].Header));

                    SqlCommand cmd = new SqlCommand(s, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string data = reader["Name"].ToString();

                        TreeViewItem treeViewItem = new TreeViewItem();
                        treeViewItem.Header = data;
                        itemsNodes[i].Items.Add(treeViewItem);
                    }
                    reader.Close();
                }

                s = "select Name from Units";
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(s, con))
                    da.Fill(dt);

                unit.Items.Clear();
                unit2.Items.Clear();
                unit_txt1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    unit.Items.Add(dt.Rows[i]["Name"]);
                    unit2.Items.Add(dt.Rows[i]["Name"]);
                    unit_txt1.Items.Add(dt.Rows[i]["Name"]);
                }
                //if (dt.Rows.Count > 0)
                //    unit.Text = unit_txt1.Text = dt.Rows[0]["Name"].ToString();

                PrefVendortxt.Items.Clear();
                SqlCommand _cmd = new SqlCommand("select Name from Vendors", con);
                SqlDataReader _reader = _cmd.ExecuteReader();
                while (_reader.Read())
                    PrefVendortxt.Items.Add(_reader[0]);


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

        //functions
        private void LoadCategoryinTreeView()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;

            try
            {
                con.Open();

                string s = "select Name from Setup_Category order by Code";
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string data = reader["Name"].ToString();
                    //Departmentcbx.Items.Add(data);

                    TreeViewItem treeViewItem = new TreeViewItem();
                    treeViewItem.Header = data;
                    treeViewItems.Items.Add(treeViewItem);
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
        private List<TreeViewItem> LoadDepartmentinTreeView()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            List<TreeViewItem> treeViewItemscopy = new List<TreeViewItem>();

            try
            {
                con.Open();

                for (int i = 0; i < treeViewItems.Items.Count; i++)
                {
                    string s = string.Format(@"SELECT Setup_Department.Name FROM Setup_Department INNER JOIN Setup_Category ON Setup_Category.Code = Setup_Department.CategoryID " +
                                                "WHERE Setup_Category.Name = '{0}'", ((TreeViewItem)treeViewItems.Items[i]).Header);

                    SqlCommand cmd = new SqlCommand(s, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string data = reader["Name"].ToString();

                        TreeViewItem treeViewItem = new TreeViewItem();
                        treeViewItem.Header = data;
                        ((TreeViewItem)treeViewItems.Items[i]).Items.Add(treeViewItem);
                        treeViewItemscopy.Add(treeViewItem);
                    }
                    reader.Close();
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
            return treeViewItemscopy;
        }
        private List<TreeViewItem> LoadClassesinTreeView(List<TreeViewItem> classNodes)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            List<TreeViewItem> treeViewItemscopy = new List<TreeViewItem>();

            try
            {
                con.Open();

                for (int i = 0; i < classNodes.Count; i++)
                {
                    string s = string.Format(@"SELECT Setup_Class.Name FROM Setup_Class INNER JOIN Setup_Department ON Setup_Class.Level1_ID = Setup_Department.Code " +
                                                "WHERE Setup_Department.Name = '{0}'", (classNodes[i].Header));

                    SqlCommand cmd = new SqlCommand(s, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string data = reader["Name"].ToString();

                        TreeViewItem treeViewItem = new TreeViewItem();
                        treeViewItem.Header = data;
                        classNodes[i].Items.Add(treeViewItem);
                        treeViewItemscopy.Add(treeViewItem);
                    }
                    reader.Close();
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
            return treeViewItemscopy;
        }
        private List<TreeViewItem> LoadSubClassesinTreeView(List<TreeViewItem> subclassNodes)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            List<TreeViewItem> treeViewItemscopy = new List<TreeViewItem>();

            try
            {
                con.Open();

                for (int i = 0; i < subclassNodes.Count; i++)
                {
                    string s = string.Format(@"SELECT Setup_SubClass.Name FROM Setup_SubClass INNER JOIN Setup_Class ON Setup_SubClass.Level2_ID = Setup_Class.Code " +
                                                "WHERE Setup_Class.Name = '{0}'", (subclassNodes[i].Header));

                    SqlCommand cmd = new SqlCommand(s, con);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        string data = reader["Name"].ToString();

                        TreeViewItem treeViewItem = new TreeViewItem();
                        treeViewItem.Header = data;
                        subclassNodes[i].Items.Add(treeViewItem);
                        treeViewItemscopy.Add(treeViewItem);
                    }
                    reader.Close();
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
            return treeViewItemscopy;
        }

        private List<TreeViewItem> FindTreeNodes()
        {
            List<TreeViewItem> treeNodes = new List<TreeViewItem>();

            TreeViewItem currentItem = treeViewItems.SelectedItem as TreeViewItem;
            while (currentItem != null)
            {
                treeNodes.Add(currentItem);

                try
                {
                    currentItem = currentItem.Parent as TreeViewItem;
                }
                catch
                {
                    return treeNodes;
                }
            }

            treeNodes.Reverse();
            while (treeNodes.Count != 5)
            {
                TreeViewItem treeViewItem = new TreeViewItem();
                treeViewItem.Header = "Null";
                treeNodes.Add(treeViewItem);
            }

            return treeNodes;
        }
        private bool TreeView_SelectedItem_Checks()
        {
            if (treeViewItems.SelectedItem == null)
                return true;

            else if (((TreeViewItem)treeViewItems.SelectedItem).Header.Equals("Undefined"))
            {
                MessageBox.Show("Can Not Add Child To Undefined");
                return true;
            }

            else if (ItemsGroupBox.IsVisible)
            {
                MessageBox.Show("Can Not Add Child To Items");
                return true;
            }

            return false;
        }

        private List<string> CodeSetupReturn()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;
            List<string> CodeSetup = new List<string>();

            try
            {
                con.Open();

                string s = "select * from Setup_Code";
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CodeSetup.Add(reader["DepCodeDigits"].ToString());
                    CodeSetup.Add(reader["ClassCodeDigits"].ToString());
                    CodeSetup.Add(reader["SubClassCodeDigits"].ToString());
                    CodeSetup.Add(reader["ItemsCodeDigits"].ToString());
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

            return CodeSetup;
        }
        private string TableCode(string tableName)
        {
            string CodeToReturn = "";
            if (tableName == "Setup_Department")
                CodeToReturn = depCodetxt.Text;
            else if (tableName == "Setup_Class")
                CodeToReturn = classCodetxt.Text;
            else if (tableName == "Setup_SubClass")
                CodeToReturn = subclassCodetxt.Text;
            else if (tableName == "Setup_Items")
                CodeToReturn = Codetxt.Text;

            return CodeToReturn;
        }
        private string TableToDeleteFrom()
        {
            List<TreeViewItem> treeNodes = FindTreeNodes();
            string TableName = "";


            if (treeViewItems.SelectedItem == treeNodes[1])
                TableName = "Setup_Department";

            else if (treeViewItems.SelectedItem == treeNodes[2])
                TableName = "Setup_Class";


            else if (treeViewItems.SelectedItem == treeNodes[3])
                TableName = "Setup_SubClass";


            else if (treeViewItems.SelectedItem == treeNodes[4])
                TableName = "Setup_Items";

            return TableName;
        }

        private void ClearGroupBox()
        {
            if (CategoryGroupBox.IsVisible)
            {
                CategoryIDtxt.Text = "";
                CategoryName.Text = "";
                CategoryName2.Text = "";
                CategoryCreatedDatetxt.Text = "";
            }

            else if (DepartmentGroupBox.IsVisible)
            {

                depIDtxt.Text = "";
                depNametxt.Text = "";
                depName2txt.Text = "";
                depCreatedDatetxt.Text = "";
                depModifiedDatetxt.Text = "";
                depDescriptiontxt.Text = "";
            }

            else if (ClassGroupBox.IsVisible)
            {
                classIDtxt.Text = "";
                classNametxt.Text = "";
                className2txt.Text = "";
                classCreatedDatetxt.Text = "";
                classModifiedDatetxt.Text = "";
                classDesctxt.Text = "";
            }

            else if (SubClassGroupBox.IsVisible)
            {
                subclassIDtxt.Text = "";
                subclassNametxt.Text = "";
                subclassName2txt.Text = "";
                subclassCreatedDatetxt.Text = "";
                subclassModifiedtxt.Text = "";
                subclassDesctxt.Text = "";
            }

            else if (ItemsGroupBox.IsVisible)
            {
                Codetxt.Text = "";
                BarCodetxt.Text = "";
                Name1txt.Text = "";
                Name2txt.Text = "";
                Specstxt.Text = "";
                PrefVendortxt.Text = "";
                Categorytxt.Text = "";
                Departmenttxt.Text = "";
                Classtxt.Text = "";
                SubClasstxt.Text = "";
                MUT_cb.IsChecked = false;
                Weight.Text = "";
                unit.Text = "";
                unit2.Text = "";
                unit3.Text = "";
                ConvUnit2.Text = "";
                //ConvUnit3.Text = "";
                Yieldtxt.Text = "";
                CW_cb.IsChecked = false;
                BI_cb.IsChecked = false;
                PI_cb.IsChecked = false;
                HI_cb.IsChecked = false;
                TI_cb.IsChecked = false;
                TI_Value.Text = "";
                ItemImage.Source = new BitmapImage(new Uri(Directory.GetCurrentDirectory() + "\\gray.jpg"));
                Imagetxt.Visibility = Visibility.Visible;
            }
        }
        private bool DoSomeChecks()
        {
            if (Codetxt.Text == "")
            {
                MessageBox.Show("Code is Empty!!!");
                return false;
            }
            else if (Manual_Code_txt.Text == "")
            {
                MessageBox.Show("Manual Code is Empty!!!");

                return false;
            }
            else if (Name1txt.Text == "")
            {
                MessageBox.Show("Name is Empty!!!");

                return false;
            }
            else if (Name2txt.Text == "")
            {
                MessageBox.Show("Name2 is Empty!!!");

                return false;
            }
            else if (Yieldtxt.Text == "")
            {
                MessageBox.Show("Yield is Empty!!!");
                return false;
            }
            else if (Weight.Text == "")
            {
                MessageBox.Show("Weight is Empty!!!");
                return false;
            }
            else if (unit.Text == "")
            {
                MessageBox.Show("Unit is Empty!!!");
                return false;
            }
            return true;
        }
        private void SaveDepartment()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            TreeViewItem item = treeViewItems.SelectedItem as TreeViewItem;
            TreeViewItem parentItem = item.Parent as TreeViewItem;

            try
            {
                con.Open();

                string s = string.Format("select Code from Setup_Category where Name = '{0}'", parentItem.Header);

                SqlCommand cmd = new SqlCommand(s, con);
                string categoryID = cmd.ExecuteScalar().ToString();


                if (item.Header.Equals("Undefined"))
                    s = "insert into Setup_Department(Code,Name,Name2,Description,CreateDate,ModifiedDate,CategoryID,CategoryName) values ('" + depCodetxt.Text + "','" + depNametxt.Text + "','" + depName2txt.Text + "','" + depDescriptiontxt.Text + "','" + depCreatedDatetxt.Text + "','" +
                        depModifiedDatetxt.Text + "','" + categoryID + "','" + parentItem.Header + "')";
                else
                    s = "Update Setup_Department SET Name = '" + depNametxt.Text +
                                                "',Name2='" + depName2txt.Text +
                                                "',Description='" + depDescriptiontxt.Text +
                                                "',CreateDate='" + depCreatedDatetxt.Text +
                                                "',ModifiedDate='" + depModifiedDatetxt.Text +
                                                "',CategoryID='" + categoryID +
                                                "' Where Code =" + depCodetxt.Text;

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
            MessageBox.Show("Saved Successfully");
        }
        private void SaveClass()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            TreeViewItem item = treeViewItems.SelectedItem as TreeViewItem;
            TreeViewItem parentItem = item.Parent as TreeViewItem;

            try
            {
                con.Open();

                string s = string.Format("select Code from Setup_Department where Name = '{0}'", parentItem.Header);

                SqlCommand cmd = new SqlCommand(s, con);
                string departmentID = cmd.ExecuteScalar().ToString();


                if (item.Header.Equals("Undefined"))
                    s = "insert into Setup_Class(Code,Name,Name2,Description,CreateDate,ModifiedDate,Level1_ID,Level1_Name) values ('" + classCodetxt.Text + "','" + classNametxt.Text + "','" + className2txt.Text + "','" + classDesctxt.Text + "','" + classCreatedDatetxt.Text + "','" +
                        classModifiedDatetxt.Text + "','" + departmentID + "','" + parentItem.Header + "')";
                else
                    s = "Update Setup_Department SET Name = '" + classNametxt.Text +
                                                "',Name2='" + className2txt.Text +
                                                "',Description='" + classDesctxt.Text +
                                                "',CreateDate='" + classCreatedDatetxt.Text +
                                                "',ModifiedDate='" + classModifiedDatetxt.Text +
                                                "',CategoryID='" + departmentID +
                                                "' Where Code =" + classCodetxt.Text;

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
            MessageBox.Show("Saved Successfully");
        }
        private void SaveSubClass()
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            TreeViewItem item = treeViewItems.SelectedItem as TreeViewItem;
            TreeViewItem parentItem = item.Parent as TreeViewItem;

            try
            {
                con.Open();

                string s = string.Format("select Code from Setup_Class where Name = '{0}'", parentItem.Header);

                SqlCommand cmd = new SqlCommand(s, con);
                string classID = cmd.ExecuteScalar().ToString();


                if (item.Header.Equals("Undefined"))
                    s = "insert into Setup_SubClass(Code,Name,Name2,Description,CreateDate,ModifiedDate,Level2_ID,Level2_Name) values ('" + subclassCodetxt.Text + "','" + subclassNametxt.Text + "','" + subclassName2txt.Text + "','" + subclassDesctxt.Text + "','" + subclassCreatedDatetxt.Text + "','" +
                        subclassModifiedtxt.Text + "','" + classID + "','" + parentItem.Header + "')";
                else
                    s = "Update Setup_SubClass SET Name = '" + subclassNametxt.Text +
                                                "',Name2='" + subclassName2txt.Text +
                                                "',Description='" + subclassDesctxt.Text +
                                                "',CreateDate='" + subclassCreatedDatetxt.Text +
                                                "',ModifiedDate='" + subclassModifiedtxt.Text +
                                                "',Level2_ID='" + classID +
                                                "' Where Code =" + subclassCodetxt.Text;

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
            MessageBox.Show("Saved Successfully");
        }
        private void SaveItem()
        {
            if (!DoSomeChecks())
                return;

            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            //string s = string.Format("select * from Setup_Items where Code = {0}", Codetxt.Text);
            //SqlCommand cmd = new SqlCommand(s, con);
            //SqlDataReader reader = cmd.ExecuteReader();

            //if (reader.HasRows)
            //{
            //    MessageBox.Show("Another Work station save at the saame time");
            //    Codetxt.Text = "0" + (int.Parse(Codetxt.Text) + 1).ToString();
            //}

            try
            {
                con.Open();

                TreeViewItem item = treeViewItems.SelectedItem as TreeViewItem;

                float weight2 = 0, weight3=0;
                try
                {
                    weight2 = float.Parse(Weight.Text) * float.Parse(ConvUnit2.Text);
                    //weight3 = float.Parse(Weight.Text) * float.Parse(Conv//Unit3.Text);
                }
                catch { }

                string taxable_prec_value = TI_Value.Text;
                if (taxable_prec_value == "")
                    taxable_prec_value = "0";
                if (ConvUnit2.Text == "")
                    ConvUnit2.Text = "0";
                //if (ConvUnit3.Text == "")
                //    ConvUnit3.Text = "0";
                string s = "";
                if (item.Header.Equals("Undefined"))
                {
                    if(unit.Text == unit2.Text)
                    {
                        s = string.Format("insert into Setup_Items Values ('{0}','{1}','{2}','{3}','{4}',(select Code from Vendors where Name = '{5}'),'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}'," +
                          "'{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}',GETDATE(),NULL,'{27}','{28}','{29}','{30}')", Codetxt.Text, Manual_Code_txt.Text, BarCodetxt.Text, Name1txt.Text, Name2txt.Text, PrefVendortxt.Text, Categorytxt.Text, Departmenttxt.Text, Classtxt.Text, SubClasstxt.Text,
                          MUT_cb.IsChecked,ExpDate_cb.IsChecked, Specstxt.Text, Yieldtxt.Text, Weight.Text, unit.Text, unit_txt1.Text, ConvUnit2.Text, unit3.Text, '1', CW_cb.IsChecked, BI_cb.IsChecked, PI_cb.IsChecked, HI_cb.IsChecked,
                          TI_cb.IsChecked, taxable_prec_value, ItemImage.Source.ToString(),MainWindow.UserID,"", Inventory_Item.IsChecked,Activecbx.IsChecked);
                    }
                    else
                    {
                        s = string.Format("insert into Setup_Items Values ('{0}','{1}','{2}','{3}','{4}',(select Code from Vendors where Name = '{5}'),'{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}'," +
                          "'{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}',GETDATE(),NULL,'{27}','{28}','{29}','{30}')", Codetxt.Text, Manual_Code_txt.Text, BarCodetxt.Text, Name1txt.Text, Name2txt.Text, PrefVendortxt.Text, Categorytxt.Text, Departmenttxt.Text, Classtxt.Text, SubClasstxt.Text,
                          MUT_cb.IsChecked, ExpDate_cb.IsChecked, Specstxt.Text, Yieldtxt.Text, Weight.Text, unit.Text, unit2.Text, ConvUnit2.Text, unit3.Text, '1', CW_cb.IsChecked, BI_cb.IsChecked, PI_cb.IsChecked, HI_cb.IsChecked,
                          TI_cb.IsChecked, taxable_prec_value, ItemImage.Source.ToString(), MainWindow.UserID, "", Inventory_Item.IsChecked,Activecbx.IsChecked);
                    }
                    
                }
                else
                {
                    if(unit.Text == unit2.Text)
                    {
                        s = "Update Setup_Items SET [Manual Code] = '" + Manual_Code_txt.Text +
                                               "',BarCode='" + BarCodetxt.Text +
                                               "',Name='" + Name1txt.Text +
                                               "',Name2='" + Name2txt.Text +
                                               "',VendorID=" + string.Format("(Select Code from Vendors Where Name='{0}')", PrefVendortxt.Text) +
                                               ",Category='" + Categorytxt.Text +
                                               "',Department='" + Departmenttxt.Text +
                                               "',Class='" + Classtxt.Text +
                                               "',SUBClass='" + SubClasstxt.Text +
                                               "',Is_MultiUnitTrack='" + MUT_cb.IsChecked.ToString() +
                                               "',Specs='" + Specstxt.Text +
                                               "',ExpDate='" + ExpDate_cb.IsChecked +
                                               "',Yield='" + Yieldtxt.Text +
                                               "',Weight='" + Weight.Text +
                                               "',Unit='" + unit.Text +
                                               "',Unit2='" + unit_txt1.Text +
                                               "',ConvUnit2='" + ConvUnit2.Text +
                                               "',Unit3='" + unit3.Text +
                                               "',ConvUnit3='" + 1 +
                                               "',Is_CatchWeight='" + CW_cb.IsChecked.ToString() +
                                               "',Is_BulkItem='" + BI_cb.IsChecked.ToString() +
                                               "',Is_ParentItem='" + PI_cb.IsChecked.ToString() +
                                               "',Is_HotItem='" + HI_cb.IsChecked.ToString() +
                                               "',Is_TaxableItem='" + TI_cb.IsChecked.ToString() +
                                               "',TaxableValue=" + taxable_prec_value +
                                               ",imagePath='" + ItemImage.Source.ToString() +
                                              "',Modified_Date= GETDATE(),UserID='" + MainWindow.UserID +
                                               "',WS=" + "''" +
                                               ",Inventory='" + Inventory_Item.IsChecked +
                                               "',Active='" + Activecbx.IsChecked +
                                               "' Where Code ='" + Codetxt.Text + "'";
                    }
                    else
                    {
                        s = "Update Setup_Items SET [Manual Code] = '" + Manual_Code_txt.Text +
                                               "',BarCode='" + BarCodetxt.Text +
                                               "',Name='" + Name1txt.Text +
                                               "',Name2='" + Name2txt.Text +
                                               "',VendorID=" + string.Format("(Select Code from Vendors Where Name='{0}')", PrefVendortxt.Text) +
                                               ",Category='" + Categorytxt.Text +
                                               "',Department='" + Departmenttxt.Text +
                                               "',Class='" + Classtxt.Text +
                                               "',SUBClass='" + SubClasstxt.Text +
                                               "',Is_MultiUnitTrack='" + MUT_cb.IsChecked.ToString() +
                                               "',Specs='" + Specstxt.Text +
                                               "',ExpDate='" + ExpDate_cb.IsChecked +
                                               "',Yield='" + Yieldtxt.Text +
                                               "',Weight='" + Weight.Text +
                                               "',Unit='" + unit.Text +
                                               "',Unit2='" + unit2.Text +
                                               "',ConvUnit2='" + ConvUnit2.Text +
                                               "',Unit3='" + unit3.Text +
                                               "',ConvUnit3='" + 1 +
                                               "',Is_CatchWeight='" + CW_cb.IsChecked.ToString() +
                                               "',Is_BulkItem='" + BI_cb.IsChecked.ToString() +
                                               "',Is_ParentItem='" + PI_cb.IsChecked.ToString() +
                                               "',Is_HotItem='" + HI_cb.IsChecked.ToString() +
                                               "',Is_TaxableItem='" + TI_cb.IsChecked.ToString() +
                                               "',TaxableValue=" + taxable_prec_value +
                                               ",imagePath='" + ItemImage.Source.ToString() +
                                               "',Modified_Date= GETDATE(),UserID='" + MainWindow.UserID +
                                               "',WS=" + "''" +
                                               ",Inventory='" + Inventory_Item.IsChecked +
                                               "',Active='" + Activecbx.IsChecked +
                                               "' Where Code ='" + Codetxt.Text + "'";
                    }
                }
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully");

                s = "select count(Code) FROM Store_Setup";
                cmd = new SqlCommand(s, con);
                string CountofSTores = cmd.ExecuteScalar().ToString();
                for (int i = 1; i <= (Convert.ToInt32(CountofSTores)); i++)
                {
                    s = string.Format("insert into Setup_KitchenItems (RestaurantID,KitchenID,ItemID) values({0},1,'{1}')", i, Codetxt.Text);
                    cmd = new SqlCommand(s, con);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //string s = string.Format("select * from Setup_Items where Code = {0}", Codetxt.Text);
                //SqlCommand cmd = new SqlCommand(s, con);
                //SqlDataReader reader = cmd.ExecuteReader();

                //if (reader.HasRows)
                //{
                //    int n = int.Parse(Codetxt.Text.Substring(Codetxt.Text.Length - 1, 1));
                //    n++;
                //    Codetxt.Text = Codetxt.Text.Substring(0, Codetxt.Text.Length - 1) + n.ToString();

                //    savebtn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                //    //MessageBox.Show("Another Workstation save conflict");
                //}

                //else
                    MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            //end of last Update
        }

        private void LoadCategoryData()
        {
            DepartmentGroupBox.Visibility = Visibility.Hidden;
            ClassGroupBox.Visibility = Visibility.Hidden;
            SubClassGroupBox.Visibility = Visibility.Hidden;
            ItemsGroupBox.Visibility = Visibility.Hidden;
            CategoryGroupBox.Visibility = Visibility.Visible;
        }
        private void LoadDepartmentData()
        {
            DepartmentGroupBox.Visibility = Visibility.Visible;
            ClassGroupBox.Visibility = Visibility.Hidden;
            SubClassGroupBox.Visibility = Visibility.Hidden;
            ItemsGroupBox.Visibility = Visibility.Hidden;
            CategoryGroupBox.Visibility = Visibility.Hidden;
        }
        private void LoadClassData()
        {
            DepartmentGroupBox.Visibility = Visibility.Hidden;
            ClassGroupBox.Visibility = Visibility.Visible;
            SubClassGroupBox.Visibility = Visibility.Hidden;
            ItemsGroupBox.Visibility = Visibility.Hidden;
            CategoryGroupBox.Visibility = Visibility.Hidden;
        }
        private void SubClassLoadClassData()
        {
            DepartmentGroupBox.Visibility = Visibility.Hidden;
            ClassGroupBox.Visibility = Visibility.Hidden;
            SubClassGroupBox.Visibility = Visibility.Visible;
            ItemsGroupBox.Visibility = Visibility.Hidden;
            CategoryGroupBox.Visibility = Visibility.Hidden;
        }
        private void LoadItemData()
        {
            DepartmentGroupBox.Visibility = Visibility.Hidden;
            ClassGroupBox.Visibility = Visibility.Hidden;
            SubClassGroupBox.Visibility = Visibility.Hidden;
            ItemsGroupBox.Visibility = Visibility.Visible;
            CategoryGroupBox.Visibility = Visibility.Hidden;
        }

        private void LoadData(string TableName, string header)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            SqlDataReader reader = null;

            try
            {
                con.Open();

                string s = string.Format("select * from {0} where Name = '{1}'", TableName, header);
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (TableName.Equals("Setup_Category"))
                    {
                        CategoryCodetxt.Text = reader["Code"].ToString();
                        CategoryName.Text = reader["Name"].ToString();
                        CategoryName2.Text = reader["Name2"].ToString();
                        CategoryCreatedDatetxt.Text = reader["CreateDate"].ToString();
                    }

                    else if (TableName.Equals("Setup_Department"))
                    {
                        depCodetxt.Text = reader["Code"].ToString();
                        depNametxt.Text = reader["Name"].ToString();
                        depName2txt.Text = reader["Name2"].ToString();
                        depCreatedDatetxt.Text = reader["CreateDate"].ToString();
                        depDescriptiontxt.Text = reader["Description"].ToString();
                        depModifiedDatetxt.Text = reader["ModifiedDate"].ToString();
                        depChildOf.Text = reader["CategoryName"].ToString();
                    }

                    else if (TableName.Equals("Setup_Class"))
                    {
                        classCodetxt.Text = reader["Code"].ToString();
                        classNametxt.Text = reader["Name"].ToString();
                        className2txt.Text = reader["Name2"].ToString();
                        classCreatedDatetxt.Text = reader["CreateDate"].ToString();
                        classDesctxt.Text = reader["Description"].ToString();
                        classModifiedDatetxt.Text = reader["ModifiedDate"].ToString();
                        classChildOf.Text = reader["Level1_Name"].ToString();
                    }

                    else if (TableName.Equals("Setup_SubClass"))
                    {
                        subclassCodetxt.Text = reader["Code"].ToString();
                        subclassNametxt.Text = reader["Name"].ToString();
                        subclassName2txt.Text = reader["Name2"].ToString();
                        subclassCreatedDatetxt.Text = reader["CreateDate"].ToString();
                        subclassDesctxt.Text = reader["Description"].ToString();
                        subclassModifiedtxt.Text = reader["ModifiedDate"].ToString();
                        subclassChildOf.Text = reader["Level2_Name"].ToString();
                    }

                    else if (TableName.Equals("Setup_Items"))
                    {
                        SqlConnection con2 = new SqlConnection(connString);
                        con2.Open();
                        cmd = new SqlCommand(string.Format("select Name From Vendors Where Code ='{0}'",reader["VendorID"].ToString()),con2);

                        Codetxt.Text = reader["Code"].ToString();
                        Manual_Code_txt.Text = reader["Manual Code"].ToString();
                        BarCodetxt.Text = reader["BarCode"].ToString();
                        Name1txt.Text = reader["Name"].ToString();
                        Name2txt.Text = reader["Name2"].ToString();
                        Specstxt.Text = reader["Specs"].ToString();
                        try
                        {
                            PrefVendortxt.Text = cmd.ExecuteScalar().ToString();
                        }
                        catch { }
                        Categorytxt.Text = reader["Category"].ToString();
                        Departmenttxt.Text = reader["Department"].ToString();
                        Classtxt.Text = reader["Class"].ToString();
                        SubClasstxt.Text = reader["SUBClass"].ToString();
                        MUT_cb.IsChecked = (bool) reader["Is_MultiUnitTrack"];
                        if(reader["ConvUnit2"].ToString().IndexOf('.')==-1)
                        {
                            unit2.Text = reader["Unit"].ToString();
                            unit_txt1.Text = reader["Unit2"].ToString();
                        }
                        else
                        {
                            unit2.Text = reader["Unit2"].ToString();
                            unit_txt1.Text = reader["Unit"].ToString();
                        }

                        unit.Text= reader["Unit"].ToString();
                        Weight.Text = reader["Weight"].ToString();
                        ConvUnit2.Text = reader["ConvUnit2"].ToString();
                        //ConvUnit3.Text = reader["ConvUnit3"].ToString();


                        Yieldtxt.Text = reader["Yield"].ToString();
                        CW_cb.IsChecked = (bool)reader["Inventory"];
                        CW_cb.IsChecked = (bool) reader["Is_CatchWeight"];
                        BI_cb.IsChecked = (bool) reader["Is_BulkItem"];
                        PI_cb.IsChecked = (bool) reader["Is_ParentItem"];
                        HI_cb.IsChecked = (bool) reader["Is_HotItem"];
                        TI_cb.IsChecked = (bool) reader["Is_TaxableItem"];
                        Activecbx.IsChecked = (bool) reader["Active"];
                        ExpDate_cb.IsChecked = (bool) reader["ExpDate"];
                        TI_Value.Text = reader["TaxableValue"].ToString();

                        if (TI_Value.Text != "")
                        {
                            TI_Value.Visibility = Visibility.Visible;
                            TI_Prec_icon.Visibility = Visibility.Visible;

                        }
                        else
                        {
                            TI_Value.Visibility = Visibility.Hidden;
                            TI_Prec_icon.Visibility = Visibility.Hidden;
                        }

                        ItemImage.Source = new BitmapImage(new Uri(reader["imagePath"].ToString()));
                        Imagetxt.Visibility = Visibility.Hidden;

                        con2.Close();
                    }
                }
            }
            catch
            {
            }
            finally
            {
                reader.Close();
                con.Close();
            }
        }

        //events
        private void AddClicked(object sender, RoutedEventArgs e)
        {
            try
            {
                Manual_Code_txt.Text = "";

                if (TreeView_SelectedItem_Checks())
                    return;
                
                TreeViewItem treeViewItem = new TreeViewItem();
                treeViewItem.Header = "Undefined";
                ((TreeViewItem)treeViewItems.SelectedItem).Items.Add(treeViewItem);

                MessageBox.Show("Item Added in " + ((TreeViewItem)treeViewItems.SelectedItem).Header);

                //generating code of added node 
                TreeViewItem parentItem = treeViewItems.SelectedItem as TreeViewItem;
                int itemPositon = parentItem.Items.Count;

                List<string> CodeSetup = CodeSetupReturn();

                ClearGroupBox();

                if (CategoryGroupBox.IsVisible)
                {
                    string categoryCode = CategoryCodetxt.Text;

                    //select added node
                    ((TreeViewItem)treeViewItems.SelectedItem).IsExpanded = true;
                    treeViewItem.IsSelected = true;

                    string CodeDigits = "";
                    for (int i = 0; i < int.Parse(CodeSetup[0]) - itemPositon.ToString().Count(); i++)
                        CodeDigits += "0";
                    CodeDigits += itemPositon.ToString();

                    depCodetxt.Text = categoryCode + CodeDigits;
                }
                else if (DepartmentGroupBox.IsVisible)
                {
                    string depCode = depCodetxt.Text;

                    //select added node
                    ((TreeViewItem)treeViewItems.SelectedItem).IsExpanded = true;
                    treeViewItem.IsSelected = true;

                    string CodeDigits = "";
                    for (int i = 0; i < int.Parse(CodeSetup[1]) - itemPositon.ToString().Count(); i++)
                        CodeDigits += "0";
                    CodeDigits += itemPositon.ToString();

                    classCodetxt.Text = depCode + CodeDigits;

                }
                else if (ClassGroupBox.IsVisible)
                {
                    string ClassCode = classCodetxt.Text;

                    //select added node
                    ((TreeViewItem)treeViewItems.SelectedItem).IsExpanded = true;
                    treeViewItem.IsSelected = true;

                    string CodeDigits = "";
                    for (int i = 0; i < int.Parse(CodeSetup[2]) - itemPositon.ToString().Count(); i++)
                        CodeDigits += "0";
                    CodeDigits += itemPositon.ToString();

                    subclassCodetxt.Text = ClassCode + CodeDigits;

                }
                else if (SubClassGroupBox.IsVisible)
                {
                    string ItemCode = subclassCodetxt.Text;

                    //select added node
                    Activecbx.IsChecked = true;
                    ((TreeViewItem)treeViewItems.SelectedItem).IsExpanded = true;
                    treeViewItem.IsSelected = true;

                    string CodeDigits = "";
                    for (int i = 0; i < int.Parse(CodeSetup[3]) - itemPositon.ToString().Count(); i++)
                        CodeDigits += "0";
                    CodeDigits += itemPositon.ToString();

                    Codetxt.Text = ItemCode + CodeDigits;

                    List<TreeViewItem> ParentsNode = FindTreeNodes();
                    Categorytxt.Text = ParentsNode[0].Header.ToString();
                    Departmenttxt.Text = ParentsNode[1].Header.ToString();
                    Classtxt.Text = ParentsNode[2].Header.ToString();
                    SubClasstxt.Text = ParentsNode[3].Header.ToString();
                }
                else if (ItemsGroupBox.IsVisible)
                {
                    return;
                }

                UndifinedExists = treeViewItem;
                CodeLabel.Visibility = Visibility.Hidden;
                Codetxt.Visibility = Visibility.Hidden;
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }

        }
        private void ReloadClicked(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("reload");
            treeViewItems.Items.Clear();
            LoadCategoryinTreeView();
            List<TreeViewItem> classNodes = LoadDepartmentinTreeView();
            List<TreeViewItem> subclassNodes = LoadClassesinTreeView(classNodes);
            List<TreeViewItem> ItemsNodes = LoadSubClassesinTreeView(subclassNodes);
            LoadItemsinTreeView(ItemsNodes);

            UndifinedExists = null;

            Manual_Code_txt.Text = "";
            CodeLabel.Visibility = Visibility.Visible;
            Codetxt.Visibility = Visibility.Visible;
        }
        private void DeleteClicked(object sender, RoutedEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);

            if((treeViewItems.SelectedItem as TreeViewItem).HasItems)
            {
                MessageBox.Show("Can not delete,because it has children !!!");
                return;
            }

            try
            {
                con.Open();
                string W = "SELECT Item_Code From Setup_RecipeItems Where Item_Code='" + Codetxt.Text+"'";
                SqlCommand cmd = new SqlCommand(W, con);
                if (cmd.ExecuteScalar() != null)
                {
                    MessageBox.Show("Can Not Delete Item Because useing it in Recipes");
                    return;
                }
                con.Close();
            }
            catch { }
            

            string TableName = TableToDeleteFrom();
            string code = TableCode(TableName); 
            try
            {
                con.Open();
                string s = "delete from " + TableName +" where Code = " + code;
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
            }
            MessageBox.Show("Deleted Successfully");

            Reload.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            //ClearGroupBox();
        }
        private void SaveBtn_Clicked(object sender, RoutedEventArgs e)
        {
            if (DepartmentGroupBox.IsVisible)
                SaveDepartment();
            else if (ClassGroupBox.IsVisible)
                SaveClass();
            else if (SubClassGroupBox.IsVisible)
                SaveSubClass();
            else if (ItemsGroupBox.IsVisible)
            {
                if(unit.Text !=unit2.Text && unit.Text != unit_txt1.Text)
                {
                    MessageBox.Show("Please Enter Correct Conversion table ");
                }
                else
                {
                    SaveItem();
                }
            }
            else
            {
                CodeLabel.Visibility = Visibility.Visible;
                Codetxt.Visibility = Visibility.Visible;
                return;
            }

            //Reload.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            //treeViewItems.Items.Refresh();
            //CodeLabel.Visibility = Visibility.Visible;
            //Codetxt.Visibility = Visibility.Visible;
            UndifinedExists = null;
        }

        private void TreeViewItems_SelectedItemChanged(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if ((treeViewItems.SelectedItem as TreeViewItem).Header.ToString().Equals("Undefined"))
                    return;

                else if (UndifinedExists != null)
                {
                    TreeViewItem selectednode = treeViewItems.SelectedItem as TreeViewItem;
                    selectednode.IsSelected = false;
                    UndifinedExists.IsSelected = true;
                    selectednode.IsSelected = false;
                    MessageBox.Show("Make sure you define selected node first");
                    //Reload.Focus();
                    
                    return;
                }
            }
            catch
            {
                return;
            }

            List<TreeViewItem> treeNodes = FindTreeNodes();
            TreeView senderObject = sender as TreeView;

            if (senderObject.SelectedItem == treeNodes[0])
            {
                LoadCategoryData();
                LoadData("Setup_Category", treeNodes[0].Header.ToString());
            }

            else if (senderObject.SelectedItem == treeNodes[1])
            {
                LoadDepartmentData();
                LoadData("Setup_Department", treeNodes[1].Header.ToString());
            }

            else if (senderObject.SelectedItem == treeNodes[2])
            {
                LoadClassData();
                LoadData("Setup_Class", treeNodes[2].Header.ToString());
            }

            else if (senderObject.SelectedItem == treeNodes[3])
            {
                SubClassLoadClassData();
                LoadData("Setup_SubClass", treeNodes[3].Header.ToString());
            }

            else if (senderObject.SelectedItem == treeNodes[4])
            {
                LoadItemData();
                LoadData("Setup_Items", treeNodes[4].Header.ToString());
            }

        }
        private void TreeViewItems_SelectedItemChanged_1(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            List<TreeViewItem> treeNodes = FindTreeNodes();
            TreeView senderObject = sender as TreeView;

            if (senderObject.SelectedItem == treeNodes[0])
            {
                LoadCategoryData();
            }

            else if (senderObject.SelectedItem == treeNodes[1])
            {
                LoadDepartmentData();
            }

            else if (senderObject.SelectedItem == treeNodes[2])
            {
                LoadClassData();
            }

            else if (senderObject.SelectedItem == treeNodes[3])
            {
                SubClassLoadClassData();
            }

            else if (senderObject.SelectedItem == treeNodes[4])
                LoadItemData();

            ClearGroupBox();
        }

        private void ItemImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe,*.png) | *.jpg; *.jpeg; *.jpe;*.png";
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Title = "Please select an image file to encrypt.";


            Nullable<bool> result = openFileDialog.ShowDialog();

            if (result == true)
            {
                Imagetxt.Visibility = Visibility.Hidden;
                ItemImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        private void MUT_cb_Clicked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (checkBox.IsChecked ==  true)
                Unit_Conversion2.Visibility = Visibility.Visible;
            else
                Unit_Conversion2.Visibility = Visibility.Hidden;
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

        private void TI_cb_Clicked(object sender, RoutedEventArgs e)
        {
            if ((e.Source as CheckBox).IsChecked == true)
            {
                TI_Value.Visibility = Visibility.Visible;
                TI_Prec_icon.Visibility = Visibility.Visible;
            }
            else
            {
                TI_Value.Visibility = Visibility.Hidden;
                TI_Prec_icon.Visibility = Visibility.Hidden;

            }
        }

        private void BI_cb_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = treeViewItems.SelectedItem as TreeViewItem;

            if (item.Header.Equals("Undefined"))
                return;
               
            if ((sender as CheckBox).IsChecked == true)
            {
                BulkWindow bulkWindow = new BulkWindow(Codetxt.Text, Name1txt.Text);
                bulkWindow.ShowDialog();
            }
        }

        private void PI_cb_Checked(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = treeViewItems.SelectedItem as TreeViewItem;
            if (item.Header.Equals("Undefined"))
                return;

            if ((sender as CheckBox).IsChecked == true)
            {
                ParentWindow parentWindow = new ParentWindow(Codetxt.Text);
                parentWindow.ShowDialog();
            }
        }

        private void unit2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
                SqlConnection con = new SqlConnection(connString);

                string s = string.Format("select Name from Units where Name <> '{0}'", unit2.SelectedItem.ToString());
                DataTable dt = new DataTable();
                using (SqlDataAdapter da = new SqlDataAdapter(s, con))
                    da.Fill(dt);

                unit_txt1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    unit_txt1.Items.Add(dt.Rows[i]["Name"]);
                }
            }
            catch { }
        }

       
    }
}
﻿using System;
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
    /// Interaction logic for Store_Sertup.xaml
    /// </summary>
    public partial class Store_Sertup : UserControl
    {
        public Store_Sertup()
        {
            InitializeComponent();
            FillDGV();
            MainUiFormat();
        }

        //functions
        private void FillDGV()
        {
            DataTable Dt = new DataTable();
            Dt.Columns.Add("Code");
            Dt.Columns.Add("Name");
            Dt.Columns.Add("Name2");
            Dt.Columns.Add("Main",typeof(bool));
            Dt.Columns.Add("Active", typeof(bool));
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            SqlDataReader reader = null;
            try
            {
                con.Open();
                string s = "select Code,Name,Name2,IsMain,IsActive from Setup_Restaurant";
                SqlCommand cmd = new SqlCommand(s, con);
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Dt.Rows.Add(reader["Code"].ToString(), reader["Name"].ToString(), reader["Name2"].ToString(), reader["IsMain"].ToString(), reader["IsActive"].ToString());
                }
                Stores_DGV.DataContext = Dt;
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
            KitchenBtn.IsEnabled = false;
            Active_chbx.IsChecked = false;
            IsMain.IsEnabled = false;
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
            IsMain.IsEnabled = true;
            KitchenBtn.IsEnabled = true;
        }
        private void ClearUIFields()
        {
            Code_txt.Text = "";
            Name_txt.Text = "";
            Name2_txt.Text = "";
            Active_chbx.IsChecked = false;
            IsMain.IsChecked = false;
        }

        private void NewButtonClicked(object sender, RoutedEventArgs e)
        {
            EnableUI();
            ClearUIFields();
            Active_chbx.IsChecked = true;
            KitchenBtn.IsEnabled = false;
            NewBtn.IsEnabled = false;
            UpdateBtn.IsEnabled = false;
            DeleteBtn.IsEnabled = false;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);

            if (Code_txt.Text == "")
            {
                MessageBox.Show("Code Field Can't Be Empty");
                return;
            }
            for(int i=0;i<Stores_DGV.Items.Count;i++)
            {
                if(Code_txt.Text == ((DataRowView)Stores_DGV.Items[i]).Row.ItemArray[0].ToString())
                {
                    MessageBox.Show("This Code Is Not Avaliable");
                    return;
                }
            }
            if(IsMain.IsChecked==true)
            {
                try
                {
                    con.Open();
                    string s = string.Format("select IsMain from Setup_Restaurant where IsMain='True'");
                    SqlCommand cmd = new SqlCommand(s, con);
                    if (cmd.ExecuteScalar() != null)
                    {
                        MessageBox.Show("Can't be More than Main Resturant !");
                        return;
                    }
                }
                catch { }
            }
            
            try
            {
                string FiledSelection = "Code,Name,Name2,IsMain,IsActive,Create_Date,WS,UserID";
                string values = string.Format("'{0}', N'{1}', N'{2}', '{3}','{4}',{5},'{6}','{7}'", Code_txt.Text, Name_txt.Text, Name2_txt.Text, IsMain.IsChecked,Active_chbx.IsChecked,"GETDATE()", Classes.WS, MainWindow.UserID);
                Classes.InsertRow("Setup_Restaurant", FiledSelection, values);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                MainUiFormat();
                Stores_DGV.DataContext = null;
                FillDGV();
            }
            MessageBox.Show("Saved Successfully");
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection(Classes.DataConnString);

            if (IsMain.IsChecked == true)
            {
                try
                {
                    con.Open();
                    string s = string.Format("select IsMain from Setup_Restaurant where IsMain='True'");
                    SqlCommand cmd = new SqlCommand(s, con);
                    if (cmd.ExecuteScalar() != null)
                    {
                        MessageBox.Show("Can't be More than Main Resturant !");
                        return;
                    }
                }
                catch { }
            }
            try
            {
                string FiledSlection = "Name,Name2,IsMain,IsActive,Last_Modified_Date";
                string values = string.Format("N'{0}', N'{1}', '{2}', '{3}',{4}", Name_txt.Text, Name2_txt.Text, IsMain.IsChecked,Active_chbx.IsChecked, "GETDATE()");
                string Where = string.Format("Code={0}", Code_txt.Text);
                Classes.UpdateRow(FiledSlection, values, Where, "Setup_Restaurant");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
                MainUiFormat();
                Stores_DGV.DataContext = null;
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
            SqlConnection con = new SqlConnection(Classes.DataConnString);
            try
            {
                con.Open();
                string s = string.Format("select Code from Setup_Kitchens where RestaurantID='{0}'", Code_txt.Text);
                SqlCommand cmd = new SqlCommand(s, con);
                if (cmd.ExecuteScalar() == null)
                {
                    try
                    {
                        s = "delete from Setup_Restaurant where Code = " + Code_txt.Text;
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
                        MainUiFormat();

                        Stores_DGV.DataContext = null;
                        FillDGV();
                    }
                    MessageBox.Show("Deleted Successfully");
                }
                else
                {
                    MessageBox.Show("You Can't Delete This Restaurant Because that Have Kitchens !");
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            
        }

        private void RowClicked(object sender, MouseButtonEventArgs e)
        {
            if (sender != null)
            {
                DataGrid data = sender as DataGrid;

                if (data != null && data.SelectedItems != null && data.SelectedItems.Count == 1)
                {
                    Code_txt.Text = ((DataRowView)Stores_DGV.SelectedItem).Row.ItemArray[0].ToString();
                    Name_txt.Text = ((DataRowView)Stores_DGV.SelectedItem).Row.ItemArray[1].ToString();
                    Name2_txt.Text = ((DataRowView)Stores_DGV.SelectedItem).Row.ItemArray[2].ToString();
                    Active_chbx.IsChecked = Convert.ToBoolean(((DataRowView)Stores_DGV.SelectedItem).Row.ItemArray[4]);
                    IsMain.IsChecked = Convert.ToBoolean(((DataRowView)Stores_DGV.SelectedItem).Row.ItemArray[3]);



                    EnableUI();
                    Code_txt.IsEnabled = false;
                    NewBtn.IsEnabled = false;
                    SaveBtn.IsEnabled = false;
                    KitchenBtn.IsEnabled = true;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(Code_txt.Text == "")
            {
                MessageBox.Show("select store");
                return;
            }
            Setup_Kitchens Setup_Kitchens = new Setup_Kitchens(Code_txt.Text);
            Setup_Kitchens.ShowDialog();
        }
    }
}
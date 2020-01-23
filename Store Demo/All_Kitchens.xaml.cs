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
using System.Windows.Shapes;

namespace Food_Cost
{
    /// <summary>
    /// Interaction logic for All_Kitchen.xaml
    /// </summary>
    public partial class All_Kitchens : Window
    {
        Transfer_Kitchens transfer_Kitchens;
        Transfer_Resturant Transfer_Resturant;
        string Kitchen, resturant;

        public All_Kitchens(Transfer_Resturant _Transfer_Resturant,string _kitchen , string _resturant)
        {
            InitializeComponent();
            resturant = _resturant;
            Kitchen = _kitchen;
            Transfer_Resturant = _Transfer_Resturant;
            LoadKitchens("Transfer_Resturant");
        }
        public All_Kitchens(Transfer_Kitchens _transfer_Kitchens, string _kitchen,string _resturant)
        {
            InitializeComponent();
            resturant = _resturant;
            Kitchen = _kitchen;
            transfer_Kitchens = _transfer_Kitchens;
            LoadKitchens("Transfer_Kitchens");
        }


        private void LoadKitchens( string kitchens)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            try
            {
                con.Open();
                string s = "";
                    if (kitchens == "Transfer_Resturant")
                    {
                        if (Kitchen == "From_Resturant")
                            s = string.Format("select Code,Name,Name2,IsActive as Active from Kitchens_Setup where RestaurantID = (select Code from Store_Setup where Name = '{0}') ", resturant, Transfer_Resturant.From_Kitchen.Text);
                        else
                            s = string.Format("select Code,Name,Name2,IsActive as Active from Kitchens_Setup where RestaurantID = (select Code from Store_Setup where Name = '{0}') ", resturant, Transfer_Resturant.From_Kitchen.Text);
                    }
                    else
                    {
                        s = string.Format("select Code,Name,Name2,IsActive as Active from Kitchens_Setup where RestaurantID = (select Code from Store_Setup where Name = '{0}')  AND Name <> '{1}' order by Code", resturant, transfer_Kitchens.From_Kitchen.Text);
                    }
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(s, con))
                        da.Fill(dt);

                    KitchensDGV.DataContext = dt;
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

        private void TextDataChange(object sender, TextChangedEventArgs e)
        {
            string connString = ConfigurationManager.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString;
            SqlConnection con = new SqlConnection(connString);
            if ((RadioByCode.IsChecked == true || RadioByName.IsChecked == true) && SearchTxt.Text != "")
            {
                if (RadioByCode.IsChecked == true && RadioByName.IsChecked == false)
                {
                    KitchensDGV.DataContext=null;
                    try
                    {
                        con.Open();
                        string s = string.Format("select Code,Name,Name2,IsActive as Active from Kitchens_Setup where RestaurantID = (select Code from Store_Setup where Name = '{1}') AND Code Like '%{0}%' order by Code", SearchTxt.Text, resturant);
                        DataTable dt = new DataTable();

                        using (SqlDataAdapter da = new SqlDataAdapter(s, con))
                            da.Fill(dt);

                        KitchensDGV.DataContext = dt;
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
                    KitchensDGV.DataContext = null;
                    try
                    {
                        con.Open();
                        string s = string.Format("select Code,Name,Name2,IsActive as Active from Kitchens_Setup where RestaurantID = (select Code from Store_Setup where Name = '{1}') AND Name Like '%{0}%' order by Code", SearchTxt.Text, resturant);
                        DataTable dt = new DataTable();

                        using (SqlDataAdapter da = new SqlDataAdapter(s, con))
                            da.Fill(dt);

                        KitchensDGV.DataContext = dt;
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
                KitchensDGV.DataContext = null;
                try
                {
                    con.Open();
                    string s = string.Format("select Code,Name,Name2,IsActive as Active from Kitchens_Setup where RestaurantID = (select Code from Store_Setup where Name = '{0}') order by Code", resturant);
                    DataTable dt = new DataTable();

                    using (SqlDataAdapter da = new SqlDataAdapter(s, con))
                        da.Fill(dt);

                    KitchensDGV.DataContext = dt;
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

        private void KitchenDGV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow main = Application.Current.MainWindow as MainWindow;
            if (sender != null)
            {
                DataGrid grid = sender as DataGrid;
                if (grid != null && grid.SelectedItems != null && grid.SelectedItems.Count == 1)
                {
                    if (main.GridMain.Children[0].GetType().Name == "Transfer_Kitchens")
                    {
                        if (Kitchen == "From_Kitchen")
                            transfer_Kitchens.From_Kitchen.Text = (grid.SelectedItem as DataRowView).Row["Name"] as string;
                        else if (Kitchen == "To_Kitchen")
                            transfer_Kitchens.To_Kitchen.Text = (grid.SelectedItem as DataRowView).Row["Name"] as string;

                        this.Close();
                    }
                    //
                    else if (main.GridMain.Children[0].GetType().Name == "Transfer_Resturant")
                    {
                        if (Kitchen == "From_Kitchen")
                            Transfer_Resturant.From_Kitchen.Text = (grid.SelectedItem as DataRowView).Row["Name"] as string;
                        else if (Kitchen == "To_Kitchen")
                            Transfer_Resturant.To_Kitchen.Text = (grid.SelectedItem as DataRowView).Row["Name"] as string;

                        this.Close();
                    }
                    this.Close();
                }
            }
        }

    }
}

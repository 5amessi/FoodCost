using System;
using System.Collections.Generic;
using System.Configuration;
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
using System.Data;

namespace Food_Cost
{
    /// <summary>
    /// Interaction logic for Fiscal_Period.xaml
    /// </summary>
    public partial class Fiscal_Period : Window
    {
        HashSet<string> SetStatus = new HashSet<string>();
        public Fiscal_Period()
        {
            InitializeComponent();

            MonthType_cbx.SelectedIndex = 0;
            string cols = "Year varchar(50),Month varchar(50),[Month Type] varchar(50),[From] datetime,[To] datetime,isClosed bit";
            Classes.CreateTable("Setup_Fiscal_Period", cols);
            DataTable Years = Classes.RetrieveData("DISTINCT(Year)", "Setup_Fiscal_Period");
            foreach (DataRow year in Years.Rows)
            {
                CBCreatedYears.Items.Add(year[0]);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MonthType_cbx.SelectedIndex == 0)
            {
                Month13_StackPanel.Visibility = Visibility.Hidden;
            }
            else
                Month13_StackPanel.Visibility = Visibility.Visible;
        }

        private void insert()
        {

           
            string where = "Year = '" + Year.Text + "'";
            Classes.DeleteRows(where, "Setup_Fiscal_Period");

            int n = 12;
            if (MonthType_cbx.SelectedIndex == 1)
                n = 13;

            for (int i = 0; i < n; i++)
            {
                DatePicker From = FindName("from" + (i + 1)) as DatePicker;
                DatePicker To = FindName("to" + (i + 1)) as DatePicker;
                string values = "'" + Year.Text + "','" + (i + 1).ToString() + "','" + MonthType_cbx.Text + "','";
                values += From.Text + "','" + To.Text + "','" + "0'";
                Classes.InsertRow("Setup_Fiscal_Period", values);
            }

            MessageBox.Show("Saved");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                insert();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Year_SelectionChanged(object sender, RoutedEventArgs e)
        {
            string year = (e.Source as TextBox).Text;

            if (MonthType_cbx.SelectedIndex == 0)
            {
                from1.Text = "1/1/" + year;
                from2.Text = "2/1/" + year;
                from3.Text = "3/1/" + year;
                from4.Text = "4/1/" + year;
                from5.Text = "5/1/" + year;
                from6.Text = "6/1/" + year;
                from7.Text = "7/1/" + year;
                from8.Text = "8/1/" + year;
                from9.Text = "9/1/" + year;
                from10.Text = "10/1/" + year;
                from11.Text = "11/1/" + year;
                from12.Text = "12/1/" + year;

                to1.Text = "1/30/" + year;
                to2.Text = "2/28/" + year;
                to3.Text = "3/31/" + year;
                to4.Text = "4/30/" + year;
                to5.Text = "5/31/" + year;
                to6.Text = "6/30/" + year;
                to7.Text = "7/31/" + year;
                to8.Text = "8/31/" + year;
                to9.Text = "9/30/" + year;
                to10.Text = "10/31/" + year;
                to11.Text = "11/30/" + year;
                to12.Text = "12/31/" + year;
            }
            else if (MonthType_cbx.SelectedIndex == 1)
            {
                from1.Text = "1/1/" + year;
                from2.Text = "1/29/" + year;
                from3.Text = "2/26/" + year;
                from4.Text = "3/26/" + year;
                from5.Text = "4/23/" + year;
                from6.Text = "5/21/" + year;
                from7.Text = "6/18/" + year;
                from8.Text = "7/16/" + year;
                from9.Text = "8/13/" + year;
                from10.Text = "9/10/" + year;
                from11.Text = "10/8/" + year;
                from12.Text = "11/2/" + year;
                from13.Text = "12/3/" + year;

                to1.Text = "1/28/" + year;
                to2.Text = "2/25/" + year;
                to3.Text = "3/25/" + year;
                to4.Text = "4/22/" + year;
                to5.Text = "5/20/" + year;
                to6.Text = "6/17/" + year;
                to7.Text = "7/15/" + year;
                to8.Text = "8/15/" + year;
                to9.Text = "9/9/" + year;
                to10.Text = "10/7/" + year;
                to11.Text = "11/4/" + year;
                to12.Text = "12/2/" + year;
                to13.Text = "12/31/" + year;
            }
        }

        private void CreatedYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable MonthsforYear = Classes.RetrieveData("*", "Year = '" + CBCreatedYears.SelectedItem + "'", "Setup_Fiscal_Period");

            if (MonthsforYear.Rows[0]["Month Type"].ToString() == "Type2")
            {
                Month13_StackPanel.Visibility = Visibility.Visible;
            }
            else
            {
                Month13_StackPanel.Visibility = Visibility.Hidden;
            }

            SetStatus = new HashSet<string>();
            for (int i = 0; i < MonthsforYear.Rows.Count; i++)
            {
                DatePicker From = FindName("from" + (i + 1)) as DatePicker;
                DatePicker To = FindName("to" + (i + 1)) as DatePicker;
                From.Text = MonthsforYear.Rows[i]["From"].ToString();
                To.Text = MonthsforYear.Rows[i]["TO"].ToString();
                SetStatus.Add(MonthsforYear.Rows[i]["isClosed"].ToString());
            }
        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            //Open all Boxes
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (SetStatus.Contains("True"))
            {
                MessageBox.Show("Open all months in this year");
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            insert();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            string where = "Year = '" + CBCreatedYears.SelectedItem + "'";
            Classes.DeleteRows(where, "Setup_Fiscal_Period");
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

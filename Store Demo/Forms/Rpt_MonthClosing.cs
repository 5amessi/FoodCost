using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Food_Cost.Report;

namespace Food_Cost.Forms
{
    public partial class Rpt_MonthClosing : Form
    {
        public Rpt_MonthClosing()
        {
            InitializeComponent();
            TVDates = Classes.LoadDates(TVDates);
        }

        string Where = "", Filter = "", s = "", s1 = "", s2 = "", f = "", Date = "",CurrMDate = "",PrevDate = "";
        DataTable DtItem_BinCard, dt, Dt, Dt2;
    
        Dictionary<string, string> dic = new Dictionary<string, string>();
        Dictionary<string, string> Stores = new Dictionary<string, string>();
        Dictionary<string, string> changed_trasfers = new Dictionary<string, string>();
        Dictionary<string, List<string>> FilterDic = new Dictionary<string, List<string>>();
        Dictionary<string, Tuple<string, string>> BBalance = new Dictionary<string, Tuple<string, string>>();
        Dictionary<string, Tuple<string, string>> EBalance = new Dictionary<string, Tuple<string, string>>();

        private void get_prev_month(string Y, string M)
        {
            if(M != "1")
                PrevDate = "Year = '" + Y + "' AND Month = '" + (double.Parse(M) - 1).ToString() + "'";
            else
            {
                Y = (double.Parse(Y) - 1).ToString();
                DataTable Temp = Classes.RetrieveData("top 1 *", "Year = '" + Y + "'", "Setup_Fiscal_Period");
                if (Temp.Rows.Count != 0)
                {
                    if (Temp.Rows[0]["Month Type"].ToString() == "Type1")
                        M = "12";
                    else
                        M = "13";
                    PrevDate = "Year = '" + Y + "' AND Month = '" + M + "'";
                }
                else
                {
                    PrevDate = "Year = '" + Y + "' AND Month = '12'";
                }
            }
        }
        private void Dates_Checked()
        {
            f = "";
            foreach (TreeNode Node in TVDates.Nodes)
            {
                foreach (TreeNode Child in Node.Nodes)
                {
                    if (Child.Checked == true)
                    {
                        string TempDate = "Year = '" + Node.Text + "' AND Month = '" + Child.Text.Replace("Month", "") + "'";
                        CurrMDate = "Year = '" + Node.Text + "' AND Month = '" + Child.Text+ "'";
                        get_prev_month(Node.Text, Child.Text.Replace("Month", ""));

                        DataTable DTDate = Classes.RetrieveData("[From],[To]", TempDate, "Setup_Fiscal_Period");
                        Date = "between '" + DTDate.Rows[0]["From"].ToString() + "' AND '"+ DTDate.Rows[0]["To"].ToString() + "'";
                      
                        break;
                    }
                }
            }
            if (Date == "")
            {
                MessageBox.Show("Please Select One Month At Least", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void CBMyKitchen_CheckedChanged(object sender, EventArgs e)
        {
            if (CBMyKitchen.Checked == true)
            {
                UC_TVKitchens2.Visible = false;
            }
            else
            {
                UC_TVKitchens2.Visible = true;
            }
        }

        private void LoadBEBalance()
        {
            foreach (string kit in UC_TVKitchens2.KitchensList)
            {
                BBalance[kit] = new Tuple<string, string>("0", "0");
                EBalance[kit] = new Tuple<string, string>("0", "0");
            }
            DataTable DT = Classes.RetrieveData("KitchenName,SUM(Qty) as Qty ,sum(Cost) as Cost", PrevDate + "AND " + Where + " group by KitchenName ", "BeginningEndingMonthView ");
            foreach (DataRow DR in DT.Rows)
            {
                BBalance[DR["KitchenName"].ToString()] = new Tuple<string, string>(DR["Qty"].ToString(), DR["Cost"].ToString());
            }
            
            DT = Classes.RetrieveData("KitchenName,SUM(Qty) as Qty ,sum(Cost) as Cost", CurrMDate + "AND " + Where + " group by KitchenName ", "BeginningEndingMonthView ");
            foreach (DataRow DR in DT.Rows)
            {
                EBalance[DR["KitchenName"].ToString()] = new Tuple<string, string>(DR["Qty"].ToString(), DR["Cost"].ToString());
            }
           
        }

        private void btnRport_Click(object sender, EventArgs e)
        {
           DtItem_BinCard = Classes.RetrieveData("*", "BinCard");
            if (!CBMyKitchen.Checked)
            {
                Where = "";
                Filter = "";
                Dates_Checked();
                UC_TVKitchens2.Kitchen_Checked(ref f,ref Where);
            }
            else
            {
                Where = " Restaurant_ID IN (1) AND Kitchen_ID IN (1)";
                Filter = "Kitchen: My kitchen";
            }
            LoadBEBalance();

            //Receive
            string Select = "RestaurantName,KitchenName,Category,SUM(Qty) as Qty ,sum(Net_Price) as Cost";
            string order = " group by RestaurantName,KitchenName,Category";
            string WhereDate = " And Receiving_Date " + Date;

            string WhereRO = Where+ WhereDate + order;

            dt = Classes.RetrieveData(Select, WhereRO, "ReceiveItemsView");

            foreach (DataRow DR in dt.Rows)
            {
                DataRow Ndr = DtItem_BinCard.NewRow();
                
                Ndr["BQty"] = BBalance[DR["KitchenName"].ToString()].Item1;
                Ndr["BCost"] = BBalance[DR["KitchenName"].ToString()].Item2;

                Ndr["EQty"] = EBalance[DR["KitchenName"].ToString()].Item1;
                Ndr["ECost"] = EBalance[DR["KitchenName"].ToString()].Item2;

                Ndr["Qty"] = DR["Qty"].ToString();
                Ndr["Cost"] = DR["Cost"].ToString();
                Ndr["RestaurantName"] = DR["RestaurantName"].ToString();
                Ndr["KitchenName"] = DR["KitchenName"].ToString();
                Ndr["TransDetails"] = "Total Receive";
                Ndr["Type"] = DR["Category"].ToString();
                DtItem_BinCard.Rows.Add(Ndr);
            }

            //Adjustment
            Select = "RestaurantName,KitchenName,Category,SUM(Variance) as Qty ,sum(Cost) as Cost";
            WhereDate = " And Adjacment_Date " + Date;
            WhereRO = Where + WhereDate + order;

            dt = Classes.RetrieveData(Select, WhereRO, "BinAdjView");
            foreach (DataRow DR in dt.Rows)
            {
                DataRow Ndr = DtItem_BinCard.NewRow();
                Ndr["BQty"] = BBalance[DR["KitchenName"].ToString()].Item1;
                Ndr["BCost"] = BBalance[DR["KitchenName"].ToString()].Item2;

                Ndr["EQty"] = EBalance[DR["KitchenName"].ToString()].Item1;
                Ndr["ECost"] = EBalance[DR["KitchenName"].ToString()].Item2;

                Ndr["Qty"] = "-" + DR["Qty"].ToString();
                Ndr["Cost"] = DR["Cost"].ToString();
                Ndr["KitchenName"] = DR["KitchenName"].ToString();
                Ndr["RestaurantName"] = DR["RestaurantName"].ToString();
                Ndr["TransDetails"] = "Total Adjustment";
                Ndr["Type"] = DR["Category"].ToString();

                DtItem_BinCard.Rows.Add(Ndr);
            }
            //Transfer In
            Select = "RestaurantName,KitchenName,Category,SUM(Qty) as Qty ,sum(Cost) as Cost";
            WhereDate = " And Receiving_Date " + Date;
            WhereRO = Where + WhereDate + order;
            dt = Classes.RetrieveData(Select, WhereRO, "TransferItemsIn");
            foreach (DataRow DR in dt.Rows)
            {
                DataRow Ndr = DtItem_BinCard.NewRow();

                Ndr["BQty"] = BBalance[DR["KitchenName"].ToString()].Item1;
                Ndr["BCost"] = BBalance[DR["KitchenName"].ToString()].Item2;

                Ndr["EQty"] = EBalance[DR["KitchenName"].ToString()].Item1;
                Ndr["ECost"] = EBalance[DR["KitchenName"].ToString()].Item2;

                Ndr["Qty"] = DR["Qty"].ToString();
                Ndr["Cost"] = DR["Cost"].ToString();
                Ndr["KitchenName"] = DR["KitchenName"].ToString();
                Ndr["RestaurantName"] = DR["RestaurantName"].ToString();
                Ndr["TransDetails"] = "Total Transfer In";
                Ndr["Type"] = DR["Category"].ToString();
                DtItem_BinCard.Rows.Add(Ndr);
            }
            //Transfer to
            WhereDate = " And Request_Date " + Date;
            WhereRO = Where + WhereDate + order;
            dt = Classes.RetrieveData(Select, WhereRO, "TransferItemsOut");

            foreach (DataRow DR in dt.Rows)
            {
                DataRow Ndr = DtItem_BinCard.NewRow();
                Ndr["BQty"] = BBalance[DR["KitchenName"].ToString()].Item1;
                Ndr["BCost"] = BBalance[DR["KitchenName"].ToString()].Item2;

                Ndr["EQty"] = EBalance[DR["KitchenName"].ToString()].Item1;
                Ndr["ECost"] = EBalance[DR["KitchenName"].ToString()].Item2;

                Ndr["Qty"] = "-" + DR["Qty"].ToString();
                Ndr["Cost"] = DR["Cost"].ToString();
                Ndr["KitchenName"] = DR["KitchenName"].ToString();
                Ndr["RestaurantName"] = DR["RestaurantName"].ToString();
                Ndr["TransDetails"] = "Total Transfer Out";
                Ndr["Type"] = DR["Category"].ToString();
                DtItem_BinCard.Rows.Add(Ndr);
            }

            ReportView Rec = new ReportView();
            Rec.Rpt = new Cr_MonthClosing();
            Rec.Rpt.SetDataSource(DtItem_BinCard);
            Rec.Rpt.SetParameterValue("Filter", Filter);
            Rec.Show();


        }

    }
}
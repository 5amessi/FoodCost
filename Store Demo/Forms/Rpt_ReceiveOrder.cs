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
    public partial class Rpt_ReceiveOrder : Form
    {
        public Rpt_ReceiveOrder()
        {
            InitializeComponent();
        }
        string Where = "";
        string Filter = "";
        string s = "";
        string f = "";
        string s2 = "";
        DataTable Dt;
        DataTable Dt2;
        Dictionary<string, string> dic = new Dictionary<string, string>();
        Dictionary<string, string> Stores = new Dictionary<string, string>();
        Dictionary<string, List<string>> FilterDic = new Dictionary<string, List<string>>();

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            if (CBMyKitchen.Checked)
            {
                Where = "";
                Filter = "";
                uC_TVKitchens1.Kitchen_Checked(ref f, ref Where);
            }
            else
            {
                Where = " Restaurant_ID IN (1) AND Kitchen_ID IN (1)";
                Filter = "Kitchen: My kitchen";
            }
            List<string> type = new List<string>();
            if (CBPurchase.Checked)
            {
                type.Add("'Recieve_Purchase'");
            }
            if (CBAutoPurchase.Checked)
            {
                type.Add("'Auto_Recieve'");
            }
            if (CBKitchenTransfer.Checked)
            {
                type.Add("'Transfer_Kitchen'");
            }
            if (CBRestaurantTransfer.Checked)
            {
                type.Add("'Transfer_Resturant'");
            }
            if (type.Count != 0)
            {
                string s = "";
                Where += "And Type IN (";
                foreach (string st in type)
                {
                    Where += s + st;
                    s = ",";
                }
                Where += ")";
            }

            Where += "And Receiving_Date between '" + dtp_from.Value + "' AND '" + dtp_to.Value.AddHours(23.9999) + "'";

            DataTable dt = Classes.RetrieveData("*", Where, "ReceiveOrderView");
            ReportView Rec = new ReportView();
            Rec.Rpt = new CR_ReceiveOrder();
            Rec.Rpt.SetDataSource(dt);
            Rec.Rpt.SetParameterValue("Rpt_Fdate", dtp_from.Value);
            Rec.Rpt.SetParameterValue("Rpt_Tdate", dtp_to.Value);
            Rec.Rpt.SetParameterValue("Filter", Filter);

            Rec.Show();
        }
    }
}

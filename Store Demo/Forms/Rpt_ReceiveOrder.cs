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
        DataTable dt;

        private void ShowBtn_Click(object sender, EventArgs e)
        {
            if (!CBMyKitchen.Checked)
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
                type.Add("'Recieve_Purchase'");
            if (CBAutoPurchase.Checked)
                type.Add("'Auto_Recieve'");
            if (CBKitchenTransfer.Checked)
                type.Add("'Transfer_Kitchen'");
            if (CBRestaurantTransfer.Checked)
                type.Add("'Transfer_Resturant'");
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
            Where += "And Receiving_Date between '" + Classes.ADjDate(dtp_from.Value) + "' AND '" + Classes.ADjDateto(dtp_to.Value) + "'";
            ReportView Rec = new ReportView();
            if (RBPurchase.Checked == true)
            {
                dt = Classes.RetrieveData("*", Where, "ReceivePoView");
                Rec.Rpt = new CR_ReceiveOrder();
            }
            else
            {
                dt = Classes.RetrieveData("*", Where, "ReceiveTransferOrders");
                Rec.Rpt = new CR_ReceiveTransfer();
            }
            Rec.Rpt.SetDataSource(dt);
            Rec.Rpt.SetParameterValue("Rpt_Fdate", dtp_from.Value);
            Rec.Rpt.SetParameterValue("Rpt_Tdate", dtp_to.Value);
            Rec.Rpt.SetParameterValue("Filter", Filter);

            Rec.Show();
        }

        private void uC_TVKitchens1_Load(object sender, EventArgs e)
        {
            uC_TVKitchens1.UC_TVKitchens_Load();
        }

        private void RBPurchase_CheckedChanged(object sender, EventArgs e)
        {
            if(RBPurchase.Checked == true)
            {
                CBPurchase.Visible = true;
                CBAutoPurchase.Visible = true;

                CBRestaurantTransfer.Checked = false;
                CBKitchenTransfer.Checked = false;

                CBRestaurantTransfer.Visible = false;
                CBKitchenTransfer.Visible = false;
            }
            else
            {
                CBPurchase.Checked = false;
                CBAutoPurchase.Checked = false;

                CBPurchase.Visible = false;
                CBAutoPurchase.Visible = false;

                CBRestaurantTransfer.Visible = true;
                CBKitchenTransfer.Visible = true;
            }
        }
    }
}

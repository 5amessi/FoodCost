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
    public partial class Rpt_ReceiveItems : Form
    {
        public Rpt_ReceiveItems()
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
                UC_TVKitchens2.Kitchen_Checked(ref f, ref Where);
            }
            else
            {
                Where = " Restaurant_ID IN (1) AND Kitchen_ID IN (1)";
                Filter = "Kitchen: My kitchen";
            }
            if (CbToday.Checked == true)
            {
                dtp_from.Value = DateTime.Today;
                dtp_to.Value = DateTime.Today;
            }
            if (TxtItemCode.Text.ToString() != "")
            {
                Where += " AND Item_ID = '" + TxtItemCode.Text.ToString() + "'";
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
            if (RbOrders.Checked == true && RBPurchase.Checked == true)
            {
                dt = Classes.RetrieveData("*", Where, "ReceivePoView");
                Rec.Rpt = new CR_ReceiveOrder();
            }
            else if (RbOrders.Checked == true && RBTransfer.Checked == true)
            {
                dt = Classes.RetrieveData("*", Where, "ReceiveTransferOrders");
                Rec.Rpt = new CR_ReceiveTransfer();
            }
            else if (RbItems.Checked == true && RBPurchase.Checked == true)
            {
                dt = Classes.RetrieveData("*", Where, "ReceivePIView");
                Rec.Rpt = new CR_ReceiveItemes();
            }
            else if (RbItems.Checked == true && RBTransfer.Checked == true)
            {
                dt = Classes.RetrieveData("*", Where, "ReceiveTransferItems");
                Rec.Rpt = new CR_ReceiveTransferItemes();
            }           
     
            Rec.Rpt.SetDataSource(dt);
            Rec.Rpt.SetParameterValue("Rpt_Fdate", dtp_from.Value);
            Rec.Rpt.SetParameterValue("Rpt_Tdate", dtp_to.Value);
            Rec.Rpt.SetParameterValue("Filter", Filter);

            if (RbItems.Checked)
            {
                double Food = 0, Bev = 0, Gen = 0;

                foreach (DataRow DR in dt.Rows)
                {
                    if (DR["Category"].ToString() == "Food")
                        Food++;
                    if (DR["Category"].ToString() == "Beverage")
                        Bev++;
                    if (DR["Category"].ToString() == "General")
                        Gen++;
                }
                if (dt.Rows.Count != 0)
                {
                    Food = Food / dt.Rows.Count;
                    Bev = Bev / dt.Rows.Count;
                    Gen = Gen / dt.Rows.Count;
                }
                Rec.Rpt.SetParameterValue("Food", Food);
                Rec.Rpt.SetParameterValue("Beverage", Bev);
                Rec.Rpt.SetParameterValue("General", Gen);
            }
            Rec.Show();

        }

        private void BtnItem_Click(object sender, EventArgs e)
        {
            FrmSelection frm = new FrmSelection();
            frm.loaddata("Code", "Name", "Setup_Items");
            frm.ShowDialog();
            if (frm.Code != "" && frm.Code != null)
            {
                TxtItemCode.Text = frm.selrow.Cells[0].Value.ToString();
                TxtItemName.Text = frm.selrow.Cells[1].Value.ToString();
            }
        }

        private void UC_TVKitchens2_Load(object sender, EventArgs e)
        {
            UC_TVKitchens2.UC_TVKitchens_Load();
        }

        private void RBPurchase_CheckedChanged(object sender, EventArgs e)
        {
            if (RBPurchase.Checked == true)
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

        private void RbOrders_CheckedChanged(object sender, EventArgs e)
        {
            if (RbOrders.Checked == true)
            {
                GbItem.Visible = false;
            }
        }

        private void RbItems_CheckedChanged(object sender, EventArgs e)
        {
            if (RbItems.Checked == true)
            {
                GbItem.Visible = true;
            }
        }
    }
}

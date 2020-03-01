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
    public partial class Rpt_Request : Form
    {
        public Rpt_Request()
        {
            InitializeComponent();
        }
        string Where = "";
        string Filter = "";
        string s = "";
        string f = "";
        string s2 = "";
        DataTable Dt;

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
                Where = " (Restaurant_ID = 1 AND Kitchen_ID = 1)";
                Filter = "Kitchen: My kitchen";
            }
            if (CbToday.Checked == true)
            {
                dtp_from.Value = DateTime.Today;
                dtp_to.Value = DateTime.Today;
            }
            if (BtnCreateDate.Checked == true)
            {
                Where += " And Create_Date between '" + Classes.ADjDate(dtp_from.Value) + "' AND '" + Classes.ADjDateto(dtp_to.Value) + "'";
                Filter += " \n" + "Date: Create_Date";
            }
            else if (BtnDeliveryDate.Checked == true)
            {
                Where += " And Delivery_Date between '" + Classes.ADjDate(dtp_from.Value) + "' AND '" + Classes.ADjDateto(dtp_to.Value) + "'";
                Filter += " \n" + "Date: Delivery_Date";
            }

            ReportView Rec = new ReportView();
            if (RbOrders.Checked == true && RbPurchase.Checked == true)
            {
                Dt = Classes.RetrieveData("*", Where, "POView");
                Rec.Rpt = new CR_PO();
            }
            else if(RbItems.Checked == true && RbPurchase.Checked == true)
            {
                if (TxtItemCode.Text.ToString() != "")
                {
                    Where += " AND Item_ID = '" + TxtItemCode.Text.ToString() + "'";
                }
                Dt = Classes.RetrieveData("*", Where, "POItems");
                Rec.Rpt = new CR_POitems();
            }
            else if (RbOrders.Checked == true && RbTransfer.Checked == true)
            {
                Where = Where.Replace("Delivery_Date", "Transfer_Date");
                Dt = Classes.RetrieveData("*", Where, "RequestTransferView");
                Rec.Rpt = new CR_RequestTransferOrder();
            }
            else if (RbItems.Checked == true && RbTransfer.Checked == true)
            {
                Where = Where.Replace("Delivery_Date", "Transfer_Date");
                if (TxtItemCode.Text.ToString() != "")
                {
                    Where += " AND Item_ID = '" + TxtItemCode.Text.ToString() + "'";
                }
                Dt = Classes.RetrieveData("*", Where, "RequestTransferItemsView");
                Rec.Rpt = new CR_RequestTransferItems();
            }
            Rec.Rpt.SetDataSource(Dt);
            Rec.Rpt.SetParameterValue("Rpt_Fdate", Classes.ADjDate(dtp_from.Value));
            Rec.Rpt.SetParameterValue("Rpt_Tdate", dtp_to.Value);
            Rec.Rpt.SetParameterValue("Filter", Filter);
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

        private void RbItems_CheckedChanged(object sender, EventArgs e)
        {
            if (RbItems.Checked == true)
            {
                GbItem.Visible = true;
            }
        }

        private void RbOrders_CheckedChanged(object sender, EventArgs e)
        {
            if (RbOrders.Checked == true)
            {
                GbItem.Visible = false;
            }
        }
        private void UC_TVKitchens2_Load(object sender, EventArgs e)
        {
            UC_TVKitchens2.UC_TVKitchens_Load();

        }

        private void CbToday_CheckedChanged(object sender, EventArgs e)
        {
            if (CbToday.Checked == true) 
                GbDate.Enabled = false;
            else
                GbDate.Enabled = true;
        }

        private void Rpt_PurchaseItems_Load(object sender, EventArgs e)
        {

        }
    }
}

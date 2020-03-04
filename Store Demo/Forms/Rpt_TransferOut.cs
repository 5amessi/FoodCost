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
    public partial class Rpt_TransferOut : Form
    {
        public Rpt_TransferOut()
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
                Where = " Restaurant_ID IN (1) AND Kitchen_ID IN (1)";
                Filter = "Kitchen: My kitchen";
            }

            if (TxtItemCode.Text.ToString() != "")
            {
                Where += " AND Item_ID = '" + TxtItemCode.Text.ToString() + "'";
            }

            if (CbToday.Checked == true)
            {
                dtp_from.Value = DateTime.Today;
                dtp_to.Value = DateTime.Today;
            }
            List<string> status = new List<string>();
            if (CbPost.Checked)
                status.Add("'Post'");
            if (CbHold.Checked)
                status.Add("'Hold'");
            if (CbApproval.Checked)
                status.Add("'Approval'");
            if (CbRejected.Checked)
                status.Add("'Rejected'");
            if (status.Count != 0)
            {
                string s = "";
                Where += "And Status IN (";
                foreach (string st in status)
                {
                    Where += s + st;
                    s = ",";
                }
                Where += ")";
            }

            ReportView Rec = new ReportView();
            Where += " And Request_Date between '" + Classes.ADjDate(dtp_from.Value) + "' AND '" + Classes.ADjDateto(dtp_to.Value) + "'";
            if (RbItems.Checked == true)
            {
                if (TxtItemCode.Text.ToString() != "") 
                {
                    Where += " AND Item_ID = '" + TxtItemCode.Text.ToString() + "'";
                }
                Dt = Classes.RetrieveData("*", Where, "TransferItemsOut");
                Rec.Rpt = new CR_TransferOutDetails();
            }
            if (RbOrders.Checked == true)
            {
                Dt = Classes.RetrieveData("*", Where, "TransferOrdersOut");
                Rec.Rpt = new CR_TransferOutSummary();
            }

            Rec.Rpt.SetDataSource(Dt);
            Rec.Rpt.SetParameterValue("Rpt_Fdate", dtp_from.Value);
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

        private void GrpDateTimeRange_Enter(object sender, EventArgs e)
        {

        }
    }
}

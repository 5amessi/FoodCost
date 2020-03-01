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
    public partial class Rpt_TransferItems : Form
    {
        public Rpt_TransferItems()
        {
            InitializeComponent();
        }
        string Where = "";
        string Filter = "";
        string s = "";
        string f = "";
        string s2 = "";
        DataTable Dt;
        Dictionary<string, string> dic = new Dictionary<string, string>();
        Dictionary<string, string> Stores = new Dictionary<string, string>();
        Dictionary<string, List<string>> FilterDic = new Dictionary<string, List<string>>();

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

            Where += " And Transfer_Date between '" + Classes.ADjDate(dtp_from.Value) + "' AND '" + Classes.ADjDateto(dtp_to.Value) + "'";
        
            ReportView Rec = new ReportView();

            if (RbOrders.Checked == true)
            {
                Dt = Classes.RetrieveData("*", Where, "RequestTransferView");
                Rec.Rpt = new CR_RequestTransferOrder();
            }

            else
            {
                if (TxtItemCode.Text.ToString() != "")
                {
                    Where += " AND Item_ID = '" + TxtItemCode.Text.ToString() + "'";
                }
                Dt = Classes.RetrieveData("*", Where, "RequestTransferItemsView");
                Rec.Rpt = new CR_RequestTransferItems();
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
    }
}

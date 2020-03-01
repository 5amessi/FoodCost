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
    public partial class Rpt_Vendors : Form
    {
        public Rpt_Vendors()
        {
            InitializeComponent();
        }

        string Where = "";
        string Filter = "";
        string s2 = "";
        DataTable dt;
        Dictionary<string, string> dic = new Dictionary<string, string>();
        private void ShowBtn_Click(object sender, EventArgs e)
        {
            if (!CBMyKitchen.Checked)
            {
                Where = "";
                Filter = "";
                UC_TVKitchens2.Kitchen_Checked(ref Filter, ref Where);
            }
            else
            {
                Where = " Restaurant_ID IN (1) AND Kitchen_ID IN (1)";
                Filter = "Kitchen: My kitchen";
            }

            Where += "And Type = 'Recieve_Purchase'";
            Where += "And Receiving_Date between '" + Classes.ADjDate(dtp_from.Value) + "' AND '" + Classes.ADjDateto(dtp_to.Value) + "'";

            ReportView Rec = new ReportView();
            if (RBSummary.Checked == true)
            {
                dt = Classes.RetrieveData("*", Where, "ReceivePoView");
                Rec.Rpt = new CR_VendorsSummary();
                Rec.Rpt.SetDataSource(dt);
            }
            else
            {
                dt = Classes.RetrieveData("*", Where, "ReceivePIView");
                Rec.Rpt = new CR_VendorsDetails();
                Rec.Rpt.SetDataSource(dt);

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
           

            Rec.Rpt.SetParameterValue("Rpt_Fdate", dtp_from.Value);
            Rec.Rpt.SetParameterValue("Rpt_Tdate", dtp_to.Value);
            Rec.Rpt.SetParameterValue("Filter", Filter);


            Rec.Show();
        }

        private void BtnItem_Click(object sender, EventArgs e)
        {
            FrmSelection frm = new FrmSelection();
            frm.loaddata("Code", "Name", "Vendors");
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
    }
}

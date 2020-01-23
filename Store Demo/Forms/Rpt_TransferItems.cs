﻿using System;
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

            DataTable KTdt = Classes.RetrieveData("*", Where, "TransferItemsFrom");
            KTdt.Rows.Clear();

            //Transfer from
            string WhereTransfer = Where + " And Transfer_Date between '" + dtp_from.Value + "' AND '" + dtp_to.Value + "'";
            Dt = Classes.RetrieveData("*", WhereTransfer, "TransferItemsFrom");
            foreach (DataRow DR in Dt.Rows)
            {
                DataRow Ndr = KTdt.NewRow();
                Ndr["RestaurantName"] = DR["RestaurantName"].ToString();
                Ndr["KitchenName"] = DR["KitchenName"].ToString();
                Ndr["ItemName"] = DR["ItemName"].ToString();
                Ndr["Transfer_Date"] = DR["Transfer_Date"].ToString();
                Ndr["Type"] = "Transferd from " + DR["FromRestaurantName"].ToString() + " Restaurant and " + DR["FromKitchenName"].ToString() + " Kitchen";
                Ndr["Qty"] = DR["Qty"].ToString();
                Ndr["Unit"] = DR["Unit"].ToString();
                Ndr["Cost"] = DR["Cost"].ToString();
                Ndr["Net Cost"] = DR["Net Cost"].ToString();
                KTdt.Rows.Add(Ndr);
            }
            //Transfer to
            Dt = Classes.RetrieveData("*", WhereTransfer, "TransferItemsTo");
            foreach (DataRow DR in Dt.Rows)
            {
                DataRow Ndr = KTdt.NewRow();
                Ndr["RestaurantName"] = DR["RestaurantName"].ToString();
                Ndr["KitchenName"] = DR["KitchenName"].ToString();
                Ndr["Transfer_Date"] = DR["Transfer_Date"].ToString();
                Ndr["ItemName"] = DR["ItemName"].ToString();
                Ndr["Type"] = "Transferd To " + DR["ToRestaurantName"].ToString() + " Restaurant and " + DR["ToKitchenName"].ToString() + " Kitchen";
                Ndr["Qty"] = DR["Qty"].ToString();
                Ndr["Unit"] = DR["Unit"].ToString();
                Ndr["Cost"] = DR["Cost"].ToString();
                Ndr["Net Cost"] = DR["Net Cost"].ToString();
                KTdt.Rows.Add(Ndr);
            }
            ReportView Rec = new ReportView();
            Rec.Rpt = new CR_Transfer();
            Rec.Rpt.SetDataSource(KTdt);
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Food_Cost.Report;


namespace Food_Cost
{
    public class Recalculate
    {
        static string where, cols, values;
        static double Qty, Cost;
        static Dictionary<string, string> changed_trasfers = new Dictionary<string, string>();
        static Dictionary<string, string> item_cost = new Dictionary<string, string>();
        static DataTable BETable;
        private static void Insert(int k)
        {
            values = "";
            cols = "_DATE,Restaurant_ID,Kitchen_ID,KitchenName,Trantype,ID,Item_ID,Qty,AcQty,Cost,CurrentCost";
            string s = "";
            for (int i = 0; i < BETable.Columns.Count; i++)
            {
                values += s + "'" + BETable.Rows[k][i].ToString() + "'";
                s = ",";
            }
            Classes.InsertRow("TransActions", cols, values);
        }

        private static void CalculateQty(DataRow DRCurrentMonth)
        {
            Classes.CreateTable("TransActions", "_DATE datetime,Restaurant_ID int,Kitchen_ID int,KitchenName varchar(50),Trantype varchar(50),ID varchar(50),Item_ID varchar(50),ItemName varchar(50),Qty bigint,AcQty bigint,Cost float,CurrentCost float");
            BETable = Classes.RetrieveStoredWithParamaeters("SPTransActions", "@StartDate,@EndDate", DRCurrentMonth["From"].ToString()+','+DRCurrentMonth["To"].ToString());
            where = "_DATE between '" + DRCurrentMonth["From"].ToString() + "' AND '" + DRCurrentMonth["To"].ToString() + "'";
            Classes.DeleteRows(where,"TransActions");

            for (int k = 0; k < BETable.Rows.Count; k++)
            {
                if (BETable.Rows[k]["Trantype"].ToString() == "Adjactment")
                {
                    Insert(k);
                    continue;
                }
                if (k == 0)
                {
                    Insert(k);
                }
                else if (BETable.Rows[k]["Item_ID"].ToString() == BETable.Rows[k - 1]["Item_ID"].ToString() && BETable.Rows[k]["KitchenName"].ToString() == BETable.Rows[k - 1]["KitchenName"].ToString())
                {
                    BETable.Rows[k]["AcQty"] = (double.Parse(BETable.Rows[k]["AcQty"].ToString()) + double.Parse(BETable.Rows[k - 1]["AcQty"].ToString())).ToString();
                    Insert(k);
                }
                else
                {
                    Insert(k);
                }
            }
        }

        private static void CalculateCost(DataRow DRCurrentMonth)
        {
            where = "_DATE between '" + DRCurrentMonth["From"].ToString() + "' AND '" + DRCurrentMonth["To"].ToString() + "'";
            string order = " order by Item_ID, _DATE ";

            DataTable Transactions = Classes.RetrieveData("*", where+order,"TransActions");

            for (int i = 0; i < Transactions.Rows.Count; i++)
            {
                string itemCostKey = Transactions.Rows[i]["KitchenName"].ToString() + Transactions.Rows[i]["Item_ID"].ToString();
                string ChangedTranKye = Transactions.Rows[i]["ID"].ToString() + Transactions.Rows[i]["Item_ID"].ToString();

                where = "Trantype = '" + Transactions.Rows[i]["Trantype"].ToString();
                where += "' AND Item_ID = '" + Transactions.Rows[i]["Item_ID"].ToString();
                where += "' AND ID = '" + Transactions.Rows[i]["ID"].ToString() + "'";

                if (Transactions.Rows[i]["Trantype"].ToString() == "Receive" || Transactions.Rows[i]["Trantype"].ToString() == "Transfer_In")
                {
                    if (changed_trasfers.ContainsKey(ChangedTranKye) == true && Transactions.Rows[i]["Trantype"].ToString() == "Transfer_In")
                    {
                        Cost = double.Parse(changed_trasfers[ChangedTranKye]);
                    }
                    else
                    {
                        Cost = double.Parse(Transactions.Rows[i]["Cost"].ToString());
                    }

                    if (Transactions.Rows[i]["AcQty"].Equals(Transactions.Rows[i]["Qty"]))
                    {
                        item_cost[itemCostKey] = Cost.ToString();
                        Classes.UpdateCell("CurrentCost", Cost.ToString(), where, "TransActions");
                    }
                    else
                    {
                        double CurrentCost;
                        double CurrentQty = double.Parse(Transactions.Rows[i]["AcQty"].ToString()) - double.Parse(Transactions.Rows[i]["Qty"].ToString());
                        Qty = double.Parse(Transactions.Rows[i]["Qty"].ToString());
                        if (item_cost.ContainsKey(itemCostKey))
                            CurrentCost = double.Parse(item_cost[itemCostKey]);
                        else
                            CurrentCost = double.Parse(Transactions.Rows[i]["Cost"].ToString());

                        double AcQty = double.Parse(Transactions.Rows[i]["AcQty"].ToString());
                        string NewCost;

                        if (AcQty == 0)
                        {
                            NewCost = "0";
                        }
                        else
                        {
                            NewCost = ((CurrentCost * CurrentQty + Cost * Qty) / AcQty).ToString();
                        }

                        item_cost[itemCostKey] = NewCost;
                        Classes.UpdateCell("CurrentCost", NewCost.ToString(), where, "TransActions");
                    }
                }
                else if (Transactions.Rows[i]["Trantype"].ToString() == "Adjactment")
                {
                    item_cost[itemCostKey] = Transactions.Rows[i]["Cost"].ToString();
                    Classes.UpdateCell("CurrentCost", Transactions.Rows[i]["Cost"].ToString(), where, "TransActions");
                }
                else if (Transactions.Rows[i]["Trantype"].ToString() == "Transfer_Out")
                {
                    if (item_cost.ContainsKey(itemCostKey))
                    {
                        if (!item_cost[itemCostKey].Equals(Transactions.Rows[i]["Cost"].ToString()))
                        {
                            changed_trasfers[ChangedTranKye] = item_cost[itemCostKey];
                            Classes.UpdateCell("CurrentCost", item_cost[itemCostKey], where, "TransActions");

                            //where = "Item_ID = '" + Transactions.Rows[i]["Item_ID"].ToString() + "' AND Transfer_ID = '" + Transactions.Rows[i]["ID"].ToString() + "'";
                            //Classes.UpdateCell("Cost", item_cost[itemCostKey], where, "Transfer_Kitchens_Items");

                            where = "Item_ID = '" + Transactions.Rows[i]["Item_ID"].ToString() + "' AND Request_ID = '" + Transactions.Rows[i]["ID"].ToString() + "'";
                            Classes.UpdateCell("Cost", item_cost[itemCostKey], where, "Requests_Items");

                            where = "Item_ID = '" + Transactions.Rows[i]["Item_ID"].ToString() + "' AND RO_No = '" + Transactions.Rows[i]["ID"].ToString() + "'";
                            Classes.UpdateCell("Price_With_Tax", item_cost[itemCostKey], where, "RO_Items");
                        }
                    }
                }
            }
        }
        public static void ReCalculate_Cost_Qty(DataRow DRCurrentMonth)
        {
            try
            {
                CalculateQty(DRCurrentMonth);
                CalculateCost(DRCurrentMonth);
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
            MessageBox.Show("Qty And Cost have recalculated");
        }
        public static void CloseMonth(DataRow DRCurrentMonth)
        {
            try
            {
                cols = "Year varchar(50),Month varchar(50),FromDate datetime,ToDate datetime,Restaurant_ID int,Kitchen_ID int,Item_ID bigint,Qty bigint,Cost float";

                Classes.CreateTable("BeginningEndingMonth", cols);

                where = "Month = '" + DRCurrentMonth["Month"].ToString() + "' AND Year = '" + DRCurrentMonth["Year"].ToString() + "'";
                Classes.DeleteRows(where, "BeginningEndingMonth");

                DataTable Items = Classes.RetrieveData("Code", "Setup_Items");

                DataTable DTTop = new DataTable();

                DataTable Kitchens = Classes.RetrieveData("*", "Kitchens_Setup");

                string Dvalues = "('" + DRCurrentMonth["Year"] + "','" + DRCurrentMonth["Month"].ToString() + "','" + DRCurrentMonth["From"] + "','" + DRCurrentMonth["To"] + "'";

                foreach (DataRow KitName in Kitchens.Rows)
                {
                    values = "";
                    string Dkitchen = ",'" + KitName["Name"].ToString() + "'";
                    for ( int i=0; i< Items.Rows.Count; i++)
                    {
                        where = " _Date <= '" + DRCurrentMonth["To"] + "' AND Item_ID = '" + Items.Rows[i][0].ToString() + "' AND KitchenName = '" + KitName["Name"].ToString() + "' order by  _DATE DESC";
                        DTTop = Classes.RetrieveData("top 1 * ", where, "TransActions");

                        if (DTTop.Rows.Count != 0)
                        {
                            Qty = double.Parse(DTTop.Rows[0]["AcQty"].ToString());
                            Cost = double.Parse(DTTop.Rows[0]["CurrentCost"].ToString());
                        }
                        else
                        {
                            Qty = 0;
                            Cost = 0;
                        }
                        string DQtyCost = ",'" + Items.Rows[i][0].ToString() + "','" + Qty.ToString() + "','" + Cost.ToString() + "'";
                        string RestKitchen = ",'" + KitName["RestaurantID"].ToString() + "','" + KitName["Code"].ToString() + "'";
                        values += Dvalues + RestKitchen + DQtyCost + "),";
                        if(i%999 == 0 || i == Items.Rows.Count-1)
                        {
                            Classes.InsertRow("BeginningEndingMonth", values.Substring(1, values.Length - 3));
                        }
                    }
                }
                MessageBox.Show("Month Closed Successfully");
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
            }
        }
    }
}

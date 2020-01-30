using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace Food_Cost
{
    public class Classes
    {
        public static string RestaurantId, KitchenId, WorkstationId;
        public static string WS;
        public static string IDs;
        private static DataTable MyTable;
        private static SqlDataAdapter MyAdapt;
        public static SqlConnection MyConnection;
        private static SqlCommand MyComm;
        public static string DataConnString;

        public static void TheConnectionString()
        {
            try
            {
                string connString = System.IO.File.ReadAllText("MyCon.txt");

                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["Food_Cost.Properties.Settings.FoodCostDB"].ConnectionString = connString;
                config.Save();
                ConfigurationManager.RefreshSection("connectionStrings");
                DataConnString = Properties.Settings.Default.FoodCostDB.ToString();

    }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        public static void GetWS()
        {
            string WorkStationData = File.ReadAllText("Workstation.dll");
            string[] splitArr = WorkStationData.Split(',');
            WorkstationId = splitArr[0];
            RestaurantId = splitArr[1];
            KitchenId = splitArr[2];
            IDs = RestaurantId + KitchenId + WorkstationId;
            WS = WorkstationId;
        }

        public static DataTable RetrieveData(string FieldSelected, string TableName)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyAdapt = new SqlDataAdapter("select " + FieldSelected + " from " + TableName, MyConnection);
            MyTable = new DataTable();
            MyAdapt.Fill(MyTable);
            return MyTable;
        }

        public static DataTable RetrieveData(string SqlStr)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyAdapt = new SqlDataAdapter(SqlStr, MyConnection);
            MyTable = new DataTable();
            MyAdapt.Fill(MyTable);
            return MyTable;
        }

        public static DataTable RetrieveData(string FieldSelected, string WhereFiltering, string TableName)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyAdapt = new SqlDataAdapter("select " + FieldSelected + " from " + TableName + " where " + WhereFiltering, MyConnection);
            MyTable = new DataTable();
            MyAdapt.Fill(MyTable);
            return MyTable;
        }

        public static void UpdateCell(string FieldSelected, string Value, string TableName)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyConnection.Open();
            MyComm = new SqlCommand("Update " + TableName + " set " + FieldSelected + " = " + Value, MyConnection);
            MyComm.ExecuteNonQuery();
        }
        public static void UpdateCell(string FieldSelected, string Value, string WhereFiltering, string TableName)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyConnection.Open();
            MyComm = new SqlCommand("Update " + TableName + " set " + FieldSelected + " = '" + Value + "' where " + WhereFiltering, MyConnection);
            MyComm.ExecuteNonQuery();
        }

        public static void UpdateRow(string FieldSelected, string Value, string WhereFiltering, string TableName)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyConnection.Open();
            string[] FS = FieldSelected.Split(',');
            string[] V = Value.Split(',');
            string FSV = "";
            string comma = "";
            for (int i =0; i< FS.Length; i++)
            {
                FSV += comma + FS[i] + " = " + V[i];
                comma = ",";
            }
            MyComm = new SqlCommand("Update " + TableName + " set " + FSV + " where " + WhereFiltering, MyConnection);
            MyComm.ExecuteNonQuery();
        }

        public static void InsertRow(string TableName, string FieldSelected, string values)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyConnection.Open();
            MyComm = new SqlCommand("insert " + TableName + "(" + FieldSelected + ")" + " values (" + values + ")", MyConnection);
            MyComm.ExecuteNonQuery();
        }

        public static void InsertRow(string TableName, string values)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyConnection.Open();
            MyComm = new SqlCommand("insert into " + TableName + " values (" + values + ")", MyConnection);
            MyComm.ExecuteNonQuery();
        }

        public static DataTable RetrieveStored(string name)
        {
            MyTable = new DataTable();
            MyConnection = new SqlConnection(DataConnString);
            MyComm = new SqlCommand(name, MyConnection);
            MyComm.CommandType = CommandType.StoredProcedure;
            MyAdapt = new SqlDataAdapter(MyComm);
            MyAdapt.Fill(MyTable);
            return MyTable;

        }

        public static DataTable RetrieveStoredWithParamaeters(string name, string parameter, string values)
        {
            MyTable = new DataTable();
            MyConnection = new SqlConnection(DataConnString);
            MyComm = new SqlCommand(name, MyConnection);
            MyComm.CommandType = CommandType.StoredProcedure;
            string[] P = parameter.Split(',');
            string[] V = values.Split(',');
            for (int i = 0; i < P.Length; i++)
            {
                MyComm.Parameters.AddWithValue(P[i], V[i]);
            }
            MyAdapt = new SqlDataAdapter(MyComm);
            MyAdapt.Fill(MyTable);
            return MyTable;

        }

        public static void CreateTable(string TableName, string Coulmns)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyConnection.Open();

            string SQLCOMMAND = "IF NOT EXISTS(SELECT * FROM sysobjects WHERE name = '" + TableName + "' ) " +
                "CREATE TABLE[dbo]." + TableName + "( " + Coulmns + " ); ";

            MyComm = new SqlCommand(SQLCOMMAND, MyConnection);
            MyComm.ExecuteNonQuery();
        }

        public static void DeleteTable(string TableName)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyConnection.Open();

            string SQLCOMMAND = "IF EXISTS(SELECT * FROM sysobjects WHERE name = '" + TableName + "' ) " +
                "DELETE " + TableName;

            MyComm = new SqlCommand(SQLCOMMAND, MyConnection);
            MyComm.ExecuteNonQuery();
        }

        public static void DeleteRows(string WhereFiltering, string TableName)
        {
            MyConnection = new SqlConnection(DataConnString);
            MyConnection.Open();

            string SQLCOMMAND = "Delete from " + TableName + " where " + WhereFiltering;

            MyComm = new SqlCommand(SQLCOMMAND, MyConnection);
            MyComm.ExecuteNonQuery();
        }

        public static TreeView LoadStores(TreeView TVKitchens)
        {
            DataTable DT = Classes.RetrieveData("Code,Name", "Store_Setup");
            foreach (DataRow DR in DT.Rows)
            {
                TVKitchens.Nodes.Add(DR["Code"].ToString(), DR["Name"].ToString());
            }

            DT = Classes.RetrieveData("Code,Name,RestaurantID", "Kitchens_Setup order by RestaurantID,Code");
            foreach (DataRow DR in DT.Rows)
            {
                TVKitchens.Nodes[DR["RestaurantID"].ToString()].Nodes.Add(DR["Code"].ToString(), DR["Name"].ToString());
            }
            return TVKitchens;
        }

        public static TreeView LoadDates(TreeView TVDates)
        {
            DataTable DT = Classes.RetrieveData("*", "isClosed = 'True'", "Setup_Fiscal_Period");

            foreach (DataRow DR in DT.Rows)
            {
                if (!TVDates.Nodes.ContainsKey(DR["Year"].ToString()))
                {
                    TVDates.Nodes.Add(DR["Year"].ToString(), DR["Year"].ToString());

                }
                TVDates.Nodes[DR["Year"].ToString()].Nodes.Add("Month" + DR["Month"].ToString());
            }
            return TVDates;
        }
    }
}

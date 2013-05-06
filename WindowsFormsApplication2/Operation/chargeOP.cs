using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class chargeOP
    {
        SqlConnection connection = new SqlConnection();
        DataTable table = new DataTable();
        DataTable table2 = new DataTable();
        DataTable tablecharge = new DataTable();
        DataTable serviceChargeTable = new DataTable();
        DataTable tablecharge3 = new DataTable();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public DataTable createChargeTable()
        {
            serviceChargeTable.Clear();
            tablecharge.Clear();
            tablecharge3.Clear();
            DataTable tablecharge2 = new DataTable();
            tablecharge2.Columns.Add("Kodu", typeof(Int32));
            tablecharge2.Columns.Add("Adı", typeof(String));
            tablecharge2.Columns.Add("Soyadı", typeof(String));
            tablecharge2.Columns.Add("Toplam Alacak", typeof(Decimal));
            tablecharge2.Columns.Add("Para Birimi", typeof(String));
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from chargeLastView", connection);
            adapter.Fill(tablecharge);

            SqlDataAdapter adapterService = new SqlDataAdapter("Select * from serviceChargeView", connection);
            adapter.Fill(serviceChargeTable);

            for (int i = 0; i < tablecharge.Rows.Count; i++)
            {
                if (Convert.ToDecimal(tablecharge.Rows[i][3])-Convert.ToDecimal(tablecharge.Rows[i][4])>0)
                {
                    tablecharge2.Rows.Add(tablecharge.Rows[i][0], tablecharge.Rows[i][1], tablecharge.Rows[i][2], (Convert.ToDecimal(tablecharge.Rows[i][3]) - Convert.ToDecimal(tablecharge.Rows[i][4])), "TL");

                }
            }
            tablecharge3 = tablecharge2;
            return tablecharge2;
        }

        public DataTable chargeListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
        {
            DataTable tabl2 = new DataTable();
            tabl2 = tablecharge3.Clone();
            for (int i = 0; i < tablecharge3.Rows.Count; i++)
            {
                if (tablecharge3.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    tabl2.ImportRow(tablecharge3.Rows[i]);
                }
            }
            return tabl2;
        }
    }
}

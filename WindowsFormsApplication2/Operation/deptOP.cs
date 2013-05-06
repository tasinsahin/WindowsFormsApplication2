using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class deptOP
    {
        SqlConnection connection = new SqlConnection();

        DataTable table = new DataTable();
        DataTable tabledept = new DataTable();
        DataTable tabledept3 = new DataTable();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public DataTable createDeptTable()
        {
            tabledept.Clear();
            tabledept3.Clear();

            DataTable tabledept2 = new DataTable();
            tabledept2.Columns.Add("Kodu", typeof(Int32));
            tabledept2.Columns.Add("Firma Adı", typeof(String));
            tabledept2.Columns.Add("Sorumlu", typeof(String));
            tabledept2.Columns.Add("Toplam Verecek", typeof(Decimal));
            tabledept2.Columns.Add("Para Birimi", typeof(String));
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from deptLastView", connection);
            adapter.Fill(tabledept);
            for (int i = 0; i < tabledept.Rows.Count; i++)
            {
                if (Convert.ToDecimal(tabledept.Rows[i][3]) - Convert.ToDecimal(tabledept.Rows[i][4]) > 0)
                {
                    tabledept2.Rows.Add(tabledept.Rows[i][0], tabledept.Rows[i][1], tabledept.Rows[i][2], (Convert.ToDecimal(tabledept.Rows[i][3]) - Convert.ToDecimal(tabledept.Rows[i][4])), "TL");

                }
            }
            tabledept3 = tabledept2;
            return tabledept2;
        }
        public DataTable deptListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
        {
            DataTable tabl2 = new DataTable();
            tabl2 = tabledept3.Clone();
            for (int i = 0; i < tabledept3.Rows.Count; i++)
            {
                if (tabledept3.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    tabl2.ImportRow(tabledept3.Rows[i]);
                }
            }
            return tabl2;
        }
    }
}

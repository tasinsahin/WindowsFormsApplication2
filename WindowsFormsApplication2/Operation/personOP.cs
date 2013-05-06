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
    class personOP
    {
        SqlConnection connection = new SqlConnection();
        DataTable table = new DataTable();
        helper helper = new helper();


        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public DataTable createPersonTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from personView", connection);
            adapter.Fill(table);
            return table;
        }
        public DataTable personListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fon ksiyon// coloumn index gerekli
        {
            DataTable tabl2 = new DataTable();
            tabl2 = table.Clone();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    tabl2.ImportRow(table.Rows[i]);
                }
            }
            return tabl2;
        }
    }
}

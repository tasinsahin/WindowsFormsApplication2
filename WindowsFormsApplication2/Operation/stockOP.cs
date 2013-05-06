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
    class stockOP
    {
        SqlConnection connection = new SqlConnection();
        DataTable table = new DataTable();
        helper helper = new helper();

        int operation;
        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }

        public DataTable createStockTable()
        {
            createConnection();
            table.Clear();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from stockView", connection);
            adapter.Fill(table);

            return table;
        }
        public void stockIncrease(int productID,int amount,DateTime datee)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "stockUpdate";

            command.Parameters.Add("@productID", SqlDbType.Int, 50);
            command.Parameters["@productID"].Value = productID;
            command.Parameters.Add("@amount", SqlDbType.Int, 50);
            command.Parameters["@amount"].Value = amount;
            command.Parameters.Add("@datee", SqlDbType.DateTime, 50);
            command.Parameters["@datee"].Value = datee;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void stockDecrease(int productID, int amount,DateTime datee)
        {
            stockIncrease(productID, amount,datee);
        }

        public DataTable chargeListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
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

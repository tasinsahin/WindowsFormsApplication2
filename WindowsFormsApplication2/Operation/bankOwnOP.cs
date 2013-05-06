using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class bankOwnOP
    {
        SqlConnection connection = new SqlConnection();
        helper helper = new helper();
        DataTable table = new DataTable();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
         
        public DataTable createbankOwnTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from bankOwnView", connection);
            adapter.Fill(table);

            return table;
        }
        public void bankOwnAdd(bankOwn bankOwn)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "bankOwnAdd";
            
            command.Parameters.Add("@accountNumber", SqlDbType.Int, 50);
            command.Parameters["@accountNumber"].Value = bankOwn.accountNumber;
            command.Parameters.Add("@bankName", SqlDbType.NVarChar, 50);
            command.Parameters["@bankName"].Value = bankOwn.bankName;
            command.Parameters.Add("@officeName", SqlDbType.NVarChar, 50);
            command.Parameters["@officeName"].Value = bankOwn.officeName;
            command.Parameters.Add("@officeCode", SqlDbType.Int, 50);
            command.Parameters["@officeCode"].Value = bankOwn.officeCode;
            command.Parameters.Add("@moneyy", SqlDbType.NVarChar, 2);
            command.Parameters["@moneyy"].Value = bankOwn.money;
            command.Parameters.Add("@total", SqlDbType.Money, 50);
            command.Parameters["@total"].Value = bankOwn.total;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void banOwnDelete(int bankCode, int bankInfoCode)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "bankOwnDelete";

            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = bankCode;
            command.Parameters.Add("@bankInfoCode", SqlDbType.Int, 50);
            command.Parameters["@bankInfoCode"].Value = bankInfoCode;
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void bankOwnUpdate(bankOwn bankOwn)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "bankOwnUpdate";

            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = bankOwn.code;
            command.Parameters.Add("@accountNumber", SqlDbType.Int, 50);
            command.Parameters["@accountNumber"].Value = bankOwn.accountNumber;
            command.Parameters.Add("@bankName", SqlDbType.NVarChar, 50);
            command.Parameters["@bankName"].Value = bankOwn.bankName;
            command.Parameters.Add("@officeName", SqlDbType.NVarChar, 50);
            command.Parameters["@officeName"].Value = bankOwn.officeName;
            command.Parameters.Add("@officeCode", SqlDbType.Int, 50);
            command.Parameters["@officeCode"].Value = bankOwn.officeCode;
            command.Parameters.Add("@moneyy", SqlDbType.NVarChar, 10);
            command.Parameters["@moneyy"].Value = bankOwn.money;
            command.Parameters.Add("@total", SqlDbType.Money, 50);
            command.Parameters["@total"].Value = bankOwn.total;
            command.Parameters.Add("@bankInfoCode", SqlDbType.Int, 50);
            command.Parameters["@bankInfoCode"].Value = bankOwn.bankInfoCode;  

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }

        public DataTable callListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
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

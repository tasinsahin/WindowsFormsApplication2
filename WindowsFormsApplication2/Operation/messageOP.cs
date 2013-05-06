using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class messageOP
    {
        SqlConnection connection = new SqlConnection();
        DataTable table = new DataTable();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public void messageAdd(message message)
        {
            createConnection();
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("messageAdd", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@name", SqlDbType.Int, 50);
            command.Parameters["@name"].Value = message.PersonID;
            command.Parameters.Add("@grup", SqlDbType.Int, 50);
            command.Parameters["@grup"].Value = message.phoneNumber;
            command.Parameters.Add("@price", SqlDbType.Money, 50);
            command.Parameters["@price"].Value = message.userID;
            command.Parameters.Add("@brand", SqlDbType.Int, 50);
            command.Parameters["@brand"].Value = message.time;
            command.Parameters.Add("@discount", SqlDbType.Int, 50);
            command.Parameters["@discount"].Value = message.Title;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void messageDelete(int  code)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("messageDelete", connection);
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = code;

            command.ExecuteNonQuery();
                    
            connection.Close();
            connection.Dispose();
        }
        public void messageUpdate(message message)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("messageUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = message.ID;
            command.Parameters.Add("@name", SqlDbType.Int, 50);
            command.Parameters["@name"].Value = message.PersonID;
            command.Parameters.Add("@grup", SqlDbType.Int, 50);
            command.Parameters["@grup"].Value = message.phoneNumber;
            command.Parameters.Add("@price", SqlDbType.Money, 50);
            command.Parameters["@price"].Value = message.userID;
            command.Parameters.Add("@brand", SqlDbType.Int, 50);
            command.Parameters["@brand"].Value = message.time;
            command.Parameters.Add("@discount", SqlDbType.Int, 50);
            command.Parameters["@discount"].Value = message.Title;

            command.ExecuteNonQuery();
            
            connection.Close();
            connection.Dispose();

        }
        public DataTable createMessageTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From messageView", connection);
            adapter.Fill(table);
            return table;
        }
        public DataTable messageListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
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

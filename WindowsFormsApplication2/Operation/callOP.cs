using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class callOP
    {
        SqlConnection connection = new SqlConnection();
        helper helper = new helper();
        DataTable table = new DataTable();
        

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public void callAdd(call call)
        {
            createConnection();
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "callAdd";


            command.Parameters.Add("@phoneNumber", SqlDbType.Int, 50);
            command.Parameters["@phoneNumber"].Value = call.phoneNumber;
            command.Parameters.Add("@dateTime", SqlDbType.DateTime, 50);
            command.Parameters["@dateTime"].Value = call.dateTime;
            command.Parameters.Add("@duration", SqlDbType.Int, 50);
            command.Parameters["@duration"].Value = call.duration;
            command.Parameters.Add("@personID", SqlDbType.Int, 50);
            command.Parameters["@personID"].Value = call.personID;
            command.Parameters.Add("@inout", SqlDbType.NChar, 10);
            command.Parameters["@inout"].Value = call.inout;


            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        
        }
        public void callDelete(int code)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("callDelete", connection);
            command.CommandType = CommandType.StoredProcedure;



            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = code;

            command.ExecuteNonQuery();


            connection.Close();
            connection.Dispose();
        }
        public void callUpdate(call call)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("callUpdate", connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = call.code;
            command.Parameters.Add("@phoneNumber", SqlDbType.Int, 50);
            command.Parameters["@phoneNumber"].Value = call.phoneNumber;
            command.Parameters.Add("@dateTime", SqlDbType.DateTime, 50);
            command.Parameters["@dateTime"].Value = call.dateTime;
            command.Parameters.Add("@duration", SqlDbType.Int, 50);
            command.Parameters["@duration"].Value = call.duration;
            command.Parameters.Add("@personID", SqlDbType.Int, 50);
            command.Parameters["@personID"].Value = call.personID;
            command.Parameters.Add("@inout", SqlDbType.NChar, 10);
            command.Parameters["@inout"].Value = call.inout;


            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();

        }
        public DataTable createCallTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From callView", connection);
            adapter.Fill(table);
            return table;
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

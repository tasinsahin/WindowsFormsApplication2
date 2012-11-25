using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace WindowsFormsApplication2
{
    class serviceOP
    {
        SqlConnection connection = new SqlConnection();
        public void createConnection()
        {
            connection.ConnectionString = "server= /SQlExpress;Database=MasisTakipVT;Integrated Security=SSPI";
        }
        public void serviceAdd(string name)
        {
            createConnection();
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("serviceAdd", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void serviceDelete(string name)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("serviceDelete", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void serviceUpdate(string name)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("serviceUpdate", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();

        }
        public DataTable serviceTable()
        {
            createConnection();
            connection.Open();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From servicedb", connection);
            adapter.Fill(table);
            connection.Close();
            connection.Dispose();
            return table;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    class messageOP
    {
        SqlConnection connection = new SqlConnection();
        public void createConnection()
        {
            connection.ConnectionString = "server= /SQlExpress;Database=MasisTakipVT;Integrated Security=SSPI";
        }
        public void messageAdd(string name)
        {
            createConnection();
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("messageAdd", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void messageDelete(string name)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("messageDelete", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void messageUpdate(string name)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("messageUpdate", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();

        }
        public DataTable messageTable()
        {
            createConnection();
            connection.Open();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From messagedb", connection);
            adapter.Fill(table);
            connection.Close();
            connection.Dispose();
            return table;
        }

    }
}

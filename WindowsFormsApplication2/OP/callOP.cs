using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    class callOP
    {
        SqlConnection connection = new SqlConnection();
        public void createConnection()
        {
            connection.ConnectionString = "server= /SQlExpress;Database=MasisTakipVT;Integrated Security=SSPI";
        }
        public void callAdd(string name)
        {
            createConnection();
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("callAdd", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void callDelete(string name)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("callDelete", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void callUpdate(string name)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("callUpdate", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();

        }
        public DataTable callTable()
        {
            createConnection();
            connection.Open();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From calldb", connection);
            adapter.Fill(table);
            connection.Close();
            connection.Dispose();
            return table;
        }

    }
}

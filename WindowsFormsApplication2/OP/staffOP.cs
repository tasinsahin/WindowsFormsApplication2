using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
        class staffOP
        {
            SqlConnection connection = new SqlConnection();
            public void createConnection()
            {
                connection.ConnectionString = "server= /SQlExpress;Database=MasisTakipVT;Integrated Security=SSPI";
            }

            public void staffAdd(string name/*hepsini tek tek yazıcan*/)
            {
                createConnection();
                connection.Open();
                SqlCommand command = new SqlCommand("staffAdd", connection);
                command.CommandTimeout = 40;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(name);
                command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
            }
            public void staffDelete(string name) // tek tek yazıcan oğlum!
            {
                createConnection();
                connection.Open();
                SqlCommand command = new SqlCommand("staffDelete", connection);
                command.CommandTimeout = 40;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
                command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
            }
            public void staffUpdate(string name) /// tek tek yazıcan aga! 
            {
                createConnection();
                connection.Open();
                SqlCommand command = new SqlCommand("staffUpdate", connection);
                command.CommandTimeout = 40;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
                command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
            }
            public DataTable staffTable()
            {
                createConnection();
                connection.Open();
                DataTable table = new DataTable();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * From staffdb", connection);
                adapter.Fill(table);
                connection.Close();
                connection.Dispose();
                return table;

            }
        }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace WindowsFormsApplication2
{
    class companyOP
    {
        company company = new company();

        SqlConnection connection = new SqlConnection();
        public void createConnection()
        {
            connection.ConnectionString = "Data Source=SQLEXPRESS;Initial Catalog=masistakipVT;Integrated Security=True";

        }

        public void companyAdd(company company)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("companyAdd", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(company);
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void companyDelete(string name) // tek tek yazıcan oğlum!
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("companyDelete", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void companyUpdate(string name) /// tek tek yazıcan aga! 
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("companyUpdate", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public DataTable companyTable()
        {
            createConnection();
            connection.Open();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From companyView", connection);
            adapter.Fill(table);
            connection.Close();
            connection.Dispose();
            return table;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    class productOP
    {
        SqlConnection connection = new SqlConnection();
        public void createConnection()
        {
            connection.ConnectionString = "server= /SQlExpress;Database=MasisTakipVT;Integrated Security=SSPI";
        }
        public void productAdd(product product)
        {
            createConnection();
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productAdd";

            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = product.code;
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters["@name"].Value = product.name;
            command.Parameters.Add("@grup", SqlDbType.NVarChar, 50);
            command.Parameters["@grup"].Value = product.grup;
            command.Parameters.Add("@price", SqlDbType.Money, 50);
            command.Parameters["@price"].Value = Convert.DBNull;
            command.Parameters.Add("@brand", SqlDbType.Int, 50);
            command.Parameters["@brand"].Value = product.brand;
            command.Parameters.Add("@discount", SqlDbType.Int, 50);
            command.Parameters["@discount"].Value = product.discount;
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void productDelete(string name)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("productDelete", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void productUpdate(string name)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("productUpdate", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();

        }
        public DataTable productTable()
        {
            createConnection();
            connection.Open();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * From productdb", connection);
            adapter.Fill(table);
            connection.Close();
            connection.Dispose();
            return table;
        }

    }
}

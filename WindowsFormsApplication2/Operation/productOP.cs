using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class productOP
    {
        
        SqlConnection connection = new SqlConnection();
        DataTable table = new DataTable();
        DataTable tableStock = new DataTable();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        
        public DataTable createProductTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from productView", connection);
            adapter.Fill(table);

            return table;
        }
        public DataTable createProductStockTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from stockView", connection);
            adapter.Fill(tableStock);

            return tableStock;
        }
        public void productAdd(product product)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productAdd";

            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters["@name"].Value = product.name;
            command.Parameters.Add("@grup", SqlDbType.NVarChar, 50);
            command.Parameters["@grup"].Value = product.grup;
            command.Parameters.Add("@price", SqlDbType.Money, 50);
            command.Parameters["@price"].Value = product.price;
            command.Parameters.Add("@brand", SqlDbType.NVarChar, 50);
            command.Parameters["@brand"].Value = product.brand;
            command.Parameters.Add("@discount", SqlDbType.Int, 50);
            command.Parameters["@discount"].Value = product.discount;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void productDelete(int  code)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productDelete";

            command.Parameters.Add("@productCode", SqlDbType.Int);
            command.Parameters["@productCode"].Value = code;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void productUpdate(product product)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productUpdate";

            command.Parameters.Add("@productCode", SqlDbType.Int, 50);
            command.Parameters["@productCode"].Value = product.code;
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters["@name"].Value = product.name;
            command.Parameters.Add("@grup", SqlDbType.NVarChar, 50);
            command.Parameters["@grup"].Value = product.grup;
            command.Parameters.Add("@price", SqlDbType.Money, 50);
            command.Parameters["@price"].Value = product.price;
            command.Parameters.Add("@brand", SqlDbType.NVarChar, 50);
            command.Parameters["@brand"].Value = product.brand;
            command.Parameters.Add("@discount", SqlDbType.Int, 50);
            command.Parameters["@discount"].Value = product.discount;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();

        }
        public Array CreateProductBrandList() 
        {
            string[] list=new string[100];
            DataTable tablebrand = new DataTable();
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select brand from productdb", connection);
            adapter.Fill(tablebrand);
            for (int i = 0; i < tablebrand.Rows.Count; i++)
            {
                list[i] = table.Rows[i][0].ToString();
            }
            return list;
        }
        public DataTable ListDatatableByName(string name)
        {
            DataTable tableNew = new DataTable();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (table.Rows[i][1].ToString().StartsWith(name))
                {
                    tableNew.Rows.Add(table.Rows[i]);
                }
            }
            return tableNew;
        }

        public DataTable productListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
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
        public DataTable productStockListByVariable(string Variable, int ColoumnIndex)
        {
            DataTable tabl2 = new DataTable();
            tabl2 = tableStock.Clone();
            for (int i = 0; i < tableStock.Rows.Count; i++)
            {
                if (tableStock.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    tabl2.ImportRow(tableStock.Rows[i]);
                }
            }
            return tabl2;
        }
        


    }
}

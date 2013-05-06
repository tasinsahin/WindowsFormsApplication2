using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class productListOP
    {
        SqlConnection connection = new SqlConnection();
        DataTable table = new DataTable();
        DataTable listtable = new DataTable();
        DataTable customerByProductOrderId = new DataTable();
        productList productList = new productList();
        DataTable productListUpdateTable = new DataTable();
        helper helper = new helper();

        int productOrderID;
        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public DataTable createProductListTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from ProductListView", connection);
            adapter.Fill(table);

            return table;
        }
        public void productListAdd(productList productList)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productListAdd";

            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = productList.code;
            command.Parameters.Add("@productCode", SqlDbType.Int, 50);
            command.Parameters["@productCode"].Value = productList.productCode;
            command.Parameters.Add("@price", SqlDbType.Decimal, 50);
            command.Parameters["@price"].Value = productList.price;
            command.Parameters.Add("@discount", SqlDbType.Int, 50);
            command.Parameters["@discount"].Value = productList.discount;
            command.Parameters.Add("@amount", SqlDbType.Int, 50);
            command.Parameters["@amount"].Value = productList.amount;
            command.Parameters.Add("@ProductOrderID", SqlDbType.Int, 50);
            command.Parameters["@ProductOrderID"].Value = productList.ProductOrderID;


            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void productListUpdate(productList productList)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productListUpdate";

            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = productList.code;
            command.Parameters.Add("@productCode", SqlDbType.Int, 50);
            command.Parameters["@productCode"].Value = productList.productCode;
            command.Parameters.Add("@price", SqlDbType.Decimal, 50);
            command.Parameters["@price"].Value = productList.price;
            command.Parameters.Add("@discount", SqlDbType.Int, 50);
            command.Parameters["@discount"].Value = productList.discount;
            command.Parameters.Add("@amount", SqlDbType.Int, 50);
            command.Parameters["@amount"].Value = productList.amount;
            command.Parameters.Add("@ProductList", SqlDbType.Int, 50);
            command.Parameters["@ProductList"].Value = productList.ProductOrderID;


            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }

        public List<product> productListByProductOrderID(int productListCode)
        {
            productOrderID = productListCode;
            listtable.Clear();
            List<product> productList=new List<product>();

            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from productListView", connection);
            adapter.Fill(listtable);

            for (int i = 0; i < listtable.Rows.Count ; i++)
            {
                    if (productListCode == Convert.ToInt32(listtable.Rows[i][7]))
                    {
                        product product = new product();
                        product.code = Convert.ToInt32(listtable.Rows[i][0]);
                        product.price = Convert.ToDecimal(listtable.Rows[i][1]);
                        product.discount = Convert.ToInt32(listtable.Rows[i][2]);
                        product.amount = Convert.ToInt32(listtable.Rows[i][3]);
                        product.productOrderId = Convert.ToInt32(listtable.Rows[i][7]);
                        product.name = listtable.Rows[i][4].ToString();
                        product.grup = listtable.Rows[i][5].ToString();
                        product.brand = listtable.Rows[i][6].ToString();

                        productList.Add(product);
                    }
            }
            return productList;

        }
        public customer customerByProductOrderID()
        {
            customer customer = new customer();
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select customerId,ProductOrderID from productOrderSell", connection);
            adapter.Fill(customerByProductOrderId);

            DataTable table = new DataTable();
            SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from customerdb", connection);
            adapter2.Fill(table);

            for (int i = 0; i < customerByProductOrderId.Rows.Count; i++)
			{
                for (int j = 0; j < table.Rows.Count; j++)
                {
                    if (Convert.ToInt32(table.Rows[j][0])==Convert.ToInt32(customerByProductOrderId.Rows[i][0]))
                    {
                        customer.code = Convert.ToInt32(customerByProductOrderId.Rows[i][0]);
                        customer.name= table.Rows[j][1].ToString();
                        customer.surname = table.Rows[j][2].ToString();
                    }
                }
            }
            return customer; 
        }
        public void productListDelete()
        {
 
        }

    }
}

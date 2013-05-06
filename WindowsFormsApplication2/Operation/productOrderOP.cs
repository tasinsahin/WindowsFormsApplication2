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
    class productOrderOP
    {
        productOrder productOrder = new productOrder();
        DataTable productOrderSell = new DataTable();
        DataTable productOrderSell2 = new DataTable();
        DataTable productBuyTable = new DataTable();
        SqlConnection connection = new SqlConnection();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public DataTable createProductOrderTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from productOrderSellView", connection);
            adapter.Fill(productOrderSell);

            return productOrderSell;
        }
        public void productOrderDelivery(int productOrderID)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productOrderDelivery";

            command.Parameters.Add("@ProductOrderID", SqlDbType.NVarChar, 50);
            command.Parameters["@ProductOrderID"].Value = productOrderID;
            command.Parameters.Add("@deliveryDate", SqlDbType.DateTime, 50);
            command.Parameters["@deliveryDate"].Value = System.DateTime.Now;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void productOrderSellDelete(int code) // productOrderDelete add update procedure leri yok
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productOrderSellDelete";

            command.Parameters.Add("@ProductOrderID", SqlDbType.NVarChar, 50);
            command.Parameters["@ProductOrderID"].Value = code;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public int productOrderBuyAdd(productOrder productOrder)
        {
            int ProductOrdercode;
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productOrderBuyAdd";

            command.Parameters.Add("@ProductOrderID", SqlDbType.Int);
            command.Parameters["@ProductOrderID"].Direction = ParameterDirection.Output;

            command.Parameters.Add("@companyID", SqlDbType.Int, 50);
            command.Parameters["@companyID"].Value = productOrder.customerID;
            command.Parameters.Add("@dateTake", SqlDbType.DateTime);
            command.Parameters["@dateTake"].Value = productOrder.dateTake;
            command.Parameters.Add("@dateCarried", SqlDbType.DateTime);
            command.Parameters["@dateCarried"].Value = productOrder.dateCarried;
            command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
            command.Parameters["@status"].Value = productOrder.status;
            command.ExecuteNonQuery();
            ProductOrdercode = Convert.ToInt32(command.Parameters["@ProductOrderID"].Value);


            connection.Close();
            return ProductOrdercode;
        }
        public int productOrderSellAdd(productOrder productOrder)
        {
            int ProductOrdercode;
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productOrderSellAdd";

            command.Parameters.Add("@ProductOrderID", SqlDbType.Int);
            command.Parameters["@ProductOrderID"].Direction = ParameterDirection.Output;

            command.Parameters.Add("@customerID", SqlDbType.Int, 50);
            command.Parameters["@customerID"].Value = productOrder.customerID;
            command.Parameters.Add("@dateTake", SqlDbType.DateTime);
            command.Parameters["@dateTake"].Value = productOrder.dateTake;
            command.Parameters.Add("@dateCarried", SqlDbType.DateTime);
            command.Parameters["@dateCarried"].Value = productOrder.dateCarried;
            command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
            command.Parameters["@status"].Value = productOrder.status;
            command.ExecuteNonQuery();
            ProductOrdercode = Convert.ToInt32(command.Parameters["@ProductOrderID"].Value);
            
            
            connection.Close();
            return ProductOrdercode; 
        }
        public void productOrderSellUpdate(productOrder productOrder)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "productOrderSellUpdate";

            command.Parameters.Add("@ProductOrderID", SqlDbType.Int, 50);
            command.Parameters["@ProductOrderID"].Value = productOrder.productOrderCode;
            command.Parameters.Add("@customerID", SqlDbType.Int, 50);
            command.Parameters["@customerID"].Value = productOrder.customerID;
            command.Parameters.Add("@dateTake", SqlDbType.DateTime, 50);
            command.Parameters["@dateTake"].Value = productOrder.dateTake;
            command.Parameters.Add("@dateCarried", SqlDbType.DateTime, 50);
            command.Parameters["@dateCarried"].Value = productOrder.dateCarried;
            command.Parameters.Add("@status", SqlDbType.NVarChar, 50);
            command.Parameters["@status"].Value = productOrder.status;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose(); 
        }
        public DataTable productOrderListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
        {
            DataTable tabl2 = new DataTable();
            tabl2 = productOrderSell.Clone();
            for (int i = 0; i < productOrderSell.Rows.Count; i++)
            {
                if (productOrderSell.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    tabl2.ImportRow(productOrderSell.Rows[i]);
                }
            }
            return tabl2;
        }
        public DataTable productOrderListByDate(DateTime date1,DateTime date2,int ColoumnIndex)
        {
            DataTable tabl3 = new DataTable();
            tabl3 = productOrderSell.Clone();
            for (int i = 0; i < productOrderSell.Rows.Count; i++)
            {
                if (date1 <= Convert.ToDateTime(productOrderSell.Rows[i][ColoumnIndex]))
                {
                    if (Convert.ToDateTime(productOrderSell.Rows[i][ColoumnIndex])<=date2)
                    {
                        tabl3.ImportRow(productOrderSell.Rows[i]);
                    }
                }
            }
            return tabl3;
        }
        public DataTable productOrderSellView2()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from productOrderSellView", connection);
            adapter.Fill(productOrderSell2);

            return productOrderSell2;
        }
        public DataTable productOrderSellView2ByVariable(string Variable,int ColoumnIndex) 
        {
            DataTable table4 = new DataTable();
            table4 = productOrderSell2.Clone();
            for (int i = 0; i < productOrderSell2.Rows.Count; i++)
            {
                if (productOrderSell2.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    table4.ImportRow(productOrderSell2.Rows[i]);
                }
            }
            return table4;
        }
        public DataTable productOrderSellView2ByDate(DateTime date1,DateTime date2,int ColoumnIndex)
        {
            DataTable table5 = new DataTable();
            table5 = productOrderSell2.Clone();
            for (int i = 0; i < productOrderSell2.Rows.Count; i++)
            {
                if (date1<=Convert.ToDateTime(productOrderSell2.Rows[i][ColoumnIndex]))
                {
                    if (Convert.ToDateTime(productOrderSell2.Rows[i][ColoumnIndex])<=date2)
                    {
                        table5.ImportRow(productOrderSell2.Rows[i]);
                    }   
                }
            }
            return table5;
        }
        public DataTable producBuyTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from productBuyView", connection);
            adapter.Fill(productBuyTable);

            return productBuyTable;
        }
        public DataTable productBuyTableByVariable(string Variable, int ColoumnIndex)
        {
            DataTable table6=new DataTable();
            table6 = productBuyTable.Clone();
            for (int i = 0; i < productBuyTable.Rows.Count; i++)
            {
                if (productBuyTable.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    table6.ImportRow(productBuyTable.Rows[i]);
                }
            }
            return table6;
        }
        public DataTable productBuyTableByDate(DateTime date1,DateTime date2, int ColoumnIndex)
        {
            DataTable table7 = new DataTable();
            table7 = productBuyTable.Clone();
            for (int i = 0; i < productBuyTable.Rows.Count; i++)
            {
                if (date1 <= Convert.ToDateTime(productBuyTable.Rows[i][ColoumnIndex]))
                {
                    if (Convert.ToDateTime(productBuyTable.Rows[i][ColoumnIndex]) <= date2)
                    {
                        table7.ImportRow(productBuyTable.Rows[i]);
                    }
                }
            }
            return table7;
        }
    }
}

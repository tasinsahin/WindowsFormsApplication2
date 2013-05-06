using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class serviceOP
    {
        SqlConnection connection = new SqlConnection();
        DataTable table = new DataTable();
        DataTable serviceFullTable = new DataTable();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public DataTable createServiceTable()
        {
            table.Clear();
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from serviceView", connection);
            adapter.Fill(table);

            return table;
        }
        public void serviceAdd(service service)
        {
            createConnection();
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("serviceOrderAdd", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@customer", SqlDbType.Int, 50);
            command.Parameters["@customer"].Value =service.customerID ;
            command.Parameters.Add("@date", SqlDbType.DateTime, 50);
            command.Parameters["@date"].Value =service.datee ;
            command.Parameters.Add("@service", SqlDbType.NVarChar, 50);
            command.Parameters["@service"].Value =service.servicee ; 
            command.Parameters.Add("@serviceGroup", SqlDbType.NVarChar, 50);
            command.Parameters["@serviceGroup"].Value =service.serviceGroup;
            command.Parameters.Add("@timee", SqlDbType.NVarChar,50);
            command.Parameters["@timee"].Value = service.timee;
            command.Parameters.Add("@statuss", SqlDbType.Int, 50);
            command.Parameters["@statuss"].Value = service.statuss; 

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void serviceDelete(int code)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("serviceOrderDelete", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@serviceCode", SqlDbType.Int, 50);
            command.Parameters["@serviceCode"].Value =code;          

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void serviceUpdate(service service)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("serviceOrderUpdate", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@serviceCode", SqlDbType.Int, 50);
            command.Parameters["@serviceCode"].Value = service.code;
            command.Parameters.Add("@customer", SqlDbType.Int, 50);
            command.Parameters["@customer"].Value = service.customerID;
            command.Parameters.Add("@date", SqlDbType.DateTime, 50);
            command.Parameters["@date"].Value = service.datee;
            command.Parameters.Add("@service", SqlDbType.NVarChar, 50);
            command.Parameters["@service"].Value = service.servicee;
            command.Parameters.Add("@serviceGroup", SqlDbType.NVarChar, 50);
            command.Parameters["@serviceGroup"].Value = service.serviceGroup;
            command.Parameters.Add("@timee", SqlDbType.NVarChar, 50);
            command.Parameters["@timee"].Value = service.timee; 
            command.Parameters.Add("@statuss", SqlDbType.Int, 50);
            command.Parameters["@statuss"].Value = service.statuss;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();

        }
        public DataTable createServiceFullView()
        {
            serviceFullTable.Clear();
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from serviceFullView", connection);
            adapter.Fill(serviceFullTable);

            return serviceFullTable;
        }
        public void completeService(int serviceCode,Decimal total,DateTime CarriedDate,int CarriedStuff)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("CompleteService", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@serviceCode", SqlDbType.Int, 50);
            command.Parameters["@serviceCode"].Value = serviceCode;
            command.Parameters.Add("@total", SqlDbType.Money, 50);
            command.Parameters["@total"].Value = total;
            command.Parameters.Add("@CarriedDate", SqlDbType.DateTime, 50);
            command.Parameters["@CarriedDate"].Value = CarriedDate;
            command.Parameters.Add("@CarriedStuff", SqlDbType.Int, 50);
            command.Parameters["@CarriedStuff"].Value = CarriedStuff;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }

        public Array createServiceGroupList()
        {
            string[] list = new string[100];
            createConnection();
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("Select serviceGroup From serviceView", connection);
            adapter.Fill(table);

            for (int i = 0; i < table.Rows.Count; i++)
            {
                list[i] = table.Rows[i][0].ToString();
            }
            return list;
        }
        public DataTable serviceListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
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
        public DataTable ServiceFullByVariable(string Variable,int ColoumnIndex)
        {
            DataTable table = new DataTable();
            table = serviceFullTable.Clone();
            for (int i = 0; i < serviceFullTable.Rows.Count; i++)
            {
                if (serviceFullTable.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    table.ImportRow(serviceFullTable.Rows[i]);
                }
            }

            return table;
        }
        public DataTable serviceFullByDate(DateTime date1, DateTime date2, int ColoumnIndex)
        {
            DataTable tabl4 = new DataTable();
            tabl4 = serviceFullTable.Clone();
            for (int i = 0; i < serviceFullTable.Rows.Count; i++)
            {
                if (date1<=Convert.ToDateTime(serviceFullTable.Rows[i][ColoumnIndex]))
                {
                    if (Convert.ToDateTime(serviceFullTable.Rows[i][ColoumnIndex])<=date2)
                    {
                        tabl4.ImportRow(serviceFullTable.Rows[i]);
                    }
                }
            }
            return tabl4;
        }
        public DataTable serviceListBByDate(DateTime date1,DateTime date2,int ColoumnIndex)
        {
            DataTable tabl3 = new DataTable();
            tabl3 = table.Clone();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (date1 <= Convert.ToDateTime(table.Rows[i][ColoumnIndex]))
                {
                    if (Convert.ToDateTime(table.Rows[i][ColoumnIndex]) <= date2)
                    {
                        tabl3.ImportRow(table.Rows[i]);
                    }
                }
            }
            return tabl3;
        }

    }
}

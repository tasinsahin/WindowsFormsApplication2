using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using WindowsFormsApplication2.Operation;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class auctionOP
    {
        DataTable auctionTable = new DataTable();
        helper helper = new helper();
        public SqlConnection connection = new SqlConnection();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public void auctionAdd(auction auction)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("auctionAdd", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@serviceCode", SqlDbType.Int, 50);
            command.Parameters["@serviceCode"].Value = auction.serviceCode;
            command.Parameters.Add("@staff", SqlDbType.Int, 50);
            command.Parameters["@staff"].Value = auction.staff;
            command.Parameters.Add("@bid", SqlDbType.DateTime, 50);
            command.Parameters["@bid"].Value = auction.bid;
            command.Parameters.Add("@timee", SqlDbType.NVarChar, 50);
            command.Parameters["@timee"].Value = auction.timee;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void acutionDelete(int code)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("auctionDelete", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = code;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public DataTable createAcutionTable()
        {
            auctionTable.Clear();
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from auctionView", connection);
            adapter.Fill(auctionTable);
            return auctionTable;
        }
        public DataTable auctionListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
        {
            DataTable tabl2 = new DataTable();
            tabl2 = auctionTable.Clone();
            for (int i = 0; i < auctionTable.Rows.Count; i++)
            {
                if (auctionTable.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    tabl2.ImportRow(auctionTable.Rows[i]);
                }
            }
            return tabl2;
        }
        public DataTable auctionListByDate(DateTime date1,DateTime date2,int ColoumnIndex) 
        {
            DataTable table = new DataTable();
            return table;
        }
    }
}

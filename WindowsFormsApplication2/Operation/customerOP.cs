using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class customerOP
    {
        SqlConnection connection = new SqlConnection();
        DataTable table = new DataTable();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }

        public DataTable createCustomerTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from customerView", connection);
            adapter.Fill(table);

            return table;
        }

        public void customerAdd(customer customer)
        {
            createConnection();
            if (connection.State==ConnectionState.Closed)
            {
                connection.Open();
            }

            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "customerAdd";
            
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters["@name"].Value = customer.name;
            command.Parameters.Add("@surname", SqlDbType.NVarChar, 50);
            command.Parameters["@surname"].Value = customer.surname;
            command.Parameters.Add("@title", SqlDbType.NVarChar, 50);
            command.Parameters["@title"].Value = customer.title;
            command.Parameters.Add("@accountNumber", SqlDbType.Int, 50);
            command.Parameters["@accountNumber"].Value = customer.accountNumber;
            command.Parameters.Add("@bankName", SqlDbType.NVarChar, 50);
            command.Parameters["@bankName"].Value = customer.bankName;
            command.Parameters.Add("@officeName", SqlDbType.NVarChar, 50);
            command.Parameters["@officeName"].Value = customer.officeName;
            command.Parameters.Add("@officeCode", SqlDbType.Int, 50);
            command.Parameters["@officeCode"].Value = customer.officeCode;
            command.Parameters.Add("@billTitle", SqlDbType.NVarChar, 50);
            command.Parameters["@billTitle"].Value = customer.billTitle;
            command.Parameters.Add("@taxDepartment", SqlDbType.NVarChar, 50);
            command.Parameters["@taxDepartment"].Value = customer.taxDepartment;
            command.Parameters.Add("@taxNumber", SqlDbType.Int, 50);
            command.Parameters["@taxNumber"].Value = customer.taxNumber;
            command.Parameters.Add("@billAdress", SqlDbType.NVarChar, 50);
            command.Parameters["@billAdress"].Value = customer.billAdress;
            command.Parameters.Add("@tel1", SqlDbType.Int, 50);
            command.Parameters["@tel1"].Value = customer.tel1;
            command.Parameters.Add("@tel1code", SqlDbType.Int, 50);
            command.Parameters["@tel1code"].Value = customer.tel1code;
            command.Parameters.Add("@tel2", SqlDbType.Int, 50);
            command.Parameters["@tel2"].Value = customer.tel2;
            command.Parameters.Add("@tel2code", SqlDbType.Int, 50);
            command.Parameters["@tel2code"].Value = customer.tel2code;
            command.Parameters.Add("@tel3", SqlDbType.Int, 50);
            command.Parameters["@tel3"].Value = customer.tel3;
            command.Parameters.Add("@tel3code", SqlDbType.Int, 50);
            command.Parameters["@tel3code"].Value = customer.tel3code;
            command.Parameters.Add("@tel4", SqlDbType.Int, 50);
            command.Parameters["@tel4"].Value = customer.tel4;
            command.Parameters.Add("@tel4code", SqlDbType.Int, 50);
            command.Parameters["@tel4code"].Value = customer.tel4code;
            command.Parameters.Add("@tel5", SqlDbType.Int, 50);
            command.Parameters["@tel5"].Value = customer.tel5;
            command.Parameters.Add("@tel5code", SqlDbType.Int, 50);
            command.Parameters["@tel5code"].Value = customer.tel5code;
            command.Parameters.Add("@tel6", SqlDbType.Int, 50);
            command.Parameters["@tel6"].Value = customer.tel6;
            command.Parameters.Add("@tel6code", SqlDbType.Int, 50);
            command.Parameters["@tel6code"].Value = customer.tel6code;
            command.Parameters.Add("@addhood", SqlDbType.NVarChar, 50);
            command.Parameters["@addhood"].Value = customer.addhood;
            command.Parameters.Add("@addstreet", SqlDbType.NVarChar, 50);
            command.Parameters["@addstreet"].Value = customer.addstreet;
            command.Parameters.Add("@addstreeet", SqlDbType.NVarChar, 50);
            command.Parameters["@addstreeet"].Value = customer.addstreeet;
            command.Parameters.Add("@addno", SqlDbType.Int, 50);
            command.Parameters["@addno"].Value = customer.addno;
            command.Parameters.Add("@addbuilding", SqlDbType.NVarChar, 50);
            command.Parameters["@addbuilding"].Value = customer.addbuilding;
            command.Parameters.Add("@addfloor", SqlDbType.Int, 50);
            command.Parameters["@addfloor"].Value = customer.addfloor;
            command.Parameters.Add("@addnoo", SqlDbType.Int, 50);
            command.Parameters["@addnoo"].Value = customer.addnoo;
            command.Parameters.Add("@addtown", SqlDbType.NVarChar, 50);
            command.Parameters["@addtown"].Value = customer.addtown;
            command.Parameters.Add("@addcity", SqlDbType.NVarChar, 50);
            command.Parameters["@addcity"].Value = customer.addcity;
            command.Parameters.Add("@adddescrip", SqlDbType.NVarChar, 50);
            command.Parameters["@adddescrip"].Value = customer.adddescrip;

            command.ExecuteNonQuery();

            connection.Close();
            connection.Dispose();
            
        }
        public void customerDelete(int code,int bankInfoCode,int contactID,int billID) 
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "customerDelete";           
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            command.Parameters.Add("@CustomerCode", SqlDbType.Int, 50);
            command.Parameters["@CustomerCode"].Value = code;
            command.Parameters.Add("@billInfoCode", SqlDbType.Int, 50);
            command.Parameters["@billInfoCode"].Value = bankInfoCode;
            command.Parameters.Add("@contactCode", SqlDbType.Int, 50);
            command.Parameters["@contactCode"].Value = contactID;
            command.Parameters.Add("@accountNumber", SqlDbType.Int, 50);
            command.Parameters["@accountNumber"].Value = billID;


            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void customerUpdate(customer customer) 
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "customerUpdate";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;

            command.Parameters.Add("@CustomerCode", SqlDbType.Int, 50);
            command.Parameters["@CustomerCode"].Value = customer.code;
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters["@name"].Value = customer.name;
            command.Parameters.Add("@surname", SqlDbType.NVarChar, 50);
            command.Parameters["@surname"].Value = customer.surname;
            command.Parameters.Add("@title", SqlDbType.NVarChar, 50);
            command.Parameters["@title"].Value = customer.title;
            command.Parameters.Add("@accountNumber", SqlDbType.Int, 50);
            command.Parameters["@accountNumber"].Value = customer.accountNumber;
            command.Parameters.Add("@bankName", SqlDbType.NVarChar, 50);
            command.Parameters["@bankName"].Value = customer.bankName;
            command.Parameters.Add("@officeName", SqlDbType.NVarChar, 50);
            command.Parameters["@officeName"].Value = customer.officeName;
            command.Parameters.Add("@officeCode", SqlDbType.Int, 50);
            command.Parameters["@officeCode"].Value = customer.officeCode;
            command.Parameters.Add("@billTitle", SqlDbType.NVarChar, 50);
            command.Parameters["@billTitle"].Value = customer.billTitle;
            command.Parameters.Add("@taxDepartment", SqlDbType.NVarChar, 50);
            command.Parameters["@taxDepartment"].Value = customer.taxDepartment;
            command.Parameters.Add("@taxNumber", SqlDbType.Int, 50);
            command.Parameters["@taxNumber"].Value = customer.taxNumber;
            command.Parameters.Add("@billAdress", SqlDbType.NVarChar, 200);
            command.Parameters["@billAdress"].Value = customer.billAdress;
            command.Parameters.Add("@tel1", SqlDbType.Int, 50);
            command.Parameters["@tel1"].Value = customer.tel1;
            command.Parameters.Add("@tel1code", SqlDbType.Int, 50);
            command.Parameters["@tel1code"].Value = customer.tel1code;
            command.Parameters.Add("@tel2", SqlDbType.Int, 50);
            command.Parameters["@tel2"].Value = customer.tel2;
            command.Parameters.Add("@tel2code", SqlDbType.Int, 50);
            command.Parameters["@tel2code"].Value = customer.tel2code;
            command.Parameters.Add("@tel3", SqlDbType.Int, 50);
            command.Parameters["@tel3"].Value = customer.tel3;
            command.Parameters.Add("@tel3code", SqlDbType.Int, 50);
            command.Parameters["@tel3code"].Value = customer.tel3code;
            command.Parameters.Add("@tel4", SqlDbType.Int, 50);
            command.Parameters["@tel4"].Value = customer.tel4;
            command.Parameters.Add("@tel4code", SqlDbType.Int, 50);
            command.Parameters["@tel4code"].Value = customer.tel4code;
            command.Parameters.Add("@tel5", SqlDbType.Int, 50);
            command.Parameters["@tel5"].Value = customer.tel5;
            command.Parameters.Add("@tel5code", SqlDbType.Int, 50);
            command.Parameters["@tel5code"].Value = customer.tel5code;
            command.Parameters.Add("@tel6", SqlDbType.Int, 50);
            command.Parameters["@tel6"].Value = customer.tel6;
            command.Parameters.Add("@tel6code", SqlDbType.Int, 50);
            command.Parameters["@tel6code"].Value = customer.tel6code;
            command.Parameters.Add("@addhood", SqlDbType.NVarChar, 50);
            command.Parameters["@addhood"].Value = customer.addhood;
            command.Parameters.Add("@addstreet", SqlDbType.NVarChar, 50);
            command.Parameters["@addstreet"].Value = customer.addstreet;
            command.Parameters.Add("@addstreeet", SqlDbType.NVarChar, 50);
            command.Parameters["@addstreeet"].Value = customer.addstreeet;
            command.Parameters.Add("@addno", SqlDbType.Int, 50);
            command.Parameters["@addno"].Value = customer.addno;
            command.Parameters.Add("@addbuilding", SqlDbType.NVarChar, 50);
            command.Parameters["@addbuilding"].Value = customer.addbuilding;
            command.Parameters.Add("@addfloor", SqlDbType.Int, 50);
            command.Parameters["@addfloor"].Value = customer.addfloor;
            command.Parameters.Add("@addnoo", SqlDbType.Int, 50);
            command.Parameters["@addnoo"].Value = customer.addnoo;
            command.Parameters.Add("@addtown", SqlDbType.NVarChar, 50);
            command.Parameters["@addtown"].Value = customer.addtown;
            command.Parameters.Add("@addcity", SqlDbType.NVarChar, 50);
            command.Parameters["@addcity"].Value = customer.addcity;
            command.Parameters.Add("@adddescrip", SqlDbType.NVarChar, 50);
            command.Parameters["@adddescrip"].Value = customer.adddescrip;

            command.Parameters.Add("@bankInfoCode", SqlDbType.Int, 50);
            command.Parameters["@bankInfoCode"].Value = customer.bankInfoCode;
            command.Parameters.Add("@billInfoCode", SqlDbType.Int, 50);
            command.Parameters["@billInfoCode"].Value = customer.billInfoCode;
            command.Parameters.Add("@contactInfoCode", SqlDbType.Int, 50);
            command.Parameters["@contactInfoCode"].Value = customer.contactInfoCode;

            command.ExecuteNonQuery();
            connection.Close();

        }
        public void CustomerPay(int customerID,DateTime datetime, decimal amount)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "customerPayAdd";           
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.Parameters.Add("@CustomerID", SqlDbType.Int, 50);
            command.Parameters["@CustomerID"].Value = customerID ;
            command.Parameters.Add("@datetime", SqlDbType.DateTime, 50);
            command.Parameters["@datetime"].Value = datetime;
            command.Parameters.Add("@Amount", SqlDbType.Money, 50);
            command.Parameters["@Amount"].Value = amount;

            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable customerListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
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

    }
}

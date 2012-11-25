using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace WindowsFormsApplication2
{
    class customerOP
    {
        


        public void customerAdd(customer customer/*hepsini tek tek yazıcan*/)
        {
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = "server= /SQlExpress;Database=MasisTakipVT;Integrated Security=SSPI";           
            connection.Open();
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
            command.Parameters.Add("@officeCode", SqlDbType.SmallInt, 50);
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
            command.Parameters["@addnoo"].Value = customer.name;
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
        public void customerDelete(string name) // tek tek yazıcan oğlum!
        {
            //createConnection();
            SqlCommand command = new SqlCommand("customerDelete");
           
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
        }
        public void customerUpdate(string name) /// tek tek yazıcan aga! 
        {
            //createConnection();
            SqlCommand command = new SqlCommand("customerUpdate");
            
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add(name); // kırmızı ışık yanmasın diye atıyoruz
            command.ExecuteNonQuery();
        }
        public DataTable customerTable() 
        {;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.Fill(table);
            return table;

        }
    }
}

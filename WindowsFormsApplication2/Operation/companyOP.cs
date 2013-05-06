using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
    class companyOP
    {
        company company = new company();

        SqlConnection connection = new SqlConnection();
        DataTable table = new DataTable();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public DataTable CreateCompanyTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from companyView", connection);
            adapter.Fill(table);

            return table;
        }
        public void companyAdd(company company)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "companyAdd";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters["@name"].Value = company.name;
            command.Parameters.Add("@statemen", SqlDbType.NVarChar, 50);
            command.Parameters["@statemen"].Value = company.statemen;
            command.Parameters.Add("@responsible", SqlDbType.NVarChar, 50);
            command.Parameters["@responsible"].Value = company.responsible;
            command.Parameters.Add("@title", SqlDbType.NVarChar, 50);
            command.Parameters["@title"].Value = company.title;
            command.Parameters.Add("@accountNumber", SqlDbType.Int, 50);
            command.Parameters["@accountNumber"].Value = company.accountNumber;
            command.Parameters.Add("@bankName", SqlDbType.NVarChar, 50);
            command.Parameters["@bankName"].Value = company.bankName;
            command.Parameters.Add("@officeName", SqlDbType.NVarChar, 50);
            command.Parameters["@officeName"].Value = company.officeName;
            command.Parameters.Add("@officeCode", SqlDbType.Int, 50);
            command.Parameters["@officeCode"].Value = company.officeCode;
            command.Parameters.Add("@taxDepartment", SqlDbType.NVarChar, 50);
            command.Parameters["@taxDepartment"].Value = company.taxDepartment;
            command.Parameters.Add("@taxNumber", SqlDbType.Int, 50);
            command.Parameters["@taxNumber"].Value = company.taxNumber;
            command.Parameters.Add("@billAdress", SqlDbType.NVarChar, 50);
            command.Parameters["@billAdress"].Value = company.billAdress;
            command.Parameters.Add("@billTitle", SqlDbType.NVarChar, 50);
            command.Parameters["@billTitle"].Value = company.billTitle;
            command.Parameters.Add("@tel1code", SqlDbType.Int, 50);
            command.Parameters["@tel1code"].Value = company.tel1code;
            command.Parameters.Add("@tel1", SqlDbType.Int, 50);
            command.Parameters["@tel1"].Value = company.tel1;
            command.Parameters.Add("@tel2code", SqlDbType.Int, 50);
            command.Parameters["@tel2code"].Value = company.tel2code;
            command.Parameters.Add("@tel2", SqlDbType.Int, 50);
            command.Parameters["@tel2"].Value = company.tel2;
            command.Parameters.Add("@tel3code", SqlDbType.Int, 50);
            command.Parameters["@tel3code"].Value = company.tel3code;
            command.Parameters.Add("@tel3", SqlDbType.Int, 50);
            command.Parameters["@tel3"].Value = company.tel3;
            command.Parameters.Add("@tel4code", SqlDbType.Int, 50);
            command.Parameters["@tel4code"].Value = company.tel4code;
            command.Parameters.Add("@tel4", SqlDbType.Int, 50);
            command.Parameters["@tel4"].Value = company.tel4;
            command.Parameters.Add("@tel5code", SqlDbType.Int, 50);
            command.Parameters["@tel5code"].Value = company.tel5code;
            command.Parameters.Add("@tel5", SqlDbType.Int, 50);
            command.Parameters["@tel5"].Value = company.tel5;
            command.Parameters.Add("@tel6code", SqlDbType.Int, 50);
            command.Parameters["@tel6code"].Value = company.tel6code;
            command.Parameters.Add("@tel6", SqlDbType.Int, 50);
            command.Parameters["@tel6"].Value = company.tel6;
            command.Parameters.Add("@addhood", SqlDbType.NVarChar, 50);
            command.Parameters["@addhood"].Value = company.addhood;
            command.Parameters.Add("@addstreet", SqlDbType.NVarChar, 50);
            command.Parameters["@addstreet"].Value = company.addstreet;
            command.Parameters.Add("@addstreeet", SqlDbType.NVarChar, 50);
            command.Parameters["@addstreeet"].Value = company.addstreeet;
            command.Parameters.Add("@addno", SqlDbType.Int, 50);
            command.Parameters["@addno"].Value = company.addno;
            command.Parameters.Add("@addbuilding", SqlDbType.NVarChar, 50);
            command.Parameters["@addbuilding"].Value = company.addbuilding;
            command.Parameters.Add("@addfloor", SqlDbType.Int, 50);
            command.Parameters["@addfloor"].Value = company.addfloor;
            command.Parameters.Add("@addnoo", SqlDbType.Int, 50);
            command.Parameters["@addnoo"].Value = company.addnoo;
            command.Parameters.Add("@addtown", SqlDbType.NVarChar, 50);
            command.Parameters["@addtown"].Value = company.addtown;
            command.Parameters.Add("@addcity", SqlDbType.NVarChar, 50);
            command.Parameters["@addcity"].Value = company.addcity;
            command.Parameters.Add("@adddescrip", SqlDbType.NVarChar, 50);
            command.Parameters["@adddescrip"].Value = company.adddescrip;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void companyDelete(int code, int billInfoCode,int contactInfoCode,int bankInfoCode)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand("companyDelete", connection);
            command.CommandTimeout = 40;
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@companyCode", SqlDbType.NVarChar, 50);
            command.Parameters["@companyCode"].Value = code;
            command.Parameters.Add("@billInfoCode", SqlDbType.NVarChar, 50);
            command.Parameters["@billInfoCode"].Value = billInfoCode;
            command.Parameters.Add("@contactCode", SqlDbType.NVarChar, 50);
            command.Parameters["@contactCode"].Value = contactInfoCode;
            command.Parameters.Add("@bankInfoCode", SqlDbType.NVarChar, 50);
            command.Parameters["@bankInfoCode"].Value = bankInfoCode;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void companyUpdate(company company) 
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection=connection;
            command.CommandText="companyUpdate";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add("@code", SqlDbType.Int, 50);
            command.Parameters["@code"].Value = company.code;
            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters["@name"].Value = company.name;
            command.Parameters.Add("@statemen", SqlDbType.NVarChar, 50);
            command.Parameters["@statemen"].Value = company.statemen;
            command.Parameters.Add("@responsible", SqlDbType.NVarChar, 50);
            command.Parameters["@responsible"].Value = company.responsible;
            command.Parameters.Add("@title", SqlDbType.NVarChar, 50);
            command.Parameters["@title"].Value = company.title;
            command.Parameters.Add("@accountNumber", SqlDbType.Int, 50);
            command.Parameters["@accountNumber"].Value = company.accountNumber;

            command.Parameters.Add("@bankName", SqlDbType.NVarChar, 50);
            command.Parameters["@bankName"].Value = company.bankName;
            command.Parameters.Add("@officeName", SqlDbType.NVarChar, 50);
            command.Parameters["@officeName"].Value = company.officeName;
            command.Parameters.Add("@officeCode", SqlDbType.Int, 50);
            command.Parameters["@officeCode"].Value = company.officeCode;
            command.Parameters.Add("@taxDepartment", SqlDbType.NVarChar, 50);
            command.Parameters["@taxDepartment"].Value = company.taxDepartment;
            command.Parameters.Add("@taxNumber", SqlDbType.Int, 50);
            command.Parameters["@taxNumber"].Value = company.taxNumber;
            command.Parameters.Add("@billAdress", SqlDbType.NVarChar, 50);
            command.Parameters["@billAdress"].Value = company.billAdress;
            command.Parameters.Add("@billTitle", SqlDbType.NVarChar, 50);
            command.Parameters["@billTitle"].Value = company.billTitle;
            command.Parameters.Add("@tel1code", SqlDbType.Int, 50);
            command.Parameters["@tel1code"].Value = company.tel1code;
            command.Parameters.Add("@tel1", SqlDbType.Int, 50);
            command.Parameters["@tel1"].Value = company.tel1;
            command.Parameters.Add("@tel2code", SqlDbType.Int, 50);
            command.Parameters["@tel2code"].Value = company.tel2code;
            command.Parameters.Add("@tel2", SqlDbType.Int, 50);
            command.Parameters["@tel2"].Value = company.tel2;
            command.Parameters.Add("@tel3code", SqlDbType.Int, 50);
            command.Parameters["@tel3code"].Value = company.tel3code;
            command.Parameters.Add("@tel3", SqlDbType.Int, 50);
            command.Parameters["@tel3"].Value = company.tel3;
            command.Parameters.Add("@tel4code", SqlDbType.Int, 50);
            command.Parameters["@tel4code"].Value = company.tel4code;
            command.Parameters.Add("@tel4", SqlDbType.Int, 50);
            command.Parameters["@tel4"].Value = company.tel4;
            command.Parameters.Add("@tel5code", SqlDbType.Int, 50);
            command.Parameters["@tel5code"].Value = company.tel5code;
            command.Parameters.Add("@tel5", SqlDbType.Int, 50);
            command.Parameters["@tel5"].Value = company.tel5;
            command.Parameters.Add("@tel6code", SqlDbType.Int, 50);
            command.Parameters["@tel6code"].Value = company.tel6code;
            command.Parameters.Add("@tel6", SqlDbType.Int, 50);
            command.Parameters["@tel6"].Value = company.tel6;
            command.Parameters.Add("@addhood", SqlDbType.NVarChar, 50);
            command.Parameters["@addhood"].Value = company.addhood;
            command.Parameters.Add("@addstreet", SqlDbType.NVarChar, 50);
            command.Parameters["@addstreet"].Value = company.addstreet;
            command.Parameters.Add("@addstreeet", SqlDbType.NVarChar, 50);
            command.Parameters["@addstreeet"].Value = company.addstreeet;
            command.Parameters.Add("@addno", SqlDbType.Int, 50);
            command.Parameters["@addno"].Value = company.addno;
            command.Parameters.Add("@addbuilding", SqlDbType.NVarChar, 50);
            command.Parameters["@addbuilding"].Value = company.addbuilding;
            command.Parameters.Add("@addfloor", SqlDbType.Int, 50);
            command.Parameters["@addfloor"].Value = company.addfloor;
            command.Parameters.Add("@addnoo", SqlDbType.Int, 50);
            command.Parameters["@addnoo"].Value = company.addnoo;
            command.Parameters.Add("@addtown", SqlDbType.NVarChar, 50);
            command.Parameters["@addtown"].Value = company.addtown;
            command.Parameters.Add("@addcity", SqlDbType.NVarChar, 50);
            command.Parameters["@addcity"].Value = company.addcity;
            command.Parameters.Add("@adddescrip", SqlDbType.NVarChar, 50);
            command.Parameters["@adddescrip"].Value = company.adddescrip;

            command.Parameters.Add("@bankInfoCode", SqlDbType.Int, 50);
            command.Parameters["@bankInfoCode"].Value = company.bankInfoCode;
            command.Parameters.Add("@billInfoCode", SqlDbType.Int, 50);
            command.Parameters["@billInfoCode"].Value = company.billInfoCode;
            command.Parameters.Add("@contactInfoCode", SqlDbType.Int, 50);
            command.Parameters["@contactInfoCode"].Value = company.contactInfoCode;
 
            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public void  companyPay(int companyID,DateTime datetime,decimal amount)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.CommandText = "companyPayAdd";
            command.CommandType = CommandType.StoredProcedure;
            command.Connection = connection;
            command.Parameters.Add("@CompanyID", SqlDbType.Int, 50);
            command.Parameters["@CompanyID"].Value = companyID;
            command.Parameters.Add("@datetime", SqlDbType.DateTime, 50);
            command.Parameters["@datetime"].Value = datetime;
            command.Parameters.Add("@Amount", SqlDbType.Money, 50);
            command.Parameters["@Amount"].Value = amount;

            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable companyListByVariable(string Variable,int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
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

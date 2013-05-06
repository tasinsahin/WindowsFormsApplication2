using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using WindowsFormsApplication2.Operation;

namespace WindowsFormsApplication2
{
        class staffOP
        {
            SqlConnection connection = new SqlConnection();
            DataTable table = new DataTable();
            helper helper = new helper();

            public void createConnection()
            {
                connection = (SqlConnection)helper.createConnection();
            }

            public DataTable createStaffTable()
            {
                createConnection();
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from staffView", connection);
                adapter.Fill(table);

                return table;
            }

            public void staffAdd(staff staff)
            {
                createConnection();
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "staffAdd";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
                command.Parameters["@name"].Value = staff.name;
                command.Parameters.Add("@surname", SqlDbType.NVarChar, 50);
                command.Parameters["@surname"].Value = staff.surname;
                command.Parameters.Add("@title", SqlDbType.NVarChar, 50);
                command.Parameters["@title"].Value = staff.title;
                command.Parameters.Add("@salary", SqlDbType.Decimal, 50);
                command.Parameters["@salary"].Value = staff.salary;
                command.Parameters.Add("@startDate", SqlDbType.Date, 50);
                command.Parameters["@startDate"].Value = staff.startDate;
                command.Parameters.Add("@leaveDate", SqlDbType.Date, 50);
                command.Parameters["@leaveDate"].Value = staff.leaveDate;
                command.Parameters.Add("@accountNumber", SqlDbType.Int, 50);
                command.Parameters["@accountNumber"].Value = staff.accountNumber;
                command.Parameters.Add("@bankName", SqlDbType.NVarChar, 50);
                command.Parameters["@bankName"].Value = staff.bankName;
                command.Parameters.Add("@officeName", SqlDbType.NVarChar, 50);
                command.Parameters["@officeName"].Value = staff.officeName;
                command.Parameters.Add("@officeCode", SqlDbType.Int, 50);
                command.Parameters["@officeCode"].Value = staff.officeCode;
                command.Parameters.Add("@billTitle", SqlDbType.NVarChar, 50);
                command.Parameters["@billTitle"].Value = staff.billTitle;
                command.Parameters.Add("@taxDepartment", SqlDbType.NVarChar, 50);
                command.Parameters["@taxDepartment"].Value = staff.taxDepartment;
                command.Parameters.Add("@taxNumber", SqlDbType.Int, 50);
                command.Parameters["@taxNumber"].Value = staff.taxNumber;
                command.Parameters.Add("@billAdress", SqlDbType.NVarChar, 200);
                command.Parameters["@billAdress"].Value = staff.billAdress;
                command.Parameters.Add("@tel1code", SqlDbType.Int, 50);
                command.Parameters["@tel1code"].Value = staff.tel1code;
                command.Parameters.Add("@tel1", SqlDbType.Int, 50);
                command.Parameters["@tel1"].Value = staff.tel1;
                command.Parameters.Add("@tel2code", SqlDbType.Int, 50);
                command.Parameters["@tel2code"].Value = staff.tel2code;
                command.Parameters.Add("@tel2", SqlDbType.Int, 50);
                command.Parameters["@tel2"].Value = staff.tel2;
                command.Parameters.Add("@tel3code", SqlDbType.Int, 50);
                command.Parameters["@tel3code"].Value = staff.tel3code;
                command.Parameters.Add("@tel3", SqlDbType.Int, 50);
                command.Parameters["@tel3"].Value = staff.tel3;
                command.Parameters.Add("@tel4code", SqlDbType.Int, 50);
                command.Parameters["@tel4code"].Value = staff.tel4code;
                command.Parameters.Add("@tel4", SqlDbType.Int, 50);
                command.Parameters["@tel4"].Value = staff.tel4;
                command.Parameters.Add("@tel5code", SqlDbType.Int, 50);
                command.Parameters["@tel5code"].Value = staff.tel5code;
                command.Parameters.Add("@tel5", SqlDbType.Int, 50);
                command.Parameters["@tel5"].Value = staff.tel5;
                command.Parameters.Add("@tel6code", SqlDbType.Int, 50);
                command.Parameters["@tel6code"].Value = staff.tel6code;
                command.Parameters.Add("@tel6", SqlDbType.Int, 50);
                command.Parameters["@tel6"].Value = staff.tel6;
                command.Parameters.Add("@addhood", SqlDbType.NVarChar, 50);
                command.Parameters["@addhood"].Value = staff.addhood;
                command.Parameters.Add("@addstreet", SqlDbType.NVarChar, 50);
                command.Parameters["@addstreet"].Value = staff.addstreet;
                command.Parameters.Add("@addstreeet", SqlDbType.NVarChar, 50);
                command.Parameters["@addstreeet"].Value = staff.addstreeet;
                command.Parameters.Add("@addno", SqlDbType.Int, 50);
                command.Parameters["@addno"].Value = staff.addno;
                command.Parameters.Add("@addbuilding", SqlDbType.NVarChar, 50);
                command.Parameters["@addbuilding"].Value = staff.addbuilding;
                command.Parameters.Add("@addfloor", SqlDbType.Int, 50);
                command.Parameters["@addfloor"].Value = staff.addfloor;
                command.Parameters.Add("@addnoo", SqlDbType.Int, 50);
                command.Parameters["@addnoo"].Value = staff.addnoo;
                command.Parameters.Add("@addtown", SqlDbType.NVarChar, 50);
                command.Parameters["@addtown"].Value = staff.addtown;
                command.Parameters.Add("@addcity", SqlDbType.NVarChar, 50);
                command.Parameters["@addcity"].Value = staff.addcity;
                command.Parameters.Add("@adddescrip", SqlDbType.NVarChar, 50);
                command.Parameters["@adddescrip"].Value = staff.adddescrip;

                command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
            }
            public void staffDelete(int code, int bankInfoCode, int billInfoCode, int contactInfoCode) // tek tek yazıcan oğlum!
            {
                createConnection();
                connection.Open();
                SqlCommand command = new SqlCommand("staffDelete", connection);
                command.CommandTimeout = 40;
                command.CommandType = CommandType.StoredProcedure;


                command.Parameters.Add("@staffCode", SqlDbType.Int, 50);
                command.Parameters["@staffCode"].Value = code;
                command.Parameters.Add("@bankInfoCode", SqlDbType.Int, 50);
                command.Parameters["@bankInfoCode"].Value = bankInfoCode;
                command.Parameters.Add("@billInfoCode", SqlDbType.Int, 50);
                command.Parameters["@billInfoCode"].Value = billInfoCode;
                command.Parameters.Add("@contactInfoCode", SqlDbType.Int, 50);
                command.Parameters["@contactInfoCode"].Value = contactInfoCode;



                command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
            }
            public void staffUpdate(staff staff) /// tek tek yazıcan aga! 
            {
                createConnection();
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "staffUpdate";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add("@staffCode", SqlDbType.Int, 50);
                command.Parameters["@staffCode"].Value = staff.code;
                command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
                command.Parameters["@name"].Value = staff.name;
                command.Parameters.Add("@surname", SqlDbType.NVarChar, 50);
                command.Parameters["@surname"].Value = staff.surname;
                command.Parameters.Add("@title", SqlDbType.NVarChar, 50);
                command.Parameters["@title"].Value = staff.title;
                command.Parameters.Add("@salary", SqlDbType.Decimal, 50);
                command.Parameters["@salary"].Value = staff.salary;
                command.Parameters.Add("@startDate", SqlDbType.Date, 50);
                command.Parameters["@startDate"].Value = staff.startDate;
                command.Parameters.Add("@leaveDate", SqlDbType.Date, 50);
                command.Parameters["@leaveDate"].Value = staff.leaveDate;
                command.Parameters.Add("@accountNumber", SqlDbType.Int, 50);
                command.Parameters["@accountNumber"].Value = staff.accountNumber;
                command.Parameters.Add("@bankName", SqlDbType.NVarChar, 50);
                command.Parameters["@bankName"].Value = staff.bankName;
                command.Parameters.Add("@officeName", SqlDbType.NVarChar, 50);
                command.Parameters["@officeName"].Value = staff.officeName;
                command.Parameters.Add("@officeCode", SqlDbType.Int, 50);
                command.Parameters["@officeCode"].Value = staff.officeCode;
                command.Parameters.Add("@billTitle", SqlDbType.NVarChar, 50);
                command.Parameters["@billTitle"].Value = staff.billTitle;
                command.Parameters.Add("@taxDepartment", SqlDbType.NVarChar, 50);
                command.Parameters["@taxDepartment"].Value = staff.taxDepartment;
                command.Parameters.Add("@taxNumber", SqlDbType.Int, 50);
                command.Parameters["@taxNumber"].Value = staff.taxNumber;
                command.Parameters.Add("@billAdress", SqlDbType.NVarChar, 200);
                command.Parameters["@billAdress"].Value = staff.billAdress;
                command.Parameters.Add("@tel1code", SqlDbType.Int, 50);
                command.Parameters["@tel1code"].Value = staff.tel1code;
                command.Parameters.Add("@tel1", SqlDbType.Int, 50);
                command.Parameters["@tel1"].Value = staff.tel1;
                command.Parameters.Add("@tel2code", SqlDbType.Int, 50);
                command.Parameters["@tel2code"].Value = staff.tel2code;
                command.Parameters.Add("@tel2", SqlDbType.Int, 50);
                command.Parameters["@tel2"].Value = staff.tel2;
                command.Parameters.Add("@tel3code", SqlDbType.Int, 50);
                command.Parameters["@tel3code"].Value = staff.tel3code;
                command.Parameters.Add("@tel3", SqlDbType.Int, 50);
                command.Parameters["@tel3"].Value = staff.tel3;
                command.Parameters.Add("@tel4code", SqlDbType.Int, 50);
                command.Parameters["@tel4code"].Value = staff.tel4code;
                command.Parameters.Add("@tel4", SqlDbType.Int, 50);
                command.Parameters["@tel4"].Value = staff.tel4;
                command.Parameters.Add("@tel5code", SqlDbType.Int, 50);
                command.Parameters["@tel5code"].Value = staff.tel5code;
                command.Parameters.Add("@tel5", SqlDbType.Int, 50);
                command.Parameters["@tel5"].Value = staff.tel5;
                command.Parameters.Add("@tel6code", SqlDbType.Int, 50);
                command.Parameters["@tel6code"].Value = staff.tel6code;
                command.Parameters.Add("@tel6", SqlDbType.Int, 50);
                command.Parameters["@tel6"].Value = staff.tel6;
                command.Parameters.Add("@addhood", SqlDbType.NVarChar, 50);
                command.Parameters["@addhood"].Value = staff.addhood;
                command.Parameters.Add("@addstreet", SqlDbType.NVarChar, 50);
                command.Parameters["@addstreet"].Value = staff.addstreet;
                command.Parameters.Add("@addstreeet", SqlDbType.NVarChar, 50);
                command.Parameters["@addstreeet"].Value = staff.addstreeet;
                command.Parameters.Add("@addno", SqlDbType.Int, 50);
                command.Parameters["@addno"].Value = staff.addno;
                command.Parameters.Add("@addbuilding", SqlDbType.NVarChar, 50);
                command.Parameters["@addbuilding"].Value = staff.addbuilding;
                command.Parameters.Add("@addfloor", SqlDbType.Int, 50);
                command.Parameters["@addfloor"].Value = staff.addfloor;
                command.Parameters.Add("@addnoo", SqlDbType.Int, 50);
                command.Parameters["@addnoo"].Value = staff.addnoo;
                command.Parameters.Add("@addtown", SqlDbType.NVarChar, 50);
                command.Parameters["@addtown"].Value = staff.addtown;
                command.Parameters.Add("@addcity", SqlDbType.NVarChar, 50);
                command.Parameters["@addcity"].Value = staff.addcity;
                command.Parameters.Add("@adddescrip", SqlDbType.NVarChar, 50);
                command.Parameters["@adddescrip"].Value = staff.adddescrip;

                command.Parameters.Add("@bankInfoCode", SqlDbType.Int, 50);
                command.Parameters["@bankInfoCode"].Value = staff.bankInfoCode;
                command.Parameters.Add("@billInfoCode", SqlDbType.Int, 50);
                command.Parameters["@billInfoCode"].Value = staff.billInfoCode;
                command.Parameters.Add("@contactInfoCode", SqlDbType.Int, 50);
                command.Parameters["@contactInfoCode"].Value = staff.contactInfoCode;

                command.ExecuteNonQuery();
                connection.Close();
                connection.Dispose();
            }
            public void staffPay(int staffId, DateTime datee, Decimal PayAmount)
            {
                createConnection();
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = "staffPayAdd";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = connection;
                command.Parameters.Add("@staffId", SqlDbType.Int, 50);
                command.Parameters["@staffId"].Value = staffId;
                command.Parameters.Add("@datee", SqlDbType.DateTime, 50);
                command.Parameters["@dateee"].Value = datee;
                command.Parameters.Add("@PayAmount", SqlDbType.Money, 50);
                command.Parameters["@PayAmount"].Value = PayAmount;

                command.ExecuteNonQuery();
                connection.Close();
            }
            public DataTable staffListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
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

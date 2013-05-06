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
    class chequeOP
    {
        cheque cheque = new cheque();
        DataTable table = new DataTable();
        SqlConnection connection = new SqlConnection();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public DataTable createChequeTable()
        {
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from chequeView", connection);
            adapter.Fill(table);

            return table;
        }
        public void chequeAdd(cheque cheque)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "chequeAdd";

            command.Parameters.Add("@alınanVerilen", SqlDbType.NVarChar, 50); 
            command.Parameters["@alınanVerilen"].Value = cheque.alınanVerilen; 
            command.Parameters.Add("@takeDate", SqlDbType.Date, 50); 
            command.Parameters["@takeDate"].Value = cheque.TakeDate; 
            command.Parameters.Add("@returnDate", SqlDbType.Date, 50); 
            command.Parameters["@returnDate"].Value = cheque.returnDate; 
            command.Parameters.Add("@moneyy", SqlDbType.Money, 50); 
            command.Parameters["@moneyy"].Value = cheque.money;  
            command.Parameters.Add("@bankName", SqlDbType.NVarChar, 50); 
            command.Parameters["@bankName"].Value = cheque.bankName;
            command.Parameters.Add("@companyCustomer", SqlDbType.Int, 50); 
            command.Parameters["@companyCustomer"].Value = cheque.companyCustomer;

            command.Parameters.Add("@ownerr", SqlDbType.NVarChar, 50);
            command.Parameters["@ownerr"].Value = cheque.ownerr;

            command.ExecuteNonQuery();
            connection.Close();
        }
        public void chequeUpdate(cheque cheque)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "chequeUpdate";

            command.Parameters.Add("@chequeCode", SqlDbType.Int, 50);
            command.Parameters["@chequeCode"].Value = cheque.code;
            command.Parameters.Add("@alınanVerilen", SqlDbType.NVarChar, 50);
            command.Parameters["@alınanVerilen"].Value = cheque.alınanVerilen;
            command.Parameters.Add("@takeDate", SqlDbType.Date, 50);
            command.Parameters["@takeDate"].Value = cheque.TakeDate;
            command.Parameters.Add("@returnDate", SqlDbType.Date, 50);
            command.Parameters["@returnDate"].Value = cheque.returnDate;
            command.Parameters.Add("@moneyy", SqlDbType.Money, 50);
            command.Parameters["@moneyy"].Value = cheque.money;
            command.Parameters.Add("@bankName", SqlDbType.NVarChar, 50);
            command.Parameters["@bankName"].Value = cheque.bankName;
            command.Parameters.Add("@companyCustomer", SqlDbType.Int, 50);
            command.Parameters["@companyCustomer"].Value = cheque.companyCustomer;

            command.Parameters.Add("@ownerr", SqlDbType.NVarChar, 50);
            command.Parameters["@ownerr"].Value = cheque.ownerr;

            command.ExecuteNonQuery();
            connection.Close();
        }
        public void chequeDelete(int code)
        {
            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "chequeDelete";

            command.Parameters.Add("@chequeCode", SqlDbType.Int, 50);
            command.Parameters["@chequeCode"].Value = code;

            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataTable chequeListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
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
        public DataTable chequeListByDate(DateTime date1, DateTime date2, int ColoumnIndex)
        {
            DataTable tabl3 = new DataTable();
            tabl3 = table.Clone();
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (date1<=Convert.ToDateTime(table.Rows[i][ColoumnIndex]))
                {
                    if (Convert.ToDateTime(table.Rows[i][ColoumnIndex])<=date2)
                    {
                        tabl3.ImportRow(table.Rows[i]);
                    }
                }
            }
            return tabl3;
        }
        public DataTable chequeListByChecked(bool check,int ColoumnIndex)
        {
            DataTable tabl4=new DataTable();
            tabl4=table.Clone();
            for (int i = 0; i < table.Rows.Count; i++)
			{
			 if (Convert.ToBoolean(table.Rows[i][ColoumnIndex])==check)
	            {
                    tabl4.ImportRow(table.Rows[i]);
                }
			}
            return tabl4;
        }
    }
}

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
    class cashOP
    {
        SqlConnection connection = new SqlConnection();
        DataTable cashTable = new DataTable();
        DataTable customerPayTable = new DataTable();
        DataTable companyPayTable = new DataTable();
        DataTable customerTable = new DataTable();
        DataTable companyTable = new DataTable();
        helper helper = new helper();


        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }

        public void billOwndbAdd()
        { }
        public void billOwndbUpdate()
        { }
        public void billOwndbDelete()
        { }
        public void salaryPayAdd()
        { }
        public void salaryPayUpdate()
        { }
        public void salaryPayDelete()
        { }
        public void AddMoney()
        { }
        public void SubMoney()
        { }
        public DataTable createCashTable()
        {
            createConnection();
            cashTable.Columns.Add("Adı", typeof(string));
            cashTable.Columns.Add("İşlem Türü", typeof(string));
            cashTable.Columns.Add("Tarih", typeof(DateTime));
            cashTable.Columns.Add("Tutar", typeof(Decimal));

            SqlDataAdapter adapter = new SqlDataAdapter("Select * from CustomerPay", connection);
            adapter.Fill(customerPayTable);

            for (int i = 0; i < customerPayTable.Rows.Count; i++)
            {
                int customerCode = Convert.ToInt32(customerPayTable.Rows[i][0]);
                string customerName = "";
                DateTime datee = Convert.ToDateTime(customerPayTable.Rows[i][1]);
                Decimal tutar = Convert.ToDecimal(customerPayTable.Rows[i][2]);
                string islemTuru = "Müşteri Ödeme";

                SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from customerdb", connection);
                adapter2.Fill(customerTable);

                for (int j = 0; j < customerTable.Rows.Count; j++)
                {
                    if (Convert.ToInt32(customerPayTable.Rows[i][0])==Convert.ToInt32(customerTable.Rows[j][0]))
                    {
                        customerName = Convert.ToString(customerTable.Rows[j][1]);
                    }
                }
                cashTable.Rows.Add(customerName,islemTuru,datee,tutar);
            }


            SqlDataAdapter adapter3 = new SqlDataAdapter("Select * from companyPay", connection);
            adapter3.Fill(companyPayTable);

            for (int i = 0; i < companyPayTable.Rows.Count; i++)
            {
                int customerCode = Convert.ToInt32(companyPayTable.Rows[i][0]);
                string companyName = "";
                DateTime datee = Convert.ToDateTime(companyPayTable.Rows[i][1]);
                Decimal tutar = Convert.ToDecimal(companyPayTable.Rows[i][2]);
                string islemTuru = "Firma Ödeme";

                SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from companydb", connection);
                adapter2.Fill(companyTable);

                for (int j = 0; j < companyTable.Rows.Count; j++)
                {
                    if (Convert.ToInt32(companyPayTable.Rows[i][0]) == Convert.ToInt32(companyTable.Rows[j][0]))
                    {
                        companyName = Convert.ToString(companyTable.Rows[j][1]);
                    }
                }
                cashTable.Rows.Add(companyName, islemTuru, datee, tutar);
            }


            return cashTable;
        }
        public DataTable cashListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
        {
            DataTable tabl2 = new DataTable();
            tabl2 = cashTable.Clone();
            for (int i = 0; i < cashTable.Rows.Count; i++)
            {
                if (cashTable.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    tabl2.ImportRow(cashTable.Rows[i]);
                }
            }
            return tabl2;
        }
        public DataTable cashListByDate(DateTime date1,DateTime date2,int ColoumnIndex)
        {
            DataTable tabl3 = new DataTable();
            tabl3=cashTable.Clone();
            for (int i = 0; i < cashTable.Rows.Count; i++)
			{
			 if (date1<=Convert.ToDateTime(cashTable.Rows[i][ColoumnIndex]))
	            {
		             if (Convert.ToDateTime(cashTable.Rows[i][ColoumnIndex])<=date2)
	                    {
                              tabl3.ImportRow(cashTable.Rows[i]);		 
	                    }
	            }
			}
            return tabl3;
        }
    }
}

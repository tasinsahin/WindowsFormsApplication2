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
    class mapOP
    {
        SqlConnection connection = new SqlConnection();
        string CustomerAdress;
        string CompanyAdress;
        string StaffAdress;
        string CustomerName;
        string CompanyName;
        string StaffName;

        DataTable tableCustomer = new DataTable();
        DataTable tableCompany = new DataTable();
        DataTable tableStaff = new DataTable();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }
        public string createTableCustomerAdress(int customerID)
        {
            tableCustomer.Clear();
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from customerView where Kod=" + customerID + " ", connection);
            adapter.Fill(tableCustomer);
            CustomerAdress = tableCustomer.Rows[0][27].ToString() + " ," + tableCustomer.Rows[0][25].ToString() + " ," + tableCustomer.Rows[0][32].ToString() + " ," + tableCustomer.Rows[0][33].ToString();
            return CustomerAdress;
        }
        public string createTableCompanyAdress(int companyID)
        {
            tableCompany.Clear();
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from companyView where Kod=" + companyID + " ", connection);
            adapter.Fill(tableCompany);
            CompanyAdress = tableCompany.Rows[0][26].ToString() + " ," + tableCompany.Rows[0][24].ToString() + " ," + tableCompany.Rows[0][31].ToString() + " ," + tableCompany.Rows[0][32].ToString();
            return CompanyAdress;
        }
        public string createTableStaffAdress(int staffID)
        {
            tableStaff.Clear();
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from staffView where Kod=" + staffID + " ", connection);
            adapter.Fill(tableStaff);
            StaffAdress = tableStaff.Rows[0][29].ToString() + " ," + tableStaff.Rows[0][27].ToString() + " ," + tableStaff.Rows[0][34].ToString() + " ," + tableStaff.Rows[0][35].ToString();
            return StaffName;
        }
        public string createTableCustomerName(int customerID)
        {
            createConnection();
            CustomerName=Convert.ToString(tableCustomer.Rows[0][1]);
            return CustomerName;
        }
        public string createTableCompanyName(int companyID)
        {
            createConnection();
            CompanyName = Convert.ToString(tableCompany.Rows[0][1]);
            return CompanyName;
        }
        public string createTableStaffName(int staffID)
        {
            createConnection();
            StaffName = Convert.ToString(tableStaff.Rows[0][1]);
            return StaffName;
        }
    }
}

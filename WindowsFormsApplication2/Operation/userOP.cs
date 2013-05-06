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
    class userOP
    {
        SqlConnection connection = new SqlConnection();
        DataTable table = new DataTable();
        helper helper = new helper();

        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }

        public void UserAdd(user user)
        {

            createConnection();
            connection.Open();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = "UserAdd";

            command.Parameters.Add("@name", SqlDbType.NVarChar, 50);
            command.Parameters["@name"].Value = user.name;
            command.Parameters.Add("@surname", SqlDbType.NVarChar, 50);
            command.Parameters["@surname"].Value = user.surname;
            command.Parameters.Add("@userName", SqlDbType.NVarChar, 50);
            command.Parameters["@userName"].Value = user.userName;
            command.Parameters.Add("@passwordd", SqlDbType.NVarChar,50);
            command.Parameters["@passwordd"].Value = user.passwordd;

            command.ExecuteNonQuery();
            connection.Close();
            connection.Dispose();
        }
        public DataTable userControl(user user)
        {
            string username = user.userName;
            string pas = user.passwordd;
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select name,surname,userName from userdb Where userName= '"+username+"' AND passwordd='"+pas+"'", connection);
            adapter.Fill(table);
            return table;
        }

    }
}

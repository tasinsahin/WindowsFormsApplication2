using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace WindowsFormsApplication2.Operation
{
    class  helper
    {
        public SqlConnection connection = new SqlConnection();

        public SqlConnection createConnection()
        {
            connection.ConnectionString = @"Data Source=TASIN;Initial Catalog=masistakipVT;Integrated Security=True";
            return (connection);
        }
    }
}

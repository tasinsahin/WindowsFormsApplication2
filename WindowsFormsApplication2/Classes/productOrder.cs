using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
    class productOrder
    {
        public int productOrderCode { get; set; }
        public int customerID { get; set; }
        public DateTime dateTake		{get;set;}
        public DateTime dateCarried		{get;set;}
        public int status	{get;set;}
    }
}
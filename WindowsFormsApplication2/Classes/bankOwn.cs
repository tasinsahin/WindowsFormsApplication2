using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace WindowsFormsApplication2
{
        class bankOwn
        {
            public int accountNumber	{get;set;}
            public string  bankName	{get;set;}	
            public string officeName	{get;set;}	
            public int officeCode	{get;set;}
		
            public int code	{get;set;}
            public string bankInfo	{get;set;}
            public string money	{get;set;}
            public decimal total { get; set; }
            public int bankInfoCode { get; set; }
        }
}

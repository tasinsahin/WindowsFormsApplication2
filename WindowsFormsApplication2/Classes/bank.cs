using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication2
{
    class bank
    {
            public int code { get; set; }
            public string billPayName { get; set; }	
            public int  billCode	{get;set;}
            public DateTime dateHold	{get;set;}
            public DateTime dateDue	{get;set;}
            public DateTime date	{get;set;}
            public TimeSpan time	{get;set;}
            public Decimal payAmount	{get;set;}
    }
}

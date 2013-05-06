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
    class storeOP
    {
        SqlConnection connection = new SqlConnection();

        DataTable storeTable2 = new DataTable();
        DataTable productTable = new DataTable();
        DataTable stockTable = new DataTable();
        helper helper = new helper();
        DataTable sellTable = new DataTable();
        DataTable buyTable = new DataTable();
        public void createConnection()
        {
            connection = (SqlConnection)helper.createConnection();
        }

        public DataTable createStoreTable()
        {
            DataTable storeTable = new DataTable();
            productTable.Reset();
            stockTable.Reset();
            sellTable.Reset();
            buyTable.Reset();

            storeTable.Columns.Add("Ürün Kodu", typeof(int));
            storeTable.Columns.Add("Ürün Adı", typeof(string));
            storeTable.Columns.Add("Adet", typeof(int));
            storeTable.Columns.Add("İşlem Türü", typeof(string));
            storeTable.Columns.Add("Tarih",typeof(DateTime));
            string productName = "";
            createConnection();
            SqlDataAdapter adapter = new SqlDataAdapter("Select * from stock", connection);
            adapter.Fill(stockTable);

            for (int i = 0; i < stockTable.Rows.Count; i++)
            {
                int productID = Convert.ToInt32(stockTable.Rows[i][0]);
                int adet = Convert.ToInt32(stockTable.Rows[i][1]);
                string islemTuru="Stok Güncelleme";
                if (adet<0)
                {                    
                     islemTuru = "Stok Azaltma";
                }
                else if (adet>0)
                {               
                     islemTuru = "Stok Arttırma";
                }
                DateTime datee = Convert.ToDateTime(stockTable.Rows[i][2]);
                storeTable.Rows.Add(productID,productName,adet ,islemTuru, datee);
            }

            SqlDataAdapter adapter2 = new SqlDataAdapter("Select * from ProductOrderSell where status=0",connection);
            adapter2.Fill(sellTable);

            for (int i = 0; i < sellTable.Rows.Count; i++)
            {
                DataTable tablein = new DataTable();
                SqlDataAdapter adapter3 = new SqlDataAdapter("Select * from ProductList Where ProductOrderID=" + Convert.ToInt32(sellTable.Rows[i][0]) + "", connection);
                adapter3.Fill(tablein);
                DateTime datee=Convert.ToDateTime(sellTable.Rows[i][3]);
                string islemTuru = "Satış";
                for (int j = 0; j < tablein.Rows.Count; j++)
                {
                    int productID = Convert.ToInt32(tablein.Rows[j][1]);
                    int amount = Convert.ToInt32(tablein.Rows[j][4]);
                    storeTable.Rows.Add(productID, productName, amount, islemTuru, datee);
                }
            }

            SqlDataAdapter adapter4 = new SqlDataAdapter("Select * from ProductOrderBuy where status=0",connection);
            adapter2.Fill(buyTable);
            for (int i = 0; i < buyTable.Rows.Count; i++)
            {
                DataTable tablein = new DataTable();
                SqlDataAdapter adapter3 = new SqlDataAdapter("Select * from ProductList Where ProductOrderID=" + Convert.ToInt32(buyTable.Rows[i][0]) + "", connection);
                adapter3.Fill(tablein);
                DateTime datee=Convert.ToDateTime(buyTable.Rows[i][3]);
                string islemTuru = "Alış";
                for (int j = 0; j < tablein.Rows.Count; j++)
                {
                    int productID = Convert.ToInt32(tablein.Rows[j][1]);
                    int amount = Convert.ToInt32(tablein.Rows[j][4]);
                    storeTable.Rows.Add(productID, productName, amount, islemTuru, datee);
                }
            }

            SqlDataAdapter adapter5 = new SqlDataAdapter("Select * from productdb", connection);
            adapter5.Fill(productTable);

            for (int i = 0; i < storeTable.Rows.Count; i++)
            {
                for (int j = 0; j < productTable.Rows.Count; j++)
                {
                    if (Convert.ToInt32(storeTable.Rows[i][0]) == Convert.ToInt32(productTable.Rows[j][0]))
                    {
                        storeTable.Rows[i]["Ürün Adı"] = Convert.ToString(productTable.Rows[j][1]);
                    }
                }

            }
            storeTable2 = storeTable;
            return storeTable;
        }
        public DataTable chargeListByVariable(string Variable, int ColoumnIndex) // String Variabllera göre listeleyen fonksiyon// coloumn index gerekli
        {
            DataTable tabl2 = new DataTable();
            tabl2 = storeTable2.Clone();
            for (int i = 0; i < storeTable2.Rows.Count; i++)
            {
                if (storeTable2.Rows[i][ColoumnIndex].ToString().StartsWith(Variable))
                {
                    tabl2.ImportRow(storeTable2.Rows[i]);
                }
            }
            return tabl2;
        }
        public DataTable chargeListByDate(DateTime date1,DateTime date2, int ColoumnIndex)
        {
            DataTable tabl3 = new DataTable();
            tabl3 = storeTable2.Clone();
            for (int i = 0; i < storeTable2.Rows.Count; i++)
            {
                DateTime gelenDate=Convert.ToDateTime(storeTable2.Rows[i][ColoumnIndex]);
                if (date1 <= gelenDate)
                {
                    if (gelenDate <= date2)
                    {
                        tabl3.ImportRow(storeTable2.Rows[i]);
                    }   
                }
            }
            return tabl3;
        }
    }
}

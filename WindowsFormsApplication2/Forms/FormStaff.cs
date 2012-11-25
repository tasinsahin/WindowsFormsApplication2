﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace WindowsFormsApplication2
{
    public partial class FormStaff : DevExpress.XtraEditors.XtraForm
    {
        public FormStaff()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormStaff_Closing);
        }
        public bool Cancel { get; set; }
        public bool newStaff; // yeni müşteri mi, update mi? tutuyor
        public bool StaffSelectedFromGrid;
        //cStaff selectedStaff = new cStaff(); /// gridde seçili müşteriyi buraya atıcan update veya silme  için

        private void FormStaff_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void FormStaff_Load(object sender, EventArgs e)
        {
            grb2.Visible = false;

            //DataTable table = toDatatable.toDb<cStaff>(MasisData.Staffs);
            //dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newStaff = true;
            callgroupbox3();
        }
        private void callgroupbox3()
        {

            if (newStaff)
            {
                grb1.Visible = false;
                MakeEmptyOrFillGroupbox3();
                grb2.Visible = true;
                ////////////////////// burada müşteri listesinden bi sonraki müşteri için id çekicen
                // textBox6.Text=Convert.ToString(MasisData.Customers.newCustomerID());
                textBox6.Enabled = false;

            }
            else if (!newStaff)
            {

                /////////////////////// update için formu grid den seçili olan müşteriyle doldurma fonksiyonu yazıcan

                gridToStaff();
                if (StaffSelectedFromGrid == true)
                {
                    MakeEmptyOrFillGroupbox3();
                    grb2.Visible = true;
                    textBox6.Enabled = false;
                    grb1.Visible = false;
                }
            }
        }
        private void gridToStaff()
        {

            if (true) // selected olmasını kontro edicen , selected değilse , mesaj vericen.
            {
                MessageBox.Show("Lütfen, İşlem Yapacağınız Çalışanı  Seçiniz!");
                StaffSelectedFromGrid = false;
            }
            // griddeki seçili olanı silme ve update işi için yukarda verilen staff ile dolduruyor
        }

        private void MakeEmptyOrFillGroupbox3()/////////////////// yeni müşteri için formun içini boşaltan fonksiyon yazıcan
        {
            if (newStaff)
            {
                StaffEmpty();
            }
            else if (!newStaff)
            {
               
            }
        }
        private void StaffEmpty() /// groupboxı yeni müşteri için temizliyor
        {
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
            textBox11.Text = "";
            textBox12.Text = "";
            textBox13.Text = "";
            textBox14.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox17.Text = "";
            textBox18.Text = "";
            textBox19.Text = "";
            textBox20.Text = "";
            textBox21.Text = "";
            textBox22.Text = "";
            textBox23.Text = "";
            textBox24.Text = "";
            textBox25.Text = "";
            textBox26.Text = "";
            textBox27.Text = "";
            textBox28.Text = "";
            textBox29.Text = "";
            textBox30.Text = "";
            textBox31.Text = "";
            textBox32.Text = "";
            textBox33.Text = "";
            textBox34.Text = "";
            textBox35.Text = "";
            textBox36.Text = "";
            textBox37.Text = "";
            textBox38.Text = "";
            textBox39.Text = "";
        }

       
        private void button5_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = false;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            grb1.Visible = false;
            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            newStaff = false;
            callgroupbox3();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
         
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {

            grb2.Visible = false;
            grb1.Visible = true;
        }

        private void grb1_Enter(object sender, EventArgs e)
        {

        }


    }
}

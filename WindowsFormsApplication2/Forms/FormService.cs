using System;
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
    public partial class FormService : DevExpress.XtraEditors.XtraForm
    {
        public FormService()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormServices_Closing);
        }
        public bool Cancel { get; set; }
        public bool newService; // yeni müşteri mi, update mi? tutuyor
        public bool ServiceSelectedFromGrid;
        serviceOP serviceOP = new serviceOP();
        service service = new service();
        auction auction = new auction();
        staffOP staffOP = new staffOP();
        customerOP customerOP = new customerOP();
        int customerCode;
        DataTable serviceTable = new DataTable();
        DataTable customerTable = new DataTable();
        DataTable staffTable = new DataTable();
        DataTable auctionTable = new DataTable();
        DataTable serviceFullTable = new DataTable();

        auctionOP auctionOP = new auctionOP();
        bool error;

        private void FormServices_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
        private void FormService_Load(object sender, EventArgs e)
        {
            formLoad();
        }

        public void formLoad()
        {
            makeFillSearchers();
            grb1.Visible = true;
            grb2.Visible = false;
            grb3.Visible = false;

            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;

            groupBox1.Parent = this;
            groupBox2.Parent = this;
            groupBox3.Parent = this;
            groupBox5.Parent = this;
            grb1.Parent = this;
            grb2.Parent = this;
            grb3.Parent = this;

            serviceTable.Clear();
            customerTable.Clear();
            staffTable.Clear();
            auctionTable.Clear();
            serviceFullTable.Clear();

            makeFillSearchers();
            makeFillSearchers2();
            makeFillSearchers3();
            makeFillSearchers4();
            makeFillSearchers5();
            makeFillSearchers6();
            serviceFullTable = serviceOP.createServiceFullView();
            serviceTable=serviceOP.createServiceTable();
            staffTable = staffOP.createStaffTable();
            customerTable = customerOP.createCustomerTable();
            auctionTable = auctionOP.createAcutionTable();

            dataGridView7.DataSource = staffTable;
            dataGridView5.DataSource = serviceFullTable;
            dataGridView4.DataSource = auctionTable;
            dataGridView2.DataSource = staffTable;
            dataGridView1.DataSource = serviceTable;
            dataGridView3.DataSource = customerTable;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView5.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView7.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            newService = true;
            makeEmptyForm();
            textBox6.Enabled = false;
            grb2.Visible = true;
            grb3.Visible = false;
            grb1.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;
            comboBox1.DataSource = serviceOP.createServiceGroupList();
            
        }

        private void makeEmptyForm()
        {
            textBox6.Text = "";
            dateTimePicker3.Value = System.DateTime.Now;
            textBox8.Text = "";
            comboBox1.Text = "";
            textBox10.Text = "";

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    newService = false;
                    MakeFillForm();
                    textBox6.Enabled = false;
                    grb2.Visible = true;
                    grb3.Visible = false;
                    grb1.Visible = false;
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    groupBox5.Visible = false;
                    comboBox1.DataSource = serviceOP.createServiceGroupList();
                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
            }
        }

        private void MakeFillForm()
        {
            string s= dataGridView1.CurrentRow.Cells[5].Value.ToString();
            string[] arra= s.Split(':');
            textBox6.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            dateTimePicker3.Value =Convert.ToDateTime(dataGridView1.CurrentRow.Cells[4].Value);
            textBox8.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox10.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox7.Text = arra[0].ToString();
            textBox9.Text = arra[1].ToString();
           // customerCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[4].Value);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    DialogResult result = MessageBox.Show("Silmek istediğinize emin misiniz?", "Silmek üzeresiniz", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        serviceOP.serviceDelete(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
                        MessageBox.Show("başarıyla gerçekleşti", "Silme işlemi");
                        formLoad();
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen seçim yapınız", "Seçim yapmadınız");
            }
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            grb1.Visible = true;
            grb2.Visible = false;
            grb3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            grb1.Visible = true;
            grb2.Visible = false;
            grb3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (newService)
            {
                formToService();
                serviceOP.serviceAdd(service);
                MessageBox.Show("Başarıyla tamamlandı", "Kayıt işlemi");
            }
            else if (!newService)
            {
                formToService();
                service.code = Convert.ToInt32(textBox6.Text);
                serviceOP.serviceUpdate(service);
                MessageBox.Show("Başarıyla tamamlandı","güncelleme işlemi");
            }
            formLoad(); // formu tekrar yüklüyoruz ki güncelemmeler görünsün
            
        }

        private void formToService()
        {
                service.customerID = customerCode;
                service.servicee = Convert.ToString(textBox8.Text);
                service.serviceGroup = Convert.ToString(comboBox1.Text);
                service.datee =Convert.ToDateTime(dateTimePicker3.Value);            
                service.timee = (textBox7.Text.ToString() +":"+ textBox9.Text.ToString());                
                service.statuss = 0;                 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBid_Click(object sender, EventArgs e)
        {
            grb1.Visible = false;
            grb2.Visible = false;
            grb3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = true;
            groupBox3.Visible = false;
            groupBox5.Visible = false;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                if (dataGridView1.CurrentRow.Selected)
                {
                    grb3.Visible = true;
                    grb2.Visible = false;
                    grb1.Visible = false;
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    groupBox5.Visible = false;
                    auction.serviceCode = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                }
            }
            else
            {
                MessageBox.Show("Lütfen servis seçiniz","Servis İşlemi");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grb2.Visible = false;
            grb3.Visible = false;
            grb1.Visible = false;
            groupBox1.Visible = true;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;

                
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count!=0)
            {
                if (dataGridView3.CurrentRow.Selected)
                {
                    textBox10.Text = Convert.ToString(dataGridView3.CurrentRow.Cells[1].Value);
                    customerCode = Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value);
                    grb2.Visible = true;
                    grb1.Visible = false;
                    grb3.Visible = false;
                    groupBox1.Visible = false;
                    groupBox2.Visible = false;
                    groupBox3.Visible = false;
                    groupBox5.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Lütfen Seçim yapınız", "Seçim yapmadınız");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            grb2.Visible = true;
            grb1.Visible = false;
            grb3.Visible = false; 
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string minute = textBox11.Text.ToString() + ":" + textBox12.Text.ToString();
            auction.timee = minute;
            auction.bid = dateTimePicker2.Value;
            auction.staff = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);
            auctionOP.auctionAdd(auction);
            MessageBox.Show("başarıyla teklif eklediniz");
            formLoad();
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            grb1.Visible = false;
            grb2.Visible = false;
            grb3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox5.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            grb1.Visible = true;
            grb2.Visible = false;
            grb3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {

            grb1.Visible = true;
            grb2.Visible = false;
            grb3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            grb1.Visible = true;
            grb2.Visible = false;
            grb3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            grb1.Visible = false;
            grb2.Visible = false;
            grb3.Visible = false;
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = false;
            groupBox5.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Rows.Count > 1)
            {
                if (dataGridView4.CurrentRow.Selected)
                {
                    DialogResult result = MessageBox.Show("Teklifi silmek istiyor musunuz?", "Teklifi Silmek üzeresiniz", MessageBoxButtons.YesNo);
                    if (result==DialogResult.Yes)
                    {
                        auctionOP.acutionDelete(Convert.ToInt32(dataGridView4.CurrentRow.Cells[7].Value));
                        MessageBox.Show("başarıyla silindi","silme işlemi");
                        formLoad();
                    }
                }
            }
            else
            {
                MessageBox.Show("seçim yapınız","Seçim yapmadınız");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!(textBox13.Text.ToString()==String.Empty))
            {
                bool isInteger = control.integerControl(textBox13.Text);
                if (isInteger)
                {
                    if (dataGridView7.Rows.Count > 1)
                    {
                        if (dataGridView7.CurrentRow.Selected)
                        {
                            serviceOP.completeService(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value),
                                Convert.ToInt32(textBox13.Text), System.DateTime.Now, Convert.ToInt32(dataGridView7.CurrentRow.Cells[0].Value));
                            MessageBox.Show("başarıyla kaydedildi", "Servis tamamlama");
                            formLoad();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Çalışan seçiniz", "Çalışan seçmediniz");
                    }
                }  
                else
                {
                    errorProvider1.SetError(textBox13, "Sayı Giriniz");
                }
            }
            else
            {
                MessageBox.Show("Tutar giriniz","Tutar Girmediniz");
            }
        }
        #region servis
        public void makeFillSearchers()
        {
            textBox1.Text = "Kod'a Göre";
            textBox2.Text = "Servis'e Göre";
            textBox3.Text = "Grup'a Göre";
            textBox4.Text = "Müşteri'ye Göre";
            textBox5.Text = "Saat'e Göre";
        }
        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox1.Text = "";
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox2.Text = "";
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox3.Text = "";
        }

        private void textBox4_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox4.Text = "";
        }

        private void textBox5_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers();
            textBox5.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceListByVariable(textBox1.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceListByVariable(textBox2.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceListByVariable(textBox3.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceListByVariable(textBox4.Text, 3);
            dataGridView1.DataSource = table;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceListByVariable(textBox5.Text,5);
            dataGridView1.DataSource = table;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceListBByDate(dateTimePicker1.Value,dateTimePicker4.Value,4);
            dataGridView1.DataSource = table;
        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceListBByDate(dateTimePicker1.Value, dateTimePicker4.Value, 4);
            dataGridView1.DataSource = table;
        }
        #endregion
        #region staffselectYapıldıOlarakİşaretle
        public void makeFillSearchers2()
        {
            textBox20.Text = "Kod'a GÖre";
            textBox21.Text = "Ad'a Göre";
            textBox22.Text = "Soyad'a Göre";
            textBox23.Text = "Banka'ya Göre";
            textBox24.Text = "Semt'e Göre";
            textBox44.Text = "Apartman'a Göre";
            textBox45.Text = "Mahalle'ye Göre";
        }
        private void textBox20_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox20.Text = "";
        }

        private void textBox22_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox22.Text = "";
        }

        private void textBox24_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox24.Text = "";
        }

        private void textBox23_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox23.Text = "";
        }

        private void textBox21_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox21.Text = "";
        }

        private void textBox45_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox45.Text = "";
        }

        private void textBox44_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers2();
            textBox44.Text = "";
        }
        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox20.Text, 0);
            dataGridView1.DataSource = table;
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox22.Text, 1);
            dataGridView1.DataSource = table;
        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox24.Text, 2);
            dataGridView1.DataSource = table;
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox23.Text, 12);
            dataGridView1.DataSource = table;
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox21.Text, 27);
            dataGridView1.DataSource = table;
        }

        private void textBox45_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox45.Text, 34);
            dataGridView1.DataSource = table;
        }

        private void textBox44_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox44.Text, 31);
            dataGridView1.DataSource = table;
        }
        #endregion
        #region StaffSelect
        public void makeFillSearchers3()
        {
            textBox25.Text = "Kod'a Göre";
            textBox26.Text = "Ad'a Göre";
            textBox27.Text = "Soyad'a Göre";
            textBox28.Text = "Banka'ya Göre";
            textBox29.Text = "Semt'e Göre";
            textBox30.Text = "Apartman'a Göre";
            textBox31.Text = "Mahalle'ye Göre";
        }
        private void textBox25_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox25.Text = "";
        }

        private void textBox26_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox26.Text = "";
        }

        private void textBox27_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox27.Text = "";
        }

        private void textBox28_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox28.Text = "";
        }

        private void textBox29_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox29.Text = "";
        }

        private void textBox30_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox30.Text = "";
        }

        private void textBox31_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers3();
            textBox31.Text = "";
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox25.Text, 0);
            dataGridView2.DataSource = table;
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox26.Text, 1);
            dataGridView2.DataSource = table;
        }

        private void textBox27_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox27.Text, 2);
            dataGridView2.DataSource = table;
        }

        private void textBox28_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox28.Text, 12);
            dataGridView2.DataSource = table;
        }

        private void textBox29_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox29.Text, 27);
            dataGridView2.DataSource = table;
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox30.Text, 34);
            dataGridView2.DataSource = table;
        }

        private void textBox31_TextChanged(object sender, EventArgs e)
        {
            DataTable table = staffOP.staffListByVariable(textBox31.Text, 31);
            dataGridView2.DataSource = table;
        }
        #endregion
        #region MüşteriSeç
        public void makeFillSearchers4()
        {
            textBox14.Text = "Kod'a Göre";
            textBox15.Text = "Ad'a Göre";
            textBox16.Text = "Soyad'a Göre";
            textBox17.Text = "Banka'ya Göre";
            textBox18.Text = "Semt'e Göre";
            textBox19.Text = "Apartman'a Göre";
        }
        private void textBox14_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox14.Text = "";
        }

        private void textBox15_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox15.Text = "";
        }

        private void textBox16_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox16.Text = "";
        }

        private void textBox19_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox19.Text = "";
        }

        private void textBox18_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox18.Text = "";
        }

        private void textBox17_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers4();
            textBox17.Text = "";
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox14.Text, 0);
            dataGridView3.DataSource = table;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox15.Text, 0);
            dataGridView3.DataSource = table;
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox16.Text, 0);
            dataGridView3.DataSource = table;
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox17.Text, 0);
            dataGridView3.DataSource = table;
        }
        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox18.Text, 0);
            dataGridView3.DataSource = table;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            DataTable table = customerOP.customerListByVariable(textBox19.Text, 0);
            dataGridView3.DataSource = table;
        }

#endregion
        #region TeklifleriGör
        public void makeFillSearchers5()
        {
            textBox36.Text = "Müşteri'ye Göre";
            textBox37.Text = "Çalışan'a Göre";
            textBox38.Text = "Servis'e Göre";
            textBox39.Text = "Saat'e Göre";
        }

        private void textBox36_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers5();
            textBox36.Text = "";
        }

        private void textBox37_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers5();
            textBox37.Text = "";
        }

        private void textBox38_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers5();
            textBox38.Text = "";
        }

        private void textBox39_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers5();
            textBox39.Text = "";
        }

        private void textBox36_TextChanged(object sender, EventArgs e)
        {
            DataTable table = auctionOP.auctionListByVariable(textBox1.Text, 0);
            dataGridView4.DataSource = table;
        }

        private void textBox37_TextChanged(object sender, EventArgs e)
        {
            DataTable table = auctionOP.auctionListByVariable(textBox1.Text, 2);
            dataGridView4.DataSource = table;
        }

        private void textBox38_TextChanged(object sender, EventArgs e)
        {
            DataTable table = auctionOP.auctionListByVariable(textBox1.Text, 3);
            dataGridView4.DataSource = table;
        }

        private void textBox39_TextChanged(object sender, EventArgs e)
        {
            DataTable table = auctionOP.auctionListByVariable(textBox1.Text, 5);
            dataGridView4.DataSource = table;
        }

        private void dateTimePicker9_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = auctionOP.auctionListByDate(dateTimePicker9.Value,dateTimePicker10.Value, 4);
            dataGridView4.DataSource = table;
        }

        private void dateTimePicker10_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = auctionOP.auctionListByDate(dateTimePicker9.Value,dateTimePicker10.Value, 4);
            dataGridView4.DataSource = table;
        }
#endregion
        #region Servis Dökümü
        public void makeFillSearchers6()
        {
            textBox40.Text = "Ad'a Göre";
            textBox41.Text = "Kod'a Göre";
            textBox42.Text = "Servis'e Göre";
            textBox43.Text = "Zaman'a Göre";
            dateTimePicker11.Value = System.DateTime.Now;
            dateTimePicker12.Value = System.DateTime.Now;
            
        }
        private void textBox40_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers6();
            textBox40.Text = "";
        }

        private void textBox41_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers6();
            textBox41.Text = "";
        }

        private void textBox42_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers6();
            textBox42.Text = "";
        }

        private void textBox43_MouseClick(object sender, MouseEventArgs e)
        {
            makeFillSearchers6();
            textBox43.Text = "";
        }

        private void textBox40_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.ServiceFullByVariable(textBox40.Text, 0);
            dataGridView5.DataSource = table;
        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.ServiceFullByVariable(textBox41.Text, 1);
            dataGridView5.DataSource = table;
        }

        private void textBox42_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.ServiceFullByVariable(textBox42.Text, 3);
            dataGridView5.DataSource = table;
        }

        private void textBox43_TextChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.ServiceFullByVariable(textBox43.Text, 5);
            dataGridView5.DataSource = table;
        }

        private void dateTimePicker11_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceFullByDate(dateTimePicker11.Value, dateTimePicker12.Value, 2);
            dataGridView5.DataSource = table;
        }

        private void dateTimePicker12_ValueChanged(object sender, EventArgs e)
        {
            DataTable table = serviceOP.serviceFullByDate(dateTimePicker11.Value, dateTimePicker12.Value, 2);
            dataGridView5.DataSource = table;
        }
#endregion

    }
}

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
    public partial class FormDept : DevExpress.XtraEditors.XtraForm
    {
        public FormDept()
        {
            InitializeComponent();
            this.Closing += new CancelEventHandler(this.FormVerecek_Closing);
        }

        private void FormVerecek_Closing(object sender, CancelEventArgs e)
        {
            e.Cancel = true;
            this.Hide(); ;
        }

        private void FormVerecek_Load(object sender, EventArgs e)
        {
            //DataTable table1 = toDatatable.toDb<cDept>(MasisData.Depts);
            //dataGridView1.DataSource = table1;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

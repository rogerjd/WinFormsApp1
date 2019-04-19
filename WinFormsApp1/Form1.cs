using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DataView dvEmp;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dvEmp = payRollDataSet.Employees.DefaultView;
            dvEmp.RowFilter = "FirstName like 'm%'";
            dvEmp.Sort = "FirstName, LastName";
            bindingSource1.DataSource = dvEmp;
//            dataGridView1.DataSource = dvEmp;

            // TODO: This line of code loads data into the 'payRollDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.payRollDataSet.Employees);

            var b = payRollDataSet.HasChanges();
        }
    }
}

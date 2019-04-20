using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
            //tbl with join > dgv  master-detail
            dvEmp = payRollDataSet.Employees.DefaultView;
            dvEmp.RowFilter = "FirstName like 'm%'";
            dvEmp.Sort = "FirstName, LastName";
            bindingSource1.DataSource = dvEmp;
            //            dataGridView1.DataSource = dvEmp;

            // TODO: This line of code loads data into the 'payRollDataSet.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.payRollDataSet.Employees);

            var b = payRollDataSet.HasChanges();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string sql = "select * from Employees e JOIN EmpJobInfoes eji on e.ID = eji.EmpID";
            using (SqlDataAdapter da = new SqlDataAdapter(sql, employeesTableAdapter.Connection))
            {
                da.Fill(payRollDataSet, "EmpEJI");
            }
            //            dataGridView2.DataSource = payRollDataSet.Tables["EmpEJI"].DefaultView;
            bindingSource2.DataSource = payRollDataSet.Tables["EmpEJI"].DefaultView;
            //dataGridView2.DataSource = bindingSource2.DataSource;
            dataGridView2.AutoGenerateColumns = true;

            //((DataView)bindingSource2.DataSource).Sort
        }
    }
}


/*
// method to fill the dataset
public void FillMyDataSet(MyDataSet ds)
{
    string sql = "SELECT a.*, b.* FROM MyTable a JOIN MyOtherTable b ON a.key = b.key";
    using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
    {
        da.Fill(ds, "MyTable");
    }
}


// call it like this
MyDataSet dsMine = new MyDataSet();
this.FillMyDataSet(dsMine);
MyGridView.DataSource = dsMine;
*/

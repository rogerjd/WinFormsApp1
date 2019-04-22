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
            bindingSourceEmployees.DataSource = dvEmp;
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

        private void Button2_Click(object sender, EventArgs e)
        {
            //            payRollDataSet.Tables["employees"].Rows[1][1] = "test";
            //            var n = employeesTableAdapter.Update(payRollDataSet);

            if (payRollDataSet.HasChanges())
            {
                var n = employeesTableAdapter.Update(payRollDataSet);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            SqlCommand GetCmd()
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = employeesTableAdapter.Connection;
                cmd.CommandText = "USP_EmpByFirstName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@firstName", "m");
/* OK
                SqlParameter p = new SqlParameter()
                {
                    ParameterName = "firstName",
                    Value = "m"
                };
                cmd.Parameters.Add(p);
*/
                return cmd;
            }

            using (SqlDataAdapter da = new SqlDataAdapter()) //employeesTableAdapter.Connection))
            {
                da.SelectCommand = GetCmd();
                DataTable dt= new DataTable();
                da.Fill(dt);
            };

            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = employeesTableAdapter.Connection;
                cmd.CommandText = "USP_EmpByFirstName";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@firstName",
                    Value = "m"
                });

                DataTable tbl = new DataTable();
                employeesTableAdapter.Connection.Open();
                tbl.Load(cmd.ExecuteReader());
                employeesTableAdapter.Connection.Close();
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var connStr = Properties.Settings.Default.PayRollConnectionString;

            var setting = Properties.Settings.Default.Properties["tst"];
            Properties.Settings.Default.tst = "new value";
            setting = Properties.Settings.Default.Properties["tst"];
            Properties.Settings.Default.Save();

            var p = WinFormsApp1.Properties.Settings.Default.tst;
            WinFormsApp1.Properties.Settings.Default.tst = "new value 2";
            WinFormsApp1.Properties.Settings.Default.Save();


            //            Properties.Settings.Default.Properties.Add(new System.Configuration.SettingsProperty("tst", typeof(string), ))
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

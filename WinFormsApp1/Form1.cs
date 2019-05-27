using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {

        DataView dvEmp;
        private (int num, string name) tst;
        public Form1()
        {
            InitializeComponent();
            tst = (1, "abc");
            Console.WriteLine(tst);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tbl with join > dgv  master-detail
            dvEmp = payRollDataSet.Employees.DefaultView;
            dvEmp.RowFilter = "FirstName like 'm%'";
            //dvEmp.Sort = "FirstName, LastName"; sort
            bindingSourceEmployees.DataSource = dvEmp;
            //            dataGridView1.DataSource = dvEmp;

            // TODO: This line of code loads data into the 'payRollDataSet.Employees' table. You can move, or remove it, as needed.
            employeesTableAdapter.Fill(payRollDataSet.Employees);
            var b_ = payRollDataSet.HasChanges();

            textBox5.LostFocus += TextBox5_LostFocus;
        }

        private void TextBox5_LostFocus(object sender, EventArgs e)
        {
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
            //            var n = eamployeesTableAdapter.Update(payRollDataSet);

            if (payRollDataSet.HasChanges())
            {
                var n = employeesTableAdapter.Update(payRollDataSet);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SqlCommand GetCmd()
                {
                    SqlCommand cmd = new SqlCommand
                    {
                        Connection = employeesTableAdapter.Connection,
                        CommandText = "USP_EmpByFirstName",
                        CommandType = CommandType.StoredProcedure
                    };
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
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                };
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var connStr = Properties.Settings.Default.PayRollConnectionString;
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            conn.Close();

            var setting = Properties.Settings.Default.Properties["tst"];
            //Properties.Settings.Default.tst = "new value"; //this writes to user, why? it is usr sttg w/default value for all usrs. because app sttg is r/o?
            //a user.config file, which is created at run time when the user who runs the application changes the value of any user setting; and Save is called

            var p2 = Properties.Settings.Default.tst;
            var p = Properties.Settings.Default.tst;

            Properties.Settings.Default.tst = "new value 2aa";
            Properties.Settings.Default.Save();
        }

        private void TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                ((DataView)bindingSourceEmployees.DataSource).RowFilter = "FirstName like '" + textBox2.Text + "%'";
            }
        }

        /*
                private void DataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
                {
                    if (e.RowIndex == -1)
                    {
                        if (dataGridView1.Columns[e.ColumnIndex].SortMode == DataGridViewColumnSortMode.NotSortable)
                        {
                            return;
                        }

                        if (e.ColumnIndex == curCol)
                        {
                            if (curDir == ListSortDirection.Ascending)
                            {
                                curDir = ListSortDirection.Descending;
                            }
                            else
                            {
                                curDir = ListSortDirection.Ascending;
                            }
                        }

                        curCol = e.ColumnIndex;

                        switch (curDir)
                        {
                            case ListSortDirection.Ascending:
                                dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], ListSortDirection.Ascending);
                                break;
                            case ListSortDirection.Descending:
                                dataGridView1.Sort(dataGridView1.Columns[e.ColumnIndex], ListSortDirection.Descending);
                                break;
                        }

                    }
                }
        */
        #region grid sort
        /*
         * 
          (int curCol, ListSortDirection curDir) sortInfo;
        */
        #endregion

        private void Button5_Click(object sender, EventArgs e)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = employeesTableAdapter.Connection;
                cmd.CommandText = "select * from employees ";
                cmd.CommandText += "where FirstName like @p1";
                cmd.Parameters.AddWithValue("@p1", textBox3.Text.Trim() + "%");

                cmd.CommandText += " AND LastName like @p2";
                cmd.Parameters.AddWithValue("@p2", textBox4.Text.Trim() + "%");

                if (radioButtonFN.Checked)
                    cmd.CommandText += " order by FirstName";
                else
                    cmd.CommandText += " order by LastName";

                DataTable tbl = new DataTable();
                using (var da = new SqlDataAdapter(cmd))
                {
                    da.Fill(tbl);
                }

                /*
            employeesTableAdapter.Connection.Open();
            tbl.Load(cmd.ExecuteReader());
            employeesTableAdapter.Connection.Close();
            */
            }
        }

        private void TextBox5_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("validation");
            Close();
        }

        private void TextBox5_Leave(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            var vf = new ValidateForm();
            var dr = vf.ShowDialog();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            MyStrs t = new MyStrs();
            foreach (var n in t)
            {
                Console.WriteLine(n);
            }

            //t.Reset();

            //wont run again, without a reset
            foreach (var n in t)
            {
                Console.WriteLine(n);
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            DirectoryInfo df = new DirectoryInfo();
            df.ShowDialog();
        }

        private void Button10_Click(object sender, EventArgs e)
        {
            if (!btnClose.CausesValidation)
                textBox6.Validating -= TextBox6_Validating;   //fix for: Form.Show  not needed for ShowDiaglog, or use Form.Closing e.Cancel = false
            Close();
        }

        private void Button10_Click_1(object sender, EventArgs e)
        {
            DataTable1 dt = new DataTable1();
            DialogResult dr =  dt.ShowDialog();
        }

        private void Button11_Click(object sender, EventArgs e)
        {
            validate();
        }

        private void validate()
        {
            MessageBox.Show("validate");
        }

        private void TextBox6_Leave(object sender, EventArgs e)
        {
            //textBox6.Leave -= TextBox6_Leave;
            //validate();
            //textBox1.Focus();
        }

        private void TextBox6_Enter(object sender, EventArgs e)
        {
            //textBox6.Leave += TextBox6_Leave;
        }

        private void TextBox6_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrEmpty(textBox6.Text.Trim());
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

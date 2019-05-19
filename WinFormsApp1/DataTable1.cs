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
    public partial class DataTable1 : Form
    {
        public DataTable1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            var connStr = Properties.Settings.Default.MovieConnStr;
            SqlConnection conn = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand
            {
                CommandText = "uspGetMovies",
                CommandType = CommandType.StoredProcedure,
                Connection = conn
            };
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
    }
}

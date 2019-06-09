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
    public partial class EventsCtrl : Form
    {
        public EventsCtrl()
        {
            InitializeComponent();
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            MessageBox.Show("txt1 leave");
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            //MessageBox.Show("txt1 enter");
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {

        }

        private void Button1_Leave(object sender, EventArgs e)
        {

        }

        private void Button1_Enter(object sender, EventArgs e)
        {

        }

        private void Button2_Enter(object sender, EventArgs e)
        {

        }

        private void Button2_Leave(object sender, EventArgs e)
        {

        }

        private void ValidateTst()
        {
            textBox1.Focus();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ValidateTst();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

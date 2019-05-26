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
    public partial class ValidateForm : Form
    {
        public ValidateForm()
        {
            InitializeComponent();
        }

        private void TextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "must be non blank");
            }
        }

        private void TextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "must be non blank");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                MessageBox.Show("validated");
            }
            else
            {
                MessageBox.Show("not validated");
                DialogResult = DialogResult.None;
            }
        }

        private void TextBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
        }

        private void TextBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox2, "");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

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
    public partial class DirectoryInfo : Form
    {
        public DirectoryInfo()
        {
            InitializeComponent();

            //            listView1.Items = new string[] {"one", "two", "three" };
            listView1.Items.Add(new ListViewItem( new string[] { "one", "two", "three" }));
        }
    }
}

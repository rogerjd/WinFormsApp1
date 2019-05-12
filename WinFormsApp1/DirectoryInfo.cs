using System;
using System.IO;
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

        private void Button1_Click(object sender, EventArgs e)
        {
            DirSearch(@"c:\users\roger\my documents");
        }

        private void DirSearch(string v)
        {
            Console.WriteLine(v);

            foreach (var dir in Directory.GetDirectories(v))
            {
                DirSearch(dir);
            }
        }
    }
}

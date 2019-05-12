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
            listBox1.Items.Clear();
            DirSearch(@"c:\Windows\help");
        }

        private void DirSearch(string v)
        {
            Console.WriteLine(v);
            listBox1.Items.Add(v);

            try
            {
                foreach (var dir in Directory.GetDirectories(v, "*", SearchOption.TopDirectoryOnly))
                {
                    DirSearch(dir);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void BuildTreeView(TreeNode tn)
        {
            Console.WriteLine(tn.Text); //there is Tag property

            try
            {
                foreach (var dir in Directory.GetDirectories(tn.Text, "*", SearchOption.TopDirectoryOnly))
                {
                    TreeNode tn2 = new TreeNode(dir);
                    tn.Nodes.Add(tn2);
                    BuildTreeView(tn2);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            treeView1.Nodes.Add(@"c:\Windows\help");

            BuildTreeView(treeView1.Nodes[0]);
        }
    }
}

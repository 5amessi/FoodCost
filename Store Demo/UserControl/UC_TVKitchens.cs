using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Food_Cost.Forms
{
   
    public partial class UC_TVKitchens : UserControl
    {
        public UC_TVKitchens()
        {
            InitializeComponent();
        }
        public List<string> KitchensList = new List<string>();

        private void UC_TVKitchens_Load(object sender, EventArgs e)
        {
            //TVKitchens = Classes.LoadStores(TVKitchens);
        }

        public void UC_TVKitchens_Load()
        {
            TVKitchens = Classes.LoadStores(TVKitchens);
        }
        public void Kitchen_Checked(ref string f, ref string Where)
        {
            KitchensList.Clear();
            string s1;
            s1 = "";
            f = "";
            Where = "(";
            foreach (TreeNode Node in TVKitchens.Nodes)
            {
                foreach (TreeNode Child in Node.Nodes)
                {
                    if (Child.Checked == true)
                    {
                        Where += s1 + "(Restaurant_ID = " + Node.Name + " AND Kitchen_ID =" + Child.Name + ")";
                        s1 = " OR ";
                        KitchensList.Add(Child.Text);
                    }
                }
            }
            Where += ")";
            if (s1 == "")
            {
                MessageBox.Show("Please Select One Kitchen At Least need edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }
        private void TVKitchens_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckAllChildNodes(e.Node, e.Node.Checked);
        } 
    }
}

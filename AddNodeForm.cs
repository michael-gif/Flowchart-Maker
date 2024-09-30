using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Northwoods.Go.Models;
using Northwoods.Go;

namespace FlowchartMaker
{
    public partial class AddNodeForm : Form
    {
        public static string nodeType = "";
        public AddNodeForm()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNodeToModel();
            Close();
        }

        private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                AddNodeToModel();
                Close();
            }
        }

        private void AddNodeToModel()
        {
            Form1 form1 = (Form1)Application.OpenForms["Form1"];
            Form1.NodeData nodedata = null;
            switch (nodeType)
            {
                case "process":
                    nodedata = new Form1.NodeData { Key = textBox1.Text, Category = "Process", Text = textBox1.Text };
                    break;
                case "decision":
                    nodedata = new Form1.NodeData { Key = textBox1.Text, Category = "Decision", Text = textBox1.Text };
                    break;
            }
            form1.diagram.Model.AddNodeData(nodedata);
            form1.diagram.UpdateAllRelationshipsFromData();
        }
    }
}

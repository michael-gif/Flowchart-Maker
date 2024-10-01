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
        public static AddNodeForm INSTANCE = new AddNodeForm();
        public string nodeType = "";
        public Diagram diagram;

        public static void Reveal(Diagram diagram, string nodeType)
        {
            INSTANCE.Text = "Add " + nodeType + " node";
            INSTANCE.diagram = diagram;
            INSTANCE.nodeType = nodeType;
            INSTANCE.textBox1.Text = "";
            INSTANCE.Show();
            INSTANCE.Location = Cursor.Position;
            INSTANCE.textBox1.Focus();
        }

        private AddNodeForm()
        {
            InitializeComponent();
            textBox1.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNodeToModel();
            Hide();
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                AddNodeToModel();
                Hide();
            }
        }

        private void AddNodeToModel()
        {
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
            diagram.Model.AddNodeData(nodedata);
            diagram.UpdateAllRelationshipsFromData();
        }

        private void AddNodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}

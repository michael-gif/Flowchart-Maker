using Northwoods.Go;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlowchartMaker
{
    public partial class ExpandedTextForm : Form
    {
        public Diagram diagram;
        public string nodeKey;
        public TextBox parentTextBox;
        public ExpandedTextForm(Diagram diagram, string nodeKey, TextBox parentTextBox)
        {
            this.diagram = diagram;
            this.nodeKey = nodeKey;
            this.parentTextBox = parentTextBox;
            InitializeComponent();
            expandTextOkButton.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
            expandedTextBox.Text = parentTextBox.Text;
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SaveNodeText();
            }
        }

        private void SaveNodeText()
        {
            Node node = diagram.FindNodeForKey(nodeKey);
            diagram.Model.Commit((m) =>
            {
                m.Set(node.Data, "Text", expandedTextBox.Text);
            });
            EditNodeForm.INSTANCE.Enabled = true;
            parentTextBox.Text = expandedTextBox.Text;
            Close();
        }

        private void expandTextOkButton_Click(object sender, EventArgs e)
        {
            SaveNodeText();
        }
    }
}

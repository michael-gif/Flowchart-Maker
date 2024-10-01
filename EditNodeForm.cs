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
using Northwoods.Go.Tools;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using SkiaSharp.Views.Desktop;

namespace FlowchartMaker
{
    public partial class EditNodeForm : Form
    {
        public static EditNodeForm INSTANCE = new EditNodeForm();
        public string NodeKey;
        public Diagram diagram;

        public static void Reveal(Diagram diagram, string nodeKey)
        {
            INSTANCE.diagram = diagram;
            INSTANCE.NodeKey = nodeKey;
            INSTANCE.Show();
            Form1.NodeData data = (Form1.NodeData)diagram.FindNodeForKey(nodeKey).Data;
            INSTANCE.editNodeNewText.Text = data.Text;
            INSTANCE.editNodeNewText.SelectionStart = 0;
            INSTANCE.editNodeNewText.SelectionLength = INSTANCE.editNodeNewText.Text.Length;
            INSTANCE.editNodeNewText.Focus();
        }
        private EditNodeForm()
        {
            InitializeComponent();
            editNodeNewText.KeyPress += new KeyPressEventHandler(CheckEnterKeyPress);
        }

        private void CheckEnterKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SaveNodeText();
                Hide();
            }
        }

        private void editNodeSaveButton_Click(object sender, EventArgs e)
        {
            SaveNodeText();
        }

        private void SaveNodeText()
        {
            Node node = diagram.FindNodeForKey(NodeKey);
            diagram.Model.Commit((m) =>
            {
                m.Set(node.Data, "Text", editNodeNewText.Text);
            });
            Hide();
        }

        private void editNodeForeColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.OK) return;
            Node node = diagram.FindNodeForKey(NodeKey);
            diagram.Model.Commit((m) =>
            {
                string rgbColor = "#" + colorDialog1.Color.ToSKColor().ToString().Substring(3);
                m.Set(node.Data, "ForeColor", rgbColor);
            });
        }

        private void editNodeBackColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.OK) return;
            Node node = diagram.FindNodeForKey(NodeKey);
            diagram.Model.Commit((m) =>
            {
                string rgbColor = "#" + colorDialog1.Color.ToSKColor().ToString().Substring(3);
                m.Set(node.Data, "BackColor", rgbColor);
            });
        }

        private void EditNodeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }
        }
    }
}

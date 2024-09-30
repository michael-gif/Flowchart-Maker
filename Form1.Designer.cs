namespace FlowchartMaker
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            diagramControl1 = new Northwoods.Go.WinForms.DiagramControl();
            menuStrip1 = new MenuStrip();
            openFlowchartToolStripMenuItem = new ToolStripMenuItem();
            saveFlowchartToolStripMenuItem = new ToolStripMenuItem();
            clearFlowchartToolStripMenuItem = new ToolStripMenuItem();
            enableGridlinesToolStripMenuItem = new ToolStripMenuItem();
            enableGridsnapToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStrip1 = new ContextMenuStrip(components);
            startEndToolStripMenuItem = new ToolStripMenuItem();
            endToolStripMenuItem = new ToolStripMenuItem();
            processToolStripMenuItem = new ToolStripMenuItem();
            decisionToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // diagramControl1
            // 
            diagramControl1.AllowDrop = true;
            diagramControl1.BackColor = Color.White;
            diagramControl1.Dock = DockStyle.Fill;
            diagramControl1.Location = new Point(0, 24);
            diagramControl1.Name = "diagramControl1";
            diagramControl1.Size = new Size(800, 426);
            diagramControl1.TabIndex = 0;
            diagramControl1.Text = "diagramControl1";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { openFlowchartToolStripMenuItem, saveFlowchartToolStripMenuItem, clearFlowchartToolStripMenuItem, enableGridlinesToolStripMenuItem, enableGridsnapToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // openFlowchartToolStripMenuItem
            // 
            openFlowchartToolStripMenuItem.Name = "openFlowchartToolStripMenuItem";
            openFlowchartToolStripMenuItem.Size = new Size(101, 20);
            openFlowchartToolStripMenuItem.Text = "Open flowchart";
            openFlowchartToolStripMenuItem.Click += openFlowchartToolStripMenuItem_Click;
            // 
            // saveFlowchartToolStripMenuItem
            // 
            saveFlowchartToolStripMenuItem.Name = "saveFlowchartToolStripMenuItem";
            saveFlowchartToolStripMenuItem.Size = new Size(96, 20);
            saveFlowchartToolStripMenuItem.Text = "Save flowchart";
            saveFlowchartToolStripMenuItem.Click += saveFlowchartToolStripMenuItem_Click;
            // 
            // clearFlowchartToolStripMenuItem
            // 
            clearFlowchartToolStripMenuItem.Name = "clearFlowchartToolStripMenuItem";
            clearFlowchartToolStripMenuItem.Size = new Size(99, 20);
            clearFlowchartToolStripMenuItem.Text = "Clear flowchart";
            clearFlowchartToolStripMenuItem.Click += clearFlowchartToolStripMenuItem_Click;
            // 
            // enableGridlinesToolStripMenuItem
            // 
            enableGridlinesToolStripMenuItem.Name = "enableGridlinesToolStripMenuItem";
            enableGridlinesToolStripMenuItem.Size = new Size(65, 20);
            enableGridlinesToolStripMenuItem.Text = "Gridlines";
            enableGridlinesToolStripMenuItem.Click += enableGridlinesToolStripMenuItem_Click;
            // 
            // enableGridsnapToolStripMenuItem
            // 
            enableGridsnapToolStripMenuItem.Name = "enableGridsnapToolStripMenuItem";
            enableGridsnapToolStripMenuItem.Size = new Size(106, 20);
            enableGridsnapToolStripMenuItem.Text = "Disable gridsnap";
            enableGridsnapToolStripMenuItem.Click += enableGridsnapToolStripMenuItem_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { startEndToolStripMenuItem, endToolStripMenuItem, processToolStripMenuItem, decisionToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.ShowImageMargin = false;
            contextMenuStrip1.Size = new Size(95, 92);
            contextMenuStrip1.Text = "New Node";
            // 
            // startEndToolStripMenuItem
            // 
            startEndToolStripMenuItem.Name = "startEndToolStripMenuItem";
            startEndToolStripMenuItem.Size = new Size(94, 22);
            startEndToolStripMenuItem.Text = "Start";
            startEndToolStripMenuItem.Click += startEndToolStripMenuItem_Click;
            // 
            // endToolStripMenuItem
            // 
            endToolStripMenuItem.Name = "endToolStripMenuItem";
            endToolStripMenuItem.Size = new Size(94, 22);
            endToolStripMenuItem.Text = "End";
            endToolStripMenuItem.Click += endToolStripMenuItem_Click;
            // 
            // processToolStripMenuItem
            // 
            processToolStripMenuItem.Name = "processToolStripMenuItem";
            processToolStripMenuItem.Size = new Size(94, 22);
            processToolStripMenuItem.Text = "Process";
            processToolStripMenuItem.Click += processToolStripMenuItem_Click;
            // 
            // decisionToolStripMenuItem
            // 
            decisionToolStripMenuItem.Name = "decisionToolStripMenuItem";
            decisionToolStripMenuItem.Size = new Size(94, 22);
            decisionToolStripMenuItem.Text = "Decision";
            decisionToolStripMenuItem.Click += decisionToolStripMenuItem_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(diagramControl1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "FlowchartMaker";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Northwoods.Go.WinForms.DiagramControl diagramControl1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem openFlowchartToolStripMenuItem;
        private ToolStripMenuItem saveFlowchartToolStripMenuItem;
        private ToolStripMenuItem clearFlowchartToolStripMenuItem;
        private ToolStripMenuItem enableGridlinesToolStripMenuItem;
        private ToolStripMenuItem enableGridsnapToolStripMenuItem;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem startEndToolStripMenuItem;
        private ToolStripMenuItem processToolStripMenuItem;
        private ToolStripMenuItem decisionToolStripMenuItem;
        private ToolStripMenuItem endToolStripMenuItem;
    }
}
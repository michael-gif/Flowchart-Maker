namespace FlowchartMaker
{
    partial class ExpandedTextForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            expandedTextBox = new TextBox();
            expandTextOkButton = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // expandedTextBox
            // 
            expandedTextBox.Location = new Point(3, 3);
            expandedTextBox.Multiline = true;
            expandedTextBox.Name = "expandedTextBox";
            expandedTextBox.Size = new Size(250, 100);
            expandedTextBox.TabIndex = 0;
            // 
            // expandTextOkButton
            // 
            expandTextOkButton.Location = new Point(3, 109);
            expandTextOkButton.Name = "expandTextOkButton";
            expandTextOkButton.Size = new Size(250, 23);
            expandTextOkButton.TabIndex = 1;
            expandTextOkButton.Text = "ok";
            expandTextOkButton.UseVisualStyleBackColor = true;
            expandTextOkButton.Click += expandTextOkButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(expandTextOkButton);
            panel1.Controls.Add(expandedTextBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(1, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(256, 135);
            panel1.TabIndex = 2;
            // 
            // ExpandedTextForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(258, 137);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExpandedTextForm";
            Padding = new Padding(1);
            Text = "ExpandedTextForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox expandedTextBox;
        private Button expandTextOkButton;
        private Panel panel1;
    }
}
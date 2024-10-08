﻿namespace FlowchartMaker
{
    partial class EditNodeForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditNodeForm));
            label1 = new Label();
            editNodeSaveButton = new Button();
            label2 = new Label();
            label3 = new Label();
            colorDialog1 = new ColorDialog();
            editNodeForeColorButton = new Button();
            editNodeBackColorButton = new Button();
            editNodeNewText = new TextBox();
            expandEditTextButton = new Button();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(60, 15);
            label1.TabIndex = 0;
            label1.Text = "Node Text";
            // 
            // editNodeSaveButton
            // 
            editNodeSaveButton.Location = new Point(12, 99);
            editNodeSaveButton.Name = "editNodeSaveButton";
            editNodeSaveButton.Size = new Size(191, 23);
            editNodeSaveButton.TabIndex = 2;
            editNodeSaveButton.Text = "Save";
            editNodeSaveButton.UseVisualStyleBackColor = true;
            editNodeSaveButton.Click += editNodeSaveButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 45);
            label2.Name = "label2";
            label2.Size = new Size(62, 15);
            label2.TabIndex = 3;
            label2.Text = "Fore Color";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 74);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 4;
            label3.Text = "Back Color";
            // 
            // editNodeForeColorButton
            // 
            editNodeForeColorButton.Location = new Point(103, 41);
            editNodeForeColorButton.Name = "editNodeForeColorButton";
            editNodeForeColorButton.Size = new Size(100, 23);
            editNodeForeColorButton.TabIndex = 5;
            editNodeForeColorButton.UseVisualStyleBackColor = true;
            editNodeForeColorButton.Click += editNodeForeColorButton_Click;
            // 
            // editNodeBackColorButton
            // 
            editNodeBackColorButton.Location = new Point(103, 70);
            editNodeBackColorButton.Name = "editNodeBackColorButton";
            editNodeBackColorButton.Size = new Size(100, 23);
            editNodeBackColorButton.TabIndex = 6;
            editNodeBackColorButton.UseVisualStyleBackColor = true;
            editNodeBackColorButton.Click += editNodeBackColorButton_Click;
            // 
            // editNodeNewText
            // 
            editNodeNewText.Location = new Point(78, 12);
            editNodeNewText.Multiline = true;
            editNodeNewText.Name = "editNodeNewText";
            editNodeNewText.Size = new Size(100, 23);
            editNodeNewText.TabIndex = 1;
            // 
            // expandEditTextButton
            // 
            expandEditTextButton.BackgroundImage = (Image)resources.GetObject("expandEditTextButton.BackgroundImage");
            expandEditTextButton.BackgroundImageLayout = ImageLayout.Zoom;
            expandEditTextButton.Image = (Image)resources.GetObject("expandEditTextButton.Image");
            expandEditTextButton.Location = new Point(178, 11);
            expandEditTextButton.Name = "expandEditTextButton";
            expandEditTextButton.Size = new Size(25, 25);
            expandEditTextButton.TabIndex = 7;
            expandEditTextButton.UseVisualStyleBackColor = true;
            expandEditTextButton.Click += expandEditTextButton_Click;
            // 
            // EditNodeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(216, 137);
            Controls.Add(expandEditTextButton);
            Controls.Add(editNodeBackColorButton);
            Controls.Add(editNodeForeColorButton);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(editNodeSaveButton);
            Controls.Add(editNodeNewText);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditNodeForm";
            Text = "Edit Node";
            FormClosing += EditNodeForm_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button editNodeSaveButton;
        private Label label2;
        private Label label3;
        private ColorDialog colorDialog1;
        private Button editNodeForeColorButton;
        private Button editNodeBackColorButton;
        private TextBox editNodeNewText;
        private Button expandEditTextButton;
        private ToolTip toolTip1;
    }
}
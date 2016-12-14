﻿namespace Multiple_Choice_Creator
{
    partial class FeedPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedPanel));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.answersDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.DeleteButtton = new System.Windows.Forms.ToolStripButton();
            this.QuestionLabel = new System.Windows.Forms.ToolStripLabel();
            this.showTimer = new System.Windows.Forms.Timer(this.components);
            this.deleteTimer = new System.Windows.Forms.Timer(this.components);
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.answersDataGridView);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 177);
            this.panel1.TabIndex = 13;
            // 
            // answersDataGridView
            // 
            this.answersDataGridView.AllowUserToAddRows = false;
            this.answersDataGridView.AllowUserToDeleteRows = false;
            this.answersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.answersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.answersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answersDataGridView.Location = new System.Drawing.Point(0, 25);
            this.answersDataGridView.Name = "answersDataGridView";
            this.answersDataGridView.Size = new System.Drawing.Size(530, 152);
            this.answersDataGridView.TabIndex = 14;
            this.answersDataGridView.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.answersDataGridView_CellBeginEdit);
            this.answersDataGridView.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.answersDataGridView_CellEndEdit);
            this.answersDataGridView.Leave += new System.EventHandler(this.answersDataGridView_Leave);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DeleteButtton,
            this.QuestionLabel,
            this.saveButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(530, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // DeleteButtton
            // 
            this.DeleteButtton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.DeleteButtton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteButtton.Image = ((System.Drawing.Image)(resources.GetObject("DeleteButtton.Image")));
            this.DeleteButtton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteButtton.Name = "DeleteButtton";
            this.DeleteButtton.Size = new System.Drawing.Size(23, 22);
            this.DeleteButtton.Text = "Delete";
            this.DeleteButtton.Click += new System.EventHandler(this.DeleteButtton_Click);
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(58, 22);
            this.QuestionLabel.Text = "Question:";
            // 
            // showTimer
            // 
            this.showTimer.Tick += new System.EventHandler(this.tm_Tick);
            // 
            // deleteTimer
            // 
            this.deleteTimer.Tick += new System.EventHandler(this.deleteTimer_Tick);
            // 
            // saveButton
            // 
            this.saveButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveButton.Image = ((System.Drawing.Image)(resources.GetObject("saveButton.Image")));
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(23, 22);
            this.saveButton.Text = "Save";
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FeedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.panel1);
            this.Name = "FeedPanel";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(533, 180);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView answersDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton DeleteButtton;
        private System.Windows.Forms.ToolStripLabel QuestionLabel;
        private System.Windows.Forms.Timer showTimer;
        private System.Windows.Forms.Timer deleteTimer;
        private System.Windows.Forms.ToolStripButton saveButton;
    }
}

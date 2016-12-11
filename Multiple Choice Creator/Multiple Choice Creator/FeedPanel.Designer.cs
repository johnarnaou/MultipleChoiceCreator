namespace Multiple_Choice_Creator
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.SaveToolStrip = new System.Windows.Forms.ToolStripButton();
            this.EditToolStrip = new System.Windows.Forms.ToolStripButton();
            this.QuestionLabel = new System.Windows.Forms.ToolStripLabel();
            this.answersDataGridView = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.answersDataGridView);
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(530, 185);
            this.panel1.TabIndex = 13;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStrip,
            this.EditToolStrip,
            this.QuestionLabel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(530, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveToolStrip
            // 
            this.SaveToolStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.SaveToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStrip.Image")));
            this.SaveToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStrip.Name = "SaveToolStrip";
            this.SaveToolStrip.Size = new System.Drawing.Size(23, 22);
            this.SaveToolStrip.Text = "Save";
            // 
            // EditToolStrip
            // 
            this.EditToolStrip.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.EditToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("EditToolStrip.Image")));
            this.EditToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditToolStrip.Name = "EditToolStrip";
            this.EditToolStrip.Size = new System.Drawing.Size(23, 22);
            this.EditToolStrip.Text = "Edit";
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(58, 22);
            this.QuestionLabel.Text = "Question:";
            // 
            // answersDataGridView
            // 
            this.answersDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.answersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.answersDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.answersDataGridView.Location = new System.Drawing.Point(0, 25);
            this.answersDataGridView.Name = "answersDataGridView";
            this.answersDataGridView.Size = new System.Drawing.Size(530, 160);
            this.answersDataGridView.TabIndex = 14;
            // 
            // FeedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Name = "FeedPanel";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(533, 188);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView answersDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveToolStrip;
        private System.Windows.Forms.ToolStripButton EditToolStrip;
        private System.Windows.Forms.ToolStripLabel QuestionLabel;
    }
}

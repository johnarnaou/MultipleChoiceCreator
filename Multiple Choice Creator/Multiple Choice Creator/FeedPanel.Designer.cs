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
            this.seeMoreLabel = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.addCheckBox = new System.Windows.Forms.CheckBox();
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.SaveToolStrip = new System.Windows.Forms.ToolStripButton();
            this.EditToolStrip = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.answersDataGridView = new System.Windows.Forms.DataGridView();
            this.answersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.answersBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // seeMoreLabel
            // 
            this.seeMoreLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.seeMoreLabel.AutoSize = true;
            this.seeMoreLabel.Location = new System.Drawing.Point(534, 168);
            this.seeMoreLabel.Name = "seeMoreLabel";
            this.seeMoreLabel.Size = new System.Drawing.Size(76, 13);
            this.seeMoreLabel.TabIndex = 11;
            this.seeMoreLabel.TabStop = true;
            this.seeMoreLabel.Text = "Show answers";
            this.seeMoreLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.seeMoreLabel_LinkClicked);
            // 
            // addCheckBox
            // 
            this.addCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addCheckBox.AutoSize = true;
            this.addCheckBox.Location = new System.Drawing.Point(595, 14);
            this.addCheckBox.Name = "addCheckBox";
            this.addCheckBox.Size = new System.Drawing.Size(15, 14);
            this.addCheckBox.TabIndex = 2;
            this.addCheckBox.UseVisualStyleBackColor = true;
            this.addCheckBox.MouseEnter += new System.EventHandler(this.addCheckBox_MouseEnter);
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionLabel.Location = new System.Drawing.Point(27, 11);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(100, 23);
            this.QuestionLabel.TabIndex = 0;
            this.QuestionLabel.Text = "Question:";
            // 
            // SaveToolStrip
            // 
            this.SaveToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("SaveToolStrip.Image")));
            this.SaveToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveToolStrip.Name = "SaveToolStrip";
            this.SaveToolStrip.Size = new System.Drawing.Size(21, 20);
            this.SaveToolStrip.Text = "Save";
            // 
            // EditToolStrip
            // 
            this.EditToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("EditToolStrip.Image")));
            this.EditToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditToolStrip.Name = "EditToolStrip";
            this.EditToolStrip.Size = new System.Drawing.Size(21, 20);
            this.EditToolStrip.Text = "Edit";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveToolStrip,
            this.EditToolStrip});
            this.toolStrip1.Location = new System.Drawing.Point(0, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(24, 188);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // answersDataGridView
            // 
            this.answersDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.answersDataGridView.AutoGenerateColumns = false;
            this.answersDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.answersDataGridView.DataSource = this.answersBindingSource;
            this.answersDataGridView.Location = new System.Drawing.Point(27, 38);
            this.answersDataGridView.Name = "answersDataGridView";
            this.answersDataGridView.Size = new System.Drawing.Size(579, 120);
            this.answersDataGridView.TabIndex = 12;
            this.answersDataGridView.Visible = false;
            // 
            // FeedPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.answersDataGridView);
            this.Controls.Add(this.seeMoreLabel);
            this.Controls.Add(this.addCheckBox);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.QuestionLabel);
            this.Name = "FeedPanel";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Size = new System.Drawing.Size(613, 191);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.answersDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.answersBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel seeMoreLabel;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox addCheckBox;
        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.ToolStripButton SaveToolStrip;
        private System.Windows.Forms.ToolStripButton EditToolStrip;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView answersDataGridView;
        private System.Windows.Forms.BindingSource answersBindingSource;
    }
}

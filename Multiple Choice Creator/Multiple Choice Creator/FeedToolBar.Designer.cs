namespace Multiple_Choice_Creator
{
    partial class FeedToolBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedToolBar));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.searchButton = new System.Windows.Forms.ToolStripButton();
            this.searchTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.HomeButton = new System.Windows.Forms.ToolStripButton();
            this.ShrinkButton = new System.Windows.Forms.ToolStripButton();
            this.ExpandButton = new System.Windows.Forms.ToolStripButton();
            this.easyButton = new System.Windows.Forms.ToolStripButton();
            this.hardButton = new System.Windows.Forms.ToolStripButton();
            this.clearFilterButton = new System.Windows.Forms.ToolStripButton();
            this.medButton = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.toolStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 25);
            this.panel1.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchButton,
            this.searchTextBox,
            this.HomeButton,
            this.ShrinkButton,
            this.ExpandButton,
            this.easyButton,
            this.medButton,
            this.hardButton,
            this.clearFilterButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(398, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // searchButton
            // 
            this.searchButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.searchButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.searchButton.Image = ((System.Drawing.Image)(resources.GetObject("searchButton.Image")));
            this.searchButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(23, 22);
            this.searchButton.Text = "Search";
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(100, 25);
            this.searchTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchTextBox_KeyDown);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.HomeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.HomeButton.Image = ((System.Drawing.Image)(resources.GetObject("HomeButton.Image")));
            this.HomeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(23, 22);
            this.HomeButton.Text = "Home";
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // ShrinkButton
            // 
            this.ShrinkButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ShrinkButton.Image = ((System.Drawing.Image)(resources.GetObject("ShrinkButton.Image")));
            this.ShrinkButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ShrinkButton.Name = "ShrinkButton";
            this.ShrinkButton.Size = new System.Drawing.Size(23, 22);
            this.ShrinkButton.Text = "Shrink";
            this.ShrinkButton.Click += new System.EventHandler(this.ShrinkButton_Click);
            // 
            // ExpandButton
            // 
            this.ExpandButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ExpandButton.Image = ((System.Drawing.Image)(resources.GetObject("ExpandButton.Image")));
            this.ExpandButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ExpandButton.Name = "ExpandButton";
            this.ExpandButton.Size = new System.Drawing.Size(23, 22);
            this.ExpandButton.Text = "Expand";
            this.ExpandButton.Visible = false;
            this.ExpandButton.Click += new System.EventHandler(this.ExpandButton_Click);
            // 
            // easyButton
            // 
            this.easyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.easyButton.Image = ((System.Drawing.Image)(resources.GetObject("easyButton.Image")));
            this.easyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.easyButton.Name = "easyButton";
            this.easyButton.Size = new System.Drawing.Size(23, 22);
            this.easyButton.Text = "E";
            this.easyButton.Click += new System.EventHandler(this.easyButton_Click);
            // 
            // hardButton
            // 
            this.hardButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.hardButton.Image = ((System.Drawing.Image)(resources.GetObject("hardButton.Image")));
            this.hardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hardButton.Name = "hardButton";
            this.hardButton.Size = new System.Drawing.Size(23, 22);
            this.hardButton.Text = "H";
            this.hardButton.Click += new System.EventHandler(this.hardButton_Click);
            // 
            // clearFilterButton
            // 
            this.clearFilterButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearFilterButton.Image = ((System.Drawing.Image)(resources.GetObject("clearFilterButton.Image")));
            this.clearFilterButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearFilterButton.Name = "clearFilterButton";
            this.clearFilterButton.Size = new System.Drawing.Size(38, 22);
            this.clearFilterButton.Text = "Clear";
            this.clearFilterButton.Click += new System.EventHandler(this.clearFilterButton_Click);
            // 
            // medButton
            // 
            this.medButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.medButton.Image = ((System.Drawing.Image)(resources.GetObject("medButton.Image")));
            this.medButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.medButton.Name = "medButton";
            this.medButton.Size = new System.Drawing.Size(23, 22);
            this.medButton.Text = "M";
            this.medButton.Click += new System.EventHandler(this.medButton_Click);
            // 
            // FeedToolBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Name = "FeedToolBar";
            this.Size = new System.Drawing.Size(398, 25);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton searchButton;
        private System.Windows.Forms.ToolStripTextBox searchTextBox;
        private System.Windows.Forms.ToolStripButton HomeButton;
        private System.Windows.Forms.ToolStripButton ShrinkButton;
        private System.Windows.Forms.ToolStripButton ExpandButton;
        private System.Windows.Forms.ToolStripButton easyButton;
        private System.Windows.Forms.ToolStripButton hardButton;
        private System.Windows.Forms.ToolStripButton clearFilterButton;
        private System.Windows.Forms.ToolStripButton medButton;
    }
}

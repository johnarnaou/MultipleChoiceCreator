﻿namespace Multiple_Choice_Creator
{
    partial class QuestionPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuestionPreview));
            this.button1 = new System.Windows.Forms.Button();
            this.edit = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.category = new System.Windows.Forms.Label();
            this.Difficulty = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.questLabel = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(295, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // edit
            // 
            this.edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edit.Image = ((System.Drawing.Image)(resources.GetObject("edit.Image")));
            this.edit.Location = new System.Drawing.Point(273, 3);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(20, 20);
            this.edit.TabIndex = 4;
            this.edit.UseVisualStyleBackColor = true;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listView1.Location = new System.Drawing.Point(3, 56);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(162, 89);
            this.listView1.TabIndex = 6;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // category
            // 
            this.category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.category.Location = new System.Drawing.Point(171, 72);
            this.category.Name = "category";
            this.category.Size = new System.Drawing.Size(60, 22);
            this.category.TabIndex = 8;
            this.category.Text = "Category:";
            // 
            // Difficulty
            // 
            this.Difficulty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Difficulty.Location = new System.Drawing.Point(169, 106);
            this.Difficulty.Name = "Difficulty";
            this.Difficulty.Size = new System.Drawing.Size(153, 22);
            this.Difficulty.TabIndex = 9;
            this.Difficulty.Text = "Difficulty:";
            // 
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.listView2.Location = new System.Drawing.Point(235, 67);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(87, 22);
            this.listView2.TabIndex = 10;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // questLabel
            // 
            this.questLabel.AutoSize = true;
            this.questLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.questLabel.Location = new System.Drawing.Point(3, 0);
            this.questLabel.Name = "questLabel";
            this.questLabel.Size = new System.Drawing.Size(0, 19);
            this.questLabel.TabIndex = 6;
            this.questLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.questLabel.UseCompatibleTextRendering = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.questLabel);
            this.flowLayoutPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(264, 41);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // QuestionPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.Difficulty);
            this.Controls.Add(this.category);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.Name = "QuestionPreview";
            this.Size = new System.Drawing.Size(327, 148);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label category;
        private System.Windows.Forms.Label Difficulty;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.Label questLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

namespace Multiple_Choice_Creator
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
            this.Correct = new System.Windows.Forms.Label();
            this.xMore = new System.Windows.Forms.Label();
            this.edit = new System.Windows.Forms.Button();
            this.questLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(149, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(20, 20);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Correct
            // 
            this.Correct.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Correct.AutoSize = true;
            this.Correct.BackColor = System.Drawing.Color.LightGreen;
            this.Correct.Location = new System.Drawing.Point(14, 57);
            this.Correct.Name = "Correct";
            this.Correct.Size = new System.Drawing.Size(35, 13);
            this.Correct.TabIndex = 2;
            this.Correct.Text = "label1";
            // 
            // xMore
            // 
            this.xMore.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.xMore.AutoSize = true;
            this.xMore.BackColor = System.Drawing.Color.Crimson;
            this.xMore.ForeColor = System.Drawing.SystemColors.ControlText;
            this.xMore.Location = new System.Drawing.Point(124, 57);
            this.xMore.Name = "xMore";
            this.xMore.Size = new System.Drawing.Size(35, 13);
            this.xMore.TabIndex = 3;
            this.xMore.Text = "label1";
            // 
            // edit
            // 
            this.edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.edit.Image = ((System.Drawing.Image)(resources.GetObject("edit.Image")));
            this.edit.Location = new System.Drawing.Point(127, 4);
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(20, 20);
            this.edit.TabIndex = 4;
            this.edit.UseVisualStyleBackColor = true;
            // 
            // questLabel
            // 
            this.questLabel.AutoSize = true;
            this.questLabel.Location = new System.Drawing.Point(14, 8);
            this.questLabel.Name = "questLabel";
            this.questLabel.Size = new System.Drawing.Size(35, 13);
            this.questLabel.TabIndex = 5;
            this.questLabel.Text = "label1";
            // 
            // QuestionPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.questLabel);
            this.Controls.Add(this.edit);
            this.Controls.Add(this.xMore);
            this.Controls.Add(this.Correct);
            this.Controls.Add(this.button1);
            this.Name = "QuestionPreview";
            this.Size = new System.Drawing.Size(190, 103);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Correct;
        private System.Windows.Forms.Label xMore;
        private System.Windows.Forms.Button edit;
        private System.Windows.Forms.Label questLabel;
    }
}

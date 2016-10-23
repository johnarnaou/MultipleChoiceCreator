namespace Multiple_Choice_Creator
{
    partial class HomeScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createNewButton = new System.Windows.Forms.Button();
            this.lessonsButton = new System.Windows.Forms.Button();
            this.allTestsButton = new System.Windows.Forms.Button();
            this.recentsListBox = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(167, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Home Screen";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.recentsListBox);
            this.groupBox1.Controls.Add(this.allTestsButton);
            this.groupBox1.Controls.Add(this.lessonsButton);
            this.groupBox1.Controls.Add(this.createNewButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(586, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // createNewButton
            // 
            this.createNewButton.Location = new System.Drawing.Point(7, 79);
            this.createNewButton.Name = "createNewButton";
            this.createNewButton.Size = new System.Drawing.Size(75, 23);
            this.createNewButton.TabIndex = 1;
            this.createNewButton.Text = "Create New";
            this.createNewButton.UseVisualStyleBackColor = true;
            this.createNewButton.Click += new System.EventHandler(this.createNewButton_Click);
            // 
            // lessonsButton
            // 
            this.lessonsButton.Location = new System.Drawing.Point(248, 79);
            this.lessonsButton.Name = "lessonsButton";
            this.lessonsButton.Size = new System.Drawing.Size(75, 23);
            this.lessonsButton.TabIndex = 2;
            this.lessonsButton.Text = "Lessons";
            this.lessonsButton.UseVisualStyleBackColor = true;
            // 
            // allTestsButton
            // 
            this.allTestsButton.Location = new System.Drawing.Point(505, 79);
            this.allTestsButton.Name = "allTestsButton";
            this.allTestsButton.Size = new System.Drawing.Size(75, 23);
            this.allTestsButton.TabIndex = 3;
            this.allTestsButton.Text = "All Tests";
            this.allTestsButton.UseVisualStyleBackColor = true;
            // 
            // recentsListBox
            // 
            this.recentsListBox.FormattingEnabled = true;
            this.recentsListBox.Location = new System.Drawing.Point(7, 138);
            this.recentsListBox.Name = "recentsListBox";
            this.recentsListBox.Size = new System.Drawing.Size(573, 147);
            this.recentsListBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recent Tests";
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 326);
            this.Controls.Add(this.groupBox1);
            this.Name = "HomeScreen";
            this.Text = "HomeScreen";
            this.Deactivate += new System.EventHandler(this.HomeScreen_Deactivate);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button createNewButton;
        private System.Windows.Forms.Button allTestsButton;
        private System.Windows.Forms.Button lessonsButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox recentsListBox;
    }
}
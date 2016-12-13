namespace Multiple_Choice_Creator
{
    partial class Settings
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
            this.AskBeforeDeleteCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // AskBeforeDeleteCheckBox
            // 
            this.AskBeforeDeleteCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AskBeforeDeleteCheckBox.Checked = true;
            this.AskBeforeDeleteCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AskBeforeDeleteCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AskBeforeDeleteCheckBox.Location = new System.Drawing.Point(13, 13);
            this.AskBeforeDeleteCheckBox.Name = "AskBeforeDeleteCheckBox";
            this.AskBeforeDeleteCheckBox.Size = new System.Drawing.Size(340, 27);
            this.AskBeforeDeleteCheckBox.TabIndex = 0;
            this.AskBeforeDeleteCheckBox.Text = "Ask before delete";
            this.AskBeforeDeleteCheckBox.UseVisualStyleBackColor = true;
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(365, 74);
            this.Controls.Add(this.AskBeforeDeleteCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox AskBeforeDeleteCheckBox;
    }
}
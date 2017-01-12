using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Model;
using System.IO;

namespace Multiple_Choice_Creator
{
    public partial class createPDFcontrol : UserControl
    {
        Panel pan;
        CreateTestControl createTC;
        public createPDFcontrol(User usr, CreateTestControl myCreateTC)
        {
            InitializeComponent();
            createTC = myCreateTC;
            getuserPreffs();

            this.Dock = DockStyle.Fill;
        }

        private void setUserPreffs()
        {
            if (checkBox1.Checked == true) { Properties.Settings.Default.userInfo = true; }
            else { Properties.Settings.Default.userInfo = false; }
            if (checkBox2.Checked == true) { Properties.Settings.Default.mail = true; }
            else { Properties.Settings.Default.mail = false; }
            if (checkBox5.Checked == true) { Properties.Settings.Default.date = true; }
            else { Properties.Settings.Default.date = false; }
            if (checkBox4.Checked == true) { Properties.Settings.Default.pdfWithAnsw = true; }
            else { Properties.Settings.Default.pdfWithAnsw = false; }
            if (checkBox3.Checked == true) { Properties.Settings.Default.sendBackup = true; }
            else { Properties.Settings.Default.sendBackup = false; }

            if (numericUpDown1!= null) { Properties.Settings.Default.qFontsize = (int)numericUpDown1.Value; }
            else { Properties.Settings.Default.qFontsize = 15; }
            if (numericUpDown2 != null) { Properties.Settings.Default.aFontsize = (int)numericUpDown2.Value; }
            else { Properties.Settings.Default.qFontsize = 13; }

            Properties.Settings.Default.Save();

        }

        private void getuserPreffs()
        {

            if (Properties.Settings.Default.userInfo) { checkBox1.CheckState = CheckState.Checked; }
            if (Properties.Settings.Default.mail) { checkBox2.CheckState = CheckState.Checked; }
            if (Properties.Settings.Default.date) { checkBox5.CheckState = CheckState.Checked; }
            if (Properties.Settings.Default.pdfWithAnsw) { checkBox4.CheckState = CheckState.Checked; }
            if (Properties.Settings.Default.sendBackup) { checkBox3.CheckState = CheckState.Checked; }
            if (Properties.Settings.Default.qFontsize != null) { numericUpDown1.Value = (int)Properties.Settings.Default.qFontsize; }
            if (Properties.Settings.Default.qFontsize != null) { numericUpDown2.Value = (int)Properties.Settings.Default.aFontsize; }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            //proeretikes metavlites
            /* FolderBrowserDialog browser = new FolderBrowserDialog();
             string tempPath = "";

             if (browser.ShowDialog() == DialogResult.OK)
             {
                 tempPath = browser.SelectedPath; // prints path
             }*/

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF Files|*.pdf";
            saveFileDialog1.Title = "Save As...";
            saveFileDialog1.DefaultExt = "*.pdf";
            saveFileDialog1.ShowDialog();
            Cursor.Current = Cursors.WaitCursor;
            string path=null;
            if (saveFileDialog1.FileName != "")
            {
                path = checkThePDFfileName(saveFileDialog1.FileName);
            }else
            {
                MessageBox.Show("Error on save File","Add file name",MessageBoxButtons.OK);
                Cursor.Current = Cursors.Default;
                return;
            }

                string topText = richTextBox1.Text;
            bool info=checkBox1.Checked;
            bool email= checkBox2.Checked;
            bool date= checkBox5.Checked;
            int questionfs=(int)numericUpDown1.Value;
            int answerfs= (int)numericUpDown2.Value;
            bool createAnswers= checkBox4.Checked;
            bool sendMail= checkBox3.Checked;
            createTC.createPDF(topText, info, email, date, questionfs, answerfs, createAnswers, sendMail, path);
            setUserPreffs();
            Cursor.Current = Cursors.Default;
        }

        

        private string checkThePDFfileName(string fileName)
        {

            return fileName;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

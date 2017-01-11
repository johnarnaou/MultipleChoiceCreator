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
            this.Dock = DockStyle.Fill;
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
            string path=null;
            if (saveFileDialog1.FileName != "")
            {
                path = checkThePDFfileName(saveFileDialog1.FileName);
            }else
            {
                MessageBox.Show("Error on save File","Add file name",MessageBoxButtons.OK);
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
        }

        private string checkThePDFfileName(string fileName)
        {

            return fileName;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

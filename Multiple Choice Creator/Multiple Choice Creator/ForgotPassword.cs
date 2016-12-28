using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    public partial class ForgotPassword : Form
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        Form loginForm;

        private void button1_Click(object sender, EventArgs e)
        {
            mail.Text = textBox1.Text;
            textBox1.Text = null;
            panel1.Visible = false;
            panel2.Visible = true;
            Update();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                //temporary
                DialogResult dr = MessageBox.Show("The 2 passwords are not the same!", "Close");
            }
        }

        private void ForgotPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loginForm == null)
            {
                loginForm = new Login();
            }
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Persistence;
using Multiple_Choice_Creator.Model;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Multiple_Choice_Creator
{
    public partial class Register : Form
    {
        Form loginForm = new Login();
        Form mainForm;
        public Register()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Register_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != textBox5.Text)
            {
                //temporary
                DialogResult dr = MessageBox.Show("Passwords don't match!", "Close");
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            String firstName = textBox1.Text;
            String lastName = textBox2.Text;
            String email = textBox3.Text;
            String password = textBox4.Text;
            if (firstName != "" && lastName != "" && email != "" && password != "")
            {
                if (IsValidEmail(email)) { 
                    User user = new User(email, password, firstName, lastName);
                    markUnWritten(firstName, lastName, email, password);
                    DaoUsers dUser = DaoUsers.getInstance();
                    DaoMysql dmsql = new DaoMysql();
                    if (dUser.register(user))
                    {
                            dUser.sendMail(user,0);
                            Form VerificationCode = new VerificationCode(user);
                            VerificationCode.StartPosition = FormStartPosition.CenterScreen;
                            VerificationCode.Show();
                            this.Hide();
                     
                    }
                    else
                    {
                        //Se periptwsh pou gia opoiodhpote logo den mporesei na kanei register
                        DialogResult dr = MessageBox.Show("Error on Registration", "Close");
                    }
                }else
                {
                    DialogResult dr = MessageBox.Show("Mail Not Valid!", "Close");
                }
            }
            else
            {
                DialogResult dr = MessageBox.Show("You must fill all the fields above!", "Close");
            }
            Cursor.Current = Cursors.Default;
        }
        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private void markUnWritten(string firstName, string lastName, string email, String password)
        {
            if (firstName == "") { 
                label6.Text = "*";
            }
            else {
                label6.Text = "";
             }
            if (lastName == "")
            {
                label7.Text = "*";
            }
            else
            {
                label7.Text = "";
            }
            if (email == "")
            {
                label8.Text = "*";
            }
            else
            {
                label8.Text = "";
            }
            if (password == "")
            {
                label9.Text = "*";
            }
            else
            {
                label9.Text = "";
            }
            Refresh();
        }

        private void Register_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.Show();
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("PLease type your first name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            return;
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("PLease type your Last name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
            return;
        }

        bool invalid = false;
        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            
        }

        
    }
}

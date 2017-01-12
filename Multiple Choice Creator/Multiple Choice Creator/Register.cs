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
using System.Net.Mail;

namespace Multiple_Choice_Creator
{
    public partial class Register : Form
    {
        Login loginForm;
        Form mainForm;
        public Register(Login mylogin)
        {
            loginForm = mylogin;
            InitializeComponent();
        }

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
        string result;
        private void button1_Click(object sender, EventArgs e)
        {
            if (!checkForNull()) { return; }
            if (!checkForPassMathing()) { return; }
            
            Cursor.Current = Cursors.WaitCursor;
            if (IsValidEmail(textBox3.Text)) {
                User user = new User(textBox3.Text, textBox4.Text, textBox1.Text, textBox2.Text);
                DaoUsers dUser = DaoUsers.getInstance();
                DaoMysql dmsql = new DaoMysql();
                if (MessageBox.Show("Are you sure you want to be registered as:\n"+user.toString(), "Register", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    Cursor.Current = Cursors.Default;
                    return;
                }
                if (dUser.register(user))
                {
                    result=dUser.sendMail(user, 0);
                    Form VerificationCode = new VerificationCode(user, loginForm);
                    VerificationCode.StartPosition = FormStartPosition.CenterScreen;
                    VerificationCode.Show();
                    this.Hide();

                }
                else
                {
                    //Se periptwsh pou gia opoiodhpote logo den mporesei na kanei register
                    DialogResult dr = MessageBox.Show("Error on Registration", "Close");
                }
                } else
                {
                    DialogResult dr = MessageBox.Show("Mail Not Valid!", "Close");
                }
                Cursor.Current = Cursors.Default;
            MessageBox.Show("Registration Status", result, MessageBoxButtons.OK);
            result = "";
        }

        private bool checkForPassMathing()
        {
            bool apot = true;
            if (textBox4.Text != textBox5.Text)
            {
                errorProvider1.SetError(textBox5, "The passwords don't match!");
                textBox4.Focus();
                errorProvider1.SetError(textBox4, "The passwords don't match!");
                apot = false;
            }else
            {
                errorProvider1.SetError(textBox4, null);
                errorProvider1.SetError(textBox5, null);
            }
            return apot;
        }

        private bool checkForNull()
        {
            bool apot = true;
            foreach (Control textBox in Controls)
            {
                if (textBox is TextBox)
                {
                    if (textBox.Text == "")
                    {
                        textBox.Focus();
                        errorProvider1.SetError(textBox, "This field is required!");
                        apot = false;
                    }
                    else
                    {
                        errorProvider1.SetError(textBox, null);
                    }
                }
            }

            return apot;
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

        /*private void markUnWritten(string firstName, string lastName, string email, String password)
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
        }*/

        private void Register_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.Show();
        }

       /* private void textBox1_Validating(object sender, CancelEventArgs e)
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
            try
            {
                MailAddress m = new MailAddress(textBox3.Text);
            }
            catch (FormatException exc)
            {
                Console.WriteLine(exc.ToString());
                MessageBox.Show("Invalid Email adresss", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            string passwordGiven = textBox4.Text;
            bool valid = false;
            if (passwordGiven.Any(char.IsUpper) && passwordGiven.Any(char.IsLower) 
                && passwordGiven.Any(char.IsDigit))
            {
                valid = true;
            }
            if (valid!=true)
            {
                MessageBox.Show("Invalid password.The password must contain at least "+
                    "one lower case,upper case and number character","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }*/
    }
}

using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using Multiple_Choice_Creator.Model;
using Multiple_Choice_Creator.Persistence;
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
        UsersTableAdapter uta=new UsersTableAdapter();
        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //Convert.ToInt32(uta.getUserID(mail.text.toString()));
            if (Convert.ToInt32(uta.checkExistanceOfUserMail(textBox1.Text)) > 0)
            {
                errorProvider1.SetError(textBox1, null);
            }
            else
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "The mail you entered does not exists!");
                Cursor.Current = Cursors.Default;
                return;
            }
            mail.Text = textBox1.Text;
            textBox1.Text = null;
            panel1.Visible = false;
            panel2.Visible = true;
            DaoUsers dUser = new DaoUsers();
            //isws thelei allon enan domith
            User tmpUser = new User(mail.Text, null, null, null);
            dUser.sendMail(tmpUser,3);
            Cursor.Current = Cursors.Default;
            Update();

        }




        private void button2_Click(object sender, EventArgs e)
        {
            //check for empty textboxes
            if (!checkforempty()) { return; }
            //check the code wrote
            if (!wrongString()) { return; }
            //check the new pass word if it is the same in both textboxes
            if (!checkNewPass()){ return; }
            enterNewPassword();

            Close();
            
        }

        private bool checkforempty()
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

        private void enterNewPassword()
        {
            int userID = Convert.ToInt32(uta.getUserID(mail.Text));
            uta.updateUser(textBox2.Text, userID);
        }

        ResetPassTableAdapter rpta = new ResetPassTableAdapter();
        private bool wrongString()
        {

            int userID = Convert.ToInt32(uta.getUserID(mail.Text));
            string correctString = Convert.ToString(rpta.getfCcodeOfUser(userID));
            string checkString = textBox4.Text.ToString();
            if (!correctString.Equals(checkString))
            {
                errorProvider1.SetError(textBox4, null);
                return false;
            }else
            {
                textBox4.Focus();
                errorProvider1.SetError(textBox4, "The code you entered is incorrect!");
                return true;
            }
        }

        private bool checkNewPass()
        {
            bool apot = true;
            if (textBox2.Text.Equals(textBox3.Text)==false)
            {
                errorProvider1.SetError(textBox3, "The passwords don't match!");
                textBox2.Focus();
                errorProvider1.SetError(textBox2, "The passwords don't match!");
                apot = false;
            }
            else
            {
                errorProvider1.SetError(textBox2, null);
                errorProvider1.SetError(textBox3, null);
            }
            return apot;
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

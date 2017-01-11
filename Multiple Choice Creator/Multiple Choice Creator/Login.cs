using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Persistence;
using Multiple_Choice_Creator.Model;
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using static Multiple_Choice_Creator.mltChoiceDataSet;

namespace Multiple_Choice_Creator
{
    public partial class Login : Form
    {
        Form signUp, mainForm,VerificationCode,ForgotPass;
        public Login()
        {
            InitializeComponent();
            setUserDataToForm();
            /*Edw tha elegxoume an o xrhsths exei stored username h password etsi wste na ta exoyme san text sth forma an exei*/
            //signUp = new Login();
        }
        //this method is to load to the login forom the data if the user has saved his preferences for username or password
        private void setUserDataToForm()
        {
            if (Properties.Settings.Default.userName != null)
            {
                textBox1.Text = (string)Properties.Settings.Default.userName;
                checkBox1.Checked=true;
            }
            if (Properties.Settings.Default.passUser != null)
            {
                textBox2.Text = (string)Properties.Settings.Default.passUser;
                checkBox2.Checked = true;
            }
        }
        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Form.ShowDialog(new StartPageVdiamant());
        }
        String mail;
        String password;
        private void loginButton_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try { 
            //var HSForm = new HomeScreen();
            //HSForm.Show();
            //var HSForm1 = new NewHomeScreen_Popis_();
            //HSForm1.Show();
            mail = textBox1.Text;
            password = textBox2.Text;
                if (checkeUP())
                {

                
                   // DaoMysql dbOb = new DaoMysql();
                    User user = new User(mail, password);
                    DaoUsers dUser=DaoUsers.getInstance();
                    UsersTableAdapter uAdapter = new UsersTableAdapter();
                    user.setUserID((int)uAdapter.getUserID(mail));
                    if (dUser.login(user))
                    {
                        setDefaultsUnamePworld();
                        try { 
                            UsersTableAdapter uta = new UsersTableAdapter();
                            UsersDataTable udt = uta.getFirstLastNameById(user.getUserID());
                            int ar = user.getUserID();
                            string name = udt.Rows[0][0].ToString();
                            string last= udt.Rows[0][1].ToString();
                            user.setFname(udt.Rows[0][0].ToString());
                            user.setLname(udt.Rows[0][1].ToString());
                            //user.setLname(uta.getUserLast(user.getUserID()));
                        }
                        catch(Exception exception)
                        {
                            MessageBox.Show("Error on Login!", "Some properties haven't set", MessageBoxButtons.OK);
                        }

                        if (dUser.checkIfVerified(user)) {

                    
                            HomeScreen form = new HomeScreen(user);
                            form.StartPosition = FormStartPosition.CenterScreen;
                            form.Show();
                            this.Hide();
                        }
                        else
                        {
                            Form VerificationCode = new VerificationCode(user);
                            VerificationCode.StartPosition = FormStartPosition.CenterScreen;
                            VerificationCode.Show();
                            this.Hide();
                        }

                    }
                    else {
                        //edw mporoyme na tsekaroyme kai an uparxei to username kai an uparxei na to kratame alliws na ta svhnoyme ola ta periexomena apo ta textbox.
                        MessageBox.Show("Error on Login!", "Please try again", MessageBoxButtons.OK);
                    }




                            /*Kaloume apo thn klash DaoMySql thn methodo gia na tsekarei to login
                            setaroume ta user attributes.*/

                            /*An einai ok tsekaroyme ta checkbox gia to an tha apothikeusoyme se arxeio ta username kai password toy xrhsth gia na ta exei sto mellon*/
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Log in Failed", "Unable to connect", MessageBoxButtons.OK);
                Console.WriteLine(ex.ToString());
            }

            Cursor.Current = Cursors.Default;
        }

        //this method is to open the mainForm whenever we need and it simplifies the Login button click method.
        private void showMainForm(User user)
        {
            if (mainForm == null)
            {
                mainForm = new HomeScreen(user);
                mainForm.StartPosition = FormStartPosition.CenterScreen;//isws na mhn xreiazetai
                mainForm.Show();
                //na aferw to log in kai register apo to menu toy xrhsth??

            }
            else
            {
                mainForm.Focus();
            }
        }

        //this method is to save tho the properties settings the username and the password if the user checked the boxs
        private void setDefaultsUnamePworld()
        {
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.userName = textBox1.Text;
            }
            if (checkBox2.Checked)
            {
                Properties.Settings.Default.passUser = textBox2.Text;
            }

            Properties.Settings.Default.Save();

        }

        //kakh methodos thelei douleia
        private bool checkeUP()
        {
            bool apot = true;
            if (textBox2.Text == "")
            {
                textBox2.Focus();
                errorProvider1.SetError(textBox2, "You must enter your password!");
                apot = false;
            }
            else
            {
                errorProvider1.SetError(textBox2, null);
            }
            if (textBox1.Text == "")
            {
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "You must enter your username!");
                apot = false;
            }
            else
            {
                errorProvider1.SetError(textBox1, null);
            }
            return apot;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Enabled = true;
            }
            else
            {
                checkBox2.Checked = false;
                checkBox2.Enabled = false;
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            if (ForgotPass == null)
            {
                ForgotPass = new ForgotPassword();
            }
            ForgotPass.StartPosition = FormStartPosition.CenterScreen;
            ForgotPass.Show();
            this.Hide();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (signUp == null)
            {
                signUp = new Register(this);
            }
            signUp.StartPosition = FormStartPosition.CenterScreen;
            signUp.Show();
            this.Hide();
        }
    }
    
}

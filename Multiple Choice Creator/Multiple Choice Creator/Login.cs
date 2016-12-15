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

namespace Multiple_Choice_Creator
{
    public partial class Login : Form
    {
        Form signUp, mainForm,VerificationCode;
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
            //var HSForm = new HomeScreen();
            //HSForm.Show();
            //var HSForm1 = new NewHomeScreen_Popis_();
            //HSForm1.Show();
            mail = textBox1.Text;
            password = textBox2.Text;
            checkeUP(mail, password);
            DaoMysql dbOb = new DaoMysql();
            User user = new User(mail, password);
            DaoUsers dUser=DaoUsers.getInstance();
            UsersTableAdapter uAdapter = new UsersTableAdapter();
            user.setUserID((int)uAdapter.getUserID(mail));
            if (dUser.login(user))
            {
                setDefaultsUnamePworld();
                if (dUser.checkIfVerified(user)) {

                    
                    HomeScreen form = new HomeScreen(user);
                    form.StartPosition = FormStartPosition.CenterScreen;
                    form.Show();
                    this.Hide();
                }
                else
                {
                    Form VerificationCode = new VerificationCode(user);
                    VerificationCode.Show();
                    this.Hide();
                }

            }
            else {
                //edw mporoyme na tsekaroyme kai an uparxei to username kai an uparxei na to kratame alliws na ta svhnoyme ola ta periexomena apo ta textbox.
                DialogResult dr = MessageBox.Show("Error, Please Try Again", "Close");
            }




            /*Kaloume apo thn klash DaoMySql thn methodo gia na tsekarei to login
            setaroume ta user attributes.*/

            /*An einai ok tsekaroyme ta checkbox gia to an tha apothikeusoyme se arxeio ta username kai password toy xrhsth gia na ta exei sto mellon*/

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
        private void checkeUP(string username, string password)
        {
            if (username == "")
            {
                label4.Text = "please enter username!";
                label5.Text = "*";
            }
            else if (username != "")
            {
                label4.Text = "";
                label5.Text = "";
            }
            if (password == "")
            {
                label4.Text = "please enter password!";
                label6.Text = "*";
            }
            else
            {
                label6.Text = "";
                if (username != "")
                    label4.Text = "";
            }

            if (username == "" && password == "")
            {
                label4.Text = "please enter username and passworld!";
            }

            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();


        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (signUp == null)
            {
                signUp = new Register();
            }
            signUp.StartPosition = FormStartPosition.CenterScreen;
            signUp.Show();
            this.Hide();
        }
    }
    
}

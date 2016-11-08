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

namespace Multiple_Choice_Creator
{
    public partial class Login : Form
    {
        Form signUp;
        public Login()
        {
            InitializeComponent();

            /*Edw tha elegxoume an o xrhsths exei stored username h password etsi wste na ta exoyme san text sth forma an exei*/
            //signUp = new Login();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.Form.ShowDialog(new StartPageVdiamant());
        }
        String username;
        String password;
        private void loginButton_Click(object sender, EventArgs e)
        {
            //var HSForm = new HomeScreen();
            //HSForm.Show();
            //var HSForm1 = new NewHomeScreen_Popis_();
            //HSForm1.Show();
            username = textBox1.Text;
            password = textBox2.Text;
            checkeUP(username,password);




            /*Kaloume apo thn klash DaoMySql thn methodo gia na tsekarei to login
            setaroume ta user attributes.*/

            /*An einai ok tsekaroyme ta checkbox gia to an tha apothikeusoyme se arxeio ta username kai password toy xrhsth gia na ta exei sto mellon*/
            
        }


        //kakh methodos thelei douleia
        private void checkeUP(string username, string password)
        {
            if (username == "")
            {
                label4.Text = "please enter username!";
                label5.Text = "*";
            }
            else if(username != "")
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
                if(username != "")
                    label4.Text = "";
            }

            if (username == "" && password=="") {
                label4.Text = "please enter username and passworld!";
            }

            Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            

        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (signUp == null)
            {
                signUp = new Register();
            }
            signUp.StartPosition = FormStartPosition.CenterScreen;
            signUp.Show();
            //this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

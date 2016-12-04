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
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;

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

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            loginForm.StartPosition = FormStartPosition.CenterScreen;
            loginForm.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String firstName = textBox1.Text;
            String lastName = textBox2.Text;
            String email = textBox3.Text;
            String password = textBox4.Text;
            if (firstName != "" && lastName != "" && email != "" && password != "")
            {
                User user = new User(email, password, firstName, lastName);
                markUnWritten(firstName, lastName, email, password);
                DaoMysql dbOb=new DaoMysql();
                if (dbOb.register(firstName, lastName, email, password))
                {
                    //tha grapsoume kai ton kwdika pou tha ton exei hdh kanei log in sto programma kai tha emfanizontai kapou ta stoixeia toy
                    UsersTableAdapter uTableAdapter = new UsersTableAdapter();
                    user.setUserID((int)uTableAdapter.getUserID(user.getEmail()));
                    mainForm = new HomeScreen(user);
                    mainForm.StartPosition = FormStartPosition.CenterScreen;
                    mainForm.Show();
                    this.Close();
                }
                else {
                    //Se periptwsh pou gia opoiodhpote logo den mporesei na kanei register
                    DialogResult dr = MessageBox.Show("Error on Registration", "Close");
                }
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

        private void Register_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login form = new Login();
            form.StartPosition = FormStartPosition.CenterScreen;
            form.Show();
        }
    }
}

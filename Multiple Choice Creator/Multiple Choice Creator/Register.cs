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
    public partial class Register : Form
    {
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
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            String firstName = textBox1.Text;
            String lastName = textBox2.Text;
            String email = textBox3.Text;
            String password = textBox4.Text;
            markUnWritten(firstName,lastName,email,password);
            if (firstName != "" && lastName != "" && email != "" && password != "")
            {
                /*
                    Edw tha graftei o kwdikaw poy tha kanei kataxwrish sth vash
                 */
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
    }
}

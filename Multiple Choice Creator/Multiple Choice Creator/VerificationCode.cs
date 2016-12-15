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

namespace Multiple_Choice_Creator
{
    public partial class VerificationCode : Form
    {
        User user;
        DaoUsers duser = new DaoUsers();
        public VerificationCode(User tempUser)
        {
            InitializeComponent();
            user = tempUser;
        }


        public void PassValue(string strValue)
        {
            label1.Text = strValue;
        }

        Form mainForm;

        public VerificationCode(string userID)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(duser.checkTheVerificationCode(user, textBox1.Text))
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
                this.Hide();
            }
            else
            {
                textBox1.Text = "";
                label3.Visible = true;
            }
            
        }

        private void VerificationCode_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            duser.sendMail(user);
        }
    }
}

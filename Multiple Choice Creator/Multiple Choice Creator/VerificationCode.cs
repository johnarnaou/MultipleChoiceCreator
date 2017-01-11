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
        Login lgform;
        public VerificationCode(User tempUser)
        {
            InitializeComponent();
            user = tempUser;
        }

        public VerificationCode(User tempUser,Login login)
        {
            lgform = login;
            InitializeComponent();
            user = tempUser;
        }


        public void PassValue(string strValue)
        {
            label1.Text = strValue;
        }

        Form mainForm;
        Form Register;

        public VerificationCode(string userID)
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (duser.checkTheVerificationCode(user, textBox1.Text))
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
                if (lgform != null)
                {
                    lgform = null;
                }
                this.Hide();
            }
            else
            {
                textBox1.Text = "";
                label3.Visible = true;
            }
            Cursor.Current = Cursors.Default;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            String msg=duser.sendMail(user,1);
            Cursor.Current = Cursors.Default;
            MessageBox.Show("Re-send Status", msg, MessageBoxButtons.OK);
        }

        private void VerificationCode_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            try { 
            //Register.Close();
            Application.Exit();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}

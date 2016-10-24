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
    public partial class HomeScreen : Form
    {
        public HomeScreen()
        {
            InitializeComponent();
        }

        private void createNewButton_Click(object sender, EventArgs e)
        {
            var Form = new InsertQuestion();
            this.Visible = false;
            Form.Show();
        }

        private void allTestsButton_Click(object sender, EventArgs e)
        {
            //test commit
        }

        private void HomeScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

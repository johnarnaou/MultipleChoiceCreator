using Multiple_Choice_Creator.Model;
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
        LoadFeed feed;
        public HomeScreen(User user)
        {
            InitializeComponent();
            splitContainer2.Panel2.AutoScroll = true;
            feed = new LoadFeed(splitContainer2.Panel2, user);
        }

        private void HomeScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}

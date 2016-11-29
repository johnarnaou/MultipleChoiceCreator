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
    public partial class HomeScreenJ : Form
    {
        public HomeScreenJ()
        {
            InitializeComponent();
            arnaouTesting();
        }

        private void arnaouTesting()
        {
            FeedPanel feedPanel = new FeedPanel();
            this.splitContainer2.Panel2.Controls.Add(feedPanel);
        }
    }
}

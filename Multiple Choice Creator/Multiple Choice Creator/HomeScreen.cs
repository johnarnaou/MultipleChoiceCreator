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
            splitContainer2.Panel2.AutoScroll = true;
            fill();
        }

        //testing
        private void fill()
        {
            Color c;
            for (var i=0; i<5; i++)
            {
                if (i % 2 == 0)
                    c = Color.LightBlue;
                else
                    c = Color.LightGray;
                this.splitContainer2.Panel2.Controls.Add(new FeedPanel(c));
            }
        }

    }
}

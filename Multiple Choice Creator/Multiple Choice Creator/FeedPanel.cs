using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    public partial class FeedPanel : UserControl
    {
        public FeedPanel(Color c)
        {
            InitializeComponent();
            this.BackColor = c;
            this.Dock = DockStyle.Top;
        }
    }
}

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
    public partial class ConfirmDelete : Form
    {
        private bool confirm = false;
        private LoadFeed feed;
        public ConfirmDelete(Object feed)
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.feed = (LoadFeed)feed;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            confirm = false;
            hideForm();
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            confirm = true;
            hideForm();
        }

        private void hideForm()
        {
            this.Dispose();
        }

        public bool getConfirm()
        {
            return confirm;
        }
    }
}

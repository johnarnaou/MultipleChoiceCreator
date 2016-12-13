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
        public ConfirmDelete()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            confirm = false;
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            confirm = true;
        }

        public bool getConfirm()
        {
            return confirm;
        }

        public bool getDontAskAgain()
        {
            return dontAskCheckBox.Checked;
        }
    }
}

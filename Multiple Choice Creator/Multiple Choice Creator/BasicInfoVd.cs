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
    public partial class BasicInfoVd : Form
    {
        public BasicInfoVd()
        {
            InitializeComponent();
        }
        //sto open elegxw an einai anoixth h main form (poy panda tha einai) kai an nai anoigw th public methodo pou anoigei thn create Project
        private void button1_Click(object sender, EventArgs e)
        {
            if (System.Windows.Forms.Application.OpenForms["StartPageVdiamant"] != null)
            {
                (System.Windows.Forms.Application.OpenForms["StartPageVdiamant"] as StartPageVdiamant).CreateFromEverywhere();
            }
        }
    }
}

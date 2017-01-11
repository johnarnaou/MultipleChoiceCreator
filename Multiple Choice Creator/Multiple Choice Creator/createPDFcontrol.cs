using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Model;

namespace Multiple_Choice_Creator
{
    public partial class createPDFcontrol : UserControl
    {
        Panel pan;
        CreateTestControl createTC;
        public createPDFcontrol(User usr, CreateTestControl myCreateTC)
        {
            InitializeComponent();
            createTC = myCreateTC;
            this.Dock = DockStyle.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createTC.createPDF();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

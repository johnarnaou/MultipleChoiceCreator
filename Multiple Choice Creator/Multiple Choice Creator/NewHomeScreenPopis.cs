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
    public partial class NewHomeScreen_Popis_ : Form
    {
        public NewHomeScreen_Popis_()
        {
            InitializeComponent();
        }
        int startWidthPanel3;
       int startWidthPanel2;
        int start;
        Point loc;
        // ta panel einai to provlima, otan sou vgazei kokkino apo katw simainei oti kati den paei kala. checkare to error
        private void button1_Click(object sender, EventArgs e)
        {
            
            start = panel3.Left;
            startWidthPanel3 = panel3.Width;
            startWidthPanel2 = panel2.Width; //auta kathe fora pou patas to koumpi xalane, gia auto
            //test
            if (button1.Text == "<"){
                loc = panel3.Location; //edw eprepe na mpei
                panel2.Visible = false;
                panel3.Left = 0;
                button1.Text = ">";
               // button1.Left = 0;
            }
            else
            {
                panel2.Visible = true;
                panel3.Location = loc;
                button1.Text = "<";
                
            }
        }

        private void NewHomeScreen_Popis__Load(object sender, EventArgs e)
        {

        }
    }
}

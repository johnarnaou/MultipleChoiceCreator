using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    

    class CreateTest
    {
        Panel panel=new Panel();
        CreateTestControl createtestcontrol;
        public CreateTest(Panel myPanel)
        {
            createtestcontrol = new CreateTestControl();
            this.panel = myPanel;
            this.panel.Controls.Add(createtestcontrol);
            
        }
        public CreateTestControl getCTC()
        {
            return this.createtestcontrol;
        }
    }
}

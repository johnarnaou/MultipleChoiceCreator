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
        Panel panel;
        CreateTestControl createtestcontrol = new CreateTestControl();
        public CreateTest(Panel myPanel)
        {
            this.panel = myPanel;
            this.panel.Controls.Add(createtestcontrol);
        }
    }
}

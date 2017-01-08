using Multiple_Choice_Creator.Model;
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
        User myUser;
        public CreateTest(Panel myPanel,User usr)
        {
            myUser = usr;
            createtestcontrol = new CreateTestControl(myUser);
            this.panel = myPanel;
            this.panel.Controls.Add(createtestcontrol);
            
        }
        public CreateTestControl getCTC()
        {
            return this.createtestcontrol;
        }
    }
}

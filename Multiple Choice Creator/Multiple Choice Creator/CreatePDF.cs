using Multiple_Choice_Creator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    class CreatePDF
    {
        createPDFcontrol crPDFcon;
        
        FlowLayoutPanel fpanel = new FlowLayoutPanel();
        createPDFcontrol createPDFcontrol;
        User myUser;
        CreateTestControl myCreateTestControl;
        public CreatePDF(FlowLayoutPanel myfPanel, User usr,CreateTestControl ctr)
        {
            myUser = usr;
            myCreateTestControl = ctr;
            createPDFcontrol = new createPDFcontrol(myUser, ctr);
            this.fpanel = myfPanel;
            this.fpanel.Controls.Add(createPDFcontrol);

        }





    }
}

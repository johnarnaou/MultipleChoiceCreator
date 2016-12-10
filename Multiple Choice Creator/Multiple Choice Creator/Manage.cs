using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Model;

namespace Multiple_Choice_Creator
{
    class Manage
    {
        Panel panel;
        User user;
        Insert management;
        public Manage(User user, Panel panel) {
            this.user = user;
            this.management = new Insert(user);
            this.panel = panel;
            panel.Controls.Add(management);
        }

    }
}

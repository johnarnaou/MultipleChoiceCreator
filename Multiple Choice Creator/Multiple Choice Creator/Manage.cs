using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Model;
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using System.Data;
using static Multiple_Choice_Creator.mltChoiceDataSet;
namespace Multiple_Choice_Creator
{
    class Manage
    {
        Panel panel;
        User user;
        Insert management;
        public Manage(User user, Panel panel,LoadFeed curfeed)
        {
            this.user = user;
            this.management = new Insert(user,curfeed);
            this.panel = panel;
            panel.Controls.Add(management);
        }
    }
}
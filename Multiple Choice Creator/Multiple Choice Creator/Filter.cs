using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    

    public class Filter
    {
        public int ID { get; set; }
        List<String> treeViewTopics = new List<String>();
        Panel panel;
        Filters myFilters;
        public Filter(Panel myPanel)
        {
            myFilters = new Filters();
            this.panel = myPanel;
            this.panel.Controls.Add(myFilters);
        }

        public Filters getFilters()
        {
            return myFilters;
        }
        
    }

    

    
}

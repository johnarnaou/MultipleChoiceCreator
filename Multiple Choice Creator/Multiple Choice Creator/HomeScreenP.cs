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
    public partial class HomeScreenP : Form
    {
        public HomeScreenP()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            fillTreeView();

        }
        private void fillTreeView() {
            DaoMysql tempbob = new DaoMysql();
            List<Theme> myList = tempbob.returnThemeTree();
            themeTree myListThemeTree = new themeTree(myList);
            myListThemeTree.printKids(0, treeView1);
        }
    }
}

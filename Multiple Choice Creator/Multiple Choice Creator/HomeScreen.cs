using Multiple_Choice_Creator.Model;
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
    public partial class HomeScreen : Form
    {
        LoadFeed feed;
        Manage manage;
        public HomeScreen(User user)
        {
            InitializeComponent();
            fillTreeView();
            feed = new LoadFeed(splitContainer3.Panel2, user);
            splitContainer3.Panel2.AutoScroll = true;
            feed.load();
            manage = new Manage(user,splitContainer3.Panel1,feed);
            
            
        }


        private void fillTreeView()
        {
            DaoMysql dMsql = new DaoMysql();
            List<Topic> topicList = dMsql.returnThemeTree();
            themeTree myThemeTree = new themeTree(topicList);
            myThemeTree.printKids(0, treeView1);



        }

        private void HomeScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void splitContainer3_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

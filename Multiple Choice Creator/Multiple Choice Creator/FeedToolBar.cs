using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.mltChoiceDataSetTableAdapters;
using Multiple_Choice_Creator.Model;

namespace Multiple_Choice_Creator
{
    public partial class FeedToolBar : UserControl
    {
        LoadFeed feed;
        Panel panel;
        bool found;
        public FeedToolBar(Panel p, User user)
        {
            InitializeComponent();
            this.BringToFront();
            this.Dock = DockStyle.Top;
            panel = p;
            HomeButton.Visible = false;
        }

        public void setFeed(Object feed)
        {
            this.feed = (LoadFeed)feed;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            HomeButton.Visible = true;

            string keyword = searchTextBox.Text;
            QuestTableAdapter myAdapter = new QuestTableAdapter();
            DataTable data = myAdapter.getsearchQuestionByID("%" + keyword + "%");

            Color c =  new Color();

            int num = (int)myAdapter.getNumberOfSearchResults("%" + keyword + "%");

            if (num == 0)
            {
                feed.NoFeed("Question not found using keyword: " + keyword);
                found = false;
            }
            else
            {
                found = true;
                for (int i = 0; i < num; i++)
                {
                    if (i % 2 == 0)
                        c = Color.LightBlue;
                    else
                        c = Color.LightGray;
                    feed.search((int)data.Rows[i][0], c);
                }
            }
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            if (found)
                feed.controlsDispose();
            else
                feed.NoFeedControlDispose();
            feed.load();
            HomeButton.Visible = false;
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchButton_Click(sender, e);

        }
    }
}

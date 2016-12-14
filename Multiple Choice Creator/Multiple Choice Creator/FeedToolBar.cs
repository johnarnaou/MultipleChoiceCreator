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
using System.Diagnostics;

namespace Multiple_Choice_Creator
{
    public partial class FeedToolBar : UserControl
    {
        LoadFeed feed;
        Panel panel;
        bool found, noFeedWasLoaded, shrinkMode = false;
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
            if (noFeedWasLoaded)
            {
                feed.NoFeedControlDispose();
                noFeedWasLoaded = false;
            }
            HomeButton.Visible = true;
            string keyword = searchTextBox.Text;
            QuestTableAdapter myAdapter = new QuestTableAdapter();
            DataTable data = myAdapter.getsearchQuestionByID("%" + keyword + "%");

            int num = (int)myAdapter.getNumberOfSearchResults("%" + keyword + "%");

            if (num == 0)
            {
                feed.NoFeed("Question not found using keyword: " + keyword);
                found = false;
                ShrinkButton.Visible = false;
                ExpandButton.Visible = false;
            }
            else
            {
                found = true;
                feed.fillSearch(data, num);
                feed.shrinkExpand(shrinkMode);
            }
            

        }

        public void setNoFeedWasLoaded(bool noFeedWasLoaded)
        {
            this.noFeedWasLoaded = noFeedWasLoaded;
        }
        private void HomeButton_Click(object sender, EventArgs e)
        {
            if (found)
                feed.controlsDispose();
            else
                feed.NoFeedControlDispose();
            feed.load();
            HomeButton.Visible = false;
            this.searchTextBox.Text = "";
        }

        private void ExpandButton_Click(object sender, EventArgs e)
        {
            ShrinkButton_Click(sender, e);
        }

        private void ShrinkButton_Click(object sender, EventArgs e)
        {
            if (shrinkMode)
            {
                shrinkMode = false;
                ShrinkButton.Visible = true;
                ExpandButton.Visible = false;
            }
            else
            {
                shrinkMode = true;
                ExpandButton.Visible = true;
                ShrinkButton.Visible = false;
            }
            feed.shrinkExpand(shrinkMode);
        }

        private void searchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                searchButton_Click(sender, e);
        }
    }
}

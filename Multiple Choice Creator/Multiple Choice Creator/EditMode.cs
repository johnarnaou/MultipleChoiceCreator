using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Multiple_Choice_Creator.Model;
using static Multiple_Choice_Creator.mltChoiceDataSet;

namespace Multiple_Choice_Creator
{
    public partial class EditMode : UserControl
    {
        Question q;
        AnswDataTable answers;
        FeedPanel panel;
        string diff;
        public EditMode(Question q, AnswDataTable answers, FeedPanel panel)
        {
            InitializeComponent();
            this.q = q;
            this.answers = answers;
            this.panel = panel;
            this.Dock = DockStyle.Fill;
            diff = q.getDifficulty();
            loadInfo();
        }

        public void loadInfo()
        {
            questRichTextBox.Text = q.getText();
            answDataGridView.DataSource = answers;
            answDataGridView.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            if(diff == "Easy")
            {
                diffTrackBar.Value = 0;
            }
            else if (diff == "Medium")
            {
                diffTrackBar.Value = 1;
            }
            else if(diff == "Hard")
            {
                diffTrackBar.Value = 2;
            }
            diffLabel.Text = diff;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            panel.showInsert();
            this.Dispose();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }
    }
}

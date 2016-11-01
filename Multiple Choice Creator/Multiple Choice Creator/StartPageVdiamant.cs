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
    public partial class StartPageVdiamant : Form
    {
        public StartPageVdiamant()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            //this.AutoSize = true;
            //this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.startingWithForm();
            showLogin();
            this.Tag = "Main";

        }
        
        private void showLogin()
        {
            Form loginForm = new Login();
            loginForm.Tag = "hidden";
            loginForm.Parent = null;
            loginForm.ShowDialog();

        }

        BasicInfoVd bskInfoForm;
        private void startingWithForm()
        {
            if (bskInfoForm == null)//elegxos gia to an einai hdh anoixth h forma
            {
                bskInfoForm = new BasicInfoVd();
                bskInfoForm.MdiParent = this;
                bskInfoForm.Tag = "mdi_child";
                bskInfoForm.FormClosed += new FormClosedEventHandler(BasicInfoVD_FormClosed);
                bskInfoForm.Location = new Point(0, 0);
                bskInfoForm.Show();
            }
            else
                bskInfoForm.Activate();//an einai anoixth thn kanei focus se periptwsh pou einai sto background
        }

        private void BasicInfoVD_FormClosed(object sender, FormClosedEventArgs e)
        {
            bskInfoForm = null;
        }

        CreateProjectVD createPrForm; //dhmiourgoume anafora ths formas Create project

        //Auth h function einai gia na anoigei apo opoiadhpote klash h create project
        public void CreateFromEverywhere()
        {
            if (createPrForm == null)//elegxos gia to an einai hdh anoixth h forma
            {
                createPrForm = new CreateProjectVD();
                createPrForm.MdiParent = this;
                createPrForm.Tag = "mdi_child";
                createPrForm.FormClosed += new FormClosedEventHandler(createPr_FormClosed);
                createPrForm.Show();
            }
            else
                createPrForm.Activate();//an einai anoixth thn kanei focus se periptwsh pou einai sto background


        }



        private void newToolStripMenuItem_Click(object sender, EventArgs e) 
        {
            CreateFromEverywhere();
        }

        private void createPr_FormClosed(object sender, FormClosedEventArgs e)//otan kleinoume th forma kanoume thn anafora ish me null gia na mporoume na thn ksanaanoiksoume
        {
            createPrForm = null;
        }
        InsertQuestion insertQForm;
        private void insertQuestionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (insertQForm == null)//elegxos gia to an einai hdh anoixth h forma
            {
                insertQForm = new InsertQuestion();
                insertQForm.MdiParent = this;
                insertQForm.Tag = "mdi_child";
                insertQForm.FormClosed += new FormClosedEventHandler(insertQForm_FormClosed);
                insertQForm.Show();
            }
            else
                insertQForm.Activate();//an einai anoixth thn kanei focus se periptwsh pou einai sto background
        }

        private void insertQForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            insertQForm = null;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Tag.ToString() == "Main" || frm.Tag.ToString()== "hidden")
                {
                    continue;
                }
                else
                    frm.Close();
            }
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void arrangeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void StartPageVdiamant_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure that you want to close the window?","Close",MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                e.Cancel=true;
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showLogin();
        }
        Register signUp;
        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (signUp==null) {
                signUp = new Register();
            }
            signUp.Show();
        }
    }
}

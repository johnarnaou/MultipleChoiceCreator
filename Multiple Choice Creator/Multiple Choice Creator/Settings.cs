﻿using System;
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
    public partial class Settings : Form
    {
        private bool check;
        public Settings(bool check)
        {
            InitializeComponent();
            this.check = check;
            AskBeforeDeleteCheckBox.Checked = check;
        }
    }
}

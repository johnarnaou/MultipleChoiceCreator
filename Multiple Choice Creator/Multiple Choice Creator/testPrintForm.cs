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
    public partial class testPrintForm : Form

    {
        CreateTest createTest;
        public testPrintForm()
        {
            InitializeComponent();
            createTest = new CreateTest(panel2);
            
        }
    }
}

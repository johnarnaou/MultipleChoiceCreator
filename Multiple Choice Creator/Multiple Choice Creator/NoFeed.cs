﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Multiple_Choice_Creator
{
    public partial class NoFeed : UserControl
    {
        public NoFeed(string text)
        {
            InitializeComponent();
            label1.Text = text;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registration Reg = new Registration();
            Reg.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Choose Choose = new Choose();
            Choose.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Authorization log = new Authorization();
            log.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

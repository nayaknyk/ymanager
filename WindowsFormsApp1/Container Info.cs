﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class container : Form
    {
        char col;
        int row;
        string yard;
        public container(string yard1, char col1, int row1)
        {
            InitializeComponent();
            col = col1;
            row = row1;
            yard = yard1;

            StringBuilder sb2 = new StringBuilder(label11.Text);
            sb2.Append(yard.ToString());
            label11.Text = sb2.ToString();

            StringBuilder sb = new StringBuilder(label9.Text);
            sb.Append(col.ToString());
            label9.Text = sb.ToString();

            StringBuilder sb1 = new StringBuilder(label10.Text);
            sb1.Append(row.ToString());
            label10.Text = sb1.ToString();
        }

        private void container_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       private void label9_Click(object sender, EventArgs e)
        {
        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}

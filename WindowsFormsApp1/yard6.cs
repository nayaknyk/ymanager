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
    public partial class yard6 : Form
    {
        public yard6()
        {
            InitializeComponent();
        }

        string yard = "EXIM,COASTAL";
        int yardid = 6;
        private void button1_Click(object sender, EventArgs e)
        {
            char col = 'A';
            int row = 1;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            char col = 'A';
            int row = 2;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            char col = 'A';
            int row = 3;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            char col = 'A';
            int row = 4;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            char col = 'B';
            int row = 1;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            char col = 'B';
            int row = 2;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            char col = 'B';
            int row = 3;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            char col = 'B';
            int row = 4;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            char col = 'C';
            int row = 1;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            char col = 'C';
            int row = 2;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            char col = 'C';
            int row = 3;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            char col = 'C';
            int row = 4;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            char col = 'D';
            int row = 1;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            char col = 'D';
            int row = 2;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            char col = 'D';
            int row = 3;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            char col = 'D';
            int row = 4;
            container c = new container(yard, col, row, yardid);
            this.Hide();
            c.ShowDialog();
        }
    }
}

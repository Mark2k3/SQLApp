﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLApp
{
    public partial class FormMain : Form
    {
        Point lastPoint;
        public FormMain()
        {
            InitializeComponent();
        }

        private void labelXReg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelXReg_MouseEnter(object sender, EventArgs e)
        {
            labelX.ForeColor = Color.Green;
        }

        private void labelXReg_MouseLeave(object sender, EventArgs e)
        {
            labelX.ForeColor = Color.White;

        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }
    }
}

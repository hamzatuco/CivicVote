using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.OleDb;
using System.Diagnostics;

namespace Zadaca
{
    public partial class dash : Form
    {


        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn
    (
        int nLeftRect,
        int nTopRect,
        int nRightRect,
        int nBottomRect,
        int nWidthEllipse,
        int nHeightEllipse
    );

        public dash()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 25, 25));
            label4.Text = Login.user;
            label2.Text = Login.user;

            label1.Text = registar.ime1;
            
        }


        


        private void dugmeDash_Click(object sender, EventArgs e)
        {
            malaNav.Height = dugmeDash.Height;
            malaNav.Top = dugmeDash.Top;
            malaNav.Left = dugmeDash.Left;
            dugmeDash.BackColor = Color.FromArgb(46,51,73);
            this.panel5.Hide();
            this.label3.Show();
            this.label4.Show();
            this.label8.Show();
            this.label5.Show();
            this.label6.Show();
            this.label7.Show();
            this.panel1.Show();
            this.panel3.Show();
            this.panel4.Show();
            this.label9.Show();
            this.pictureBox2.Show();
        }

        private void dugmeStatistika_Click(object sender, EventArgs e)
        {
            malaNav.Height = dugmeStatistika.Height;
            malaNav.Top = dugmeStatistika.Top;
            dugmeStatistika.BackColor = Color.FromArgb(46, 51, 73);
            this.label3.Hide();
            this.label4.Hide();
            this.label8.Hide();
            this.label5.Hide();
            this.label6.Hide();
            this.label7.Hide();
            this.panel1.Hide();
            this.panel3.Hide();
            this.panel4.Hide();
            this.label9.Hide();
            this.pictureBox2.Hide();
            this.panel5.Show();
        }

        private void dugmeIgrice_Click(object sender, EventArgs e)
        {
            malaNav.Height = dugmeIgrice.Height;
            malaNav.Top = dugmeIgrice.Top;
            dugmeIgrice.BackColor = Color.FromArgb(46, 51, 73);
            this.label3.Hide();
            this.label4.Hide();
            this.label8.Hide();
            this.label5.Hide();
            this.label6.Hide();
            this.label7.Hide();
            this.panel1.Hide();
            this.panel3.Hide();
            this.panel4.Hide();
            this.label9.Hide();
            this.pictureBox2.Hide();
            this.panel5.Show();
        }

        private void dugmePomoc_Click(object sender, EventArgs e)
        {
            malaNav.Height = dugmePomoc.Height;
            malaNav.Top = dugmePomoc.Top;
            dugmePomoc.BackColor = Color.FromArgb(46, 51, 73);
            this.label3.Hide();
            this.label4.Hide();
            this.label8.Hide();
            this.label5.Hide();
            this.label6.Hide();
            this.label7.Hide();
            this.panel1.Hide();
            this.panel3.Hide();
            this.panel4.Hide();
            this.label9.Hide();
            this.pictureBox2.Hide();
            this.panel5.Show();
        }

        private void dugmePostavke_Click(object sender, EventArgs e)
        {
            malaNav.Height = dugmePostavke.Height;
            malaNav.Top = dugmePostavke.Top;
            dugmePostavke.BackColor = Color.FromArgb(46, 51, 73);
            this.label3.Hide();
            this.label4.Hide();
            this.label8.Hide();
            this.label5.Hide();
            this.label6.Hide();
            this.label7.Hide();
            this.panel1.Hide();
            this.panel3.Hide();
            this.panel4.Hide();
            this.label9.Hide();
            this.pictureBox2.Hide();
            this.panel5.Show();
        }

        private void dugmeDash_Leave(object sender, EventArgs e)
        {
            dugmeDash.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void dugmeStatistika_Leave(object sender, EventArgs e)
        {
            dugmeStatistika.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void dugmeIgrice_Leave(object sender, EventArgs e)
        {
            dugmeIgrice.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void dugmePomoc_Leave(object sender, EventArgs e)
        {
            dugmePomoc.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void dugmePostavke_Leave(object sender, EventArgs e)
        {
            dugmePostavke.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private static readonly Stopwatch sat = new Stopwatch();
        private void dash_Load(object sender, EventArgs e)
        {
            sat.Start();
            this.panel5.Hide();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label8.Text = string.Format("{0:hh\\:mm\\:ss}",sat.Elapsed);
        }

        
    }
    }

        
    


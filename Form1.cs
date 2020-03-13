using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication2 {
    public partial class Form1 : Form {
        /* VARIABLES */
        bool jump = false;
        int force = 0, jumpSpeed = 12 , score=0;
        /* CODE */ 
        public Form1() {
            InitializeComponent();
        }
        private void keyisdown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Space && jump==false) {
                jump = true;
            }
        }

        private void keyisup(object sender, KeyEventArgs e) {
            if (jump) {
                jump = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            money();
            obstacles();
            player.Top += jumpSpeed;
            if (jump && force < 0) {
                jump = false;
            }

           
            if (jump)
            {
                jumpSpeed =-25;
                force -= 1;
            }
            else {
                jumpSpeed = 12;
            }
            foreach (Control x in this.Controls) {
                if (x is PictureBox && x.Tag == "platform") {
                    if (player.Bounds.IntersectsWith(x.Bounds) && !jump) {
                        force = 8;
                        player.Top = x.Top - player.Height;
                    }
                }
                if (x is PictureBox && x.Tag == "obstacle") {
                    if (player.Bounds.IntersectsWith(x.Bounds)) {
                        timer1.Stop();
                        MessageBox.Show("you suck!!!");
                    }
                }
            }
            if (player.Bounds.IntersectsWith(pictureBox5.Bounds)) {
                pictureBox5.Left = 920;
                score++;
                label1.Text = "SCORE" + " " + score.ToString();
            }
            if (player.Bounds.IntersectsWith(pictureBox6.Bounds)) {
                pictureBox6.Left = 960;
                score++;
                label1.Text = "SCORE" + " " + score.ToString();
            }

        }
        public void obstacles() {
            pictureBox1.Left -= 10;
            if (pictureBox1.Left <= 0) {
                pictureBox1.Left = 900;
            }
            pictureBox2.Left -= 10;
            if (pictureBox2.Left <= 0) {
                pictureBox2.Left = 900;
            }
            pictureBox3.Left -= 10;
            if (pictureBox3.Left <= 0) {
                pictureBox3.Left = 940;
            }
        }
        public void money() {
            pictureBox5.Left-=10;
            if (pictureBox5.Left <= 0) {
                pictureBox5.Left = 900;
            }
            pictureBox6.Left-=10;
            if (pictureBox6.Left <= 0) {
                pictureBox6.Left = 940;
            }
        }     
    }
}

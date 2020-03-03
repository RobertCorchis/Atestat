using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bird_shooter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Random r = new Random();
        int score = 0;
        int total_shots = 0;
        int miss_shot = 0;

        void shot_voice()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@"E:\Visual Studio Projects Robert Corchis 12A\bird shooter atestat Robert Corchis\shot.wav");
            player.Play();
            
        }
        void fn_shot()
        {
            score++;
            label1.Text = "Score=" + score;
            total_shots++;
            label3.Text = "Total Shots=" + total_shots;

            shot_voice();
        }
        void fn_miss_shot()
        {
            miss_shot++;
            label2.Text = "Missing shots=" + miss_shot;
            total_shots++;
            label3.Text = "Total Shots=" + total_shots;

            shot_voice();
        }

        void reset()
        {
            score = 0;
            miss_shot = 0;
            total_shots = 0;
            label2.Text = "Missing shots=" + miss_shot;
            label3.Text = "Total Shots=" + total_shots;
            label1.Text = "Score=" + score;
            timer1.Start();
            label4.Text = "";

        }
      
        private void Timer1_Tick(object sender, EventArgs e)
        {
            int x, y;
            x = r.Next(0, 500);
            y = r.Next(200, 330);
            pictureBox1.Location = new Point(x, y);
            if(miss_shot>=10)
            {
                timer1.Stop();
                label4.Text = "Game Over";
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            fn_shot();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            fn_miss_shot();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

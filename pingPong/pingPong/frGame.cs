﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;

namespace pingPong
{
    public partial class frGame : Form
    {
        public static bool soundEnabled = true;
        public static void enableSound()
        {
            soundEnabled = true;
        }
        public static void disableSound()
        {
            soundEnabled = false;
        }
        bool mustClose = false;
        DateTime tempoInicial;
        public static TimeSpan subTimes;

        public frGame()
        {
            Time.Setup();
            InitializeComponent();
            Time.InternalTimer.Tick += InternalTimer_Tick;
        }

        private void InternalTimer_Tick(object sender, EventArgs e)
        {
            if (pbYouWin.Bounds.IntersectsWith(player1.Bounds))
            {
                Cursor.Show();
                Cursor.Clip = Rectangle.Empty;
                Time.InternalTimer.Stop(); Time.BlinkTimer.Stop();
                frEndGame end = new frEndGame();
                DateTime tempoFinal = DateTime.Now;
                subTimes = tempoFinal.Subtract(tempoInicial);
                end.ShowDialog();
                this.Close();
            }
            if (mustClose) this.Close();
            if (player1.Bounds.IntersectsWith(pbCJappears.Bounds))
            {
                if(frGame.soundEnabled) playCJ();
                pbCJbolado.Visible = true;
            }
        }
        public static void playCJ()
        {
            SoundPlayer CJ = new SoundPlayer(pingPong.Properties.Resources.i_got_a_gun);
            CJ.Play();
        }

        public void frGame_Load(object sender, EventArgs e)
        {
            player1.Click += Player1_Click;
        }

        private void Player1_Click(object sender, EventArgs e)
        {
            if (!player1.Clicked)
                tempoInicial = DateTime.Now;
        }
    }
}

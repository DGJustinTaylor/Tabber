using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace Tabber
{
    public partial class frmChyron : Form
    {
        public Timer timerTextScroll;
        private int xPos = 0;
        private int yPos = 0;
        private int origX = 0;
        private int origY = 0;
        private int count = 0;
        public ArrayList texts = new ArrayList();

        public frmChyron()
        {
            InitializeComponent();
        }

        /*
        Target: frmChyron_Load - EventHandler
        Purpose: Initialize our important variables
        to save necessary values for later use
        Date: 6/25/2019
        Date-Last-Edited: 6/26/2019
        */
        private void frmChyron_Load(object sender, EventArgs e)
        {
            timerTextScroll = new Timer();
            timerTextScroll.Interval = 10;
            timerTextScroll.Tick += new EventHandler(TimerTextScrollElapsed);
            origX = lblChyronText.Location.X;
            origY = lblChyronText.Location.Y;
        }

        /*
        Target: frmChyron_Activated - EventHandler
        Purpose: Everytime the Chyron is activated we reset the
        position of the text, reset the actual text and restart the timer.
        Date: 6/26/2019
        Date-Last-Edited: 6/26/2019
        */
        private void frmChyron_Activated(object sender, EventArgs e)
        {
            count = 0;
            xPos = origX;
            yPos = origY;
            timerTextScroll.Start();
            lblChyronText.Text = texts[count].ToString();
        }

        /*
        Target: TimerTextScrollElapsed - EventHandler
        Purpose: Controls the movement of the text, and the iteration
        of the array which changes the text that is being shown.
        Date: 6/25/2019
        Date-Last-Edited: 6/27/2019
        */
        private void TimerTextScrollElapsed(object sender, EventArgs e)
        {
            int minLeft = this.lblChyronText.Width * -1;

            if (xPos <= minLeft)
            {
                xPos = this.Width;
                 
                if(count >= texts.Count - 1)
                {
                    count = 0;
                }
                else
                {
                    count++;
                }

                lblChyronText.Text = texts[count].ToString();
            }
            this.lblChyronText.Location = new Point(xPos, yPos);
            xPos -= 2;
        }
    }
}

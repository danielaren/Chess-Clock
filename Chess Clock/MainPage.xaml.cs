using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.Windows.Threading;

namespace Chess_Clock
{
    public partial class MainPage : PhoneApplicationPage
    {
        private int stopTime1 = 10;
        private int stopTime2 = 10;
        private int startTime1 = 0;
        private int startTime2 = 0;
        private int lastTime1 = 0;
        private int lastTime2 = 0;
        private bool firstPlayer = true;
        DispatcherTimer timer1 = new DispatcherTimer();
        DispatcherTimer timer2 = new DispatcherTimer();

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            InitiateClock();
        }

        private void InitiateClock()
        {
            timer1.Tick += time_Tick;
            timer2.Tick += time_Tick;
            timer1.Interval = TimeSpan.FromSeconds(1);
            timer2.Interval = TimeSpan.FromSeconds(1);
            lastTime1 = startTime1;
            lastTime2 = startTime2;
            if (firstPlayer)
            {
                timer1.Start();
                
            }
        }

        void time_Tick(object sender, object e)
        {
            if (firstPlayer)
            {
                textBlockTimerPlayer1.Text = (10 - lastTime1).ToString();
                lastTime1++;

                if (lastTime1 > stopTime1)
                {
                    timer1.Stop();
                    hyperlinkButtonDone.Content = "Player 2 Won!";
                }
            }
            else
            {
                textBlockTimerPlayer2.Text = (10 - lastTime2).ToString();
                lastTime2++;

                if (lastTime2 > stopTime2)
                {
                    timer2.Stop();
                    hyperlinkButtonDone.Content = "Player 1 Won!";
                }
            }
            
        }

        private void hyperlinkButtonDone_Click(object sender, RoutedEventArgs e)
        {
            if (firstPlayer)
            {
                timer1.Stop();
                timer2.Start();
                firstPlayer = false;
            }
            else
            {
                timer2.Stop();
                timer1.Start();
                firstPlayer = true;
            }
        }
    }
}
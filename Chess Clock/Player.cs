﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Chess_Clock
{
    public class Player 
    {
        private string name;
        
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int startTime;

        public int StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        private int stopTime;

        public int StopTime
        {
            get { return stopTime; }
            set { stopTime = value; }
        }

        private int lastTime;

        public int LastTime
        {
            get { return lastTime; }
            set { lastTime = value; }
        }

        public DispatcherTimer timer;

        public Player()
        {
            startTime = 0;
            stopTime = 10;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
        }
        
    }
}

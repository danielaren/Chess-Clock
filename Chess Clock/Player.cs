using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chess_Clock
{
    public class Player : ClockTime
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
        
        
        
    }
}

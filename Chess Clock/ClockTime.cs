using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace Chess_Clock
{
    public class ClockTime
    {
        private DispatcherTimer time;

        public DispatcherTimer Time
        {
            get { return time; }
            set { time = value; }
        }

    }
}

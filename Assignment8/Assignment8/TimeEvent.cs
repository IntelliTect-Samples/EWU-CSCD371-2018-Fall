using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    public class TimeEvent
    {
        private string _timeElapsed { get; set; }

        public string Description { get; }

        public TimeEvent(string elapsedTime, string description)
        {
            _timeElapsed = elapsedTime;
            Description = description;
        }

        public override string ToString()
        {
            return _timeElapsed;
        }
    }
}

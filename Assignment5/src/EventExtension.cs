using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public static class EventExtension
    {
        
        //Extension method
        public static int timeLengthOfEvent(this IEvent thisEvent)
        {
            return Math.Abs(thisEvent.EndHour - thisEvent.StartHour);
        }
    }
}
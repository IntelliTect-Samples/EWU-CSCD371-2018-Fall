using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCourseWork
{
    public class Event
    {
        public string Event_Schedule = "ColumbusDay.Monday.11AM"
           + "Thanksgiving.Thursday.2PM"
           + "Christmas.Wednesday.10AM"
           + "Easter.Sunday.8AM";

        public string GetSummaryInformation()
        {
            return Event_Schedule;
        }
    }
}

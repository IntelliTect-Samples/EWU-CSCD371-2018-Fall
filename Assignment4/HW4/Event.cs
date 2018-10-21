using System;
using System.Collections.Generic;
using System.Text;

namespace HW4
{
    public class Event : UniversityCalender
    {

        public Event(String name, String location, String startDate)
        {
            Name = name;
            Location = location;
            StartDate = startDate;
            incTotalCalendarItems();
        }
        
        public override string Display()
        {
            return GetSummaryInformation();
        }

        public string GetSummaryInformation()
        {
            return "EVENT: " + Name + "| " + Location + "| " + StartDate;
        }

        
    }
}

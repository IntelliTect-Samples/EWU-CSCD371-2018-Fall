using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    public class Event : UniversityCalender , IEvent 
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

        public void RoomsRescourseValidator()
        {
            System.Console.WriteLine("Rooms resouces verified for the \"" +  Name + "\" event, no scheduling conficts.");
        }


    }
}

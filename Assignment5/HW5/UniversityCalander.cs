using System;
using System.Collections.Generic;
using System.Text;

namespace HW5
{
    public abstract class UniversityCalender
    {
        public static int TotalCalendarItems = 0; //inc this total from within the course and event constructors
        public string Location { get; set; }
        public string StartDate { get; set; }
        public string Name { get; set; }

        public abstract string Display();     
        
        public void incTotalCalendarItems()
        {
            TotalCalendarItems++;
        }

        public int getTotalCalendarItems()
        {
            return TotalCalendarItems;
        }

        public void setTotalCalendarItems(int num)
        {
            TotalCalendarItems = num;
        }
    }
}

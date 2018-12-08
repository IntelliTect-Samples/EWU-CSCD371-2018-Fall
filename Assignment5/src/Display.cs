using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public static class DisplayClass
    {
        public static string Display(Object e) 
        {
            switch (e)
            {
                case Course course:
                    return course.GetSummaryInformation();
                case Event eventTemp:
                    return eventTemp.GetSummaryInformation();
                case null:
                    throw new ArgumentNullException("Cannot display a null object");
                default:
                    return e.ToString();
            }
        }

        public static string DisplayList(List<Event> list)
        {
            StringBuilder totalSummary = new StringBuilder();
            foreach (Event e in list)
            {
                totalSummary.Append(Display(e));
            }
            return totalSummary.ToString();
        }
    }
}
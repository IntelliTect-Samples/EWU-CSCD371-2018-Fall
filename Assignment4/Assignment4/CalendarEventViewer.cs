using System;
using System.IO;

namespace Assignment4
{
    public static class CalendarEventViewer
    {
        public static string Display(Object toDisplay)
        {
            switch (toDisplay)
            {
                 case Event toUse:
                     return toUse.GetSummaryInformation();
                 default:
                     return toDisplay.ToString();
            }
        }
    }
}
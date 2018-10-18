using System;
using System.IO;

namespace Assignment4
{
    public static class CalendarEventViewer
    {
        public static string Display(Object toDisplay)
        {
            if (! (toDisplay is Event))
            {
                throw new InvalidDataException("Object must be a type of Event!");
            }

            switch (toDisplay)
            {
                 case UniversityCourse toUse:
                     return toUse.GetSummaryInformation();
                 case Event toUse:
                     return toUse.GetSummaryInformation();
                 default:
                     return toDisplay.ToString();
            }
        }
    }
}
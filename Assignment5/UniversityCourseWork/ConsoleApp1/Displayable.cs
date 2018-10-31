using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public static class Displayable
    {

        public static string Display(Object displayableObject)
        {
            switch (displayableObject)
            {
                case Event temp:
                    return temp.GetSummaryInformation();
                default:
                    return displayableObject.ToString();
            }
        }
    }
}

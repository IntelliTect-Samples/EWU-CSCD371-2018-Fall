using System;

namespace UniversityCourseWork
{
    public class UniversityCourse
    {

        public string Course_Schedule = "Algebra.Monday.8AM"
            + "Calculus.Tuesday.10AM"
            + "Geometry.Wednesday.11AM"
            + "Statistics.Thursday.2PM";

        public string GetSummaryInformation()
        {
            return Course_Schedule;
        }
    }
}

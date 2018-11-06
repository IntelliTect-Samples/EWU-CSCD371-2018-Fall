using System;

namespace UniversityCourse.@event
{
    public interface IEvent
    {
        string GetSummaryInformation();
        string GetName();
        DateTime GetStartDate();
        DateTime GetEndDate();
        
    }
}
using System;

namespace UniversityCourse
{
    public interface IEvent
    {
        string GetSummaryInformation();
        string GetName();
        DateTime GetStartDate();
        DateTime GetEndDate();
        
    }
}
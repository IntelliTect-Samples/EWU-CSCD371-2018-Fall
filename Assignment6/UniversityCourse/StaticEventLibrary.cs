using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCourse
{
    public static class StaticEventLibrary
    {
        public static string Display(object @object)
        {
            switch (@object)
            {
                case UniversityCourse course:
                    return course.GetSummaryInformation();
                case Event @event:
                    return @event.GetSummaryInformation();
                case null:
                    throw new ArgumentNullException("Event is null", nameof(@object));
                default:
                    return @object.ToString();
            }
        }
    }
}

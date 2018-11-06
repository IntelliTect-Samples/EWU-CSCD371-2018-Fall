namespace UniversityCourse.@event
{
    public static class EventExtension
    {
        public static double GetLength(this IEvent myIEvent)
        {
            return myIEvent.GetEndDate().Hour - myIEvent.GetStartDate().Hour + 
                   (myIEvent.GetEndDate().Minute - myIEvent.GetStartDate().Minute) / 60.0;
        }
    }
}
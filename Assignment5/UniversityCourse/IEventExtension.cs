namespace UniversityCourse
{
    public static class IEventExtension
    {
        public static double GetLength(this IEvent myIEvent)
        {
            return myIEvent.GetEndDate().Hour - myIEvent.GetStartDate().Hour + 
                   (myIEvent.GetEndDate().Minute - myIEvent.GetStartDate().Minute) / 60.0;
        }
    }
}
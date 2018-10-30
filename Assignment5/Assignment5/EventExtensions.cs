namespace Assignment5
{
    public static class EventExtensions
    {
        public static int GetHourRangeOfEvent(this IEvent toUse)
        {
            return toUse.GetEndingHour() - toUse.GetStartingHour();
        }
    }
}
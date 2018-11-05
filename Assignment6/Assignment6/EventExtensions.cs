namespace Assignment6
{
    public static class EventExtensions
    {
        public static int GetHourRangeOfEvent(this IEvent toUse)
        {
            return toUse.GetEndingHour() - toUse.GetStartingHour();
        }
    }
}
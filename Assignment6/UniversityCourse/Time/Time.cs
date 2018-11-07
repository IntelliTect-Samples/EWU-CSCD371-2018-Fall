
namespace UniversityCourse.Time
{
    public struct Time
    {
        public Time(int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public int Hour { get; private set; }

        public int Minute { get; private set; }

        public int Second { get; private set; }
    }
}
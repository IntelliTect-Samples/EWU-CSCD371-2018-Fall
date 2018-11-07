
namespace UniversityCourse.Scheduling 
{
    public readonly struct Time
    {
        public Time(byte hour, byte minute, byte second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public byte Hour { get; }

        public byte Minute { get; }

        public byte Second { get; }
    }
}
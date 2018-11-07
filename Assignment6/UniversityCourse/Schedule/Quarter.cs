using System;

namespace UniversityCourse.Schedule
{
    [Flags]
    public enum Quarter
    {
        Winter = 1 << 0,
        Spring = 1 << 1,
        Summer = 1 << 2,
        Fall = 1 << 3
    }
}
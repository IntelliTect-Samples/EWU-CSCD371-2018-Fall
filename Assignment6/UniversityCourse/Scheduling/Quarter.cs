using System;

namespace UniversityCourse.Scheduling 
{
    [Flags]
    public enum Quarter : byte
    {
        Winter = 1 << 0,
        Spring = 1 << 1,
        Summer = 1 << 2,
        Fall = 1 << 3
    }
}
using System;

namespace Assignment6
{
    public readonly struct Time
    {
        public readonly byte hour;
        public readonly byte minute;
        public readonly int second;

        public Time(byte hour, byte minute, byte second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
    }
}
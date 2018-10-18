using System;

namespace Assignment4
{
    public class Event
    {
        public static int courseCount { get; private set; }

        public Event()
        {
            courseCount++;
        }
    }
}
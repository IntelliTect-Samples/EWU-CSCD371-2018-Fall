using System;

namespace Assignment8
{
    public class TimeEventArgs : EventArgs
    {
        public TimeEventArgs(string elapsedTime)
        {
            ElapsedTime = elapsedTime;
        }
        public string ElapsedTime { get; set; }
    }
}
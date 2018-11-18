using System;

namespace Assignment8
{
    /// <summary>
    /// TimeEventArgs are used to carry the elapsed time as event args, whenever a new time record is complete
    /// </summary>
    public class TimeEventArgs : EventArgs
    {
        public TimeEventArgs(string elapsedTime)
        {
            ElapsedTime = elapsedTime;
        }
        public string ElapsedTime { get; set; }
    }
}
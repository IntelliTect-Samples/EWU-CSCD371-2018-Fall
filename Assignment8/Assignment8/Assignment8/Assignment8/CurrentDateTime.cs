using System;

namespace Assignment8
{
    public class CurrentDateTime : IDateTime
    {
        public DateTime GetNow() => DateTime.Now;
    }
}
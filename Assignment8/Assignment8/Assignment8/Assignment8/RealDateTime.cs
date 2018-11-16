using System;

namespace Assignment8
{
    public class RealDateTime : IDateTime
    {
        public DateTime Now() => DateTime.Now;
        
    }
}
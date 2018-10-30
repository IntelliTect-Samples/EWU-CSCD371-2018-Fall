using System;
using Microsoft.VisualBasic.CompilerServices;

namespace Assignment5
{
    public interface IEvent
    {
        int GetStartingHour();
        int GetEndingHour();
    }
}
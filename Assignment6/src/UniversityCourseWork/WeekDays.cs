﻿using System;

namespace Assignment6
{
    [Flags]
    public enum WeekDays : byte
    {
        Monday = 1,
        Tuesday = 2,
        Wednesday = 4,
        Thursday = 8,
        Friday = 16,
        Saturday = 32,
        Sunday = 64
    }
}
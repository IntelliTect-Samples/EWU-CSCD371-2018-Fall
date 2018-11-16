using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment8.Tests
{
    class TestableDateTime : IDateTime
    {
        public int Index { get; private set;}
        public List<DateTime> DatesToBeRead { get; private set; }

        public TestableDateTime(List<DateTime> dateTimesToBeRead)
        {
            DatesToBeRead = dateTimesToBeRead;
        }

        public DateTime Now()
        {
            if (Index > DatesToBeRead.Count)
                Index = DatesToBeRead.Count - 1;
          return DatesToBeRead[Index++];
        }    
    }
}



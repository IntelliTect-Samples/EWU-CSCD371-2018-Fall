using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment8.Tests
{
    class TestableDateTime : IDateTime
    {
        private int _index = 0;
        private List<DateTime> _datesToBeRead;

        public TestableDateTime(List<DateTime> dateTimesToBeRead)
        {
            _datesToBeRead = dateTimesToBeRead;
        }

        public DateTime Now()
        {
            if (_index > _datesToBeRead.Count)
                _index = _datesToBeRead.Count - 1;
          return _datesToBeRead[_index++];
        }    
    }
}



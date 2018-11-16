using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_WPF
{
    public class TestableDateTime : IDateTime
    {
        public DateTime _ManuallySetTime;

        public void SetDateTimeManually(DateTime date)
        {
            _ManuallySetTime = date;
        }
        public DateTime DateTime()
        {
            return _ManuallySetTime;
        }
    }
}


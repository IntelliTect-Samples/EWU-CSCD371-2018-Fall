using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCourse
{
    public class Event
    {
        private string _TimeStart;
        public string TimeStart
        {
            get { return _TimeStart; }
            set { _TimeStart = value; }
        }

        public string TimeEnd{ get; set; }


        public string GetSummaryInformation()
        {
            return null;
        }
    }
}

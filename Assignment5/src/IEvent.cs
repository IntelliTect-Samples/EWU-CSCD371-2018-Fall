using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public interface IEvent
    {
        int StartHour
        {
            get;
            set;
        }
        int EndHour
        {
            get;
            set;
        }
        String Title
        {
            get;
            set;
        }
        String GetSummaryInformation();
    }
}
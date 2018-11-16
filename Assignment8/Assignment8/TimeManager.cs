using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment8
{
    class TimeManager : IDateTime
    {
        private DateTime _StartTime;
        //private DateTime _EndTime;
        private string _Title;

        public TimeManager(string title, DateTime start)
        {
            Title = title;
            StartTime = start;
        }

        public DateTime StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                _StartTime = value;
            }
        }

        /*public DateTime EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                _EndTime = value;
            }
        }*/

        public string Title
        {
            get
            {
                return _Title;
            }
            set
            {
                _Title = value;
            }
        }


        public DateTime getDateTime()
        {
            return DateTime.Now;
        }




        override
        public string ToString()
        {
            return $"Title: {Title} , Total Time: {StartTime}";
        }
    }
}

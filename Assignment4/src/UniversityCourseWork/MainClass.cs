using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityCourseWork
{
    public class MainClass
    {
        public static void Main(string[] args)
        {

        }

        public MainClass()
        {

        }

        public MainClass(string stringToChange)
        {
            _StringToChange = stringToChange;
        }

        public MainClass(int calculatedProperty)
        {
            CalculatedProperty = calculatedProperty;
        }

        private readonly string _StringToChange = "";
        public string StringToChange
        {
            get
            {
                return _StringToChange;
            }
        }

        private readonly int _minDegree = -42;
        private readonly int _maxDegree = 42;
        public int degree;

        public int Degree
        {
            get
            {
                return degree;
            }
            set
            {
                if (value < _minDegree || value > _maxDegree)
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
        }

        private int _CalculatedProperty;
        public object CalculatedProperty
        {
            get
            {
                return _CalculatedProperty * _CalculatedProperty;
            }
            set
            {
                _CalculatedProperty = (int)value;
            }
        }

        public string AutoImplementedProperty { get; set; }

        //--------------------------------------------------------
        //Events and courses

        private List<string> courseList = new List<string>();
        private List<string> eventList = new List<string>();
        private List<string> courseDays = new List<string>();
        private List<string> eventDays = new List<string>();
        private List<string> courseTimes = new List<string>();
        private List<string> eventTimes = new List<string>();

        public void CourseCollection()
        {
            UniversityCourse UC = new UniversityCourse();
            Event EV = new Event();

            string courses = UC.GetSummaryInformation();
            string events = EV.GetSummaryInformation();
            string[] courseParts = courses.Split(".");
            string[] eventParts = events.Split(".");

            for(int i = 0; i < courseParts.Length; i+=3)
            {
                courseList.Add(courseParts[0]);
                courseDays.Add(courseParts[1]);
                courseTimes.Add(courseParts[2]);

                eventList.Add(eventParts[0]);
                eventDays.Add(eventParts[1]);
                eventTimes.Add(eventParts[2]);
            }
        }
    }
}

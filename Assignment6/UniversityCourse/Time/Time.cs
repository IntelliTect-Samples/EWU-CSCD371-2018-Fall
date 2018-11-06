using System.ComponentModel;

namespace UniversityCourse.Time
{
    [ImmutableObject(true)]
    public struct Time
    {
        public Time(int hour, int minute, int second)
        {
//            Hour = hour;
//            Minute = minute;
//            Second = second;
        }

        private readonly int _Hour;
        public int Hour => _Hour;
    };

        readonly private int _Minute;
        public int Minute => _Minute;

        readonly private int _Second;
        public int Second => _Second;
    }
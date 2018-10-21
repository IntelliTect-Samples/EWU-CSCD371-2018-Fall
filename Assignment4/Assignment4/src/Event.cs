using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class Event
    {
            private int _StartHour, _EndHour;
            private static int _EventNum;
            private String _Title;
            public int StartHour
            {
                get
                {
                    return this._StartHour;
                }
                set
                {
                    if(value < 0 || value > 23)
                    {
                        throw new NotSupportedException("Start hour must be in millitary time, between 0 and 23 inclusively.");
                    }
                    else
                    {
                        this._StartHour = value;
                    }
                }
            }

            public int EndHour
            {
                get
                {
                    return this._EndHour;
                }
                set
                {
                    if(value < 0 || value > 23)
                    {
                        throw new NotSupportedException("End hour must be in millitary time, between 0 and 23 inclusively.");
                    }
                    else
                    {
                        this._EndHour = value;
                    }
                }
            }

            public int EventNum
            {
                get
                {
                    return _EventNum;
                }
                private set//the constructor and destructor are in charge of keeping track of the number of instantiates, so having a public setter would be redundent and dangerous.
                {
                    _EventNum = value;
                }
            }

            public String Title
            {
                get
                {
                    return this._Title;
                }
                set
                {
                    string tValue = value.Trim();
                    if(tValue.Length == 0)
                    {
                        this._Title = "No Title";
                    }
                    else
                    {
                        this._Title = tValue;
                    }
                }
            }
            
            public Event(int start, int end, String title)
            {
                Title = title;
                StartHour = start;
                EndHour = end;
                EventNum++;
            }

            public void Deconstruct(out int startHour, out int endHour, out String title)
            {
                title = Title;
                startHour = StartHour;
                endHour = EndHour;
            }

            public virtual String GetSummaryInformation()
            {
                return $@"Title    : {Title}{Environment.NewLine}
                         Start Hour: {StartHour}{Environment.NewLine}
                         End Hour  : {EndHour}{Environment.NewLine}";
            }
            public static void Main()
            {

            }
        }
}
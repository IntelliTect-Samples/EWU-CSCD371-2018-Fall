using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment5
{
    public class Course : Event, IEvent
    {
        private string _Subject;
        //private int _NumStudents;

        private int _NumTeachers = 1;

        private int _RoomNum;

        private static int _CourseTotal;

        public string Subject
        {
            get
            {
                return _Subject;
            }
            set
            {
                if(value.Length > 0)
                {
                    _Subject = value;
                }
                else if(value.Length == 0)
                {
                    throw new NotSupportedException("Subject cannot be empty.");           
                }
                else
                {
                    throw new NullReferenceException("Subject cannot be null.");
                }
            }
        }

        public int NumTeachers //Read-only Property
        {
            get => _NumTeachers;
        }

        public int NumStudents //Default Property
        {
            get;
            set;
        }

        public int RoomNum //Validation Property
        {
            get
            {
                return _RoomNum;
            }
            set
            {
                if(isValidRoomNum(value))
                {
                    _RoomNum = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Room number must be a three digit value.");
                }
            }
        }

        public int FloorNum //Read-only Calculated Property
        {
            get => _RoomNum / 100;
        }

        public int CourseTotal 
        {
            get
            {
                int temp = _CourseTotal;
                return temp;
            }
            private set
            {
                _CourseTotal = value;
            }
        }

        public void resetCourseTotal()
        {
            this.CourseTotal = 0;
        }

        public override String GetSummaryInformation()
        {
            return $@"Title: {Title}{Environment.NewLine}
                    Start Hour: {StartHour}{Environment.NewLine}
                    End Hour: {EndHour}{Environment.NewLine}
                    Subject: {Subject}{Environment.NewLine}
                    Room Number: {RoomNum}{Environment.NewLine}
                    Floor Number: {FloorNum}{Environment.NewLine}
                    Number of Teachers: {NumTeachers}{Environment.NewLine}
                    Number of Students: {NumStudents}{Environment.NewLine}";
        }

        public Course(string title, string subject, int roomNum, int numOfStudents, int startHour, int endHour) : base(startHour, endHour, title)
        {
            this.Subject = subject;
            this.RoomNum = roomNum;
            this.NumStudents = numOfStudents;
            CourseTotal++;
        }

        public static Course makeNewCourse()
        {
                MyConsole myConsole = new MyConsole();
                
                string title = userInputTitle(myConsole);

                string subject = userInputSubject(myConsole);

                int numOfStudents = userInputStudentTotal(myConsole);

                int roomNum = userInputRoomNum(myConsole);
                
                int startHour = Event.userInputHour(myConsole, "Course", "start");

                int endHour = Event.userInputHour(myConsole, "Course", "end");

                return new Course(title, subject, roomNum, numOfStudents, startHour, endHour);
        }

        public static string userInputTitle(MyConsole myConsole)
        {
            myConsole.Write("Please enter the title of the Course: ");
            return myConsole.ReadLine();
        }

        public static string userInputSubject(MyConsole myConsole)
        {
            myConsole.Write("Please enter the Subject of the Course: ");
            return myConsole.ReadLine();
        }

        public static int userInputStudentTotal(MyConsole myConsole)
        {
            int studentNum = -1;
            myConsole.Write("Please type the number of students in the Course: ");
            while(!int.TryParse(myConsole.ReadLine(), out studentNum))
            {
                myConsole.Write("Incorrect input, please type in a valid integer for number of students: ");
            }
            return studentNum;
        }

        public static int userInputRoomNum(MyConsole myConsole)
        {
            myConsole.Write("Please type the room number of the Course: ");
            int roomNum = -1;
            while(!int.TryParse(myConsole.ReadLine(), out roomNum) || !isValidRoomNum(roomNum))
            {
                myConsole.Write("Incorrect input, please reinput a valid, 3 digit room num: ");
            }
            return roomNum;
        }

        public static bool isValidRoomNum(int num)
        {
            return (num > 99 && num < 1000);
        }
    }
}
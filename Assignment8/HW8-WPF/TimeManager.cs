using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_WPF
{
    public class TimeManager 
    {
        public DateTime StartTickTime { get; set; }
        public DateTime StopTickTime { get; set; }
        public TimeSpan ElapseTaskTime { get; set; }
        public string  TM_TaskName { get; set; }



        public void TimerStopEvent(DateTime dateTime)
        {
            StopTickTime = dateTime;
        }

        public void TimerStartEvent(DateTime dateTime)
        {
             StartTickTime = dateTime;
            CalElpasedTime();
           // System.Console.WriteLine("THIS IS A TEST");
        }

        public void CalElpasedTime()
        {
            ElapseTaskTime = StopTickTime - StartTickTime;
        }

        public void SaveButtonEvent(string taskName)
        {
            TM_TaskName = taskName;
        }
        public void AddCompletedTaskToListBox()
        {

        }
        

        public Action TimeEventCompleted { get; set; }   //It should have an event that is raised whenever a time entry is completed.

        

        public void StartButtonActions()
        {

        }
    }
}

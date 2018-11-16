using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace Assignment8
{
    /// <summary>
    /// TimeManager uses DispatcherTimer to record the elapsed time between calls to Start() and Stop()
    /// </summary>
    public class TimeManager : INotifyPropertyChanged
    {

        private readonly DispatcherTimer _timer;
        private readonly IDateTime _myDateTime;
        private DateTime _lastTickTime;
        public TimeSpan ElapsedTime { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<TimeEventArgs> OnTimeComplete;

        /// <summary>
        /// Creates a new TimeManager
        /// </summary>
        /// <param name="myDateTime">The object used to get current time</param>
        public TimeManager(IDateTime myDateTime)
        {
            _timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(.01)};
            _timer.Tick += TimerOnClick;
            _elapsedTimeStr = "00:00.00";
            _myDateTime = myDateTime;
        }
        
        
        
        private string _elapsedTimeStr;
        public string ElapsedTimeStr
        {
            get => _elapsedTimeStr;
            private set {
                if (_elapsedTimeStr == value) return;
                _elapsedTimeStr = value;
                OnElapsedTimeChanged();
            }
        }

        /// <summary>
        /// An event that is raised every time the elapsed time changes.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnElapsedTimeChanged([CallerMemberName] string propertyName = null) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
 

      /// <summary>
      /// Stops execution of the timer and raises an event that uses TimeEventArgs to carry the total elapsed time before resetting the elapsed time
      /// </summary>
        public void Stop()
        {
            OnTimeComplete?.Invoke(this, new TimeEventArgs(ElapsedTimeStr));
            ElapsedTimeStr = "00:00.00";
            _timer.Stop();
        }

        
        /// <summary>
        /// Pauses execution of the timer
        /// </summary>
        public void Pause() => _timer.Stop();


        /// <summary>
        /// Starts the timer
        /// </summary>
        public void Start()
        {
            ElapsedTime = DateTime.MinValue - DateTime.MinValue;
            _lastTickTime = _myDateTime.Now();
            _timer.Start();
        }

        
        /// <summary>
        /// An event that is triggered using the timer, it updates the elapsed time, as well as its string representation
        /// </summary>
        /// <param name="sender">The timer that triggered it</param>
        /// <param name="e">The events arguments</param>
        private void TimerOnClick(object sender, EventArgs e)
        {
            ElapsedTime += _myDateTime.Now() - _lastTickTime;
            _lastTickTime = _myDateTime.Now();
            ElapsedTimeStr = $"{ElapsedTime.Minutes.ToString("0#")}:{ElapsedTime.Seconds.ToString("0#")}.{ElapsedTime.Milliseconds}";
        }
        
        

    }
}

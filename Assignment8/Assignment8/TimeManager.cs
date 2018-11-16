using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Assignment8
{
    public class TimeManager : IDateTime, INotifyPropertyChanged
    {
        private DispatcherTimer _currentTimer;
        private DispatcherTimer _elapsedTimer;
        private DateTime _startTime;
        private bool _isTimerRunning;

        private string _currentTime;
        public string CurrentTime
        {
            get => _currentTime;
            set
            {
                if (_currentTime != value)
                {
                    _currentTime = value;
                    OnPropertyChanged();
                }
            }
        }

        public TimeManager(Action<TimeEvent> stopEvent)
        {
            StopEvent = stopEvent;
            StartClock();
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler PropertyChanged;

        public void StartClock()
        {
            _currentTimer = new DispatcherTimer();
            _currentTimer.Interval = TimeSpan.FromMilliseconds(10);
            _currentTimer.Tick += OnTickClock;
            CurrentTime = GetCurrentTime().ToString(@"hh \: mm :\ ss");
            _currentTimer.Start();
        }

        public void OnTickClock(object sender, EventArgs e)
        {
            DateTime now = GetCurrentTime();
            CurrentTime = now.ToString(@"hh \: mm :\ ss");
        }

        public void TimerStart()
        {
            if(!_isTimerRunning)
            {
                // stop clock timer
                _currentTimer.Stop();

                _elapsedTimer = new DispatcherTimer();
                _elapsedTimer.Interval = TimeSpan.FromMilliseconds(10);
                _elapsedTimer.Tick += OnTickElapsed;
                _startTime = GetCurrentTime();
                _elapsedTimer.Start();
                _isTimerRunning = true;
            }
        }

        public void OnTickElapsed(object sender, EventArgs e)
        {
            DateTime now = GetCurrentTime();
            TimeSpan elapsedTime = now - _startTime;
            CurrentTime = elapsedTime.ToString(@"hh':'mm':'ss':'ff");
        }

        public void TimerStop(string eventDescription)
        {
            if (_isTimerRunning)
            {
                _elapsedTimer.Stop();
                _isTimerRunning = false;

                TimeEvent toSend = new TimeEvent(CurrentTime, eventDescription);

                StopEvent(toSend);

                //start clock
                StartClock();
            }
        }

        public Action<TimeEvent> StopEvent { get; set; }

        public bool IsClockEnabled()
        {
            if (_currentTimer is null)
            {
                return false;
            }

            return _currentTimer.IsEnabled;
        }

        public bool IsTimerEnabled()
        {
            if(_elapsedTimer is null)
            {
                return false;
            }

            return _elapsedTimer.IsEnabled;
        }

        public DateTime GetCurrentTime()
        {
            return DateTime.Now;
        }
    }
}

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace Assignment8
{
    public class TimeManager : INotifyPropertyChanged
    {

        private readonly DispatcherTimer _timer;
        private readonly IDateTime _myDateTime;
        private DateTime _lastTickTime;
        public TimeSpan ElapsedTime { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler AddToListEvent;

        public TimeManager(IDateTime myDateTime)
        {
            _timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(.01)};
            _timer.Tick += TimerOnClick;
            _currentTime = "00:00.00";
            _myDateTime = myDateTime;
        }
        
        
        
        private string _currentTime;
        public string CurrentTime
        {
            get => _currentTime;
            private set { 
                    if (_currentTime != value)
                    {
                        _currentTime = value;
                        OnCurrentTimeChanged();
                    }
                }
        }


        protected virtual void OnCurrentTimeChanged([CallerMemberName] string propertyName = null) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
 

      
        public void Stop()
        {
            AddToListEvent(this, new EventArgs());
            CurrentTime = "00:00.00";
            _timer.Stop();
            }

        public void Pause()
        {
            _timer.Stop();
        }

        public void Start()
        {
            ElapsedTime = DateTime.MinValue - DateTime.MinValue;
            _lastTickTime = _myDateTime.Now();
            _timer.Start();
        }

        private void TimerOnClick(object sender, EventArgs e)
        {
            ElapsedTime += _myDateTime.Now() - _lastTickTime;
            _lastTickTime = _myDateTime.Now();
            CurrentTime = $"{ElapsedTime.Minutes.ToString("0#")}:{ElapsedTime.Seconds.ToString("0#")}.{ElapsedTime.Milliseconds}";
        }
        
        

    }
}

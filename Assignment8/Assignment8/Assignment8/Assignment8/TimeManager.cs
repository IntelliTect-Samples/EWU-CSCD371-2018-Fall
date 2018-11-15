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
        private readonly RealDateTime _realDateTime;
        private DateTime _lastTickTime;
        private DateTime ElapsedTime { get; set; }
        
        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler AddToListEvent;

        public TimeManager(RealDateTime realDateTime)
        {
            _timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(.01)};
            _timer.Tick += TimerOnClick;
            _currentTime = "00:00.00";
            _realDateTime = realDateTime;
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
 

      
        public void StopButton()
        {
            AddToListEvent(this, new TimeEventArgs(CurrentTime));
            ElapsedTime = DateTime.MinValue;
            CurrentTime = "00:00.00";
            _timer.Stop();
            }

        public void PauseButton()
        {
            _timer.Stop();
        }

        public void StartButton()
        {
            _lastTickTime = DateTime.Now;
            _timer.Start();
        }

        private void TimerOnClick(object sender, EventArgs e)
        {
            ElapsedTime += _realDateTime.Now() - _lastTickTime;
            _lastTickTime = _realDateTime.Now();
            CurrentTime = ElapsedTime.ToString("mm:ss.FF");
        }
        
        

    }
}

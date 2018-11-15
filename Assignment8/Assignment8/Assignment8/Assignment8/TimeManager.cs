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
        public DateTime ElapsedTime { get; private set; }




        public TimeManager(RealDateTime realDateTime)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(.01);
            _timer.Tick += TimerOnClick;
            _currentTime = "00:00:00";
            _realDateTime = realDateTime;
        }
        
        
        
        private string _currentTime;
        public string CurrentTime
        {
            get { return _currentTime; }
            set { 
                    if (_currentTime != value)
                    {
                        _currentTime = value;
                        OnCurrentTimeChanged();
                    }
                }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnCurrentTimeChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void StopButtonClick()
        {
            ElapsedTime = DateTime.MinValue;
            CurrentTime = "00:00:00";
            _timer.Stop();
        }

        public void PauseButtonClick()
        {
            _timer.Stop();
        }

        public void StartButtonClick()
        {
            _lastTickTime = DateTime.Now;
            _timer.Start();
        }

        private void TimerOnClick(object sender, EventArgs e)
        {
            ElapsedTime += DateTime.Now - _lastTickTime;
            _lastTickTime = DateTime.Now;
            CurrentTime = ElapsedTime.ToString("mm:ss.FF");
        }
        
        

    }
}

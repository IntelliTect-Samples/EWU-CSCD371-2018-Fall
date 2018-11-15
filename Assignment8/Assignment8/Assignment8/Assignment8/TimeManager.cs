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
        private DateTime _LastTickTime;
        public DateTime ElapsedTime { get; private set; }




        public TimeManager()
        {
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(.1);
            _timer.Tick += TimerOnClick;
            _currentTime = "00:00:00";
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
            CurrentTime = "00:00:00";
            _timer.Stop();
        }

        public void StartButtonClick()
        {
            _LastTickTime = DateTime.Now;
            _timer.Start();
        }

        private void TimerOnClick(object sender, EventArgs e)
        {
            ElapsedTime += DateTime.Now - _LastTickTime;
            _LastTickTime = DateTime.Now;
            CurrentTime = ElapsedTime.ToString("mm:ss.FF");
        }
        
        

    }
}

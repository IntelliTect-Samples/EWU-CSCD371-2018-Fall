using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Assignment8
{
    /// <summary>
    /// ClockManager is used to raise an event whenever the current time changes
    /// *Note I chose to not implement this in TimeManager to make things more easily testable without adding conditional complexity to the class*
    /// </summary>
    public class ClockManager : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DispatcherTimer ClockTimer { get; set; }

        private const double V = .01;
        private string _CurrentTime;
        public string CurrentTime
        {
            get => _CurrentTime;
            set
            {
                if (CurrentTime == value) return;
                _CurrentTime = value;
                OnCurrentTimeChanged();
            }
        }

        /// <summary>
        /// Creates a new TimeManager
        /// </summary>
        public ClockManager()
        {
            ClockTimer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(.1) };
            ClockTimer.Tick += UpdateClock;
        }


        /// <summary>
        /// An event that is raised every time the current time changes.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnCurrentTimeChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        /// <summary>
        /// Updates the time to be displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateClock(object sender, EventArgs e) =>
            CurrentTime = DateTime.Now.ToString("HH:mm:ss tt");


        /// <summary>
        /// Starts the timer that updates the current time
        /// </summary>
        public void Start()
        {
            ClockTimer.Start();
            CurrentTime = DateTime.Now.ToString("HH:mm:ss tt");
        }


        /// <summary>
        /// Stops the timer that updates the current time
        /// </summary>
        public void Stop()
        {
            ClockTimer.Start();
            CurrentTime = DateTime.Now.ToString("HH:mm:ss tt");
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace HW8_WPF
{
       public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer;
        private readonly DispatcherTimer _clocksTimer;
        public DateTime _startTickTime;
        public DateTime _stoppedTickTime;
        public Boolean IsTimerRunning = false;

        IDateTime idateTime = new RealDateTime();

        public MainWindow()
        {
            InitializeComponent();
            Timer.Content = "00:00:00.000";
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += new EventHandler(Timer_Click);            
            
            _clocksTimer = new DispatcherTimer();
            _clocksTimer.Interval = TimeSpan.FromSeconds(1);
            _clocksTimer.Tick += new EventHandler(Clock_Click);
            _clocksTimer.Start();

            StartButton.Click += StartButton_OnClick;
            StopButton.Click += StopButton_OnClick;
            SaveButton.Click += SaveButton_OnClick;
            ResetButton.Click += ResetButton_OnClick;
            DeleteButton.Click += DeleteButton_Click;

            TasksListBox.Items.Clear();
        }

        
        public DateTime TimerTick(object sender, EventArgs e)
        {            
            return idateTime.DateTime(); 
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            
            DateTime now = idateTime.DateTime();
            TimeSpan elapseTime = (now - _startTickTime);
            Timer.Content = elapseTime.Hours + ":" + elapseTime.Minutes 
                + ":" + elapseTime.Seconds + "." + elapseTime.Milliseconds;
        }

        private void Clock_Click(object sender, EventArgs e)
        {            
            DateTime DT = idateTime.DateTime();
            Clock.Content = DT.ToString("hh:mm:ss tt");
          
        }
        public void StartButton_OnClick(object sender, EventArgs e)
        {            
            _timer.Start();
            IsTimerRunning = true;            
            _startTickTime = idateTime.DateTime();            
        }

        public void StopButton_OnClick(object sender, EventArgs e)
        {
            _timer.Stop();
            if (IsTimerRunning)
            {
                _stoppedTickTime = idateTime.DateTime();
                IsTimerRunning = false;
            }
            else
            { }//do nothing
        }

        public void ResetButton_OnClick(object sender, EventArgs e)
        {
            _stoppedTickTime = _startTickTime;
            Timer.Content = "00:00:00.000";
        }

        public void SaveButton_OnClick(object sender, EventArgs e)
        {            
            StopButton_OnClick(this, null);            
             TimeSpan elapsedTime = _stoppedTickTime - _startTickTime;            
            TasksListBox.Items.Add(new CompletedTaskItem() { Title = TaskTitleTextBox.Text,  ElapsedTime = elapsedTime });
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TasksListBox.SelectedItem == null)
            {   }
            else
            {
                TasksListBox.Items.RemoveAt
                    (TasksListBox.Items.IndexOf(TasksListBox.SelectedItem));
            }
        }
        
        public class CompletedTaskItem
        {
            public string Title { get; set; }
            public TimeSpan ElapsedTime { get; set; }
        }
    }
}

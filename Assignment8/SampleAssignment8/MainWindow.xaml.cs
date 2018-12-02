using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SampleAssignment8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly DispatcherTimer _Timer;
        private readonly TimeManager _TimeManager;

        public MainWindow()
        {
            InitializeComponent();

            _Timer = new DispatcherTimer();
            _Timer.Interval = TimeSpan.FromMilliseconds(500);
            _Timer.Tick += TimerOnTick;
            _Timer.Start();

            _TimeManager = new TimeManager(new RealDateTime());
            _TimeManager.TimeEntryCreated += TimeManagerOnTimeEntryCreated;
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            ClockText.Text = DateTime.Now.ToLongTimeString();
        }

        private void TimeManagerOnTimeEntryCreated(object sender, TimeEntryCreatedEventArgs e)
        {
            TimesList.Items.Add($"Entry Duration: {e.Duration:h\\:mm\\:ss}");
        }

        private void StartStopButton_OnClick(object sender, RoutedEventArgs e)
        {
            switch (_TimeManager.MarkTime())
            {
                case Status.Running:
                    StartStopButton.Content = "Stop";
                    break;
                case Status.NotRunning:
                    StartStopButton.Content = "Start";
                    break;
            }
        }

        private void TimesList_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                TimesList.Items.Remove(TimesList.SelectedItem);
            }
        }
    }
}

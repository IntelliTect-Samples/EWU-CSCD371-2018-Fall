using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Assignment8
{
    /// <summary>
    /// TimeEventArgs does not pass data to handler
    /// clock and timer cant work at the same time
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _clockTimer;
        public MainWindow()
        {
           var timeManager = new TimeManager(new RealDateTime());
            DataContext = timeManager;
            timeManager.AddToListEvent += AddListItem;
            InitializeComponent();
            _clockTimer = new DispatcherTimer{Interval = TimeSpan.FromSeconds(.01)};
            _clockTimer.Tick += UpdateClockTick;
            //_clockTimer.Start();
        }


        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
           // _clockTimer.Stop();
            StartBtn.Visibility = Visibility.Collapsed;
            PauseBtn.Visibility = Visibility.Visible;
            StopBtn.Opacity = 1;
            StopBtn.IsEnabled = true;
            ((TimeManager) DataContext).StartButton();
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            //_clockTimer.Start();
            PauseBtn.Visibility = Visibility.Collapsed;
            StartBtn.Visibility = Visibility.Visible;
            StopBtn.Opacity = .5;
            StopBtn.IsEnabled = false;
            ((TimeManager) DataContext).StopButton();
        }



        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            PauseBtn.Visibility = Visibility.Collapsed;
            StartBtn.Visibility = Visibility.Visible;
            ((TimeManager)DataContext).PauseButton();
        }

        private void AddListItem(object sender, EventArgs e)
        {
           //TimesListBox.Items.Add(new TimeItem(args.ElapsedTime));
           TimesListBox.Items.Add(new TimeItem(((TimeManager) DataContext).CurrentTime));
        }



        private void DeleteListItem(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is TimeItem caller)
                TimesListBox.Items.Remove(caller);
            
        }
            
        private void UpdateClockTick(object sender, EventArgs e)
        {
            //ClockTxt.Text = DateTime.Now.ToString("HH:MM:ss");
        }
    }


    public class TimeItem
    {
        public string ElapsedTime { get; }

        public TimeItem(string elapsedTime)
        {
            ElapsedTime = elapsedTime;
        }

        public override string ToString()
        {
            return ElapsedTime;
        }
    }
   
}

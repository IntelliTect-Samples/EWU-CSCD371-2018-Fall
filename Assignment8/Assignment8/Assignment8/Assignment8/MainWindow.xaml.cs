using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace Assignment8
{
    /// <summary>
    /// TimeEventArgs does not pass data to handler
    /// clock and timer cant work at the same time
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private DispatcherTimer ClockTimer { get; set; }

        private string _CurrentTime;
        public string CurrentTime
        {
            get => _CurrentTime;
            set { 
                if(CurrentTime == value) return;
                _CurrentTime = value;     
                OnCurrentTimeChanged();
            }
        }

        public MainWindow()
        {
            var timeManager = new TimeManager(new RealDateTime());
            DataContext = timeManager;
            timeManager.OnTimeComplete += AddListItem;
            InitializeClock();   
            InitializeComponent();
            SwitchDisplayToClock();
        }


        /// <summary>
        /// Hides the start button and starts the timer in TimeManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            SwitchDisplayToTimer();
            StartBtn.Visibility = Visibility.Collapsed;
            PauseBtn.Visibility = Visibility.Visible;
            StopBtn.Opacity = 1;
            StopBtn.IsEnabled = true;
            ((TimeManager) DataContext).Start();
        }

        
        /// <summary>
        /// Hides the stop button and stops the timer in TimeManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            SwitchDisplayToClock();
            PauseBtn.Visibility = Visibility.Collapsed;
            StartBtn.Visibility = Visibility.Visible;
            StopBtn.Opacity = .5;
            StopBtn.IsEnabled = false;
            ((TimeManager) DataContext).Stop();
        }


        /// <summary>
        /// Hides the pause button and pauses the timer in TimeManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            PauseBtn.Visibility = Visibility.Collapsed;
            StartBtn.Visibility = Visibility.Visible;
            ((TimeManager)DataContext).Pause();
        }

        
        /// <summary>
        /// An event subscriber called whenever a new time record us completed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddListItem(object sender, EventArgs e)
        {
            var args = (TimeEventArgs)e;
            var title = "Time Record " + (TimesListBox.Items.Count + 1);
            var description = $"The event took {args.ElapsedTime}";
            TimesListBox.Items.Add(new TimeRecord(args.ElapsedTime, title, description));
        }


        /// <summary>
        /// Deletes the currently selected time record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteListItem(object sender, RoutedEventArgs e)
        {
            if (((Button) sender).DataContext is TimeRecord timeItem)
            {
                TimesListBox.Items.Remove(timeItem);
                InfoGrid.Visibility = Visibility.Hidden;
            }

        }

        
        /// <summary>
        /// When a time record is selected, its information is displayed at the bottom
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoGrid.Visibility = Visibility.Visible;
            var timeItem = (TimeRecord)TimesListBox.SelectedItem;
            if (timeItem != null)
            {
                TimeTxt.Text = timeItem.ElapsedTime;
                TitleTxt.Text = timeItem.Title;
                DescriptionTxt.Text = timeItem.Description;
            }
        }


        /// <summary>
        /// Updates the list of records when the description of a record is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DescriptionTxt_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var descriptionTextBox = (TextBox) sender;
            var timeItem = (TimeRecord)TimesListBox.SelectedItem;
            timeItem.Description = descriptionTextBox.Text;

        }

        
        /// <summary>
        /// Updates the list of records when the title of a record is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TitleTxt_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var titleTextBox = (TextBox) sender;
            var timeItem = (TimeRecord)TimesListBox.SelectedItem;
            timeItem.Title = titleTextBox.Text;
         }
        
        
        /*Clock*/
        /// <summary>
        /// Initializes the clock timer and adds its event handler
        /// </summary>
        private void InitializeClock()
        {
            ClockTimer = new DispatcherTimer{Interval = TimeSpan.FromSeconds(.01)};
            ClockTimer.Tick += UpdateClock;
        }

        
        /// <summary>
        /// Updates the time to be displayed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateClock(object sender, EventArgs e)=>
            CurrentTime = DateTime.Now.ToString("HH:mm:ss tt");
        

        /// <summary>
        /// Switches the display binding to the current time
        /// </summary>
        private void SwitchDisplayToClock()
        {
            ClockTimer.Start();
            var myBinding = new Binding("CurrentTime") {Source = this};
            ClockTxt.SetBinding(TextBlock.TextProperty, myBinding);
            ClockTxt.FontSize = 35;
        }

        
        /// <summary>
        /// Switches the display binding to the timer
        /// </summary>
        private void SwitchDisplayToTimer()
        {
            ClockTimer.Stop();
            var myBinding = new Binding("ElapsedTimeStr") {Source = (TimeManager) DataContext};
            ClockTxt.SetBinding(TextBlock.TextProperty, myBinding);
            ClockTxt.FontSize = 50;
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        
        /// <summary>
        /// An event that is raised every time the current time changes.
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnCurrentTimeChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));       
    }
   
}

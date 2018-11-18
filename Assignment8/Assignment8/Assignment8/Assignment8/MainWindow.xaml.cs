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
    /// MainWindow contains all event handlers from WPF elements.
    /// </summary>
    public partial class MainWindow
    {

        private ClockManager _MyClockManager;
        public ClockManager MyClockManager
        {
            get => _MyClockManager ?? (_MyClockManager = new ClockManager());
            set { _MyClockManager = value; }
        }


        public MainWindow()
        {
            var timeManager = new TimeManager();
            DataContext = timeManager;
            timeManager.OnTimeComplete += AddListItem;  
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
        
        
 

        /// <summary>
        /// Switches the display binding to the current time
        /// </summary>
        private void SwitchDisplayToClock()
        {
            MyClockManager.Start();
            var myBinding = new Binding("CurrentTime") {Source = MyClockManager};
            ClockTxt.SetBinding(TextBlock.TextProperty, myBinding);
            ClockTxt.FontSize = 35;
        }

        
        /// <summary>
        /// Switches the display binding to the timer
        /// </summary>
        private void SwitchDisplayToTimer()
        {
            MyClockManager.Stop();
            var myBinding = new Binding("ElapsedTimeStr") {Source = (TimeManager) DataContext};
            ClockTxt.SetBinding(TextBlock.TextProperty, myBinding);
            ClockTxt.FontSize = 50;
        }
         
    }
   
}

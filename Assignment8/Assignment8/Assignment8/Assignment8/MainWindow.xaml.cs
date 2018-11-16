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
        public MainWindow()
        {
            var timeManager = new TimeManager(new RealDateTime());
            DataContext = timeManager;
            timeManager.OnTimeComplete += AddListItem;
            InitializeComponent();
        }


        /// <summary>
        /// Hides the start button and starts the timer in TimeManager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
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
            var description = "TimeItem " + (TimesListBox.Items.Count + 1);
            TimesListBox.Items.Add(new TimeRecord(args.ElapsedTime, description, description));
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

    }
   
}

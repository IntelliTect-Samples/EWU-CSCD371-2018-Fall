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
            timeManager.AddToListEvent += AddListItem;
            InitializeComponent();
        }


        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            StartBtn.Visibility = Visibility.Collapsed;
            PauseBtn.Visibility = Visibility.Visible;
            StopBtn.Opacity = 1;
            StopBtn.IsEnabled = true;
            ((TimeManager) DataContext).Start();
        }

        private void StopBtn_Click(object sender, RoutedEventArgs e)
        {
            PauseBtn.Visibility = Visibility.Collapsed;
            StartBtn.Visibility = Visibility.Visible;
            StopBtn.Opacity = .5;
            StopBtn.IsEnabled = false;
            ((TimeManager) DataContext).Stop();
        }



        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            PauseBtn.Visibility = Visibility.Collapsed;
            StartBtn.Visibility = Visibility.Visible;
            ((TimeManager)DataContext).Pause();
        }

        private void AddListItem(object sender, EventArgs e)
        {
            var args = (TimeEventArgs)e;
            var description = "TimeItem " + (TimesListBox.Items.Count + 1);
            TimesListBox.Items.Add(new TimeItem(args.ElapsedTime, description, description));
        }



        private void DeleteListItem(object sender, RoutedEventArgs e)
        {
            if (((Button) sender).DataContext is TimeItem timeItem)
            {
                TimesListBox.Items.Remove(timeItem);
                InfoGrid.Visibility = Visibility.Hidden;
            }

        }

        private void TimesListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            InfoGrid.Visibility = Visibility.Visible;
            var timeItem = (TimeItem)TimesListBox.SelectedItem;
            if (timeItem != null)
            {
                TimeTxt.Text = timeItem.ElapsedTime;
                TitleTxt.Text = timeItem.Title;
                DescriptionTxt.Text = timeItem.Description;
            }
        }


        private void DescriptionTxt_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var descriptionTextBox = (TextBox) sender;
            var timeItem = (TimeItem)TimesListBox.SelectedItem;
            timeItem.Description = descriptionTextBox.Text;

        }

        private void TitleTxt_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            var titleTextBox = (TextBox) sender;
            var timeItem = (TimeItem)TimesListBox.SelectedItem;
            timeItem.Title = titleTextBox.Text;
         }

        private void TimesListBox_OnUnselected(object sender, RoutedEventArgs e)
        {
            InfoGrid.Visibility = Visibility.Hidden;
        }

    }


    public class TimeItem
    {
        public string ElapsedTime { get; }
        public string Description { get; set; }
        public string Title { get; set; }
    
        public TimeItem(string elapsedTime, string title, string description)
        {
            ElapsedTime = elapsedTime;
            Title = title;
            Description = description;
        }

        public override string ToString()
        {
            return ElapsedTime;
        }
    }
   
}

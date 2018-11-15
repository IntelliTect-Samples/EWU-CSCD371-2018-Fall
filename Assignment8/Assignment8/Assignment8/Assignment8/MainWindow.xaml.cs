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

namespace Assignment8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {      
        public MainWindow()
        {
            DataContext = new TimeManager(new RealDateTime());
            InitializeComponent();
        }

        private void StartStopBtn_Click(object sender, RoutedEventArgs e)
        {
            var buttonClicked = (Button)sender;
            if(buttonClicked.Name == "StartBtn")
            {
                StartBtn.Visibility = Visibility.Collapsed;
                PauseBtn.Visibility = Visibility.Visible;
                StopBtn.Opacity = 1;
                StopBtn.IsEnabled = true;
                ((TimeManager) DataContext).StartButtonClick();
            }
            else
            {
                PauseBtn.Visibility = Visibility.Collapsed;
                StartBtn.Visibility = Visibility.Visible;
                StopBtn.Opacity = .5;
                StopBtn.IsEnabled = false;
                AddListItem();
                ((TimeManager) DataContext).StopButtonClick();
            }
        }

        private void PauseBtn_Click(object sender, RoutedEventArgs e)
        {
            PauseBtn.Visibility = Visibility.Collapsed;
            StartBtn.Visibility = Visibility.Visible;
            ((TimeManager)DataContext).PauseButtonClick();
        }

        private void AddListItem()
        {
            TimesListBox.Items.Add(new TimeItem(((TimeManager) DataContext).CurrentTime));
        }



        private void DeleteListItem(object sender, RoutedEventArgs e)
        {
            Button deleteBtn = (Button)sender;
            if (deleteBtn.DataContext is TimeItem caller)
            {
                TimesListBox.Items.Remove(caller);
            }
        }
    }

    public class TimeItem
    {
        public string ElapsedTime { get; }
        public string Description { get; set; }

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

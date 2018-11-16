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

namespace Assignment8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer _Timer;
        private DateTime _LastTickTime;
        private DateTime _TimeStarted;
        private Boolean _IsTimerOn = false;


        public MainWindow()
        {
            InitializeComponent();
            _TimeStarted = DateTime.Now;
            MyStartCurrentClock();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan interval = now - _TimeStarted;
            _LastTickTime = now;
            CurrentTimeBlock.Text = getIntervalString(interval);
        }

        private void MyStartCurrentClock()
        {
            DispatcherTimer currTime = new DispatcherTimer();
            currTime.Interval = TimeSpan.FromSeconds(0);
            currTime.Tick += updateTime;
            currTime.Start();
        }

        public void MyStartTimer()
        {
            _TimeStarted = DateTime.Now;
            _Timer = new DispatcherTimer();
            _Timer.Interval = TimeSpan.FromMilliseconds(100);
            _Timer.Tick += TimerOnTick;
            _LastTickTime = DateTime.Now;
            _Timer.Start();
        }



        private void updateTime(object sender, EventArgs e)
        {
            CurrentTimeTimer.Text = DateTime.Now.TimeOfDay.ToString();
        }

        private void ResetTextBlock(object block)
        {
            ((TextBox)block).Text = "";
        }


        private void ResetTimer_Click(object sender, RoutedEventArgs e)
        {
            /*if (_IsTimerOn)
            {*/
                MyStartTimer();
                _Timer.Stop();
                _IsTimerOn = false;
                ResetTextBlock(TitleTextBox);
            //}
        }

        private void EndTimer_Click(object sender, RoutedEventArgs e)
        {
            if (TitleTextBox.Text != null && TitleTextBox.Text.Length > 0)
            {
                string time = CurrentTimeBlock.Text.ToString();
                //TimeSpan t = DateTime.Now - _TimeStarted;
                _Timer = new DispatcherTimer();
                _IsTimerOn = false;
                ListBoxOfCompleteTasks.Items.Add(new ListBoxItem() { Content = $"Title:{TitleTextBox.Text}, Time Taken: {time}" });
                ResetTextBlock(TitleTextBox);

            }
        }

        private void StartTimer_Click(object sender, RoutedEventArgs e)
        {
            if (!_IsTimerOn)
            {
                MyStartTimer();
                _IsTimerOn = true;
            }
        }

        private void PauseTimer_Click(object sender, RoutedEventArgs e)
        {
            /*if (_IsTimerOn)
            {*/
                _Timer.Stop();
                _IsTimerOn = false;
            //}
            /*else
            {
                _Timer.Start();
                _IsTimerOn = true;
            }*/
        }

        private void Delete_Item_Click(object sender, RoutedEventArgs e)
        {
            int indexChosen = ListBoxOfCompleteTasks.SelectedIndex;
            if (indexChosen != -1)
            {
                ListBoxOfCompleteTasks.Items.RemoveAt(indexChosen);
            }
        }

        private string getIntervalString(TimeSpan interval)
        {
            return $"{interval.Hours} : {interval.Minutes} : {interval.Seconds}";
        }
    }
}

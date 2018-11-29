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

namespace LearnWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DispatcherTimer _timer;
        private DateTime _lastTickTime;

        public MainWindow()
        {
            InitializeComponent();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(3);
            _timer.Tick += TimerOnTick;
            _lastTickTime = DateTime.Now;
            _timer.Start();

            //ClickMeButton.Click += ClickMeButton_OnClick;
            //ClickMeButton.Click += ClickMeButton_OnClickXaml;
            //ClickMeButton.Click -= ClickMeButton_OnClick;
            var button = new Button();
            button.Content = new TextBlock { Text = "Kevin" };
            StackPanel.Children.Add(button);
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            TimeSpan interval = _lastTickTime - now;
            _lastTickTime = now;
            
            ListBox.Items.Add(interval);
        }

        private void ClickMeButton_OnClick(object sender, EventArgs e)
        {
            ListBox.Items.Add(new ListBoxItem
            {
                Content = (ListBox.Items.Count + 1)
            });
        }

        private void ClickMeButton_OnClickXaml(object sender, RoutedEventArgs e)
        {
            
        }
        
    }
}

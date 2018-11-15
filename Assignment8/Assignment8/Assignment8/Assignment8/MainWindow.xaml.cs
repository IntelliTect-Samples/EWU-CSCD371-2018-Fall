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
            DataContext = new TimeManager();
            InitializeComponent();
        }

        private void StartStopBtn_Click(object sender, RoutedEventArgs e)
        {
            Button buttonClicked = ((Button)sender);
            if(buttonClicked.Name == "StartBtn")
            {
                StartBtn.Visibility = Visibility.Collapsed;
                StopBtn.Visibility = Visibility.Visible;
            }
            else
            {
                StopBtn.Visibility = Visibility.Collapsed;
                StartBtn.Visibility = Visibility.Visible;
            }
        }
    }
}

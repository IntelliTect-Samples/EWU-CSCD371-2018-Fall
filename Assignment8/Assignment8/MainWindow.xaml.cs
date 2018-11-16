using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            DataContext = new TimeManager(CreateNewListBoxEntry);

            InitializeComponent();
        }

        public void OnStartClicked(object sender, EventArgs args)
        {
            ((TimeManager)DataContext).TimerStart();
        }

        public void OnStopClicked(object sender, EventArgs args)
        {
            // do something
            ((TimeManager)DataContext).TimerStop(DescriptionText.Text);
        }

        public void CreateNewListBoxEntry(TimeEvent passedEvent)
        {
            TimeEvent eventToAdd = passedEvent;

            TimeList.Items.Add(eventToAdd);
        }

        private void DeleteListBoxEntry(object sender, EventArgs e)
        {
            Button thing = (Button)sender;
            if (thing.DataContext is TimeEvent caller)
            {
                TimeList.Items.Remove(caller);
            }
        }
    }
}

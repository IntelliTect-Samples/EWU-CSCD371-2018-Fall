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
using System.Windows.Shapes;

namespace LearnWpf
{
    /// <summary>
    /// Interaction logic for NewWindow.xaml
    /// </summary>
    public partial class NewWindow : Window
    {
        public NewWindow()
        {
            DataContext = new NewWindowViewModel();
            InitializeComponent();
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine($"Text is: {((TextBox)sender).Text}");
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            ((NewWindowViewModel) DataContext).Name = "Mark";
        }
    }
}

using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;

namespace WpfApp2
{
    public class GetChildrenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DirectoryInfo directory)
            {
                try
                {
                    return directory.GetFileSystemInfos();
                }
                catch
                {
                    //Ignore all error because we don't care
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
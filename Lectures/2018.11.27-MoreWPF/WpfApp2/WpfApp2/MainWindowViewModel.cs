using GalaSoft.MvvmLight.CommandWpf;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GalaSoft.MvvmLight;

namespace WpfApp2
{
    public class MainWindowViewModel : ViewModelBase
    {

        public ObservableCollection<FileSystemInfo> FileInfos { get; } 
            = new ObservableCollection<FileSystemInfo>();

        public ICommand LoadCommand { get; }

        private string _RootDirectory = @"C:\";
        public string RootDirectory
        {
            get => _RootDirectory;
            set
            {
                if (Set(ref _RootDirectory, value))
                {

                }
            }
        }

        public MainWindowViewModel()
        {
            LoadCommand = new RelayCommand<string>(OnLoad, CanLoad);

            Load(RootDirectory);
        }

        private bool CanLoad(string rootPath)
        {
            return !string.IsNullOrWhiteSpace(rootPath);
        }

        private void OnLoad(string rootPath)
        {
            Load(rootPath);
            //RootDirectory = @"C:\";
        }

        private void Load(string rootPath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(rootPath);

            IEnumerable<FileSystemInfo> fileSystemInfos = directoryInfo.EnumerateFileSystemInfos();

            FileInfos.Clear();
            foreach (FileSystemInfo info in fileSystemInfos)
            {
                FileInfos.Add(info);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
using System;
using System.Windows.Input;

namespace WpfApp2
{
    //public class RelayCommand<T> : ICommand
    //{
    //    private Action<T> ExecuteAction { get; }
    //
    //    public RelayCommand(Action<T> execute)
    //    {
    //        ExecuteAction = execute ?? 
    //                        throw new ArgumentNullException(nameof(execute));
    //    }
    //
    //    public bool CanExecute(object parameter)
    //    {
    //        return true;
    //    }
    //
    //    public void Execute(object parameter) => 
    //        ExecuteAction.Invoke((T)parameter);
    //
    //    public event EventHandler CanExecuteChanged;
    //}
    //
    //public class RelayCommand : ICommand
    //{
    //    private Action ExecuteAction { get; }
    //
    //    public RelayCommand(Action execute)
    //    {
    //        ExecuteAction = execute ?? throw new ArgumentNullException(nameof(execute));
    //    }
    //
    //    public bool CanExecute(object parameter)
    //    {
    //        return true;
    //    }
    //
    //    public void Execute(object parameter) => ExecuteAction.Invoke();
    //
    //    public event EventHandler CanExecuteChanged;
    //}
}
using System.Windows.Input;

namespace BookShop.Mvvm.Commands;


public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
    : ICommand
{
    public event EventHandler? CanExecuteChanged
    {
        add => CommandManager.RequerySuggested += value;
        remove => CommandManager.RequerySuggested -= value;
    }

    public bool CanExecute(object? parameter)
    {
        if(canExecute == null) return true;
        
        //if (parameter == null) return true;
        return canExecute.Invoke(parameter);
    }

    public void Execute(object? parameter)
    {
        execute?.Invoke(parameter);
    }
}
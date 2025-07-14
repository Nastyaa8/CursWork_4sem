using System.Windows.Controls;
using BookShop.Mvvm.Helpers;

namespace BookShop.Personal.Views.Base;

public class BaseUserControl : UserControl
{
    public BaseUserControl()
    {
        var name = GetType().Name;
        
        ViewModelManager.Views.Add(UniqueNumber);
        Console.WriteLine($"{name} Init - {UniqueNumber} - {ViewModelManager.Views.Count}");
    }

    public Guid UniqueNumber { get; } = Guid.NewGuid();
    
    ~BaseUserControl()
    {
        var name = GetType().Name;
        
        ViewModelManager.Views.Remove(UniqueNumber);
        Console.WriteLine($"{name} - {UniqueNumber} Destructor - {ViewModelManager.Views.Count}");
    }
}
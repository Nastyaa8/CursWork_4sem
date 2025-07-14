using System.Collections.ObjectModel;

namespace BookShop.Mvvm.Helpers;

public static class ViewModelManager
{
    public static ObservableCollection<Guid> Views { get; set; } = [];
    
    public static ObservableCollection<Guid> ViewModels { get; set; } = [];
}
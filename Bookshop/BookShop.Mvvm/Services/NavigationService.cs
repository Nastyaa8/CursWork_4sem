using BookShop.Mvvm.Base;

namespace BookShop.Mvvm.Services;

public interface INavigationService
{
    ViewModelBase CurrentViewModel { get; }
    
    Task<TViewModel> NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;
}


public class NavigationService(Func<Type, ViewModelBase> viewModelFactory) : ViewModelBase, INavigationService
{
    private ViewModelBase? _currentViewModel;

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        private set => Set(ref _currentViewModel, value);
    }

    public async Task<TViewModel> NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
    {
        var temp = CurrentViewModel;
        var viewModel = viewModelFactory.Invoke(typeof(TViewModel));

        if (temp != null)
        {
            await temp.DisposeAsync();
        }

        CurrentViewModel = viewModel;
        GC.Collect();
        
        return (TViewModel)viewModel;
    }
}
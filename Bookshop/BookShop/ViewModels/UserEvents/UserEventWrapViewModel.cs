using System.Globalization;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.UserEvents;

public class UserEventWrapViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly MainWindowViewModel _mainWindowViewModel;

    /// <inheritdoc />
    public UserEventWrapViewModel(INavigationService navigationService, MainWindowViewModel mainWindowViewModel)
    {
        _navigationService = navigationService;
        _mainWindowViewModel = mainWindowViewModel;

        Title = GetResource("RegisterEvent");
        
        ListCommand.Execute(this);
        _mainWindowViewModel.OnLanguageChanged += MainWindowViewModelOnOnLanguageChanged;
    }
    
    private void MainWindowViewModelOnOnLanguageChanged(object? sender, CultureInfo e)
    {
        Title = GetResource("RegisterEvent");
    }
    
    public RelayCommand ListCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<UserEventsViewModel>();
        await vm.LoadDataAsync();
        CurrentViewModel = vm;
        CurrentViewModel.ParentViewModel = this;
    });
    
    public override ValueTask DisposeAsync()
    {
        _mainWindowViewModel.OnLanguageChanged -= MainWindowViewModelOnOnLanguageChanged;
        return base.DisposeAsync();
    }
}
using System.Globalization;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.Events;

public class EventWrapViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly MainWindowViewModel _mainWindowViewModel;

    /// <inheritdoc />
    public EventWrapViewModel(INavigationService navigationService, MainWindowViewModel mainWindowViewModel)
    {
        _navigationService = navigationService;
        _mainWindowViewModel = mainWindowViewModel;

        Title = GetResource("Events");
        
        ListCommand.Execute(this);
        _mainWindowViewModel.OnLanguageChanged += MainWindowViewModelOnOnLanguageChanged;
    }
    
    private void MainWindowViewModelOnOnLanguageChanged(object? sender, CultureInfo e)
    {
        Title = GetResource("Events");
    }
    
    public RelayCommand ListCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<EventsViewModel>();
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
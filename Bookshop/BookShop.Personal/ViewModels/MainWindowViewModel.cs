using System.Globalization;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Helpers;
using BookShop.Mvvm.Services;
using BookShop.Personal.Stores;
using BookShop.Personal.ViewModels.Base;
using BookShop.Personal.Views;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Personal.ViewModels;

public class MainWindowViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public event EventHandler<CultureInfo> OnLanguageChanged;
    public event EventHandler<EThemeType> OnThemeChanged;
    
    public MainWindowViewModel(INavigationService navigationService, IServiceScopeFactory serviceScopeFactory)
    {
        _navigationService = navigationService;
        _serviceScopeFactory = serviceScopeFactory;
        //_navigationService.NavigateTo<MainViewModel>();

        //CurrentViewModel = _navigationService.CurrentViewModel;

        OnOpenMainViewCommand.Execute(null);
    }

    public RelayCommand OnOpenMainViewCommand => new RelayCommand(async obj =>
    {
        if (CurrentViewModel is not MainViewModel mainViewModel)
        {
            await _navigationService.NavigateToAsync<MainViewModel>();
            CurrentViewModel = _navigationService.CurrentViewModel;
        }
    });

    public RelayCommand ChangeLanguageCommand => new(obj =>
    {
        ApplicationSettings.Language = ApplicationSettings.Language.Name == "ru-RU" ? new CultureInfo("en-US") : new CultureInfo("ru-RU");
        OnLanguageChanged?.Invoke(this, ApplicationSettings.Language);
    });
    
    public RelayCommand ChangeThemeCommand => new(obj =>
    {
        ApplicationSettings.Theme = ApplicationSettings.Theme == EThemeType.Pink ? EThemeType.Blue : EThemeType.Pink;
        OnThemeChanged?.Invoke(this, ApplicationSettings.Theme);
    });
    
    public RelayCommand OpenLoginCommand => new(obj =>
    {
        var scope = _serviceScopeFactory.CreateScope();
        var vm = scope.ServiceProvider.GetRequiredService<LoginWindowViewModel>();
        
        var wnd = scope.ServiceProvider.GetRequiredService<LoginWindow>();
        wnd.DataContext = vm;
        
        wnd.ShowDialog();

        var temp = (BaseViewModel)CurrentViewModel;

        
        if (temp != null)
        {
            IsLogged = temp.IsLogged = UserStore.IsLogged;
            IsAdmin = temp.IsAdmin = UserStore.CurrentUser?.IsAdmin ?? false;
        }

        CurrentViewModel = null;
        CurrentViewModel = temp;
    });
}
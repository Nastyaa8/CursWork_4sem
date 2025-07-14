using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.ViewModels.Base;
using BookShop.ViewModels.Books;
using BookShop.ViewModels.Events;
using BookShop.ViewModels.Orders;
using BookShop.ViewModels.UserEvents;
using BookShop.ViewModels.Users;

namespace BookShop.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;

    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        
    }

    public RelayCommand OpenCatalogCommand => new RelayCommand(async obj =>
    {
        if (CurrentViewModel is not BookWrapViewModel catalogViewModel)
        {
            var vm = await _navigationService.NavigateToAsync<BookWrapViewModel>();
            vm.ParentViewModel = this;
            CurrentViewModel = vm;
        }
    });
    
    public RelayCommand OpenUsersCommand => new RelayCommand(async obj =>
    {
        if (CurrentViewModel is not UserWrapViewModel userWrapViewModel)
        {
            var vm = await _navigationService.NavigateToAsync<UserWrapViewModel>();
            vm.ParentViewModel = this;
            CurrentViewModel = vm;
        }
    });
    
    public RelayCommand OpenEventsCommand => new RelayCommand(async obj =>
    {
        if (CurrentViewModel is not EventWrapViewModel eventWrapViewModel)
        {
            var vm = await _navigationService.NavigateToAsync<EventWrapViewModel>();
            vm.ParentViewModel = this;
            CurrentViewModel = vm;
        }
    });
    
    public RelayCommand OpenOrdersCommand => new RelayCommand(async obj =>
    {
        if (CurrentViewModel is not OrderWrapViewModel orderWrapViewModel)
        {
            var vm = await _navigationService.NavigateToAsync<OrderWrapViewModel>();
            vm.ParentViewModel = this;
            CurrentViewModel = vm;
        }
    });
    
    public RelayCommand OpenUserEventsCommand => new RelayCommand(async obj =>
    {
        if (CurrentViewModel is not UserEventWrapViewModel userEventWrapViewModel)
        {
            var vm = await _navigationService.NavigateToAsync<UserEventWrapViewModel>();
            vm.ParentViewModel = this;
            CurrentViewModel = vm;
        }
    });
}
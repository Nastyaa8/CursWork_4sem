using System.Collections.ObjectModel;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.Stores;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.UserEvents;

/// <summary>
/// 
/// </summary>
public class UserEventsViewModel : BaseViewModel
{
    private readonly IUserEventRepository _userEventRepository;
    private readonly INavigationService _navigationService;

    public UserEventsViewModel(IUserEventRepository userEventRepository, INavigationService navigationService)
    {
        _userEventRepository = userEventRepository;
        _navigationService = navigationService;
        Title = "Список зарегистрированых мероприятий";
    }

    private ObservableCollection<UserEvent> _items = [];
    private UserEvent? _selectedItem;

    /// <summary>
    /// 
    /// </summary>
    public ObservableCollection<UserEvent> Items
    {
        get => _items;
        set => Set(ref _items, value);
    }

    public UserEvent? SelectedItem
    {
        get => _selectedItem;
        set => Set(ref _selectedItem, value);
    }
    
    public RelayCommand AddCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<AddUserEventViewModel>();

        if (ParentViewModel != null)
        {
            await vm.LoadDataAsync();
            ParentViewModel.CurrentViewModel = vm;
            _navigationService.CurrentViewModel.ParentViewModel = this;
        }
    });
    
    public RelayCommand DeleteCommand => new(async obj =>
    {
        if (SelectedItem != null)
        {
            var result = MessageBox.Show(Application.Current.Resources["DeleteQuestion"] as string,
                Application.Current.Resources["DeleteTitle"] as string, MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result.Equals(MessageBoxResult.Yes))
            {
                _userEventRepository.Delete(SelectedItem);
                Items.Remove(SelectedItem);
            }
        }
        
    }, _ => SelectedItem != null);
    
    
    public override Task LoadDataAsync()
    {
        Items = new ObservableCollection<UserEvent>(_userEventRepository.GetAllByUserId(UserStore.CurrentUser!.Id));
        return base.LoadDataAsync();
    }
}
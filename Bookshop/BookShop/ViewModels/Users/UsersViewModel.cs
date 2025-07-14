using System.Collections.ObjectModel;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.Users;

/// <summary>
/// 
/// </summary>
public class UsersViewModel : BaseViewModel
{
    private readonly IUserRepository _userRepository;
    private readonly INavigationService _navigationService;

    public UsersViewModel(IUserRepository userRepository, INavigationService navigationService)
    {
        _userRepository = userRepository;
        _navigationService = navigationService;
        Title = "Список пользователей";
    }

    private ObservableCollection<User> _items = [];
    private User? _selectedItem;

    /// <summary>
    /// 
    /// </summary>
    public ObservableCollection<User> Items
    {
        get => _items;
        set => Set(ref _items, value);
    }

    public User? SelectedItem
    {
        get => _selectedItem;
        set => Set(ref _selectedItem, value);
    }
    
    public RelayCommand AddCommand => new(async obj =>
    {
        if (ParentViewModel != null)
        {
            var vm = await _navigationService.NavigateToAsync<AddUserViewModel>();
            
            await vm.LoadDataAsync();
            ParentViewModel.CurrentViewModel = vm;
            vm.ParentViewModel = this;
            //_navigationService.CurrentViewModel.ParentViewModel = this;
        }
    });
    
    public RelayCommand EditCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<AddUserViewModel>();
        
        if (ParentViewModel != null)
        {
            vm.IsEdit = true;
            vm.User.Id = SelectedItem?.Id ?? 0;
            await vm.LoadDataAsync();
            ParentViewModel.CurrentViewModel = vm;
            _navigationService.CurrentViewModel.ParentViewModel = this;
        }
    }, _ => SelectedItem != null);
    
    public RelayCommand DeleteCommand => new(async obj =>
    {
        if (SelectedItem != null)
        {
            var result = MessageBox.Show(Application.Current.Resources["DeleteQuestion"] as string,
                Application.Current.Resources["DeleteTitle"] as string, MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result.Equals(MessageBoxResult.Yes))
            {
                _userRepository.Delete(SelectedItem);
                Items.Remove(SelectedItem);
            }
        }
        
    }, _ => SelectedItem != null);


    public override Task LoadDataAsync()
    {
        Items = new ObservableCollection<User>(_userRepository.GetAll());
        return base.LoadDataAsync();
    }
}
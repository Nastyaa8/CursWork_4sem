using System.Collections.ObjectModel;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.Stores;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels;

public class CartViewModel : BaseViewModel
{
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly INavigationService _navigationService;
    private readonly IOrderRepository _orderRepository;
    private ObservableCollection<ExtendedOrderItem> _items = [];
    private ExtendedOrderItem? _selectedItem;

    public CartViewModel(MainWindowViewModel mainWindowViewModel, INavigationService navigationService, IOrderRepository orderRepository)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _navigationService = navigationService;
        _orderRepository = orderRepository;
    }

    public ObservableCollection<ExtendedOrderItem> Items
    {
        get => _items;
        set => Set(ref _items, value);
    }

    public ExtendedOrderItem? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (Equals(value, _selectedItem)) return;
            _selectedItem = value;
            OnPropertyChanged();
        }
    }

    public RelayCommand ProcessOrderCommand => new RelayCommand(async obj =>
    {
        try
        {
            var order = new Order
            {
                Date = DateTime.Now,
                UserId = UserStore.CurrentUser!.Id,
                User = UserStore.CurrentUser,
                Status = "Оформлен",
                TotalPrice = Items.Sum(x => x.TotalPrice)
            };
            
            _orderRepository.Add(order);
            
            MessageBox.Show(order.Id.ToString());

            Items.Clear();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }, _ => Items.Count > 0);
    
    public RelayCommand DeleteCommand => new RelayCommand(async obj =>
    {
        if (SelectedItem != null)
        {
            var result = MessageBox.Show("Удалить позицию из корзины?", "Удаление из корзины", MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result.Equals(MessageBoxResult.Yes))
            {
                Items.Remove(SelectedItem);
            }
        }
    }, _ => SelectedItem != null);

    public RelayCommand CancelCommand => new RelayCommand(async obj =>
    {
        if (Items.Count > 0)
        {
            var result = MessageBox.Show("Отменить заказ?", "Отмена заказа", MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result.Equals(MessageBoxResult.Yes))
            {
                Items.Clear();
            }
        }
    }, _ => Items.Count > 0);
    
    public RelayCommand BackCommand => new RelayCommand(async obj =>
    {
        if (CurrentViewModel is not MainViewModel mainViewModel)
        {
            var vm = await _navigationService.NavigateToAsync<MainViewModel>();
            vm.ParentViewModel = _mainWindowViewModel;
            _mainWindowViewModel.CurrentViewModel = vm;
        }
    });
}

public class ExtendedOrderItem : OrderItem
{
    public decimal TotalPrice { get; set; }
}
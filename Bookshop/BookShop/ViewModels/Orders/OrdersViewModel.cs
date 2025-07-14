using System.Collections.ObjectModel;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.Stores;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.Orders;

/// <summary>
/// 
/// </summary>
public class OrdersViewModel : BaseViewModel
{
    private readonly IOrderRepository _orderRepository;
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly INavigationService _navigationService;

    public OrdersViewModel(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, INavigationService navigationService)
    {
        _orderRepository = orderRepository;
        _orderItemRepository = orderItemRepository;
        _navigationService = navigationService;
        Title = "Список заказов";
    }

    private ObservableCollection<Order> _items = [];
    private Order? _selectedItem;

    /// <summary>
    /// 
    /// </summary>
    public ObservableCollection<Order> Items
    {
        get => _items;
        set => Set(ref _items, value);
    }

    public Order? SelectedItem
    {
        get => _selectedItem;
        set => Set(ref _selectedItem, value);
    }
    
    public RelayCommand EditCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<EditOrderViewModel>();

        if (ParentViewModel != null)
        {
            vm.Entity.Id = SelectedItem!.Id;
            await vm.LoadDataAsync();
            ParentViewModel.CurrentViewModel = vm;
            _navigationService.CurrentViewModel.ParentViewModel = this;
        }
    }, _ => SelectedItem != null);
    
    public RelayCommand DeleteCommand => new(async obj =>
    {
        try
        {
            if (SelectedItem != null)
            {
                var result = MessageBox.Show(Application.Current.Resources["DeleteQuestion"] as string,
                    Application.Current.Resources["DeleteTitle"] as string, MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result.Equals(MessageBoxResult.Yes))
                {
                    _orderItemRepository.DeleteByOrderId(SelectedItem.Id);
                    _orderRepository.Delete(SelectedItem);

                    Items.Remove(SelectedItem);
                }
            }
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }

    }, _ => SelectedItem != null);


    public override Task LoadDataAsync()
    {
        if (!IsAdmin)
        {
            Title = "Мои заказы";
        }

        Items = new ObservableCollection<Order>(IsAdmin
            ? _orderRepository.GetAll()
            : _orderRepository.GetAllByUserId(UserStore.CurrentUser!.Id));

        return base.LoadDataAsync();
    }
}
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Helpers;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.Orders;

public class EditOrderViewModel : BaseViewModel
{
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly IOrderRepository _orderRepository;
    private readonly IReferencesRepository _referencesRepository;
    private OrderViewModel _entity = null!;
    private ObservableCollection<Reference> _statuses = [];
    private Reference? _selectedStatus;

    public EditOrderViewModel(MainWindowViewModel mainWindowViewModel, IOrderRepository orderRepository, IReferencesRepository referencesRepository)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _orderRepository = orderRepository;
        _referencesRepository = referencesRepository;

        Title = "Изменить состояние заказа";
        Entity = new OrderViewModel();
        
        _mainWindowViewModel.OnLanguageChanged += MainWindowViewModelOnOnLanguageChanged;
    }

    private void MainWindowViewModelOnOnLanguageChanged(object? sender, CultureInfo e)
    {
        var temp = SelectedStatus;

        Statuses = new ObservableCollection<Reference>(_referencesRepository.GetStatuses(e));

        if (temp != null)
        {
            SelectedStatus = Statuses.FirstOrDefault(x => x.Id == temp.Id);
        }
    }

    public OrderViewModel Entity
    {
        get => _entity;
        set => Set(ref _entity, value);
    }

    public ObservableCollection<Reference> Statuses
    {
        get => _statuses;
        set => Set(ref _statuses, value);
    }

    public Reference? SelectedStatus
    {
        get => _selectedStatus;
        set
        {
            if (Set(ref _selectedStatus, value))
            {
                if (value != null)
                {
                    Entity.Status = value.Name;
                }
            }
        }
    }

    public RelayCommand BackCommand => new(async obj =>
    {
        ReturnToParent<OrderWrapViewModel>();
    });
    
    public RelayCommand SaveCommand => new(async obj =>
    {
        try
        {
            var entity = new Order
            {
                Id = Entity.Id,
                User = Entity.User,
                UserId = Entity.User.Id,
                TotalPrice = Entity.TotalPrice,
                Date = Entity.Date,
                Status = Entity.Status!,
            };

            _orderRepository.Update(entity);

            if (ParentViewModel != null)
            {
                var ordersViewModel = (OrdersViewModel)ParentViewModel;

                if (ordersViewModel.SelectedItem != null)
                {
                    ordersViewModel.SelectedItem.Status = entity.Status;
                }
            }

            ReturnToParent<OrderWrapViewModel>();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }, _ => !Entity.HasErrors);

    public override Task LoadDataAsync()
    {
        Statuses = new ObservableCollection<Reference>(_referencesRepository.GetStatuses(ApplicationSettings.Language));
        
        var entity = _orderRepository.GetById(Entity.Id);

        if (entity != null)
        {
            SelectedStatus = Statuses.FirstOrDefault(x => x.Name == entity.Status);
                
            Entity = new OrderViewModel
            {
                Id = entity.Id,
                User = entity.User,
                Date = entity.Date,
                TotalPrice = entity.TotalPrice,
                Status = SelectedStatus?.Name,
            };
        }
        
        return Task.CompletedTask;
    }

    public override ValueTask DisposeAsync()
    {
        _mainWindowViewModel.OnLanguageChanged -= MainWindowViewModelOnOnLanguageChanged;
        return base.DisposeAsync();
    }
}

public class OrderViewModel : ViewModelBase
{
    private int _id;
    private string? _status;

    public int Id
    {
        get => _id;
        set => Set(ref _id, value);
    }
    
    public User User { get; set; } = null!;
    
    public DateTime Date { get; set; }
    
    public decimal TotalPrice { get; set; }

    public string? Status
    {
        get => _status;
        set => Set(ref _status, value);
    }
}
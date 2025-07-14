using System.Collections.ObjectModel;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.Events;

/// <summary>
/// 
/// </summary>
public class EventsViewModel : BaseViewModel
{
    private readonly IEventRepository _eventRepository;
    private readonly INavigationService _navigationService;

    public EventsViewModel(IEventRepository eventRepository, INavigationService navigationService)
    {
        _eventRepository = eventRepository;
        _navigationService = navigationService;
        Title = "Список мероприятий";
    }

    private ObservableCollection<Event> _items = [];
    private Event? _selectedItem;

    /// <summary>
    /// 
    /// </summary>
    public ObservableCollection<Event> Items
    {
        get => _items;
        set => Set(ref _items, value);
    }

    public Event? SelectedItem
    {
        get => _selectedItem;
        set => Set(ref _selectedItem, value);
    }
    
    public RelayCommand AddCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<AddEventViewModel>();

        if (ParentViewModel != null)
        {
            await vm.LoadDataAsync();
            ParentViewModel.CurrentViewModel = vm;
            _navigationService.CurrentViewModel.ParentViewModel = this;
        }
    });
    
    public RelayCommand EditCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<AddEventViewModel>();
        
        if (ParentViewModel != null)
        {
            vm.IsEdit = true;
            vm.Entity.Id = SelectedItem?.Id ?? 0;
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
                _eventRepository.Delete(SelectedItem);
                Items.Remove(SelectedItem);
            }
        }
        
    }, _ => SelectedItem != null);
    
    
    public override Task LoadDataAsync()
    {
        Items = new ObservableCollection<Event>(_eventRepository.GetAll());
        return base.LoadDataAsync();
    }
}
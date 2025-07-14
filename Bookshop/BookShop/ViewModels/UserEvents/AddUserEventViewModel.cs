using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.Stores;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.UserEvents;

public class AddUserEventViewModel : BaseViewModel
{
    private readonly IEventRepository _eventRepository;
    private readonly IUserEventRepository _userEventRepository;
    private UserEventViewModel _entity = null!;
    private ObservableCollection<Event> _events = [];

    public AddUserEventViewModel(IEventRepository eventRepository, IUserEventRepository userEventRepository)
    {
        _eventRepository = eventRepository;
        _userEventRepository = userEventRepository;

        Title = "Звписаться на мероприятие";
        Entity = new UserEventViewModel();

        Entity.User = UserStore.CurrentUser!;
    }

    public UserEventViewModel Entity
    {
        get => _entity;
        set => Set(ref _entity, value);
    }

    public ObservableCollection<Event> Events
    {
        get => _events;
        set => Set(ref _events, value);
    }

    public RelayCommand BackCommand => new(async obj =>
    {
        ReturnToParent<UserEventWrapViewModel>();
    });
    
    public RelayCommand SaveCommand => new(async obj =>
    {
        try
        {
            var entity = new UserEvent
            {
                Id = Entity.Id,
                UserId = Entity.User.Id,
                User = Entity.User,
                EventId = Entity.Event!.Id,
                Event = Entity.Event
            };

            _userEventRepository.Add(entity);

            if (ParentViewModel != null)
            {
                var booksViewModel = (UserEventsViewModel)ParentViewModel;
                booksViewModel.Items.Add(entity);
                booksViewModel.SelectedItem = entity;
            }

            ReturnToParent<UserEventWrapViewModel>();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }, _ => !Entity.HasErrors);

    public override Task LoadDataAsync()
    {
        Events = new ObservableCollection<Event>(_eventRepository.GetAvailableEvents(Entity.User.Id));
        return Task.CompletedTask;
    }

    public override ValueTask DisposeAsync()
    {
        return base.DisposeAsync();
    }
}

public class UserEventViewModel : ViewModelBase
{
    private int _id;
    private Event? _event;

    public int Id
    {
        get => _id;
        set => Set(ref _id, value);
    }
    
    public User User { get; set; } = null!;

    /// <summary>
    /// 
    /// </summary>
    [Required(ErrorMessage = "Выберите мероприятие")]
    public Event? Event
    {
        get => _event;
        set => Set(ref _event, value);
    }
}
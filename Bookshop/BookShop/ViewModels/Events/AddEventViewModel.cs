using System.ComponentModel.DataAnnotations;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.Events;

public class AddEventViewModel : BaseViewModel
{
    private readonly IEventRepository _eventRepository;
    private bool _isEdit;
    private EventViewModel _entity = null!;

    public AddEventViewModel(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
        
        Title = "Добавить новое мероприятие";
        Entity = new EventViewModel();
    }

    public bool IsEdit
    {
        get => _isEdit;
        set => Set(ref _isEdit, value);
    }

    public EventViewModel Entity
    {
        get => _entity;
        set => Set(ref _entity, value);
    }
    
    public RelayCommand BackCommand => new(async obj =>
    {
        ReturnToParent<EventWrapViewModel>();
    });
    
    public RelayCommand SaveCommand => new(async obj =>
    {
        try
        {
            var entity = new Event
            {
                Id = Entity.Id,
                Name = Entity.Name!,
                Description = Entity.Description,
                Location = Entity.Location!,
                Date = Entity.Date ?? DateTime.Now,
            };

            if (IsEdit)
            {
                _eventRepository.Update(entity);
                
                if (ParentViewModel != null)
                {
                    var booksViewModel = (EventsViewModel)ParentViewModel;

                    if (booksViewModel.SelectedItem != null)
                    {
                        booksViewModel.SelectedItem.Name = entity.Name;
                        booksViewModel.SelectedItem.Date = entity.Date;
                        booksViewModel.SelectedItem.Description = entity.Description;
                        booksViewModel.SelectedItem.Location = entity.Location;
                    }
                }
            }
            else
            {
                _eventRepository.Add(entity);

                if (ParentViewModel != null)
                {
                    var booksViewModel = (EventsViewModel)ParentViewModel;
                    booksViewModel.Items.Add(entity);
                    booksViewModel.SelectedItem = entity;
                }
            }

            ReturnToParent<EventWrapViewModel>();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }, _ => !Entity.HasErrors);

    public override Task LoadDataAsync()
    {
        if (IsEdit)
        {
            Title = "Редактировать мероприятие";

            var entity = _eventRepository.GetById(Entity.Id);

            if (entity != null)
            {
                Entity = new EventViewModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Description = entity.Description,
                    Date = entity.Date,
                    Location = entity.Location
                };
            }
        }
        
        return Task.CompletedTask;
    }

    public override ValueTask DisposeAsync()
    {
        return base.DisposeAsync();
    }
}

public class EventViewModel : ViewModelBase
{
    private int _id;
    private string? _name;
    private string? _description;
    private string? _location;
    private DateTime? _date;

    public int Id
    {
        get => _id;
        set => Set(ref _id, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public string? Name
    {
        get => _name;
        set => Set(ref _name, value);
    }

    public string? Description
    {
        get => _description;
        set => Set(ref _description, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public DateTime? Date
    {
        get => _date;
        set => Set(ref _date, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public string? Location
    {
        get => _location;
        set => Set(ref _location, value);
    }
}
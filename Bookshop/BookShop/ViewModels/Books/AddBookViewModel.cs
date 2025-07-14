using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Helpers;
using BookShop.ViewModels.Base;
using Microsoft.Win32;

namespace BookShop.ViewModels.Books;

public class AddBookViewModel : BaseViewModel
{
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly IBookRepository _bookRepository;
    private readonly IReferencesRepository _referencesRepository;
    private bool _isEdit;
    private BookViewModel _entity = null!;
    private ObservableCollection<Reference> _genres = null!;
    private Reference? _selectedGenre;

    public AddBookViewModel(MainWindowViewModel mainWindowViewModel, IBookRepository bookRepository, IReferencesRepository referencesRepository)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _bookRepository = bookRepository;
        _referencesRepository = referencesRepository;
        
        Title = "Добавитьть новую книгу";
        Entity = new BookViewModel();
        
        _mainWindowViewModel.OnLanguageChanged += MainWindowViewModelOnOnLanguageChanged;
    }

    private void MainWindowViewModelOnOnLanguageChanged(object? sender, CultureInfo e)
    {
        var temp = SelectedGenre;

        Genres = new ObservableCollection<Reference>(_referencesRepository.GetGenres(e));

        if (temp != null)
        {
            SelectedGenre = Genres.FirstOrDefault(x => x.Id == temp.Id);
        }
    }

    public bool IsEdit
    {
        get => _isEdit;
        set => Set(ref _isEdit, value);
    }

    public BookViewModel Entity
    {
        get => _entity;
        set => Set(ref _entity, value);
    }

    /// <summary>
    /// 
    /// </summary>
    public ObservableCollection<Reference> Genres
    {
        get => _genres;
        set => Set(ref _genres, value);
    }

    public Reference? SelectedGenre
    {
        get => _selectedGenre;
        set
        {
            if (Set(ref _selectedGenre, value))
            {
                if (value != null)
                {
                    Entity.Genre = value.Name;
                }
            }
        }
    }

    public RelayCommand SelectImageCommand => new(async obj =>
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "JPG|*.jpg|PNG|*.png|GIF|*.gif";
        
        var result = openFileDialog.ShowDialog();

        if (result == true)
        {
            var fileName = openFileDialog.FileName;
            
            var appPath = AppDomain.CurrentDomain.BaseDirectory;
            //var newFileName = Path.GetFileName(fileName);
            var extension = Path.GetExtension(fileName);
            var newFileName = $"{Guid.NewGuid().ToString()}{extension}";
            var newImgPath = Path.Combine(appPath, "Images", newFileName);

            if (File.Exists(fileName))
            {
                File.Copy(fileName, newImgPath, true);

                Entity.Image = newFileName;
            }
        }
    });
    
    public RelayCommand BackCommand => new(async obj =>
    {
        ReturnToParent<BookWrapViewModel>();
    });
    
    public RelayCommand SaveCommand => new(async obj =>
    {
        try
        {
            var entity = new Book
            {
                Id = Entity.Id,
                Name = Entity.Name!,
                Author = Entity.Author!,
                Genre = Entity.Genre!,
                Price = Convert.ToDecimal(Entity.Price!),
                Image = Entity.Image!,
                Available = Entity.Available,
                Description = Entity.Description
            };

            if (IsEdit)
            {
                _bookRepository.Update(entity);
                
                if (ParentViewModel != null)
                {
                    var booksViewModel = (BooksViewModel)ParentViewModel;

                    if (booksViewModel.SelectedItem != null)
                    {
                        booksViewModel.SelectedItem.Name = entity.Name;
                        booksViewModel.SelectedItem.Author = entity.Author;
                        booksViewModel.SelectedItem.Genre = entity.Genre;
                        booksViewModel.SelectedItem.Price = entity.Price;
                        booksViewModel.SelectedItem.Image = entity.Image;
                        booksViewModel.SelectedItem.Available = entity.Available;
                        booksViewModel.SelectedItem.Description = entity.Description;
                    }
                }
            }
            else
            {
                _bookRepository.Add(entity);

                if (ParentViewModel != null)
                {
                    var booksViewModel = (BooksViewModel)ParentViewModel;
                    booksViewModel.Items.Add(entity);
                    booksViewModel.SelectedItem = entity;
                }
            }

            ReturnToParent<BookWrapViewModel>();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }, _ => !Entity.HasErrors);

    public override Task LoadDataAsync()
    {
        Genres = new ObservableCollection<Reference>(_referencesRepository.GetGenres(ApplicationSettings.Language));
        
        if (IsEdit)
        {
            Title = "Редактировать книгу";

            var entity = _bookRepository.GetById(Entity.Id);

            if (entity != null)
            {
                SelectedGenre = Genres.FirstOrDefault(x => x.Name == entity.Genre);
                
                Entity = new BookViewModel
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    Author = entity.Author,
                    Genre = SelectedGenre?.Name,
                    Price = entity.Price.ToString(),
                    Available =  entity.Available,
                    Image = entity.Image,
                    Description = entity.Description
                };
            }
        }
        
        return Task.CompletedTask;
    }

    public override ValueTask DisposeAsync()
    {
        _mainWindowViewModel.OnLanguageChanged -= MainWindowViewModelOnOnLanguageChanged;
        return base.DisposeAsync();
    }
}

public class BookViewModel : ViewModelBase
{
    private int _id;
    private string? _name;
    private string? _author;
    private string? _genre;
    private string? _price;
    private string? _image;
    private bool _available;
    private string? _description;

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

    [Required(ErrorMessage = "Поле обязательно")]
    public string? Author
    {
        get => _author;
        set => Set(ref _author, value);
    }

    [Required(ErrorMessage = "Поле обязательно", AllowEmptyStrings = false)]
    public string? Genre
    {
        get => _genre;
        set => Set(ref _genre, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть в диапазоне от 0.01 до 100000000.00")]
    public string? Price
    {
        get => _price;
        set => Set(ref _price, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public string? Image
    {
        get => _image;
        set => Set(ref _image, value);
    }

    public bool Available
    {
        get => _available;
        set => Set(ref _available, value);
    }

    public string? Description
    {
        get => _description;
        set => Set(ref _description, value);
    }
}
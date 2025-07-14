using System.Globalization;
using System.Windows;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Commands;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.Books;

public class BookInfoViewModel : BaseViewModel
{
    private readonly CartViewModel _cartViewModel;
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly IBookRepository _bookRepository;
    private readonly IReferencesRepository _referencesRepository;
    private BookViewModel _entity = null!;

    public BookInfoViewModel(CartViewModel cartViewModel, MainWindowViewModel mainWindowViewModel, IBookRepository bookRepository, IReferencesRepository referencesRepository)
    {
        _cartViewModel = cartViewModel;
        _mainWindowViewModel = mainWindowViewModel;
        _bookRepository = bookRepository;
        _referencesRepository = referencesRepository;
        
        Title = "Информация о книге";
        Entity = new BookViewModel();
        
        _mainWindowViewModel.OnLanguageChanged += MainWindowViewModelOnOnLanguageChanged;
    }

    private void MainWindowViewModelOnOnLanguageChanged(object? sender, CultureInfo e)
    {
    }

    public BookViewModel Entity
    {
        get => _entity;
        set => Set(ref _entity, value);
    }
    
    public RelayCommand BackCommand => new(async obj =>
    {
        ReturnToParent<BookWrapViewModel>();
    });

    public RelayCommand AddToCartCommand => new(async obj =>
    {
        if (!IsLogged)
        {
            MessageBox.Show("Чтобы товар добавить в корзину необходимо войти в систему");
        }
        else
        {
            if (Entity != null)
            {
                var result = MessageBox.Show("Добавить книгу в козину?", "Добавление книги в корзину",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result.Equals(MessageBoxResult.Yes))
                {
                    var item = _cartViewModel.Items.FirstOrDefault(x => x.BookId == Entity.Id);

                    if (item != null)
                    {
                        item.Quantity++;
                        item.TotalPrice = item.Quantity * item.Book.Price;
                    }
                    else
                    {
                        item = new ExtendedOrderItem
                        {
                            BookId = Entity.Id,
                            Book = new Data.Models.Book
                            {
                                Id = Entity.Id,
                                Author = Entity.Author!,
                                Available = Entity.Available,
                                Genre = Entity.Genre!,
                                Image = Entity.Image!,
                                Name = Entity.Name!,
                                Price = Convert.ToDecimal(Entity.Price!)
                            },
                            Quantity = 1,
                            TotalPrice = 1 * Convert.ToDecimal(Entity.Price)
                        };

                        _cartViewModel.Items.Add(item);
                    }
                }
            }
        }

    }, _ =>  true);

    public override Task LoadDataAsync()
    {
        //Genres = new ObservableCollection<Reference>(_referencesRepository.GetGenres(App.Language));

        var entity = _bookRepository.GetById(Entity.Id);

        if (entity != null)
        {
            //SelectedGenre = Genres.FirstOrDefault(x => x.Name == entity.Genre);

            Entity = new BookViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                Author = entity.Author,
                Genre = entity.Genre,
                Price = entity.Price.ToString(),
                Available = entity.Available,
                Image = entity.Image,
                Description = entity.Description
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
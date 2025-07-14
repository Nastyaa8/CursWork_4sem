using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Helpers;
using BookShop.Mvvm.Services;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.Books;

/// <summary>
/// 
/// </summary>
public class BooksViewModel : BaseViewModel
{
    private readonly IBookRepository _bookRepository;
    private readonly INavigationService _navigationService;
    private readonly CartViewModel _cartViewModel;
    private readonly IReferencesRepository _referencesRepository;

    public BooksViewModel(IBookRepository bookRepository, INavigationService navigationService, CartViewModel cartViewModel, IReferencesRepository referencesRepository)
    {
        _bookRepository = bookRepository;
        _navigationService = navigationService;
        _cartViewModel = cartViewModel;
        _referencesRepository = referencesRepository;
        Title = "Список книг";
    }

    private ObservableCollection<Book> _items = [];
    private Book? _selectedItem;
    private string? _searchText;
    private ICollectionView _filterItems;
    private string? _maxPrice;
    private string? _minPrice;
    private ObservableCollection<Reference> _genres;
    private Reference? _selectedGenre;
    private bool? _isAvailable;

    /// <summary>
    /// 
    /// </summary>
    public ObservableCollection<Book> Items
    {
        get => _items;
        set => Set(ref _items, value);
    }

    public ICollectionView FilterItems
    {
        get => _filterItems;
        set => Set(ref _filterItems, value);
    }

    public Book? SelectedItem
    {
        get => _selectedItem;
        set => Set(ref _selectedItem, value);
    }

    public string? SearchText
    {
        get => _searchText;
        set => Set(ref _searchText, value);
    }

    public string? MinPrice
    {
        get => _minPrice;
        set => Set(ref _minPrice, value);
    }


    public string? MaxPrice
    {
        get => _maxPrice;
        set => Set(ref _maxPrice, value);
    }

    public ObservableCollection<Reference> Genres
    {
        get => _genres;
        set => Set(ref _genres, value);
    }

    public Reference? SelectedGenre
    {
        get => _selectedGenre;
        set => Set(ref _selectedGenre, value);
    }

    public bool? IsAvailable
    {
        get => _isAvailable;
        set => Set(ref _isAvailable, value);
    }

    public RelayCommand ApplyFilterCommand => new(async obj =>
    {
        try
        {
            // var minPrice = decimal.Parse(MinPrice, CultureInfo.InvariantCulture);
            // var maxPrice = decimal.Parse(MinPrice, CultureInfo.InvariantCulture);
            
            FilterItems.Filter = o =>
            {
                var bookItem = o as Book;

                if (bookItem == null)
                {
                    return bookItem == null;
                }

                var result = string.IsNullOrEmpty(SearchText) || bookItem.Name.Contains(SearchText, StringComparison.CurrentCultureIgnoreCase);
                
                if (!string.IsNullOrEmpty(MinPrice) && !string.IsNullOrEmpty(MaxPrice))
                {
                    var minPrice = decimal.Parse(MinPrice, CultureInfo.InvariantCulture);
                    var maxPrice = decimal.Parse(MaxPrice, CultureInfo.InvariantCulture);

                    result = result && (bookItem.Price >= minPrice && bookItem.Price <= maxPrice);
                }
                else if(!string.IsNullOrEmpty(MinPrice) && string.IsNullOrEmpty(MaxPrice))
                {
                    var minPrice = decimal.Parse(MinPrice, CultureInfo.InvariantCulture);
                    result = result && bookItem.Price >= minPrice;
                }
                else if (string.IsNullOrEmpty(MinPrice) && !string.IsNullOrEmpty(MaxPrice))
                {
                    var maxPrice = decimal.Parse(MaxPrice, CultureInfo.InvariantCulture);
                    result = result && bookItem.Price <= maxPrice;
                }

                if (SelectedGenre == null)
                {
                    result = result && SelectedGenre == null;
                }
                else
                {
                    if (SelectedGenre.Id != 1)
                    {
                        result = result && bookItem.Genre.Equals(SelectedGenre.Name, StringComparison.CurrentCultureIgnoreCase);
                    }
                }
                
                if (IsAvailable == null)
                {
                    result = result && IsAvailable == null;
                }
                else
                {
                    result = result && bookItem.Available == IsAvailable;
                }
                
                return result;
            };
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    });
    
    public RelayCommand ClearFilterCommand => new(async obj =>
    {
        SearchText = string.Empty;
        MinPrice = string.Empty;
        MaxPrice = string.Empty;
        IsAvailable = null;
        SearchText = null;
        
        FilterItems.Filter = null;
        FilterItems.Refresh();
    });
    
    public RelayCommand AddCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<AddBookViewModel>();

        if (ParentViewModel != null)
        {
            await vm.LoadDataAsync();
            ParentViewModel.CurrentViewModel = vm;
            _navigationService.CurrentViewModel.ParentViewModel = this;
        }
    });
    
    public RelayCommand EditCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<AddBookViewModel>();
        
        if (ParentViewModel != null)
        {
            vm.IsEdit = true;
            vm.Entity.Id = SelectedItem?.Id ?? 0;
            await vm.LoadDataAsync();
            ParentViewModel.CurrentViewModel = vm;
            _navigationService.CurrentViewModel.ParentViewModel = this;
        }
    }, _ => SelectedItem != null);

    public RelayCommand ViewCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<BookInfoViewModel>();

        if (ParentViewModel != null)
        {
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
                _bookRepository.Delete(SelectedItem);
                Items.Remove(SelectedItem);
            }
        }
        
    }, _ => SelectedItem != null);
    
    public RelayCommand AddToCartCommand => new(async obj =>
    {
        if (!IsLogged)
        {
            MessageBox.Show("Чтобы товар добавить в корзину необходимо войти в систему");
        }
        else 
        {
            if (SelectedItem != null)
            {
                var result = MessageBox.Show("Добавить книгу в козину?", "Добавление книги в корзину",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (result.Equals(MessageBoxResult.Yes))
                {
                    var item = _cartViewModel.Items.FirstOrDefault(x => x.BookId == SelectedItem.Id);

                    if (item != null)
                    {
                        item.Quantity++;
                        item.TotalPrice = item.Quantity * item.Book.Price;
                    }
                    else
                    {
                        item = new ExtendedOrderItem
                        {
                            BookId = SelectedItem.Id,
                            Book = SelectedItem,
                            Quantity = 1,
                            TotalPrice = 1 * SelectedItem.Price
                        };

                        _cartViewModel.Items.Add(item);
                    }
                }
            }
        }

    }, _ => SelectedItem != null); 
    
    public override Task LoadDataAsync()
    {
        Genres = new ObservableCollection<Reference>(_referencesRepository.GetGenres(ApplicationSettings.Language));
        Items = new ObservableCollection<Data.Models.Book>(_bookRepository.GetAll());
        FilterItems = CollectionViewSource.GetDefaultView(Items);
        
        return base.LoadDataAsync();
    }
}
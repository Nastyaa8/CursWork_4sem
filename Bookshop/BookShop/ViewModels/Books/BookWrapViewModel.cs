using System.Globalization;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.Books;

public class BookWrapViewModel : BaseViewModel
{
    private readonly INavigationService _navigationService;
    private readonly MainWindowViewModel _mainWindowViewModel;

    /// <inheritdoc />
    public BookWrapViewModel(INavigationService navigationService, MainWindowViewModel mainWindowViewModel)
    {
        _navigationService = navigationService;
        _mainWindowViewModel = mainWindowViewModel;

        Title = GetResource("Catalog");
        
        ListCommand.Execute(this);
        
        _mainWindowViewModel.OnLanguageChanged += MainWindowViewModelOnOnLanguageChanged;
    }

    private void MainWindowViewModelOnOnLanguageChanged(object? sender, CultureInfo e)
    {
        Title = GetResource("Catalog");
    }


    public RelayCommand ListCommand => new(async obj =>
    {
        var vm = await _navigationService.NavigateToAsync<BooksViewModel>();
        await vm.LoadDataAsync();
        CurrentViewModel = vm;
        CurrentViewModel.ParentViewModel = this;
    });

    public override ValueTask DisposeAsync()
    {
        _mainWindowViewModel.OnLanguageChanged -= MainWindowViewModelOnOnLanguageChanged;
        return base.DisposeAsync();
    }
}
using BookShop.Mvvm.Base;
using BookShop.Personal.Stores;

namespace BookShop.Personal.ViewModels.Base;

public abstract class BaseViewModel : ViewModelBase
{
    public BaseViewModel()
    {
        IsLogged = UserStore.IsLogged;
        if (UserStore.CurrentUser != null)
        {
            IsAdmin = UserStore.CurrentUser.IsAdmin;
        }
    }

    public bool IsLogged
    {
        get
        {
            _isLogged = UserStore.IsLogged;
            return _isLogged;
        }
        set => Set(ref _isLogged, value);
    }

    private bool _isAdmin;
    
    public bool IsAdmin
    {
        get => _isAdmin;
        set => Set(ref _isAdmin, value);
    }
    
    
    private bool _isLogged;
}
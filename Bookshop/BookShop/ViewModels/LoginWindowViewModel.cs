using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.Stores;
using BookShop.ViewModels.Base;
using BookShop.Views;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.ViewModels;

public class LoginWindowViewModel : BaseViewModel
{
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly INavigationService _navigationService;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IUserRepository _userRepository;
    private string _username;
    private string _password;

    public LoginWindowViewModel(MainWindowViewModel mainWindowViewModel, INavigationService navigationService, IServiceScopeFactory scopeFactory, IUserRepository userRepository)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _navigationService = navigationService;
        _scopeFactory = scopeFactory;
        _userRepository = userRepository;
    }

    [Required(ErrorMessage = "Username is required")]
    public string Username
    {
        get => _username;
        set => Set(ref _username, value);
    }

    [Required(ErrorMessage = "Password is required")]
    public string Password
    {
        get => _password;
        set => Set(ref _password, value);
    }

    public RelayCommand LoginCommand => new RelayCommand(async obj =>
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            
        }

        var user = _userRepository.GetUserByLoginOrEmail(Username);
        
        if (user != null)
        {
            var inputPasswordHash = GenerateHash(Password);
            var existingPasswordHash = user.PasswordHash;

            if (inputPasswordHash.ToLower().Equals(existingPasswordHash.ToLower()))
            {
                UserStore.CurrentUser = user;
                
                //_mainWindowViewModel.IsAdmin = App.CurrentUser.IsAdmin;
                UserStore.IsLogged = true;
                
                Application.Current.Windows.OfType<LoginWindow>().ToList().ForEach(window => window.Close());
            }
            else
            {
                MessageBox.Show($"Username or password is incorrect");
            }
        }
    }, _ => !HasErrors);
    
    public string GenerateHash(string data)
    {
        if (string.IsNullOrEmpty(Password))
        {
            throw new Exception("Пароль не должен быть пустым");
        }
        return BitConverter.ToString(MD5.HashData(Encoding.UTF8.GetBytes(data))).Replace("-", "");
    }
}
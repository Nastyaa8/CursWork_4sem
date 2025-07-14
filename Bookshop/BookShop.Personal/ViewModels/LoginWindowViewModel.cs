using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using BookShop.Data.UnitOfWork;
using BookShop.Mvvm.Commands;
using BookShop.Mvvm.Services;
using BookShop.Personal.Command;
using BookShop.Personal.Stores;
using BookShop.Personal.ViewModels.Base;
using BookShop.Personal.Views;
using Microsoft.Extensions.DependencyInjection;

namespace BookShop.Personal.ViewModels;

public class LoginWindowViewModel : BaseViewModel
{
    private readonly UndoRedoManager _undoRedoManager = new();
    private readonly MainWindowViewModel _mainWindowViewModel;
    private readonly INavigationService _navigationService;
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IUnitOfWork _database;
    private string _username;
    private string _password;

    public LoginWindowViewModel(
        MainWindowViewModel mainWindowViewModel,
        INavigationService navigationService,
        IServiceScopeFactory scopeFactory,
        IUnitOfWork database)
    {
        _mainWindowViewModel = mainWindowViewModel;
        _navigationService = navigationService;
        _scopeFactory = scopeFactory;
        _database = database;
    }

    [Required(ErrorMessage = "Username is required")]
    public string Username
    {
        get => _username;
        set
        {
            if (Set(ref _username, value))
            {
            }
        }
    }

    [Required(ErrorMessage = "Password is required")]
    public string Password
    {
        get => _password;
        set => Set(ref _password, value);
    }


    public RelayCommand TextChangeCommand => new RelayCommand(async obj =>
    {
        var eventArgs = obj as TextCompositionEventArgs;
        var textBox = (eventArgs.Source as TextBox);
        
        var command = new TextChangeCommand(textBox, textBox.Text, textBox.Text + eventArgs.Text);
        _undoRedoManager.Execute(command);
    });
    
    public RelayCommand UndoCommand => new RelayCommand(async obj =>
    {
        _undoRedoManager.Undo();
    }, _ => _undoRedoManager.CanUndo);
    
    public RelayCommand RedoCommand => new RelayCommand(async obj =>
    {
        _undoRedoManager.Redo();
    }, _ => _undoRedoManager.CanRedo);
    
    public RelayCommand LoginCommand => new RelayCommand(async obj =>
    {
        if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
        {
            
        }

        var user = _database.Users.GetUserByLoginOrEmail(Username);
        
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

                if (_mainWindowViewModel.CurrentViewModel is MainViewModel mv)
                {
                    await mv.LoadDataAsync();
                } 
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
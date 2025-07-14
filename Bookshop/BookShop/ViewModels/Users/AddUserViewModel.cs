using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.ViewModels.Base;

namespace BookShop.ViewModels.Users;

public class AddUserViewModel : BaseViewModel
{
    private readonly IUserRepository _userRepository;
    private bool _isEdit;
    private UserViewModel _user;

    public AddUserViewModel(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        Title = "Добавитьть нового пользователя";
        User = new UserViewModel();
    }

    public bool IsEdit
    {
        get => _isEdit;
        set => Set(ref _isEdit, value);
    }

    public UserViewModel User
    {
        get => _user;
        set => Set(ref _user, value);
    }


    public RelayCommand BackCommand => new(async obj =>
    {
        ReturnToParent<UserWrapViewModel>();
    });
    
    public RelayCommand SaveCommand => new(async obj =>
    {
        try
        {
            var passwordHash = User.GenerateHash();
            
            var user = new User
            {
                Id = User.Id,
                Login = User.Login!,
                Email = User.Email!,
                FirstName = User.FirstName!,
                LastName = User.LastName!,
                Address = User.Address!,
                Phone = User.Phone!,
                IsAdmin = User.IsAdmin,
                PasswordHash = passwordHash
            };

            if (IsEdit)
            {
                _userRepository.Update(user);
                
                if (ParentViewModel != null)
                {
                    var usersViewModel = (UsersViewModel)ParentViewModel;

                    if (usersViewModel.SelectedItem != null)
                    {
                        usersViewModel.SelectedItem.FirstName = user.FirstName;
                        usersViewModel.SelectedItem.LastName = user.LastName;
                        usersViewModel.SelectedItem.Login = user.Login;
                        usersViewModel.SelectedItem.Email = user.Email;
                        usersViewModel.SelectedItem.Phone = user.Phone;
                        usersViewModel.SelectedItem.Address = user.Address;
                        usersViewModel.SelectedItem.PasswordHash = user.PasswordHash;
                        usersViewModel.SelectedItem.IsAdmin = user.IsAdmin;
                    }
                }
            }
            else
            {
                _userRepository.Add(user);

                if (ParentViewModel != null)
                {
                    var usersViewModel = (UsersViewModel)ParentViewModel;
                    usersViewModel.Items.Add(user);
                    usersViewModel.SelectedItem = user;
                }
            }

            ReturnToParent<UserWrapViewModel>();

        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }, _ => !User.HasErrors);

    public override Task LoadDataAsync()
    {
        if (IsEdit)
        {
            Title = "Редактировать пользователя";

            var user = _userRepository.GetById(User.Id);

            if (user != null)
            {
                User = new UserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Address = user.Address,
                    Phone = user.Phone,
                    IsAdmin = user.IsAdmin,
                    Email = user.Email,
                    Login = user.Login
                };
            }
        }
        
        return Task.CompletedTask;
    }
}

public class UserViewModel : ViewModelBase
{
    private string? _firstName;
    private int _id;
    private string? _login;
    private string? _email;
    private string? _lastName;
    private string? _phone;
    private string? _address;
    private string? _password;
    private bool _isAdmin;

    public int Id
    {
        get => _id;
        set => Set(ref _id, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public string? Login
    {
        get => _login;
        set => Set(ref _login, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public string? Email
    {
        get => _email;
        set => Set(ref _email, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public string? FirstName
    {
        get => _firstName;
        set => Set(ref _firstName, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public string? LastName
    {
        get => _lastName;
        set => Set(ref _lastName, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public string? Phone
    {
        get => _phone;
        set => Set(ref _phone, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public string? Address
    {
        get => _address;
        set => Set(ref _address, value);
    }

    [Required(ErrorMessage = "Поле обязательно")]
    public string? Password
    {
        get => _password;
        set => Set(ref _password, value);
    }

    public bool IsAdmin
    {
        get => _isAdmin;
        set => Set(ref _isAdmin, value);
    }

    public string GenerateHash()
    {
        if (string.IsNullOrEmpty(Password))
        {
            throw new Exception("Пароль не должен быть пустым");
        }
        return BitConverter.ToString(MD5.HashData(Encoding.UTF8.GetBytes(Password))).Replace("-", "");
    }
}
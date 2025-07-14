using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using BookShop.Data.Models;
using BookShop.Data.Repositories;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using BookShop.ViewModels.Base;
using BookShop.Views;

namespace BookShop.ViewModels;

public class RegisterWindowViewModel : BaseViewModel
{
    private readonly IUserRepository _userRepository;

    public RegisterWindowViewModel(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    private string _login;
    private string _password;
    private string _confirmPassword;
    private string _lastName;
    private string _firstName;
    private string _email;
    private string _phone;
    private string _address;

    [Required(ErrorMessage = "Логин не должен быть пустой")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "Логин не может быть меньше 2 символов")]
    public string Login
    {
        get => _login;
        set => Set(ref _login, value);
    }

    [Required(ErrorMessage = "Фамилия не должна быть пустая")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "Фамилия не может быть меньше 2 символов")]
    public string LastName
    {
        get => _lastName;
        set => Set(ref _lastName, value);
    }

    [Required(ErrorMessage = "Имя не должно быть пустое")]
    [StringLength(255, MinimumLength = 2, ErrorMessage = "Имя не может быть меньше 2 символов")]
    public string FirstName
    {
        get => _firstName;
        set => Set(ref _firstName, value);
    }

    [Required(ErrorMessage = "Email не должен быть пустой")]
    [EmailAddress(ErrorMessage = "Не является адресом электронной почты")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Email не может быть меньше 5 символов")]
    public string Email
    {
        get => _email;
        set => Set(ref _email, value);
    }

    [Required(ErrorMessage = "Телефон не должен быть пустой")]
    public string Phone
    {
        get => _phone;
        set => Set(ref _phone, value);
    }

    [Required(ErrorMessage = "Адрес не должен быть пустой")]
    public string Address
    {
        get => _address;
        set => Set(ref _address, value);
    }


    [Required(ErrorMessage = "Пароль не должен быть пустой")]
    [Compare("ConfirmPassword", ErrorMessage = "Пароли не совпадают")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Пароль не может быть меньше 5 символов")]
    public string Password
    {
        get => _password;
        set => Set(ref _password, value);
    }

    [Required(ErrorMessage = "Подтверждение пароля не должно быть пустым")]
    [Compare("Password", ErrorMessage = "Пароли не совпадают")]
    [StringLength(255, MinimumLength = 5, ErrorMessage = "Подтверждение пароля не может быть меньше 5 символов")]
    public string ConfirmPassword
    {
        get => _confirmPassword;
        set => Set(ref _confirmPassword, value);
    }

    public RelayCommand RegisterCommand => new RelayCommand(async obj =>
    {
        var user = _userRepository.GetUserByLoginOrEmail(Login);
        
        if (user == null)
        {
            var inputPasswordHash = GenerateHash(Password);

            user = new User
            {
                Login = Login,
                Email = Email,
                Address = Address,
                FirstName = FirstName,
                LastName = LastName,
                PasswordHash = inputPasswordHash,
                Phone = Phone,
                IsAdmin = false
            };

            _userRepository.Add(user);

            MessageBox.Show("User is successfully registered");
            Application.Current.Windows.OfType<RegisterWindow>().ToList().ForEach(window => window.Close());
        }
        else
        {
            MessageBox.Show("User is already registered");
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
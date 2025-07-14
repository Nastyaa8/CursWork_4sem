using System.ComponentModel.DataAnnotations;
using BookShop.Data.UnitOfWork;
using BookShop.Mvvm.Commands;
using BookShop.Personal.Stores;
using BookShop.Personal.ViewModels.Base;

namespace BookShop.Personal.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly IUnitOfWork _unitOfWork;
    private UserViewModel _user;

    public MainViewModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        User = new UserViewModel();
    }

    public UserViewModel User
    {
        get => _user;
        set => Set(ref _user, value);
    }

    public RelayCommand SaveCommand => new RelayCommand(async obj =>
    {
        var user = UserStore.CurrentUser;

        if (user != null)
        {
            user.Login = User.Login!;
            user.Email = User.Email!;
            user.FirstName = User.FirstName!;
            user.LastName = User.LastName!;
            user.Phone = User.Phone!;
            user.Address = User.Address!;
            user.Image = User.Image!;

            _unitOfWork.Users.Update(user);
            
            var updated = _unitOfWork.Users.GetById(UserStore.CurrentUser!.Id);
            
            UserStore.CurrentUser = updated;
        }

    }, _ => !User.HasErrors);
    
    public override Task LoadDataAsync()
    {
        var user = _unitOfWork.Users.GetById(UserStore.CurrentUser!.Id);

        if (user != null)
        {
            User = new UserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Login = user.Login,
                IsAdmin = user.IsAdmin,
                Image = user.Image,
            };
        }
        
        return base.LoadDataAsync();
    }
}

public class UserViewModel : BaseViewModel
{
    private int _id;
    private string? _firstName;
    private string? _lastName;
    private string? _email;
    private string? _phone;
    private string? _address;
    private string? _login;
    private byte[] _image;

    public int Id
    {
        get => _id;
        set => Set(ref _id, value);
    }
    
    [Required(ErrorMessage = "Имя обязательно")]
    [StringLength(maximumLength: 255, MinimumLength = 5, ErrorMessage = "Количество символов должно быть от 5 до 255")]
    public string? FirstName
    {
        get => _firstName;
        set => Set(ref _firstName, value);
    }

    [Required(ErrorMessage = "Фамилия обязательна")]
    [StringLength(maximumLength: 255, MinimumLength = 5, ErrorMessage = "Количество символов должно быть от 5 до 255")]
    public string? LastName
    {
        get => _lastName;
        set => Set(ref _lastName, value);
    }

    [Required(ErrorMessage = "Email обязателен")]
    [StringLength(maximumLength: 255, MinimumLength = 5, ErrorMessage = "Количество символов должно быть от 5 до 255")]
    public string? Email
    {
        get => _email;
        set => Set(ref _email, value);
    }

    [Required(ErrorMessage = "Телефон обязателен")]
    [StringLength(maximumLength: 255, MinimumLength = 5, ErrorMessage = "Количество символов должно быть от 5 до 255")]
    public string? Phone
    {
        get => _phone;
        set => Set(ref _phone, value);
    }

    [Required(ErrorMessage = "Адрес обязателен")]
    [StringLength(maximumLength: 255, MinimumLength = 5, ErrorMessage = "Количество символов должно быть от 5 до 255")]
    public string? Address
    {
        get => _address;
        set => Set(ref _address, value);
    }

    [Required(ErrorMessage = "Логин обязателен")]
    [StringLength(maximumLength: 255, MinimumLength = 5, ErrorMessage = "Количество символов должно быть от 5 до 255")]
    public string? Login
    {
        get => _login;
        set => Set(ref _login, value);
    }

    public byte[]? Image
    {
        get => _image;
        set => Set(ref _image, value);
    }
}
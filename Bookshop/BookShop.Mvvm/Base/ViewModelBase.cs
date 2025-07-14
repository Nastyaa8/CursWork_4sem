using System.Collections;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using BookShop.Mvvm.Helpers;

namespace BookShop.Mvvm.Base;

/// <summary>
/// 
/// </summary>
public abstract class ViewModelBase : INotifyPropertyChanged, INotifyDataErrorInfo, IAsyncDisposable
{
    public ViewModelBase()
    {
        UniqueNumber = Guid.NewGuid();
        var name = GetType().Name;
        Title = name;
        
        ViewModelManager.ViewModels.Add(UniqueNumber);
        Console.WriteLine($"{name} - {UniqueNumber} Init - {ViewModelManager.ViewModels.Count}");
        
        Validate();
    }

    
    public ViewModelBase? ParentViewModel
    {
        get => _parentViewModel;
        set => Set(ref _parentViewModel, value);
    }

    public ViewModelBase? CurrentViewModel
    {
        get => _currentViewModel;
        set => Set(ref _currentViewModel, value);
    }
    
    public void ReturnToParent<T>() where T : ViewModelBase
    {
        if (ParentViewModel == null) return;
        // AddBook -> Books
        //CatalogViewModel -> CurrentViewModel  = Books
        GetParentViewModel<T>(this)!.CurrentViewModel = ParentViewModel;
        ParentViewModel = null;
    }

    private T? GetParentViewModel<T>(ViewModelBase viewModel) where T : ViewModelBase
    {
        if (viewModel.ParentViewModel == null) return null;

        if (viewModel.ParentViewModel.GetType() == typeof(T))
        {
            return (T)viewModel.ParentViewModel;
        }

        return GetParentViewModel<T>(viewModel.ParentViewModel);
    }

    public Guid UniqueNumber
    {
        get => _uniqueNumber;
        set => Set(ref _uniqueNumber, value);
    }

    private string _title = null!;
    private Guid _uniqueNumber;
    private ViewModelBase? _parentViewModel;
    private ViewModelBase? _currentViewModel;
    
    
    /// <summary>
    /// Заголовок
    /// </summary>
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public virtual Task LoadDataAsync()
    {
        return Task.CompletedTask;
    }

    protected string GetResource(string resourceName)
    {
        return (Application.Current.Resources[resourceName] as string)!;
    }
    
    private ValidationContext _validationContext;
    
    protected void Validate()
    {
        _validationContext = new ValidationContext(this, null, null);

        var validationResults = new List<ValidationResult>();
        Validator.TryValidateObject(this, _validationContext, validationResults, true);

        foreach (var kv in _errors.ToList()
                     .Where(kv => validationResults.All(r => r.MemberNames.All(m => m != kv.Key))))
        {
            _errors.TryRemove(kv.Key, out _);
            OnErrorsChanged(kv.Key);
        }

        var q = from r in validationResults
            from m in r.MemberNames
            group r by m
            into g
            select g;

        foreach (var prop in q)
        {
            var messages = prop.Select(r => r.ErrorMessage).ToList();

            if (_errors.ContainsKey(prop.Key))
            {
                _ = _errors.TryRemove(prop.Key, out _);
            }

            if (_errors.TryAdd(prop.Key, messages!))
            {
                OnErrorsChanged(prop.Key);
            }
        }
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        File.AppendAllText("log.txt", $"Свойство изменено: {propertyName}\n");
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool Set<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        Validate();
        return true;
    }

    public async virtual ValueTask DisposeAsync()
    {
        ViewModelManager.ViewModels.Remove(UniqueNumber);
        var name = GetType().Name;
        Console.WriteLine($"{name} - {UniqueNumber} Dispose - {ViewModelManager.ViewModels.Count}");
    }

    
    private readonly ConcurrentDictionary<string, List<string>> _errors = new();
    
    public bool HasErrors => _errors.Any(propErrors => propErrors.Value is { Count: > 0 });

    public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
    
    public IEnumerable GetErrors(string? propertyName)
    {
        if (string.IsNullOrEmpty(propertyName)) return _errors.SelectMany(err => err.Value.ToList());
        if (!_errors.ContainsKey(propertyName)) return null!;

        if (_errors.TryGetValue(propertyName, out var li) && li is { Count: > 0 }) return li;

        return null!;
    }

    private void OnErrorsChanged(string propertyName)
    {
        ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
}
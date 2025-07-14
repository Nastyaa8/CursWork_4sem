using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Input;
using BookShop.Mvvm.Base;
using BookShop.Mvvm.Commands;
using UndoRedoProject.CommandManager;
using UndoRedoProject.Commands;

namespace UndoRedoProject;

/// <summary>
/// 
/// </summary>
public class MainWindowViewModel : ViewModelBase
{
    private ObservableCollection<Product> _products = [];
    private CommandUIManager _uiManager;
    private Product? _selectedProduct;
    private Product _product;

    public MainWindowViewModel()
    {
        _uiManager = new CommandUIManager();
        Product = new Product();
    }

    public ObservableCollection<Product> Products
    {
        get => _products;
        set => Set(ref _products, value);
    }

    [Required]
    public Product? SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            if (Set(ref _selectedProduct, value))
            {
                if (_selectedProduct != null)
                {
                    Product.ProductName = _selectedProduct.ProductName;
                }
                else
                {
                    Product.ProductName = string.Empty;
                }
            }
        }
    }
    
    public Product Product
    {
        get => _product;
        set => Set(ref _product, value);
    }

    public ICommand AddProductCommand => new RelayCommand(obj =>
    {
        _uiManager.ExecuteCommand(new AddProductCommand(Products, Product));
        Product = new Product();
    }, _ => !Product.HasErrors);
    
    public ICommand RemoveProductCommand => new RelayCommand(obj =>
    {
        if (MessageBox.Show("Удалить продукт?", "Удаление продукта", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            if (SelectedProduct != null)
            {
                _uiManager.ExecuteCommand(new RemoveProductCommand(Products, SelectedProduct));
            }
        }
    }, _ => SelectedProduct is not null);

    public ICommand UndoCommand => new RelayCommand(obj =>
    {
        _uiManager.Undo();
    }, _ => _uiManager.UndoStack.Count > 0);
    
    public ICommand RedoCommand => new RelayCommand(obj =>
    {
        _uiManager.Redo();
    },_ => _uiManager.RedoStack.Count > 0);
}

public class Product : ViewModelBase
{
    private string _productName;

    [Required]
    public string ProductName
    {
        get => _productName;
        set => Set(ref _productName, value);
    }
}
using System.Collections.ObjectModel;

namespace UndoRedoProject.Commands;

public class AddProductCommand : ICommandAction
{
    private ObservableCollection<Product> _products;
    private Product _product;

    public AddProductCommand(ObservableCollection<Product> products, Product product)
    {
        _products = products;
        _product = product;
    }

    public void Execute()
    {
        _products.Add(_product);
    }

    public void Undo()
    {
        var product = _products.FirstOrDefault(x => x.ProductName == _product.ProductName);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}

public class RemoveProductCommand : ICommandAction
{
    private ObservableCollection<Product> _products;
    private Product _product;

    public RemoveProductCommand(ObservableCollection<Product> products, Product product)
    {
        _products = products;
        _product = product;
    }

    public void Execute()
    {
        _products.Remove(_product);
    }

    public void Undo()
    {
        var product = _products.FirstOrDefault(x => x.ProductName == _product.ProductName);
        if (product != null)
        {
            _products.Remove(product);
        }
    }
}

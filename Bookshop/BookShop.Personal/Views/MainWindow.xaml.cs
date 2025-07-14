using System.Windows;
using System.Windows.Input;

namespace BookShop.Personal.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
    {
        var result = MessageBox.Show("Заблокировать и не подыматься дальше по родительским элементам?", "Пузырьковое событие",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            e.Handled = true;
        }

        
        MessageBox.Show($"Кликнули на {sender}");
    }
}
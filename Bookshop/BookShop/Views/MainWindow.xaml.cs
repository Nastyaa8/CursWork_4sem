using System.Windows;
using System.Windows.Input;

namespace BookShop.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    private void ShowMessage_Executed(object sender, ExecutedRoutedEventArgs e)
    {
        MessageBox.Show("Команда выполнена!");
    }

    private void ShowMessage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
    {
        e.CanExecute = true; // Команда всегда доступна
    }
}
using System.Windows;
using BookShop.Personal.Views.Base;

namespace BookShop.Personal.Views;

public partial class MainView : BaseUserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void UserIcon_OnImageChanged(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("ImageChanged");
    }
}
using System.Windows.Input;

namespace BookShop.Mvvm.Commands;

public static class CustomCommands
{
    public static readonly RoutedUICommand ShowMessage = new RoutedUICommand(
        "Показать сообщение", "ShowMessage", typeof(CustomCommands),
        new InputGestureCollection { new KeyGesture(Key.M, ModifierKeys.Control) });
}
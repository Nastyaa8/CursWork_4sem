using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace BookShop.Personal.Control;

public partial class UserIcon : UserControl
{
    public UserIcon()
    {
        InitializeComponent();
    }
    
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(object), typeof(UserIcon), new PropertyMetadata(string.Empty));
    
    public object Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    
    public static readonly DependencyProperty DescriptionTextProperty =
        DependencyProperty.Register(nameof(DescriptionText), typeof(object), typeof(UserIcon),
            new FrameworkPropertyMetadata(string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    null,
                    CoerceDescription),
                ValidateDescription);
    
    
    public object DescriptionText
    {
        get => GetValue(DescriptionTextProperty);
        set => SetValue(DescriptionTextProperty, value);
    }
    
    public static readonly DependencyProperty ImageProperty =
        DependencyProperty.Register(nameof(Image), typeof(ImageSource), typeof(UserIcon), new UIPropertyMetadata(null));
    
    private static bool ValidateDescription(object value)
    {
        // Не допускаем значение null.
        return value is string;
    }

    private static object CoerceDescription(DependencyObject d, object baseValue)
    {
        string str = baseValue as string;
        return string.IsNullOrEmpty(str) ? "Default Description" : str;
    }
    
    public ImageSource Image
    {
        get => (ImageSource)GetValue(ImageProperty);
        set => SetValue(ImageProperty, value);
    }
    
    public static readonly RoutedEvent ImageChangedEvent = EventManager.RegisterRoutedEvent(
        "ImageChanged", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(UserIcon));

    public event RoutedEventHandler ImageChanged
    {
        add => AddHandler(ImageChangedEvent, value);
        remove => RemoveHandler(ImageChangedEvent, value);
    }

    protected void RaiseImageChanged()
    {
        var args = new RoutedEventArgs(ImageChangedEvent);
        RaiseEvent(args);
    }

    private bool IsShow { get; set; }
    
    private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Image files (*.png, *.jpg, *.bmp)|*.png;*.jpg;*.bmp";

        if (openFileDialog.ShowDialog() != true) return;
        using var fs = new FileStream(openFileDialog.FileName, FileMode.Open);
            
        Image = GetImageFromStream(fs);
        RaiseImageChanged();
        
        var result = MessageBox.Show("Заблокировать туннельное событие и не спускаться дальше по элементам?", "Туннельное событие",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (result == MessageBoxResult.Yes)
        {
            e.Handled = true;
        }

        MessageBox.Show($"Кликнули на {sender}");
    }

    private ImageSource GetImageFromStream(FileStream stream)
    {
        // Создаем новый экземпляр BitmapImage
        var bitmap = new BitmapImage();

        // Начинаем инициализацию
        bitmap.BeginInit();
        // Указываем кэширование OnLoad, чтобы можно было закрыть FileStream после загрузки
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        // Устанавливаем источник потока
        bitmap.StreamSource = stream;
        // Завершаем инициализацию
        bitmap.EndInit();
        // Замораживаем изображение (опционально) для повышения производительности и потокобезопасности
        bitmap.Freeze();

        return bitmap;
    }
}
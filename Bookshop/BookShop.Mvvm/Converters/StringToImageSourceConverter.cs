using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace BookShop.Mvvm.Converters;

public class StringToImageSourceConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string path && !string.IsNullOrEmpty(path))
        {
            var appPAth = AppDomain.CurrentDomain.BaseDirectory;
            var imgPath = System.IO.Path.Combine(appPAth, "Images", path);
            if (File.Exists(imgPath))
            {
                return  new BitmapImage(new Uri(imgPath, UriKind.RelativeOrAbsolute));
                
                // var ms = new MemoryStream();
                // ms.Seek(0, SeekOrigin.Begin);
                // bmp.StreamSource = ms;
                // bmp.EndInit();
                // return bmp;
            }
        }
        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
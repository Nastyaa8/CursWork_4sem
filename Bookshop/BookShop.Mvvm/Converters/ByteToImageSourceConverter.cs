using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace BookShop.Mvvm.Converters;

public class ByteToImageSourceConverter : IValueConverter
{
    /// <summary>
    /// Преобразует массив байтов в ImageSource.
    /// </summary>
    /// <param name="value">Массив байтов, представляющий изображение.</param>
    /// <param name="targetType">Целевой тип (ImageSource).</param>
    /// <param name="parameter">Дополнительный параметр (не используется).</param>
    /// <param name="culture">Информация о культуре.</param>
    /// <returns>Объект ImageSource или null, если преобразование невозможно.</returns>
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is byte[] { Length: > 0 } bytes)
        {
            try
            {
                // Используем MemoryStream для создания потока из массива байтов
                using var stream = new MemoryStream(bytes);
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                // Опция OnLoad гарантирует, что изображение полностью загрузится, 
                // и поток можно немедленно закрыть
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.StreamSource = stream;
                bitmap.EndInit();
                // Замораживание объекта повышает производительность и позволяет использовать его в других потоках
                bitmap.Freeze();
                return bitmap;
            }
            catch (Exception ex)
            {
                // Если необходимо, можно залогировать исключение
                System.Diagnostics.Debug.WriteLine(ex.Message);
                return null;
            }
        }
        return null;
    }

    /// <summary>
    /// Преобразование обратно в массив байтов не реализовано.
    /// </summary>
    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        // Приводим входное значение к BitmapSource
        if (value is not BitmapSource bitmapSource)
            return null;

        // Определяем тип кодировщика в зависимости от параметра
        BitmapEncoder? encoder = null;
        var formatParam = parameter as string;
        if (!string.IsNullOrEmpty(formatParam))
        {
            encoder = formatParam.ToLowerInvariant() switch
            {
                "jpg" or "jpeg" => new JpegBitmapEncoder(),
                "bmp" => new BmpBitmapEncoder(),
                "gif" => new GifBitmapEncoder(),
                "tiff" => new TiffBitmapEncoder(),
                _ => new PngBitmapEncoder()
            };
        }
        else
        {
            encoder = new PngBitmapEncoder();
        }

        // Добавляем кадр с изображением в кодировщик
        encoder.Frames.Add(BitmapFrame.Create(bitmapSource));

        // Сохраняем изображение в поток и возвращаем массив байтов
        using var ms = new MemoryStream();
        encoder.Save(ms);
        return ms.ToArray();
    }
}
using System.Globalization;
using System.Windows;

namespace BookShop.Mvvm.Helpers;

public enum EThemeType
{
    Pink = 0,
    Blue = 1
}

public static class ApplicationSettings
{
    private static readonly List<CultureInfo> Languages = [
        new("en-US"),
        new("ru-RU")
    ];
    
    private static EThemeType _theme;
    
    
    public static CultureInfo Language
    {
        get => Thread.CurrentThread.CurrentUICulture;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            // if (Equals(value, Thread.CurrentThread.CurrentUICulture))
            // {
            //     return;
            // }
            
            Thread.CurrentThread.CurrentCulture = value;
            Thread.CurrentThread.CurrentUICulture = value;
            var dict = new ResourceDictionary();
            
            const string resourceDictionaries = "pack://application:,,,/BookShop.Resources;component/ResourceDictionaries/lang";
            const string type = "xaml";
            const string ruLang = "ru-RU";
            
            dict.Source = value.Name switch
            {
                "ru-RU" => new Uri($"{resourceDictionaries}.{ruLang}.{type}", UriKind.RelativeOrAbsolute),
                _ => new Uri($"{resourceDictionaries}.{type}", UriKind.RelativeOrAbsolute)
            };
            var oldDict = Application.Current.Resources.MergedDictionaries
                .FirstOrDefault(d =>
                    d.Source != null && d.Source.OriginalString.StartsWith($"{resourceDictionaries}.{type}"));
            
            if (oldDict != null)
            {
                var ind = Application.Current.Resources.MergedDictionaries.IndexOf(oldDict);
                Application.Current.Resources.MergedDictionaries.Remove(oldDict);
                Application.Current.Resources.MergedDictionaries.Insert(ind, dict);
            }
            else
            {
                Application.Current.Resources.MergedDictionaries.Add(dict);
            }
            
            // FrameworkElement.LanguageProperty.OverrideMetadata(
            //     typeof(FrameworkElement),
            //     new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentUICulture.IetfLanguageTag))
            // );
        }
    }

    public static EThemeType Theme
    {
        get => _theme;
        set
        {
            ArgumentNullException.ThrowIfNull(value);

            var founded = Application.Current.Resources.MergedDictionaries.Where(x => x.Source.OriginalString.StartsWith("Themes")).ToList();

            if (founded.Count != 0)
            {
                foreach (var theme in founded)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(theme);
                }
            }
            
            _theme = value;
            
            switch (_theme)
            {
                case EThemeType.Pink:
                {
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/BookShop.Resources;component/Themes/PinkTheme.xaml", UriKind.RelativeOrAbsolute) });
                    break;
                }
                case EThemeType.Blue:
                {
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/BookShop.Resources;component/Themes/BlueTheme.xaml", UriKind.RelativeOrAbsolute) });
                    break;
                }
                default:
                {
                    Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("Themes/PinkTheme.xaml", UriKind.Relative) });
                    break;
                }
            }
        }
    }
}
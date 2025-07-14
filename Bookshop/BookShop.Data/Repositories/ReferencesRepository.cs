using System.Globalization;

namespace BookShop.Data.Repositories;

public class ReferencesRepository : IReferencesRepository
{
    public List<Reference> GetGenres(CultureInfo? language)
    {
        var enList = new List<Reference>()
        {
            new(1, "All"),
            new(2, "Fiction"),
            new(3, "Non-fiction"),
            new(4, "Fantasy"),
            new(5, "Science Fiction"),
            new(6, "Mystery"),
            new(7, "Biography"),
            new(8, "History"),
            new(9, "Children's Books")
        };
        
        if (language == null)
        {
            return enList;
        }

        if (Equals(language, new CultureInfo("ru-RU")))
        {
            return
            [
                new Reference(1, "Все"),
                new Reference(2, "Художественная литература"),
                new Reference(3, "Документальная литература"),
                new Reference(4, "Фэнтези"),
                new Reference(5, "Научная фантастика"),
                new Reference(6, "Детектив"),
                new Reference(7, "Биография"),
                new Reference(8, "История"),
                new Reference(9, "Детские книги")
            ];
        }

        return enList;
    }

    public List<Reference> GetStatuses(CultureInfo? language)
    {
        var enList = new List<Reference>()
        {
            new(1, "Placed"),
            new(2, "Processed"),
            new(3, "Issued"),
            new(4, "Delivered"),
            new(5, "Cancelled"),
        };
        
        if (language == null)
        {
            return enList;
        }

        if (Equals(language, new CultureInfo("ru-RU")))
        {
            return
            [
                new Reference(1, "Оформлен"),
                new Reference(2, "Обработан"),
                new Reference(3, "Выдан"),
                new Reference(4, "Доставлен"),
                new Reference(5, "Отменен")
            ];
        }

        return enList;
    }
}
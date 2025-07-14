using System.Globalization;

namespace BookShop.Data.Repositories;

public class Reference(int id, string name)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
}

public interface IReferencesRepository
{
    List<Reference> GetGenres(CultureInfo? language);
    
    List<Reference> GetStatuses(CultureInfo? language);
}
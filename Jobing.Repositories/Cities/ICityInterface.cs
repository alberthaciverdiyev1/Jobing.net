using Repositories.Generics;

namespace Repositories.Cities;

public interface ICityInterface:IGenericRepository<City>
{
    public Task<List<City>> GetLastCitiesAsync(int count);
}
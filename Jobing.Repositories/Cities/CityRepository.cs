using Microsoft.EntityFrameworkCore;
using Repositories.Database;
using Repositories.Generics;

namespace Repositories.Cities;

public class CityRepository(AppDbContext context):GenericRepository<City>(context),ICityInterface
{
    public Task<List<City>> GetLastCitiesAsync(int count)
    {
       return Context.Cities.OrderByDescending(o => o.Id).Take(count).ToListAsync();
    }
}
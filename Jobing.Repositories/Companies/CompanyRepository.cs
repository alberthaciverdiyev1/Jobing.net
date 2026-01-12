using Repositories.Database;
using Repositories.Generics;

namespace Repositories.Companies;

public class CompanyRepository(AppDbContext context) : GenericRepository<Company>(context),ICompanyRepository
{
    
}
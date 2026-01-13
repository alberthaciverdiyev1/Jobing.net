using Repositories.Categories;
using Repositories.Cities;
using Repositories.Companies;

namespace Repositories.Vacancies;

public class Vacancy:IAuditEntity
{
    public int Id { get; set; }
    public Dictionary<string,string>? Title { get; set; }
    public Dictionary<string,string>? Description { get; set; }
    public Dictionary<string,string>? Requirements { get; set; }
    public byte? MinAge { get; set; }
    public byte? MaxAge { get; set; }
    
    public int? Experience { get; set; }
    public int? Education { get; set; }
    public int? Salary { get; set; }
    
    public string? Email { get; set; }  
    public string? Phone { get; set; }
    public string? CompanyId { get; set; }
    public string? CategoryId { get; set; }
    public string? CityId { get; set; }
    public Company? Company { get; set; }
    public Category? Category { get; set; }
    public City? City { get; set; }
    
    public bool IsActive { get; set; }
    
    public DateTime ExpiresAt { get; set; }
    
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
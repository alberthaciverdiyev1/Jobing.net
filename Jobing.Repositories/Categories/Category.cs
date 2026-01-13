namespace Repositories.Categories;

public class Category:IAuditEntity
{
    public int Id { get; set; }
    public string? NameAz { get; set; } = default!;
    public string? NameRu { get; set; }
    public string? NameEn { get; set; }
    public string? NameTr { get; set; }
    public string? Icon { get; set; }
    
    public int? ParentId { get; set; }         
    public Category? Parent { get; set; }     
    public ICollection<Category> Children { get; set; } = new List<Category>();

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
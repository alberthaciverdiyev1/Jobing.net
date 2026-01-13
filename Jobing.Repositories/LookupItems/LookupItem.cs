namespace Repositories.LookupItems;

public class LookupItem : IAuditEntity
{
    public int Id { get; set; }
    public string Code { get; set; } = null!;
    public string Group { get; set; } = null!;
    
    public Dictionary<string, string> Name { get; set; } = [];

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
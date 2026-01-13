namespace Services.LookupItems;

public record LookupItemAdminDto(
    int Id,
    IDictionary<string, string> Name,
    string Group,
    string Code,
    bool IsActive,
    DateTime CreatedAt,
    DateTime? UpdatedAt);
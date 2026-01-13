namespace Services.LookupItems.Update;

public record UpdateLookupItemRequest(int Id, Dictionary<string,string> Name,string Group,string Code,bool IsActive);
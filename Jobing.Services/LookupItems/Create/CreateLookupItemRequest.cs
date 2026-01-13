namespace Services.LookupItems.Create;

public record CreateLookupItemRequest(Dictionary<string,string> Name,string Group,string Code);
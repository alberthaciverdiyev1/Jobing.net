namespace Repositories;

public abstract class MultiLangEntityBase
{
    public Dictionary<string, string> Name { get; set; } = new();
    public Dictionary<string, string> Description { get; set; } = new();

    public string GetName(string culture = "az") =>
        Name.ContainsKey(culture) ? Name[culture] : Name.GetValueOrDefault("az", string.Empty);

    public string GetDescription(string culture = "az") =>
        Description.ContainsKey(culture) ? Description[culture] : Description.GetValueOrDefault("az", string.Empty);
}
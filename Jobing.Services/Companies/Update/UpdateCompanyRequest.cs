using Microsoft.AspNetCore.Http;

namespace Services.Companies.Update;

public record UpdateCompanyRequest(Dictionary<string, string> Name, Dictionary<string, string> Description, IFormFile? Logo);
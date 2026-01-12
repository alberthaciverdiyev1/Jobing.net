using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Http;

namespace Services.Companies.Create;

public record CreateCompanyRequest(
    IDictionary<string, string> Name,     
    IDictionary<string, string> Description,
    IFormFile? Logo                        
);
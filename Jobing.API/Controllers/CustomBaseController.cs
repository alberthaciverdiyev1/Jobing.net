using System.Net;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace App.API.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class CustomBaseController : ControllerBase
{
    [NonAction]
    public IActionResult CreateActionResult<T>(ServiceResult<T> result)
    {
        if (result.StatusCode == HttpStatusCode.NoContent)
        {
            return new ObjectResult(null) { StatusCode = result.StatusCode.GetHashCode() };
        }

        return new OkObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() };
    }

    [NonAction]
    public IActionResult CreateActionResult(ServiceResult result)
    {
        if (result.StatusCode == HttpStatusCode.NoContent)
        {
            return new ObjectResult(null) { StatusCode = result.StatusCode.GetHashCode() };
        }

        return new OkObjectResult(result) { StatusCode = result.StatusCode.GetHashCode() };
    }
}
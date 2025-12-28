using System.Net;
using Microsoft.AspNetCore.Mvc;
using Services.Cities;
using Services.Cities.Create;
using Services.Cities.Update;

namespace App.API.Controllers;

public class CitiesController(ICityService cityService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => CreateActionResult(await cityService.GetAll());
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id) => CreateActionResult(await cityService.GetByIdAsync(id));

    [HttpPost]
    public async Task<IActionResult> CreateAsync(CreateCityRequest request) =>CreateActionResult(await cityService.CreateAsync(request));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(int id, UpdateCityRequest request) => CreateActionResult(await cityService.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(int id)  => CreateActionResult(await cityService.DeleteAsync(id));

}
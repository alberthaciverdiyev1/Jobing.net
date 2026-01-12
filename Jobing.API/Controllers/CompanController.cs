using Microsoft.AspNetCore.Mvc;
using Services.Categories.Create;
using Services.Categories.Update;
using Services.Companies;
using Services.Companies.Create;
using Services.Companies.Update;

namespace App.API.Controllers;

public class CompanyController(ICompanyService companyService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() =>
        CreateActionResult(await companyService.GetAllAsync<CompanyUserDto>("az"));

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id) =>
        CreateActionResult(await companyService.GetByIdAsync<CompanyUserDto>(id));

    [HttpPost]
    public async Task<IActionResult> Create(CreateCompanyRequest request) =>
        CreateActionResult(await companyService.CreateAsync(request));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateCompanyRequest request) =>
        CreateActionResult(await companyService.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) => CreateActionResult(await companyService.DeleteAsync(id));
}
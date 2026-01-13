using Microsoft.AspNetCore.Mvc;
using Services.Categories;
using Services.Categories.Create;
using Services.Categories.Update;

namespace App.API.Controllers;

public class CategoryController(ICategoryService categoryService) : CustomBaseController
{
    [HttpGet]
    public async Task<IActionResult> GetAll() => CreateActionResult(await categoryService.GetAll());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id) => CreateActionResult(await categoryService.GetByIdAsync(id));
    
    [HttpGet("children/{id:int}")]
    public async Task<IActionResult> GetChildren(int id) => CreateActionResult(await categoryService.GetChildrenAsync(id));
    
    [HttpGet("with-children")]
    public async Task<IActionResult> GetAllWithChildren() => CreateActionResult(await categoryService.GetAllWithChildrenAsync());

    [HttpPost]
    public async Task<IActionResult> Create(CreateCategoryRequest request) =>
        CreateActionResult(await categoryService.CreateAsync(request));

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, UpdateCategoryRequest request) =>
        CreateActionResult(await categoryService.UpdateAsync(id, request));

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id) => CreateActionResult(await categoryService.DeleteAsync(id));
}
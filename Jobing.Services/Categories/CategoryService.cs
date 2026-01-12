using System.Net;
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Categories;
using Services.Categories.Create;
using Services.Categories.Update;

namespace Services.Categories;

public class CategoryService(
    ICategoryRepository categoryRepository,
    IUnitOfWork unitOfWork,
    IValidator<CreateCategoryRequest> createRequestValidator,
    IValidator<UpdateCategoryRequest> updateRequestValidator,
    IMapper mapper) : ICategoryService
{
    public async Task<ServiceResult<List<CategoryDto>>> GetAll()
    {
        var categories = await categoryRepository.GetAll().ToListAsync();
        var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);

        return ServiceResult<List<CategoryDto>>.Success(categoriesAsDto);
    }

    public async Task<ServiceResult<CategoryDto?>> GetByIdAsync(int id)
    {
        var category = await categoryRepository.GetByIdAsync(id);

        if (category == null)
        {
            return ServiceResult<CategoryDto?>.Fail("Category not found");
        }

        var categoryAsDto = mapper.Map<CategoryDto>(category);

        return ServiceResult<CategoryDto?>.Success(categoryAsDto);
    }

    public async Task<ServiceResult<CreateCategoryResponse>> CreateAsync(CreateCategoryRequest request)
    {
        var anyCategory = await categoryRepository.Where(x =>
            x.NameAz == request.NameAz || x.NameEn == request.NameEn || x.NameRu == request.NameEn ||
            x.NameTr == request.NameTr).AnyAsync();

        if (anyCategory)
        {
            return ServiceResult<CreateCategoryResponse>.Fail("Category name must be unique");
        }

        var validation = await createRequestValidator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            return ServiceResult<CreateCategoryResponse>.Fail(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }

        var category = mapper.Map<Category>(request);

        await categoryRepository.AddAsync(category);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult<CreateCategoryResponse>.Success(new CreateCategoryResponse(category.Id, category.NameAz!,
            category.Icon!));
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateCategoryRequest request)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        if (category is null)
        {
            return ServiceResult.Fail("Category not found", HttpStatusCode.NotFound);
        }

        var validated = await updateRequestValidator.ValidateAsync(request);
        if (!validated.IsValid)
        {
            return ServiceResult.Fail(validated.Errors.Select(x => x.ErrorMessage).ToList());
        }

        mapper.Map(request, category);
        categoryRepository.Update(category);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }

    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var category = await categoryRepository.GetByIdAsync(id);
        if (category is null)
        {
            return ServiceResult.Fail("Category not found", HttpStatusCode.NotFound);
        }

        categoryRepository.Delete(category);
        await unitOfWork.SaveChangesAsync();
        return ServiceResult.Success(HttpStatusCode.NoContent);
    }
}
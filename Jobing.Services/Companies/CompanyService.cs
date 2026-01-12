using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Companies;
using Services.Companies.Create;
using Services.Companies.Update;
using Services.Helpers;

namespace Services.Companies;

public class CompanyService(
    ICompanyRepository companyRepository,
    IMapper mapper,
    IUnitOfWork unitOfWork,
    CreateCompanyRequestValidator createCompanyRequestValidator,
    UpdateCompanyRequestValidator updateCompanyRequestValidator) : ICompanyService
{
    public async Task<ServiceResult<List<TDto>>> GetAllAsync<TDto>(string? culture = null) where TDto : class
    {
        var companies = await companyRepository.GetAll().ToListAsync();
        var data = companies
            .Select(c => mapper.Map<TDto>(c, opts =>
            {
                if (culture != null)
                    opts.Items["culture"] = culture;
            }))
            .ToList();

        return ServiceResult<List<TDto>>.Success(data);
    }


    public async Task<ServiceResult<TDto?>> GetByIdAsync<TDto>(int id, string? culture = null) where TDto : class
    {
        var company = await companyRepository.GetByIdAsync(id);

        if (company == null)
            return ServiceResult<TDto?>.Fail("Company not found");

        var dto = mapper.Map<TDto>(company, opts =>
        {
            if (culture != null)
                opts.Items["culture"] = culture;
        });

        return ServiceResult<TDto?>.Success(dto);
    }

    public async Task<ServiceResult<CreateCompanyResponse>> CreateAsync(CreateCompanyRequest request)
    {
        var validation = await createCompanyRequestValidator.ValidateAsync(request);

        if (!validation.IsValid)
        {
            return ServiceResult<CreateCompanyResponse>.Fail(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }

        var company = new Company
        {
            Name = request.Name.ToDictionary(x => x.Key, x => x.Value),
            Description = request.Description.ToDictionary(x => x.Key, x => x.Value),
            Logo = request.Logo != null ? await FileHelper.SaveAsync(request.Logo, "companies") : null,
        };

        await companyRepository.AddAsync(company);
        await unitOfWork.SaveChangesAsync();


        return ServiceResult<CreateCompanyResponse>.Success(new CreateCompanyResponse(company.Id,
            company.Name.GetValueOrDefault("az", ""), company.Logo));
    }

    public async Task<ServiceResult> UpdateAsync(int id, UpdateCompanyRequest request)
    {
        var validation = await updateCompanyRequestValidator.ValidateAsync(request);
        if (!validation.IsValid)
        {
            return ServiceResult.Fail(validation.Errors.Select(x => x.ErrorMessage).ToList());
        }

        var company = await companyRepository.GetByIdAsync(id);
        if (company is null) return ServiceResult.Fail("Company not found");

        foreach (var kvp in request.Name) company.Name[kvp.Key] = kvp.Value;

        foreach (var kvp in request.Description) company.Description[kvp.Key] = kvp.Value;

        if (request.Logo != null) company.Logo = await FileHelper.SaveAsync(request.Logo, "companies");


        companyRepository.Update(company);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success();
    }


    public async Task<ServiceResult> DeleteAsync(int id)
    {
        var company = await companyRepository.GetByIdAsync(id);
        if (company is null) return ServiceResult.Fail("Company not found");

        companyRepository.Delete(company);
        await unitOfWork.SaveChangesAsync();

        return ServiceResult.Success();
    }
}
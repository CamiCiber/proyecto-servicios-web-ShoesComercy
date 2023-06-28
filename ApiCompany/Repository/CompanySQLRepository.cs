using System;
using ApiCompany.DbContexts;
using ApiCompany.Dtos;
using ApiCompany.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ApiCompany.Repository
{
    public class CompanySQLRepository : ICompanyRepository
    {
        private AppDbContext appDbContext;
        private IMapper mapper;

        public CompanySQLRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.appDbContext = dbContext;
            this.mapper = mapper;
        }


        public async Task<CompanyDto> createCompany(CompanyDto companyDto)
        {
            var company = mapper.Map<Company>(companyDto);
            this.appDbContext.Companies.Add(company);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<CompanyDto>(company);
        }

        public async Task<bool> deleteCompanyById(int id)
        {
            try
            {
                Company company = await this.appDbContext.Companies
                    .FirstOrDefaultAsync(company => company.CompanyId == id);
                if (company == null)
                {
                    return false;
                }
                appDbContext.Companies.Remove(company);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<CompanyDto>> GetAllCompany()
        {
            List<Company> companies = await this.appDbContext.Companies.ToListAsync();
            return mapper.Map<List<CompanyDto>>(companies);
        }

        public async Task<Company> GetCompanyById(int id)
        {
            var Company = await appDbContext.Companies.Where(Company => Company.CompanyId == id)
                .FirstOrDefaultAsync();
            return Company;
        }

        public async Task<CompanyDto> updateCompany(CompanyDto companyDto)
        {
            var company = mapper.Map<Company>(companyDto);
            this.appDbContext.Update(company);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<CompanyDto>(company);
        }
    }
}

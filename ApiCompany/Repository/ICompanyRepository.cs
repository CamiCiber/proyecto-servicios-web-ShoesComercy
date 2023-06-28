using ApiCompany.Dtos;
using ApiCompany.Models;

namespace ApiCompany.Repository

{

    public interface ICompanyRepository
    {
        Task<IEnumerable<CompanyDto>> GetAllCompany();
        Task<CompanyDto> createCompany(CompanyDto companyDto);
        Task<bool> deleteCompanyById(int id);
        Task<CompanyDto> updateCompany(CompanyDto companyDto);
        Task<Company> GetCompanyById(int id);
    }
}
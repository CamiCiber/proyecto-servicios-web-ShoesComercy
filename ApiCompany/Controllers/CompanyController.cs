using ApiCompany.Dtos;
using ApiCompany.Models;
using ApiCompany.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompany.Controllers
{
    [Route("api/company/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICompanyRepository companyRepository;

        private ResponseDto responseDto;
        public CompanyController(ICompanyRepository companyRepository)
        {
            this.companyRepository = companyRepository;
            this.responseDto = new ResponseDto();
        }
        [HttpGet]
        [Route("/getAll")]
        public async Task<object> getCompany()
        {
            try
            {
                IEnumerable<CompanyDto> companyDtos = await companyRepository.GetAllCompany();
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = companyDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }

        [HttpGet]
        [Route("/GetCompanies/{id}")]
        public async Task<object> getCompanyById(int id)
        {
            return await companyRepository.GetCompanyById(id);
        }


        [HttpPost]
        [Route("/insert")]
        public async Task<object> createCompany(CompanyDto companyDto)
        {
            try
            {
                CompanyDto result = await companyRepository.createCompany(companyDto);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }


        [HttpPut]
        [Route("/update")]
        public async Task<object> updateCompany(CompanyDto companyDto)
        {
            try
            {
                CompanyDto result = await companyRepository.updateCompany(companyDto);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }


        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<object> deleteCompany(int id)
        {
            try
            {
                bool result = await companyRepository.deleteCompanyById(id);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = result;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }
    }



}


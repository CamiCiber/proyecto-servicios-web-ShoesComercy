using ApiShoes.Dtos;
using ApiShoes.Models;
using ApiShoes.Repository;
using Microsoft.AspNetCore.Mvc;


namespace ApiShoes.Controllers
{
    [Route("api/Shoes/[controller]")]
    [ApiController]
    public class ShoesController : ControllerBase
    {
        private IShoesRepository shoesRepository;

        private ResponseDto responseDto;
        public ShoesController(IShoesRepository shoesRepository)
        {
            this.shoesRepository = shoesRepository;
            this.responseDto = new ResponseDto();
        }
        [HttpGet]
        [Route("/getAll")]
        public async Task<object> getShoes()
        {
            try
            {
                IEnumerable<ShoesDto> companyDtos = await shoesRepository.GetAllShoes();
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
        [Route("/GetShoes/{id}")]
        public async Task<object> getShoesById(int id)
        {
            return await shoesRepository.GetShoesById(id);
        }
        [HttpGet]
        [Route("/getByMarca/{marcaCode}")]
        public async Task<object> Get(string marcaCode)
        {
            try
            {
                IEnumerable<ShoesDto> productDtos = await shoesRepository
                    .GetShoesByMarcaCode(marcaCode);
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = productDtos;
                this.responseDto.DisplayMessage = "Success";
            }
            catch (Exception ex)
            {
                this.responseDto.IsSucceed = false;
                this.responseDto.DisplayMessage = ex.ToString();
            }
            return responseDto;
        }


        [HttpPost]
        [Route("/insert")]
        public async Task<object> createShoes(ShoesDto shoesDto)
        {
            try
            {
                ShoesDto result = await shoesRepository.createShoes(shoesDto);
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
        public async Task<object> updateShoes(ShoesDto shoesDto)
        {
            try
            {
                ShoesDto result = await shoesRepository.updateShoes(shoesDto);
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
                bool result = await shoesRepository.deleteShoesById(id);
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


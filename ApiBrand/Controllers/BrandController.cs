using ApiBrand.Dtos;
using ApiBrand.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ApiBrand.Controllers
{
    [Route("api/brand/[controller]")]
    [ApiController]
    public class BrandController: ControllerBase
    {
        private IBrandRepository brandRepository;

        private ResponseDto responseDto;

        public BrandController (IBrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
            this.responseDto = new ResponseDto();
        }


        [HttpGet]
        [Route("/GetBrands")]
        public async Task<object> GetBrands()
        {
            try
            {
                IEnumerable<BrandDto> brandDtos = await brandRepository.GetAllBrands();
                this.responseDto.IsSucceed = true;
                this.responseDto.Result = brandDtos;
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
        [Route("/GetBrand/{id}")]
        public async Task<object> getBrandById(int id)
        {
            return await brandRepository.GetBrandById(id);
        }


        [HttpPost]
        [Route("/InsertBrand")]
        public async Task<object> createBrand(BrandDto brandDto)
        {
            try
            {
                BrandDto result = await brandRepository.createBrand(brandDto);
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
        [Route("/UpdateBrand")]
        public async Task<object> updateBrand(BrandDto brandDto)
        {
            try
            {
                BrandDto result = await brandRepository.updateBrand(brandDto);
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
        [Route("/DeleteBrand/{id}")]
        public async Task<object> deleteBrand(int id)
        {
            try
            {
                bool result = await brandRepository.deleteBrandById(id);
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


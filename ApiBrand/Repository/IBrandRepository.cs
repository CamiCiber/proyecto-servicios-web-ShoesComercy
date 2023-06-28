using ApiBrand.Dtos;
using ApiBrand.Models;

namespace ApiBrand.Repository
{
    public interface IBrandRepository
    {
        Task<IEnumerable<BrandDto>> GetAllBrands();
        Task<BrandDto> createBrand(BrandDto brandDto);
        Task<bool> deleteBrandById(int id);
        Task<BrandDto> updateBrand(BrandDto brandDto);
        Task<Brand> GetBrandById(int id);
    }
}

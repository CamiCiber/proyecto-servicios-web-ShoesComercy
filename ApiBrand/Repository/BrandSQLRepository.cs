using AutoMapper;
using ApiBrand.DbContexts;
using ApiBrand.Dtos;
using ApiBrand.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBrand.Repository
{
    public class BrandSQLRepository : IBrandRepository
    {
        private AppDbContext appDbContext;

        private IMapper mapper;

        public BrandSQLRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.appDbContext = dbContext;
            this.mapper = mapper;
        }

        public async Task<BrandDto> createBrand(BrandDto brandDto)
        {
            var brand = mapper.Map<Brand>(brandDto);
            this.appDbContext.Brands.Add(brand);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<BrandDto>(brand);
        }

        public async Task<bool> deleteBrandById(int id)
        {
            try
            {
                Brand brand = await this.appDbContext.Brands
                    .FirstOrDefaultAsync(category => category.BrandId == id);
                if (brand == null)
                {
                    return false;
                }
                appDbContext.Brands.Remove(brand);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<BrandDto>> GetAllBrands()
        {
            List<Brand> brands = await this.appDbContext.Brands.ToListAsync();
            return mapper.Map<List<BrandDto>>(brands);
        }

        public async Task<Brand> GetBrandById(int id)
        {
            var brand = await appDbContext.Brands.Where(brand => brand.BrandId == id)
                .FirstOrDefaultAsync();
            return brand;
        }

        public async Task<BrandDto> updateBrand(BrandDto brandDto)
        {
            var brand = mapper.Map<Brand>(brandDto);
            this.appDbContext.Update(brand);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<BrandDto>(brand);
        }
    }
}

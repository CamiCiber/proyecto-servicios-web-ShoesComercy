using System;
using ApiShoes.DbContexts;
using ApiShoes.Dtos;
using ApiShoes.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ApiShoes.Repository
{
    public class ShoesSQLRepository : IShoesRepository
    {
        private AppDbContext appDbContext;
        private IMapper mapper;
        public ShoesSQLRepository(AppDbContext dbContext, IMapper mapper)
        {
            this.appDbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<ShoesDto> createShoes(ShoesDto shoesDto)
        {
            var shoes = mapper.Map<Shoes>(shoesDto);
            this.appDbContext.shoess.Add(shoes);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<ShoesDto>(shoes);
        }

        public async Task<bool> deleteShoesById(int id)
        {

            try
            {
                Shoes shoes = await this.appDbContext.shoess
                    .FirstOrDefaultAsync(category => category.ShoesId == id);
                if (shoes == null)
                {
                    return false;
                }
                appDbContext.shoess.Remove(shoes);
                await appDbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<IEnumerable<ShoesDto>> GetAllShoes()
        {
            List<Shoes> shoes = await this.appDbContext.shoess.ToListAsync();
            return mapper.Map<List<ShoesDto>>(shoes);
        }

        public async Task<Shoes> GetShoesById(int id)
        {
            var shoes = await appDbContext.shoess.Where(Shoes => Shoes.ShoesId == id)
    .FirstOrDefaultAsync();
            return shoes;
        }

        public async Task<IEnumerable<ShoesDto>> GetShoesByMarcaCode(string marcaCode)
        {

            List<Shoes> shoes = await appDbContext.shoess.Where(shoe =>
            shoe.MarcaCode == marcaCode).ToListAsync();

            return mapper.Map<List<ShoesDto>>(shoes);

        }

        public async Task<ShoesDto> updateShoes(ShoesDto shoesDto)
        {
            var shoes = mapper.Map<Shoes>(shoesDto);
            this.appDbContext.Update(shoes);
            await this.appDbContext.SaveChangesAsync();
            return mapper.Map<ShoesDto>(shoes);
        }
    }
}

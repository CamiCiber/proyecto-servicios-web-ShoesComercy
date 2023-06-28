using ApiShoes.Dtos;
using ApiShoes.Models;

namespace ApiShoes.Repository
{
    public interface IShoesRepository
    {
        Task<IEnumerable<ShoesDto>> GetAllShoes();
        Task<ShoesDto> createShoes(ShoesDto shoesDto);
        Task<bool> deleteShoesById(int id);
        Task<ShoesDto> updateShoes(ShoesDto shoesDto);
        Task<Shoes> GetShoesById(int id);
        Task<IEnumerable<ShoesDto>> GetShoesByMarcaCode(string marcaCode);

    }
}

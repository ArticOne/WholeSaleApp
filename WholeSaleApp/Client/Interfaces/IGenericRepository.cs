using Json.Patch;
using WholeSaleApp.Shared.DTOs;

namespace WholeSaleApp.Client.Interfaces
{
    public interface IGenericRepository<TResponseDto, TRequestDto> where TResponseDto : BaseDto where TRequestDto : class
    {
        Task<List<TResponseDto>> GetAsync();
        Task<List<TResponseDto>> GetPaginatedAsync();
        Task<TResponseDto> GetAsync(int id);
        Task<bool> PostAsync(TRequestDto dtoToPost);
        Task<bool> PutAsync(int id, TRequestDto dtoToPut);
        Task<bool> PatchAsync(int id, JsonPatch createPatch);
        Task<bool> DeleteAsync(int id);
    }
}
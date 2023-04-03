using WholeSaleApp.Shared.DTOs;

namespace WholeSaleApp.Client.Interfaces
{
    public interface IGenericRepository<T> where T : BaseDto
    {
        Task<List<T>> GetAsync();
        Task<T> GetAsync(int id);
        Task<bool> PostAsync(T dtoToPost);
        Task<bool> PutAsync(T dtoToPut);
        Task<bool> DeleteAsync(int id);
    }
}
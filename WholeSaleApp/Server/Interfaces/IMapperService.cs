using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.Model;

namespace WholeSaleApp.Server.Interfaces
{
    public interface IMapperService
    {
        TDto ToDto<TModel, TDto>(TModel model) where TModel : BaseModel where TDto : BaseDto;
        TModel ToModel<TModel, TRequestDto>(TRequestDto dto) where TModel : BaseModel where TRequestDto : class;
    }
}

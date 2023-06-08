
using System.Reflection;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.Maps;
using WholeSaleApp.Shared.Model;
using WholeSaleApp.Shared.Model.CodeBook;


namespace WholeSaleApp.Server.Services
{
    public class MapperService : IMapperService
    {
        public TDto ToDto<TModel, TDto>(TModel input) where TModel : BaseModel where TDto : BaseDto
        {
            var mappingMethod = typeof(MapperMapsExtensions).GetMethod("ToResponseDto", new Type[] {typeof(TModel)});
            var resultDto = mappingMethod.Invoke(null, new TModel[] { input }) as TDto;
            return resultDto;
        }

        public TModel ToModel<TModel, TRequestDto>(TRequestDto dto) where TModel : BaseModel where TRequestDto : class
        {
            var mappingMethod = typeof(ReverseMapperMapsExtensions).GetMethod("FromRequestDto", new Type[] { typeof(TRequestDto) });
            var resultDto = mappingMethod.Invoke(null, new TRequestDto[] { dto }) as TModel;
            return resultDto;
        }
    }
}

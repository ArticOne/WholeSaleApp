
using System.Reflection;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.Maps;
using WholeSaleApp.Shared.Model;
using WholeSaleApp.Shared.Model.CodeBook;


namespace WholeSaleApp.Server.Services
{
    public class MapperService : IMapperService
    {
        public TDto ToDto<TModel, TDto>(TModel input) where TModel : BaseModel where TDto : BaseDto
        {
            var mappingMethod = typeof(MapperMapsExtensions).GetMethod("ToDto", new Type[] {typeof(TModel)});
            var resultDto = mappingMethod.Invoke(null, new TModel[] { input }) as TDto;
            return resultDto;
        }

        public TModel ToModel<TModel, TDto>(TDto dto) where TModel : BaseModel where TDto : BaseDto
        {
            var mappingMethod = typeof(ReverseMapperMapsExtensions).GetMethod("FromDto", new Type[] { typeof(TDto) });
            var resultDto = mappingMethod.Invoke(null, new TDto[] { dto }) as TModel;
            return resultDto;
        }
    }
}

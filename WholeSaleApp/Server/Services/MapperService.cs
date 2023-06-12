
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
            var mappingMethod = typeof(ModelToResponseMapperExtensions).GetMethod("ToResponseDto", new Type[] {typeof(TModel)});
            var resultDto = mappingMethod.Invoke(null, new TModel[] { input }) as TDto;
            return resultDto;
        }

        public TModel ToModel<TModel, TRequestDto>(TRequestDto dto) where TModel : BaseModel where TRequestDto : class
        {
            var mappingMethod = typeof(RequestToModelMapperExtensions).GetMethod("FromRequestDto", new Type[] { typeof(TRequestDto) });
            var resultDto = mappingMethod.Invoke(null, new TRequestDto[] { dto }) as TModel;
            return resultDto;
        }

        public TRequestDto ToRequestDto<TModel, TRequestDto>(TModel input)
            where TModel : BaseModel where TRequestDto : class
        {
            var mappingMethod = typeof(ModelToRequestMapperExtensions).GetMethod("ToRequestDto", new Type[] { typeof(TModel) });
            var resultDto = mappingMethod.Invoke(null, new TModel[] { input }) as TRequestDto;
            return resultDto;
        }
    }
}

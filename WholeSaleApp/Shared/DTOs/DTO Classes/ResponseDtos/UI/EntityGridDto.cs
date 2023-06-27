namespace WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.UI
{
    public class EntityGridDto : BaseDto
    {
        public string Name { get; set; }
        public List<EntityColumnDto> EntityColumns { get; set; }
    }
}

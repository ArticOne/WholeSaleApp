

namespace WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.Documents.GoodsReceivedNote
{
    public class GoodsReceivedNoteAddDto
    {
        public string Code { get; set; }
        public DateTime Date { get; set; }
        public int PartnerId { get; set; }
        public int? PartnerOfficeId { get; set; }
        public string Note { get; set; }
        public List<GoodsReceivedNoteItemAddDto> GoodsReceivedNoteItems { get; set; }
    }
}

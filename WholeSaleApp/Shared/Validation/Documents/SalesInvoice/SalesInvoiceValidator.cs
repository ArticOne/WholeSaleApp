using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WholeSaleApp.Shared.DTOs.DTO_Classes.ResponseDtos.Documents.SalesInvoice;

namespace WholeSaleApp.Shared.Validation.Documents.SalesInvoice
{
    public class SalesInvoiceDtoValidator : AbstractValidator<SalesInvoiceDto>
    {
        public SalesInvoiceDtoValidator()
        {
          //  RuleForEach(x => x.SalesInvoiceItems).SetValidator(new SalesInvoiceItemDtoValidator());
            RuleFor(x => x.Partner).NotNull().WithMessage("Morate odabrati partnera");
            RuleFor(x => x.PartnerOffice)
                .NotNull()
                .When(x => x.Partner.PartnerOffices.Any())
                .WithMessage("Morate odabrati Poslovnicu");
            RuleFor(x => x.Warehouse).NotNull().WithMessage("Morate odabrati magacin");
            RuleFor(x => x.SalesInvoiceItems).NotNull().NotEmpty().WithMessage("Morate uneti barem jednu stavku").WithErrorCode("ItemCount");
        }
        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model,propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<SalesInvoiceDto>.CreateWithOptions((SalesInvoiceDto)model, x => x.IncludeProperties(propertyName)));
            return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
        };
    }

    public class SalesInvoiceItemDtoValidator : AbstractValidator<SalesInvoiceItemDto>
    {
        public SalesInvoiceItemDtoValidator()
        {
            RuleFor(x => x.OrdinalNumber).GreaterThan(0).WithMessage("Redni broj mora biti veća od 0");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Količina mora biti veća od 0");
            RuleFor(x => x.Price).GreaterThan(0).WithMessage("Cena mora biti veća od 0");
            RuleFor(x => x.Good).NotNull().WithMessage("Morate odabrati robu");
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateValue => async (model, propertyName) =>
        {
            propertyName = propertyName.Replace("Item.", "");
            var result = await ValidateAsync(ValidationContext<SalesInvoiceItemDto>.CreateWithOptions((SalesInvoiceItemDto)model, x => x.IncludeProperties(propertyName)));
            return result.IsValid ? Array.Empty<string>() : result.Errors.Select(e => e.ErrorMessage);
        };
    }
}
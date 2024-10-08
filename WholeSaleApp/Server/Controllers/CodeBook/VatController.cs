﻿using AutoMapper;
using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Server.Controllers.CodeBook
{
    public class VatController : BaseController<VatDto, VatAddDto,Vat>
    {
        public VatController(WsDbContext db, IMapper mapper) : base(db, mapper)
        {
        }
    }
}

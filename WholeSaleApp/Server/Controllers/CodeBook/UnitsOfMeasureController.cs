﻿using WholeSaleApp.Server.Data;
using WholeSaleApp.Server.Interfaces;
using WholeSaleApp.Shared.DTOs.CodeBook;
using WholeSaleApp.Shared.Model.CodeBook;

namespace WholeSaleApp.Server.Controllers.CodeBook
{
    public class UnitsOfMeasureController : BaseController<UnitOfMeasureDto, UnitOfMeasure>
    {
        public UnitsOfMeasureController(IMapperService mapperService, WsDbContext db) : base(mapperService, db)
        {
        }
    }
}

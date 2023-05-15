using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MudBlazor;


namespace WholeSaleApp.Shared.DTOs.Helper_DTOs
{
    public class GridStateDto
    {
        public List<SortDefinitionDto>? FilterDefinitions { get; set; }
        public List<FilterDefinitionDto>? SortDefinitions { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}

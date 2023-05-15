using System.Linq;
using System.Linq.Dynamic.Core;
using MudBlazor;
using WholeSaleApp.Shared.DTOs.Helper_DTOs;

public static class GridStateExtensions
{
    public static GridStateDto ToGridStateDto<T>(this GridState<T> gridState)
    {
        //var gridQuery = new GridStateDto
        //{
        //    Page = gridState.Page,
        //    PageSize = gridState.PageSize,
        //    Filter = new List<Filter>(),
        //    SortOrders = new List<SortOrder>()
        //};

        //if (gridState.FilterDefinitions.Count > 0)
        //{
        //    foreach (var filterDefinition in gridState.FilterDefinitions)
        //    {
        //        if (filterDefinition is { Operator: not null, Column: not null })
        //            gridQuery.Filters.Add(new Filter(filterDefinition.Operator)
        //            {
        //                Column = filterDefinition.Column.Title,
        //                Value = filterDefinition.Value?.ToString(),
        //                PropertyName = filterDefinition.Column.PropertyName
        //            });
        //    }
        //}

        //if (gridState.SortDefinitions.Count <= 0) return gridQuery;
        //foreach (var sortDefinition in gridState.SortDefinitions)
        //{
        //    gridQuery.SortOrders.Add(new SortOrder
        //    {
        //        Column = sortDefinition.SortBy,
        //        Descending = sortDefinition.Descending,
        //        Index = sortDefinition.Index
        //    });
        //}

        //return gridQuery;
        return null;
    }
}
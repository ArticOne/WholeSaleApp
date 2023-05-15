namespace WholeSaleApp.Shared.DTOs.Helper_DTOs;

public sealed record SortDefinitionDto(
    string SortBy,
    bool Descending,
    int Index)
;
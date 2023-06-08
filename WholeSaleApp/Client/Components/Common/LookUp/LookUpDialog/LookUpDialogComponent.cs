using System.Collections;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.CodeBook;
using static MudBlazor.CategoryTypes;

namespace WholeSaleApp.Client.Components.Common.LookUp.LookUpDialog
{
#warning "There is lots of copy paste from BrowserComponent, needs to be looked at!"
    public partial class LookUpDialogComponent<TResponseDto, TRequestDto> where TResponseDto : BaseDto where TRequestDto : class

    {
    [CascadingParameter] MudDialogInstance MudDialog { get; set; }


    void Submit() => MudDialog.Close(DialogResult.Ok((_dataGrid.SelectedItem)));
    void Cancel() => MudDialog.Cancel();


    #region BrowserCopyPaste

    private MudDataGrid<TResponseDto> _dataGrid;
    [Inject] private IGenericRepository<TResponseDto,TRequestDto> Repository { get; set; }
    private Dictionary<PropertyInfo, RenderFragment> columnFragments = new();
    private ObservableCollection<TResponseDto> GridSource { get; set; }


    protected override void OnInitialized()
    {
        GridSource = new ObservableCollection<TResponseDto>();
        base.OnInitialized();
    }

    protected override async Task OnInitializedAsync()
    {
        GridSource = new ObservableCollection<TResponseDto>(await Repository.GetAsync());
        await base.OnInitializedAsync();
    }

    private void RowClicked(DataGridRowClickEventArgs<TResponseDto> arg)
    {
        if (arg.MouseEventArgs.Detail > 1)
        {
            MudDialog.Close(DialogResult.Ok((arg.Item)));
        }

        _dataGrid.SelectedItem = arg.Item;
    }
#warning "This is a copy paste from BrowserComponent, needs to be looked at!"
    private string SelectedRowClassFunc(TResponseDto item, int rowIndex)
    {
        if (_dataGrid.SelectedItem?.Id == item.Id)
            return " selected ";

        return "";
    }

#warning "This is a copy paste from BrowserComponent, needs to be looked at!"
    private IEnumerable<PropertyInfo> GetPropertiesForDisplay()
    {
        return typeof(TResponseDto).GetProperties();
    }

#warning "This is a copy paste from BrowserComponent, needs to be looked at!"
    private RenderFragment CreateComponent(PropertyInfo propInfo) => builder =>
    {
        var parameterExpression = Expression.Parameter(typeof(TResponseDto), "x");
        var propertyAccess = Expression.Property(parameterExpression, propInfo.Name);
        var lambdaMethod = typeof(Expression).GetMethod("Lambda", 1,
            new[] { typeof(Expression), typeof(ParameterExpression[]) }, new ParameterModifier[] { new(2) });
        var func = typeof(Func<,>).MakeGenericType(typeof(TResponseDto), propInfo.PropertyType);
        var lambdaMethodInstance = lambdaMethod.MakeGenericMethod(func);
        var expression =
            lambdaMethodInstance.Invoke(this, new object[] { propertyAccess, new[] { parameterExpression } });


        builder.OpenComponent(0,
            typeof(PropertyColumn<,>).MakeGenericType(new[] { typeof(TResponseDto), propInfo.PropertyType }));
        builder.AddAttribute(1, "Property", expression);
        builder.CloseComponent();

    };

    private RenderFragment GetComponent(PropertyInfo property)
    {
        if (columnFragments.ContainsKey(property))
        {
            return columnFragments[property];
        }

        var newRenderFragment = CreateComponent(property);
        columnFragments.Add(property, newRenderFragment);
        return newRenderFragment;
    }

    #endregion

    }
}

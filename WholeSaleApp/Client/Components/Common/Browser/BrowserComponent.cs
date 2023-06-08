using System;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Reflection;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using WholeSaleApp.Client.Helpers;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Client.Services;
using WholeSaleApp.Shared.DTOs;
using WholeSaleApp.Shared.DTOs.DTO_Classes.RequestDtos.CodeBook;
using static MudBlazor.CategoryTypes;


namespace WholeSaleApp.Client.Components.Common.Browser
{
    public partial class BrowserComponent<T, TAddDto> where T : BaseDto where TAddDto : class
    {
        [Inject] private IDialogService DialogService { get; set; }
#warning "FIX THIS!"
        [Inject] private IGenericRepository<T, TAddDto> Repository { get; set; }

        [Inject] private NavigationManager NavManager { get; set; }
        private ObservableCollection<T> GridSource { get; set; }
        private MudDataGrid<T> _dataGrid;
        private Dictionary<PropertyInfo, RenderFragment> columnFragments = new();

        protected override void OnInitialized()
        {
            GridSource = new ObservableCollection<T>();
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            GridSource = new ObservableCollection<T>(await Repository.GetAsync());
            await base.OnInitializedAsync();
        }

        private IEnumerable<PropertyInfo> GetPropertiesForDisplay()
        {
            return typeof(T).GetProperties();
        }

        private RenderFragment CreateComponent(PropertyInfo propInfo) => builder =>
        {
            //to be replaced by this, to be analyzed
            //    // Define our instance parameter, which will be the input of the Func
            //    var objParameterExpr = Expression.Parameter(typeof(T), "instance");
            //    // 1. Cast the instance to the correct type
            //    var instanceExpr = Expression.TypeAs(objParameterExpr, property.DeclaringType);
            //    // 2. Call the getter and retrieve the value of the property
            //    var propertyExpr = Expression.Property(instanceExpr, property);
            //    // 3. Convert the property's value to object
            //    var propertyObjExpr = Expression.Convert(propertyExpr, typeof(U));
            //    // Create a lambda expression of the latest call & compile it
            //    return Expression.Lambda<Func<T, U>>(propertyObjExpr, objParameterExpr);


            var parameterExpression = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.Property(parameterExpression, propInfo.Name);
            var lambdaMethod = typeof(Expression).GetMethod("Lambda", 1,
                new[] { typeof(Expression), typeof(ParameterExpression[]) }, new ParameterModifier[] { new(2) });
            var func = typeof(Func<,>).MakeGenericType(typeof(T), propInfo.PropertyType);
            var lambdaMethodInstance = lambdaMethod.MakeGenericMethod(func);
            var expression =
                lambdaMethodInstance.Invoke(this, new object[] { propertyAccess, new[] { parameterExpression } });


            builder.OpenComponent(0,
                typeof(PropertyColumn<,>).MakeGenericType(new[] { typeof(T), propInfo.PropertyType }));
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

        private async Task<GridData<T>> ServerData(GridState<T> gridState)
        {
            var items = await Repository.GetAsync();
            //    var filterFunctions = gridState.FilterDefinitions.Select(x => x.GenerateFilterFunction());

            //var json = JsonSerializer.Serialize(gridState);

            return new GridData<T>() { Items = items };
        }

        private void RowClicked(DataGridRowClickEventArgs<T> arg)
        {
            if (arg.MouseEventArgs.Detail > 1)
            {
                OpenEdit(arg.Item.Id);
            }
            _dataGrid.SelectedItem = arg.Item;
        }

        private void ToolBarOpenNew(MouseEventArgs arg)
        {
            NavManager.NavigateTo($"/{UrlResolver.GetUrlSectionForType<T>()}/New");
        }

        private void ToolBarOpenEdit()
        {
            if (_dataGrid.SelectedItem != null)
            {
                OpenEdit(_dataGrid.SelectedItem.Id);
            }
        }

        private void ToolBarDelete()
        {
            if (_dataGrid.SelectedItem != null)
            {
                Delete(_dataGrid.SelectedItem.Id);
            }
        }

        private void OpenEdit(int id)
        {

            NavManager.NavigateTo($"/{UrlResolver.GetUrlSectionForType<T>()}/{id}");
        }

        private async Task Delete(int id)
        {
            bool? result = await DialogService.ShowMessageBox(
                "Brisanje podatka",
                "Da li ste sigurni da želite obrisati odabrani podatak? ",
                yesText: "Obriši", cancelText: "Otkaži");

            if (result == true)
            {
                await Repository.DeleteAsync(id);
                await _dataGrid.ReloadServerData();
            }
        }

        private string SelectedRowClassFunc(T item, int rowIndex)
        {
            if (_dataGrid.SelectedItem?.Id == item.Id)
                return " selected ";

            return "";
        }

        private EventCallback<List<T>> GridSourceChanged { get; set; }
    }
}
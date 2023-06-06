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
    public partial class LookUpDialogComponent<T> where T : BaseDto
    {
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }


        void Submit() => MudDialog.Close(DialogResult.Ok((_dataGrid.SelectedItem)));
        void Cancel() => MudDialog.Cancel();


        #region BrowserCopyPaste
        private MudDataGrid<T> _dataGrid;
        [Inject] private IGenericRepository<T> Repository { get; set; }
        private Dictionary<PropertyInfo, RenderFragment> columnFragments = new();
        private ObservableCollection<T> GridSource { get; set; }


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

        private void RowClicked(DataGridRowClickEventArgs<T> arg)
        {
            if (arg.MouseEventArgs.Detail > 1)
            {
                MudDialog.Close(DialogResult.Ok((arg.Item)));
            }
            _dataGrid.SelectedItem = arg.Item;
        }
#warning "This is a copy paste from BrowserComponent, needs to be looked at!"
        private string SelectedRowClassFunc(T item, int rowIndex)
        {
            if (_dataGrid.SelectedItem?.Id == item.Id)
                return " selected ";

            return "";
        }

#warning "This is a copy paste from BrowserComponent, needs to be looked at!"
        private IEnumerable<PropertyInfo> GetPropertiesForDisplay()
        {
            return typeof(T).GetProperties();
        }

#warning "This is a copy paste from BrowserComponent, needs to be looked at!"
        private RenderFragment CreateComponent(PropertyInfo propInfo) => builder =>
        {
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
        #endregion
    }
}

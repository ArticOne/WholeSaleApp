using System.Linq.Expressions;
using System.Reflection;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using WholeSaleApp.Client.Interfaces;
using WholeSaleApp.Client.Services;
using WholeSaleApp.Shared.DTOs;


namespace WholeSaleApp.Client.Components.Common.Browser
{
    public partial class BrowserComponent<T> where T : BaseDto
    {
        [Inject] private IGenericRepository<T> Repository{ get; set; } 
        private List<T> GridSource { get; set; }
        private MudDataGrid<T> _dataGrid;
        private Dictionary<PropertyInfo, RenderFragment> columnFragments = new();

        protected override void OnInitialized()
        {
            GridSource = new List<T>();
            base.OnInitialized();
        }
        protected override async Task OnInitializedAsync()
        {
            GridSource = await Repository.GetAsync();
            await base.OnInitializedAsync();
         //   _dataGrid.Loading = false;
        }

        private IEnumerable<PropertyInfo> GetPropertiesForDisplay()
        {
            return typeof(T).GetProperties();
        }

        private RenderFragment CreateComponent(PropertyInfo propInfo) => builder =>
        {
            var parameterExpression = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.Property(parameterExpression, propInfo.Name);
            var lambdaMethod = typeof(Expression).GetMethod("Lambda", 1, new[] { typeof(Expression), typeof(ParameterExpression[]) }, new ParameterModifier[] { new(2) });
            var func = typeof(Func<,>).MakeGenericType(typeof(T), propInfo.PropertyType);
            var lamdaMethodInstance = lambdaMethod.MakeGenericMethod(func);
            var expression = lamdaMethodInstance.Invoke(this, new object[] { propertyAccess, new[] { parameterExpression } });


            builder.OpenComponent(0, typeof(PropertyColumn<,>).MakeGenericType(new[] { typeof(T), propInfo.PropertyType }));
            builder.AddAttribute(1, "Property", expression);
            builder.CloseComponent();

        };


        private RenderFragment GetComponent(PropertyInfo property)
        {
            if (columnFragments.ContainsKey(property))
            {
                return columnFragments[property];
            }
            else
            {
                var newRenderFragment = CreateComponent(property);
                columnFragments.Add(property,newRenderFragment);
                return  newRenderFragment;
            }
        }
    }

}

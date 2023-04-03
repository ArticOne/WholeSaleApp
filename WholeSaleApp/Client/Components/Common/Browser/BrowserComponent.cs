using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Options;
using MudBlazor;
using WholeSaleApp.Shared.DTOs;


namespace WholeSaleApp.Client.Components.Common.Browser
{
    public partial class BrowserComponent<T> where T : BaseDto
    {
        [Parameter] public List<T> GridSource { get; set; }
        private MudDataGrid<T> _dataGrid;

        protected override void OnInitialized()
        {
            base.OnInitialized();
        }


        private dynamic GetPropertyValue(PropertyInfo property, T baseDto)

        {
            var value = property.GetValue(baseDto);
            return value;
        }

        private IEnumerable<PropertyInfo> GetPropertiesForDisplay()
        {
            return typeof(T).GetProperties();
        }

        private string GetTitle(PropertyInfo property)
        {
            return property.Name;
        }

        //private RenderFragment CreateComponent(PropertyInfo propInfo) => builder =>
        //{
        //    //var discountFilter = "album => album.Quantity > 0";
        //    //var options = ScriptOptions.Default.AddReferences(typeof(Album).Assembly);

        //    //Func<Album, bool> discountFilterExpression = await CSharpScript.EvaluateAsync<Func<Album, bool>>(discountFilter, options);

        //    //var discountedAlbums = albums.Where(discountFilterExpression);
        //    ////hooray now we have discountedAlbums!






        //   var a = typeof(PropertyColumn<,>).MakeGenericType(new[] { typeof(T), propInfo.PropertyType });

        //   Type funcType = typeof(Func<,>).MakeGenericType(typeof(T), propInfo.PropertyType);


        //   Func<Album, bool> discountFilterExpression = await CSharpScript.EvaluateAsync(discountFilter, options);


        //    builder.OpenComponent(0, a);
        //   // builder.AddAttribute(1, "Property", "x => x.GetPropertyValue(propInfo, x)");
        //   // builder.AddAttribute(1, "Property", );
        //    builder.CloseComponent();

        //};
        private RenderFragment CreateComponent(PropertyInfo propInfo) => builder =>
        {
            var methodInfos = typeof(LambdaExpression).GetMethods(BindingFlags.Public | BindingFlags.Static).ToList();
            var methodInfos2 = typeof(Expression).GetMethods(BindingFlags.Public | BindingFlags.Static).ToList().Where(x => x.Name == "Lambda" && x.IsGenericMethod).ToList();



            var probaa = methodInfos2[2].GetParameters();

            var parameterExpression = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.Property(parameterExpression, propInfo.Name);

       //     var lambda = Expression.Lambda<Func<T, dynamic>>(propertyAccess, parameterExpression);

            var method = typeof(Expression).GetMethod("Lambda", 1,  new[] { typeof(Expression), typeof(ParameterExpression[]) }, new ParameterModifier[] { new (2) });

            var funk = typeof(Func<,>).MakeGenericType(typeof(T), propInfo.PropertyType);


            var m2=method.MakeGenericMethod(funk);
            var aaaa = m2.Invoke(this, new object[] { propertyAccess, new[] { parameterExpression } });


            builder.OpenComponent(0, typeof(PropertyColumn<,>).MakeGenericType(new[] { typeof(T), propInfo.PropertyType }));
            builder.AddAttribute(1, "Property", aaaa);
            builder.CloseComponent();

        };


    }

}

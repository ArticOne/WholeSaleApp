using Microsoft.VisualBasic;
using MudBlazor;
using System.Reflection;
using WholeSaleApp.Client.Components.Modules.CrudComponentBase;
using WholeSaleApp.Client.Helpers;

namespace WholeSaleApp.Tests
{
    public class UriResolverTests
    {
        [Fact]
        public void GetUrlForTypeAllCrudComponentsHaveExactlyOneUrl()
        {
            // Arrange
            var clientAssembly = Assembly.Load("WholeSaleApp.Client");
            var typesInheritingFromCrudComponentBase =
                GetAllTypesImplementingOpenGenericType(typeof(CrudComponentBase<>), clientAssembly);

            var existingUris = new HashSet<string>();

            // Act

            foreach (var crudType in typesInheritingFromCrudComponentBase)
            {
                var genericArguments = crudType.BaseType.GetGenericArguments();
                if (genericArguments.Count() != 1)
                {
                    throw new Exception("Number of parameters has changed");
                }
                var baseDto = genericArguments[0];

                var uri = typeof(UrlResolver)
                    .GetMethod("GetUrlSectionForType")
                    .MakeGenericMethod(baseDto)
                    .Invoke(null, null) as Uri;

                if (existingUris.Contains(uri.AbsolutePath))
                {
                    throw new Exception("Duplication of an Uri");

                }
                existingUris.Add(uri.AbsolutePath);

            }

            // Assert
            // no assert needed, currently I'm checking for exceptions



        }

        private static HashSet<Type> GetAllTypesImplementingOpenGenericType(Type openGenericType, Assembly assembly)
        {
            var types = from x in assembly.GetTypes()
                let y = x.BaseType
                where
                    (y != null && y.IsGenericType &&
                     openGenericType.IsAssignableFrom(y.GetGenericTypeDefinition()))
                select x;

            return new HashSet<Type>(types);
        }
    }
}
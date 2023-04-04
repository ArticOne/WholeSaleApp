using Microsoft.AspNetCore.Components;
using WholeSaleApp.Client.Components.Common.Browser;
using WholeSaleApp.Shared.DTOs.CodeBook;

namespace WholeSaleApp.Client.Components.Common.MainWindow
{
    public partial class MainWindowComponent
    {
        private RenderFragment? _customRender;

        private RenderFragment? CustomRender
        {
            get
            {
                return CreateComponent();
            }
            set => _customRender = value;
        }

        private RenderFragment CreateComponent() => builder =>
        {
            var dtoType = Type.GetType("WholeSaleApp.Shared.DTOs.CodeBook.LocationDto, WholeSaleApp.Shared");
            builder.OpenComponent(0, typeof(BrowserComponent<>).MakeGenericType(new Type[] { dtoType }));
            builder.AddAttribute(1, "GridSource", new List<LocationDto>() { new LocationDto() { Id = 1, Name = "AVIONSKIR", ZipCode = "zipkod" } });
            builder.CloseComponent();

        };
    }
}

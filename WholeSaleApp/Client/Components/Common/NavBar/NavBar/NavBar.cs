using MudBlazor;

namespace WholeSaleApp.Client.Components.Common.NavBar.NavBar
{
    public partial class NavBar
    {
        bool open = false;
        void ToggleDrawer()
        {
            open = !open;
        }
        private string SubNavOpenClass = "";

        private void OpenSubMenu()
        {
            SubNavOpenClass = " open ";
        }

        private void CloseSubMenu()
        {
            SubNavOpenClass = "";
        }
    }
}

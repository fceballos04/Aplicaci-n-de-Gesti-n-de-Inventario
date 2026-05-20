using AntHiveStock.Services;
using AntHiveStock.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AntHiveStock;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(ProductFormPage), new ServiceProviderRouteFactory<ProductFormPage>(serviceProvider));

        DashboardContent.ContentTemplate = new DataTemplate(() => serviceProvider.GetRequiredService<DashboardPage>());
        InventoryContent.ContentTemplate = new DataTemplate(() => serviceProvider.GetRequiredService<InventoryPage>());
        SettingsContent.ContentTemplate = new DataTemplate(() => serviceProvider.GetRequiredService<SettingsPage>());
    }

    
    public void ActualizarDatosUsuario()
    {
        LblFlyoutEmpresa.Text = Models.SesionUsuario.NombreEmpresa;
        LblFlyoutCorreo.Text = Models.SesionUsuario.Correo;
    }

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert("Cerrar Sesión", "¿Estás seguro de que deseas salir de la aplicación?", "Sí", "No");

        if (confirmar)
        {
            
            Models.SesionUsuario.NombreEmpresa = "Invitado";
            Models.SesionUsuario.Correo = string.Empty;

            
            if (Application.Current != null)
            {
                Application.Current.MainPage = new NavigationPage(new LoginViews.Login());
            }
        }
    }
}
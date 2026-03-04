using Invex_App.LoginViews;
using Invex_App.Views;
using Invex_App.Views; 


namespace Invex_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();


            // 1. Registro de páginas de la carpeta LoginViews
            Routing.RegisterRoute("SigIn", typeof(SigIn));
            Routing.RegisterRoute("Register", typeof(Register));
            Routing.RegisterRoute("ForgotPassword", typeof(ForgotPassword));

            // 2. Registro de páginas de la carpeta Views
            Routing.RegisterRoute("DashboardPage", typeof(DashboardPage));

            // 3. (Opcional) Si creas la carpeta Modules, las registrarías aquí también
            // Routing.RegisterRoute("InventoryHome", typeof(Modules.InventoryHome));
        } 
        private async void OnLogoutClicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Salir", "¿Estás seguro de que quieres cerrar sesión?", "Sí", "No");
            if (answer)
            {
                // Regresamos al Login y limpiamos el historial (usando //)
                await Shell.Current.GoToAsync("//SigIn");
            }

            // 2. Registramos la ruta usando la clase que está en Views
            Routing.RegisterRoute("DashboardPage", typeof(DashboardPage));

        }
    }
}
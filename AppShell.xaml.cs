using Invex_App.Views;
using Invex_App.LoginViews; // IMPORTANTE: Para que reconozca SigIn, Register, etc.

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
    }
}
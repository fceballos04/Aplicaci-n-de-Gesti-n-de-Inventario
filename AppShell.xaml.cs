using Invex_App.Views; 

namespace Invex_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // 2. Registramos la ruta usando la clase que está en Views
            Routing.RegisterRoute("DashboardPage", typeof(DashboardPage));
        }
    }
}
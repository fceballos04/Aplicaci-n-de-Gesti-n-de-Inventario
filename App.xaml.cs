using Invex_App.LoginViews;

namespace Invex_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // ESTA ES LA LÍNEA MAESTRA:
            // Al asignar AppShell, activas el menú de la izquierda y todas las rutas.
            MainPage = new AppShell();
        }

        // NO necesitas el método CreateWindow para un proyecto estándar de MAUI.
        // Al quitarlo, dejas que AppShell tome el control total.
    }
}
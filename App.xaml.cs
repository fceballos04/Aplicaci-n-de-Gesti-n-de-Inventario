using Microsoft.Extensions.DependencyInjection;
// IMPORTANTE: Agrega el "using" de tu carpeta para que reconozca la página
using Invex_App.LoginViews;

namespace Invex_App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Cambiamos 'new AppShell()' por tu página de Login
            // Usamos NavigationPage para que puedas navegar después a otras carpetas
            return new Window(new NavigationPage(new Login()));
        }
    }
}
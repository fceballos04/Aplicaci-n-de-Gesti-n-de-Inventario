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

            MainPage = new NavigationPage(new Login());
        }
    }
}
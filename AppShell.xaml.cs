using Invex_App.Interfaz;

namespace Invex_App
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("DashboardPage", typeof(Interfaz.InterfazPage));
        }
        private void OnSettingClicked(object sender, EventArgs e)
        {

        }
    }
}

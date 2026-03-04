using Invex_App.Views;

namespace Invex_App.LoginViews
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        // --- NAVEGACIÓN MODERNA CON SHELL ---

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            // En lugar de PushModal, usamos la ruta que registramos en AppShell
            await Shell.Current.GoToAsync("SigIn");
        }

        private async void OnCreateAccountClicked(object sender, EventArgs e)
        {
            // Usamos la ruta del registro
            await Shell.Current.GoToAsync("Register");
        }

        private async void OnGoogleLoginTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Google", "Conectando con Google...", "OK");
        }
    }
}
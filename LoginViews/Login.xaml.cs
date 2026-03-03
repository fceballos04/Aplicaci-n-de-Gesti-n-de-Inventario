using Microsoft.Maui.Controls;
using Invex_App.Views; // CORRECCIÓN 1: Agregar el namespace de la carpeta Views

namespace Invex_App.LoginViews
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        
        }

        // --- NAVEGACIÓN ENTRE CONTENEDORES (VISTAS INTERNAS) ---

        private async void OnLoginClicked(object sender, EventArgs e)
        {

=======
            await Navigation.PushModalAsync(new SigIn(), animated: true);

        }

        private async void OnCreateAccountClicked(object sender, EventArgs e)
        {

=======
            await Navigation.PushModalAsync(new Register(), animated: true);

        }

        private async void OnGoogleLoginTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Google", "Conectando con Google...", "OK");
        }


    }
}
using Microsoft.Maui.Controls;

namespace Invex_App.LoginViews
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        //NAVEGACIÓN

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            InitialButtonsContainer.IsVisible = false;
            LoginFormContainer.Opacity = 0;
            LoginFormContainer.IsVisible = true;

            await LoginFormContainer.FadeTo(1, 250);
        }

        private async void OnCreateAccountClicked(object sender, EventArgs e)
        {
            InitialButtonsContainer.IsVisible = false;
            RegisterFormContainer.Opacity = 0;
            RegisterFormContainer.IsVisible = true;

            await RegisterFormContainer.FadeTo(1, 250);
        }

        private void OnBackClicked(object sender, EventArgs e)
        {
            // Oculta ambos formularios y vuelve al inicio
            LoginFormContainer.IsVisible = false;
            RegisterFormContainer.IsVisible = false;
            OlvidasteContraseñaFormContainer.IsVisible = false;
            InitialButtonsContainer.IsVisible = true;
            InitialButtonsContainer.Opacity = 1;
        }

        private async void OnOlvidasteContraseñaClicked(object sender, EventArgs e)
        {
            InitialButtonsContainer.IsVisible = false;
            OlvidasteContraseñaFormContainer.Opacity = 0;
            OlvidasteContraseñaFormContainer.IsVisible = true;

            await OlvidasteContraseñaFormContainer.FadeTo(1, 250);
        }

        //ACCIONES (POR EL MOMENTO)

        private async void OnSubmitLoginClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Invex", "Inicio de sesion exitoso", "OK");
        }

        private async void OnSubmitRegisterClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Invex", "Empresa registrada con éxito", "OK");
        }

        private async void OnGoogleLoginTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Google", "Conectando...", "OK");
        }
        private async void OnRecuperarContraseñaClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Invex", "Datos correctos", "OK");
        }
    }
}
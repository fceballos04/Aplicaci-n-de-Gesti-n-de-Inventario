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
            LoginFormContainer.IsVisible = false;
            OlvidasteContraseñaFormContainer.Opacity = 0;
            OlvidasteContraseñaFormContainer.IsVisible = true;

            await OlvidasteContraseñaFormContainer.FadeTo(1, 250);
        }

        //ACCIONES (POR EL MOMENTO)
        private void OnLoginPasswordClicked(object sender, EventArgs e)
        {
            LoginPasswordEntry.IsPassword = !LoginPasswordEntry.IsPassword;
            ToggleLoginPasswordButton.Source = LoginPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
        }
        private void OnToggleRegisterPasswordClicked(object sender, EventArgs e)
        {
            RegisterPasswordEntry.IsPassword = !RegisterPasswordEntry.IsPassword;
            ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
        }
        private async void OnSubmitLoginClicked(object sender, EventArgs e)
        {
             await DisplayAlert("Invex", "Inicio de sesion exitoso", "OK");
        }

        private async void OnSubmitRegisterClicked(object sender, EventArgs e)
        {
            // Se extrae los textos de los campos (el ?.Trim() elimina los espacios accidentales al inicio o final)
            string nombreEmpresa = TxtEmpresa.Text?.Trim();
            string correo = TxtEmail.Text?.Trim();
            string contraseña = RegisterPasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(nombreEmpresa) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(contraseña))
            {
               LabelError.IsVisible=true;

                return;
            }

            LabelError.IsVisible = false;
            await DisplayAlert("Invex", "Campos validados correctamente.\nGuardando...", "OK");
         

            // Espacio para guardar los datos en un JSON (INVESTIGAR COMO)
        
        }

        private async void OnGoogleLoginTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Google", "Conectando con Google...", "OK");
        }
        private async void OnRecuperarContraseñaClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Invex", "Datos correctos", "OK");
        }
    }
}
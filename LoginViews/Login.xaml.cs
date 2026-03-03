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

        // --- ACCIONES DE FORMULARIO ---

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
            // 1. Validación de campos
            if (string.IsNullOrWhiteSpace(LoginEmailEntry.Text) || string.IsNullOrWhiteSpace(LoginPasswordEntry.Text))
            {
                await DisplayAlert("Error", "Por favor ingresa tus credenciales", "OK");
                return;
            }

            try
            {
                // 2. Mensaje de éxito
                await DisplayAlert("Invex", "Inicio de sesión exitoso", "OK");

                // CORRECCIÓN 2: Verificación de nulidad del Shell antes de navegar
                if (Shell.Current != null)
                {
                    await Shell.Current.GoToAsync("//DashboardPage");
                }
                else
                {
                    // Si el Shell es nulo, usamos una navegación alternativa de emergencia
                    Application.Current.MainPage = new AppShell();
                    await Shell.Current.GoToAsync("//DashboardPage");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error de Navegación", $"Detalle: {ex.Message}", "OK");
            }
        }

        private async void OnSubmitRegisterClicked(object sender, EventArgs e)
        {
            string nombreEmpresa = TxtEmpresa.Text?.Trim();
            string correo = TxtEmail.Text?.Trim();
            string contraseña = RegisterPasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(nombreEmpresa) ||
                string.IsNullOrWhiteSpace(correo) ||
                string.IsNullOrWhiteSpace(contraseña))
            {
                LabelError.IsVisible = true;
                return;
            }

            LabelError.IsVisible = false;
            await DisplayAlert("Invex", "Cuenta creada correctamente", "OK");
        }

        private async void OnGoogleLoginTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Google", "Conectando con Google...", "OK");
        }

        private async void OnRecuperarContraseñaClicked(object sender, EventArgs e)
        {
            await DisplayAlert("Invex", "Se ha enviado un correo de recuperación", "OK");
            OnBackClicked(null, null);
        }
    }
}
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

        private async void OnSubmitLoginClicked(object sender, EventArgs e)
        {
             await DisplayAlert("Invex", "Inicio de sesion exitoso", "OK");
        }

        private async void OnSubmitRegisterClicked(object sender, EventArgs e)
        {
            // Se extrae los textos de los campos (el ?.Trim() elimina los espacios accidentales al inicio o final)
            string nombreEmpresa = TxtEmpresa.Text?.Trim();
            string correo = TxtEmail.Text?.Trim();
            string contraseña = TxtContraseña.Text;

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
        private void ValidarCampos()
        {
            // Si está vacío se muestra el LabelError 
            bool hayError = LabelError.IsVisible = string.IsNullOrWhiteSpace(TxtContraseña.Text);
                            LabelError.IsVisible = string.IsNullOrWhiteSpace(TxtEmail.Text);
                            LabelError.IsVisible = string.IsNullOrWhiteSpace(TxtEmpresa.Text);

            LabelError.IsVisible = hayError;

            TxtContraseña.PlaceholderColor = string.IsNullOrWhiteSpace(TxtContraseña.Text) ? Colors.Red : Colors.Gray;
            TxtEmail.PlaceholderColor = string.IsNullOrWhiteSpace(TxtEmail.Text) ? Colors.Red : Colors.Gray;
            TxtEmpresa.PlaceholderColor = string.IsNullOrWhiteSpace(TxtEmpresa.Text) ? Colors.Red : Colors.Gray;
        }
    }
}
namespace Invex_App.LoginViews;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
	}

     //NAVEGACIÓN

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(animated: true);
    }

    //ACCIONES (POR EL MOMENTO)

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
            LabelError.IsVisible = true;

            return;
        }

        LabelError.IsVisible = false;
        await DisplayAlert("Invex", "Campos validados correctamente.\nGuardando...", "OK");


        // Después de registrar, lo enviamos al Dashboard de una vez
        // El "//" limpia el historial de navegación para que no pueda volver al registro con el botón de atrás
        await Shell.Current.GoToAsync("//DashboardPage");

    }

    private async void OnGoogleLoginTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Google", "Conectando con Google...", "OK");
    }
    private async void OnRecuperarContraseñaClicked(object sender, EventArgs e)
    {
        await DisplayAlert("Invex", "Los datos son correctos", "OK");
    }
}

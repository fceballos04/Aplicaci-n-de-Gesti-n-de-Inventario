namespace Invex_App.LoginViews;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
    }

    // --- NAVEGACIÓN ---

    private async void OnBackClicked(object sender, EventArgs e)
    {
        // Regresa a la página anterior en el historial de Shell (hacia atrás)
        await Shell.Current.GoToAsync("..");
    }

    // --- ACCIONES ---

    private void OnToggleRegisterPasswordClicked(object sender, EventArgs e)
    {
        RegisterPasswordEntry.IsPassword = !RegisterPasswordEntry.IsPassword;
        // Cambia el icono del ojo
        ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
    }

    private async void OnSubmitRegisterClicked(object sender, EventArgs e)
    {
        string nombreEmpresa = TxtEmpresa.Text?.Trim();
        string correo = TxtEmail.Text?.Trim();
        string contraseña = RegisterPasswordEntry.Text;

        // Validación de campos
        if (string.IsNullOrWhiteSpace(nombreEmpresa) ||
            string.IsNullOrWhiteSpace(correo) ||
            string.IsNullOrWhiteSpace(contraseña))
        {
            LabelError.IsVisible = true;
            return;
        }

        LabelError.IsVisible = false;
        await DisplayAlert("Invex", "Cuenta creada con éxito.\nBienvenido.", "OK");

        // Después de registrar, lo enviamos al Dashboard de una vez
        // El "//" limpia el historial de navegación para que no pueda volver al registro con el botón de atrás
        await Shell.Current.GoToAsync("//DashboardPage");
    }

    private async void OnGoogleLoginTapped(object sender, EventArgs e)
    {
        await DisplayAlert("Google", "Conectando con Google...", "OK");
    }
}
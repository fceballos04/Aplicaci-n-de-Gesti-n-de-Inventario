namespace Invex_App.LoginViews;

public partial class SigIn : ContentPage
{
    public SigIn()
    {
        InitializeComponent();
    }

    // --- NAVEGACIÓN ---

    private async void OnBackClicked(object sender, EventArgs e)
    {
        // En Shell, regresamos de forma segura a la página anterior con ".."
        await Shell.Current.GoToAsync("..");
    }

    private async void OnOlvidasteContraseñaClicked(object sender, EventArgs e)
    {
        // Navegamos a la ruta que registramos en AppShell.xaml.cs
        await Shell.Current.GoToAsync("ForgotPassword");
    }

    // --- ACCIONES ---

    private void OnLoginPasswordClicked(object sender, EventArgs e)
    {
        LoginPasswordEntry.IsPassword = !LoginPasswordEntry.IsPassword;
        ToggleLoginPasswordButton.Source = LoginPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
    }

    private async void OnSubmitLoginClicked(object sender, EventArgs e)
    {
        // Aquí podrías validar si los campos están vacíos antes de entrar
        if (string.IsNullOrWhiteSpace(LoginPasswordEntry.Text))
        {
            await DisplayAlert("Invex", "Por favor ingresa tu contraseña", "OK");
            return;
        }

        await DisplayAlert("Invex", "Inicio de sesión exitoso", "OK");

        // IMPORTANTE: Después del login, saltamos al Dashboard.
        // Usamos "//" para que el usuario no pueda "regresar" al login con el botón del celular.
        await Shell.Current.GoToAsync("//DashboardPage");
    }
}
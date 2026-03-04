namespace Invex_App.LoginViews;

public partial class ForgotPassword : ContentPage
{
    public ForgotPassword()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        // En Shell nos sirve para regresar a la página anterior de forma segura se usamos ".."
        await Shell.Current.GoToAsync("..");
    }
        // Acciones 
    private async void OnRecuperarContraseñaClicked(object sender, EventArgs e)
    {
       
        await DisplayAlert("Invex", "Si el correo está registrado, recibirás instrucciones para restablecer tu contraseña.", "OK");

        // Después de mostrar el mensaje, lo enviamos de vuelta al Login
        await Shell.Current.GoToAsync("..");
    }
}
namespace Invex_App.LoginViews;

using Invex_App;


public partial class SigIn : ContentPage
{
    public SigIn()
    {
        InitializeComponent();
    }
    //NAVEGACIÓN
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(animated: true);
    }

    private async void OnOlvidasteContraseñaClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ForgotPassword(), animated: true);
    }

    //ACCIONES (POR EL MOMENTO)
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
        await DisplayAlert("Invex", "Inicio de sesion exitoso", "OK");

        Application.Current.MainPage = new AppShell();
    }
}
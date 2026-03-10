namespace Invex_App.LoginViews;

using Invex_App;


public partial class SigIn : ContentPage
{
    public SigIn()
    {
        InitializeComponent();
        ActualizarDiseñoSegunTema();
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

        bool esOscuro = Application.Current.Resources["AppTextColor"].Equals(Colors.White);

        if (LoginPasswordEntry.IsPassword)
        {
            ToggleLoginPasswordButton.Source = esOscuro ? "ojo_cerrado.png" : "ojonegro_cerrado.png";
        }
        else
        {
            ToggleLoginPasswordButton.Source = esOscuro ? "ojo_abierto.png" : "ojonegro_abierto.png";
        }
    }
    private async void OnSubmitLoginClicked(object sender, EventArgs e)
    {
        ErrorEmail.IsVisible = false;
        ErrorPassword.IsVisible = false;

        string email = TxtEmail.Text?.Trim();
        string password = LoginPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(email))
        {
            ErrorEmail.IsVisible = true;
            return;
        }

        if (string.IsNullOrWhiteSpace(password))
        {
            ErrorPassword.IsVisible = true;
            return;
        }

        await DisplayAlert("ANTHIVE STOCK", "Inicio de sesión exitoso", "OK");
        Application.Current.MainPage = new AppShell();
    }

    private void OnThemeToggleButtonClicked(object sender, EventArgs e)
    {
        
        bool esModoOscuroActualmente = Application.Current.Resources["AppTextColor"].Equals(Colors.White);

        if (esModoOscuroActualmente)
        {
            // CAMBIAR A MODO CLARO
            BackgroundImage.Source = "inventario_claro.png";
            ThemeToggleButton.Source = "luna_simbolo.png";
            DarkOverlay.Opacity = 0.1;

            Application.Current.Resources["AppTextColor"] = Colors.Black;
            Application.Current.Resources["AppSubTitleColor"] = Color.FromArgb("#707070");
            Application.Current.Resources["AppButtonBorder"] = Colors.Black;
            Application.Current.Resources["AppEntryTextColor"] = Colors.Black;

            ToggleLoginPasswordButton.Source = LoginPasswordEntry.IsPassword ? "ojonegro_cerrado.png" : "ojonegro_abierto.png";
        }
        else
        {
            // CAMBIAR A MODO OSCURO
            BackgroundImage.Source = "inventario.png";
            ThemeToggleButton.Source = "sol_simbolo.png";
            DarkOverlay.Opacity = 0.5;

            Application.Current.Resources["AppTextColor"] = Colors.White;
            Application.Current.Resources["AppSubTitleColor"] = Color.FromArgb("#D1D1D1");
            Application.Current.Resources["AppButtonBorder"] = Colors.White;
            Application.Current.Resources["AppEntryTextColor"] = Colors.White;

            ToggleLoginPasswordButton.Source = LoginPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
        }
    }

    private void ActualizarDiseñoSegunTema()
    {
        bool esOscuro = Application.Current.Resources["AppTextColor"].Equals(Colors.White);

        if (esOscuro)
        {
            BackgroundImage.Source = "inventario.png";
            ThemeToggleButton.Source = "sol_simbolo.png";
            DarkOverlay.Opacity = 0.5;
            // Ojo blanco para modo oscuro
            ToggleLoginPasswordButton.Source = LoginPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
        }
        else
        {
            BackgroundImage.Source = "inventario_claro.png";
            ThemeToggleButton.Source = "luna_simbolo.png";
            DarkOverlay.Opacity = 0.1;
            // Ojo negro para modo claro
            ToggleLoginPasswordButton.Source = LoginPasswordEntry.IsPassword ? "ojonegro_cerrado.png" : "ojonegro_abierto.png";
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ActualizarDiseñoSegunTema();
    }

}
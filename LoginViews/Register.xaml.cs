namespace Invex_App.LoginViews;

public partial class Register : ContentPage
{
	public Register()
	{
		InitializeComponent();
        ActualizarDiseñoSegunTema();
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

        bool esOscuro = Application.Current.Resources["AppTextColor"].Equals(Colors.White);

        if (RegisterPasswordEntry.IsPassword)
        {
            ToggleRegisterPasswordButton.Source = esOscuro ? "ojo_cerrado.png" : "ojonegro_cerrado.png";
        }
        else
        {
            ToggleRegisterPasswordButton.Source = esOscuro ? "ojo_abierto.png" : "ojonegro_abierto.png";
        }
    }
    private async void OnSubmitLoginClicked(object sender, EventArgs e)
    {
        await DisplayAlert("ANTHIVE STOCK", "Inicio de sesion exitoso", "OK");
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
        await DisplayAlert("ANTHIVE STOCK", "Campos validados correctamente.\nGuardando...", "OK");


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
        await DisplayAlert("ANTHIVE STOCK", "Los datos son correctos", "OK");
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

         
            ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword ? "ojonegro_cerrado.png" : "ojonegro_abierto.png";
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

            
            ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
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
            // Ojo blanco
            ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
        }
        else
        {
            BackgroundImage.Source = "inventario_claro.png";
            ThemeToggleButton.Source = "luna_simbolo.png";
            DarkOverlay.Opacity = 0.1;
            // Ojo negro
            ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword ? "ojonegro_cerrado.png" : "ojonegro_abierto.png";
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        ActualizarDiseñoSegunTema();
    }

}

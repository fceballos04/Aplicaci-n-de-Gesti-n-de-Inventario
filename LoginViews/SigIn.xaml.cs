using AntHiveStock.Models;
using AntHiveStock.Services;

namespace AntHiveStock.LoginViews;

public partial class SigIn : ContentPage
{
    private readonly IServiceProvider _serviceProvider;

    // Usamos el contenedor de servicios para poder resolver el AppShell inyectado
    public SigIn()
    {
        InitializeComponent();
        _serviceProvider = App.Current?.Handler?.MauiContext?.Services ?? throw new InvalidOperationException("No se encontraron los servicios.");
        ActualizarDiseñoSegunTema();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(animated: true);
    }

    private async void OnOlvidasteContraseñaClicked(object sender, EventArgs e)
    {
        await Navigation.PushModalAsync(new ForgotPassword(), animated: true);
    }

    private void OnLoginPasswordClicked(object sender, EventArgs e)
    {
        LoginPasswordEntry.IsPassword = !LoginPasswordEntry.IsPassword;
        bool esOscuro = Application.Current!.Resources["AppTextColor"].Equals(Colors.White);

        ToggleLoginPasswordButton.Source = LoginPasswordEntry.IsPassword
            ? (esOscuro ? "ojo_cerrado.png" : "ojonegro_cerrado.png")
            : (esOscuro ? "ojo_abierto.png" : "ojonegro_abierto.png");
    }

    private async void OnSubmitLoginClicked(object sender, EventArgs e)
    {
        ErrorEmail.IsVisible = false;
        ErrorPassword.IsVisible = false;

        string emailIngresado = TxtEmail.Text?.Trim() ?? string.Empty;
        string passwordIngresada = LoginPasswordEntry.Text ?? string.Empty;

        if (string.IsNullOrWhiteSpace(emailIngresado))
        {
            ErrorEmail.IsVisible = true;
            return;
        }

        if (string.IsNullOrWhiteSpace(passwordIngresada))
        {
            ErrorPassword.IsVisible = true;
            return;
        }

        var usuariosRegistrados = UserService.ObtenerTodos();
        var usuarioEncontrado = usuariosRegistrados.FirstOrDefault(u =>
            u.Correo.Equals(emailIngresado, StringComparison.OrdinalIgnoreCase) &&
            u.Password == passwordIngresada);

        // ... (código previo de validación dentro de OnSubmitLoginClicked)
        if (usuarioEncontrado != null)
        {
            SesionUsuario.NombreEmpresa = usuarioEncontrado.NombreEmpresa;
            SesionUsuario.Correo = usuarioEncontrado.Correo;

            await DisplayAlert("ANTHIVE STOCK", $"Bienvenido {usuarioEncontrado.NombreEmpresa}", "OK");

            // Solicitamos el AppShell del contenedor de dependencias
            var shellPrincipal = _serviceProvider.GetRequiredService<AppShell>();

            // LINEA CLAVE: Actualiza el texto del menú lateral con los datos reales antes de mostrarlo
            shellPrincipal.ActualizarDatosUsuario();

            Application.Current.MainPage = shellPrincipal;
        }
        else
        {
            await DisplayAlert("Error de acceso", "El correo o la contraseña son incorrectos.", "OK");
        }
    }

    private void OnThemeToggleButtonClicked(object sender, EventArgs e)
    {
        bool esModoOscuroActualmente = Application.Current!.Resources["AppTextColor"].Equals(Colors.White);

        if (esModoOscuroActualmente)
        {
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
        bool esOscuro = Application.Current!.Resources["AppTextColor"].Equals(Colors.White);

        if (esOscuro)
        {
            BackgroundImage.Source = "inventario.png";
            ThemeToggleButton.Source = "sol_simbolo.png";
            DarkOverlay.Opacity = 0.5;
            ToggleLoginPasswordButton.Source = LoginPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
        }
        else
        {
            BackgroundImage.Source = "inventario_claro.png";
            ThemeToggleButton.Source = "luna_simbolo.png";
            DarkOverlay.Opacity = 0.1;
            ToggleLoginPasswordButton.Source = LoginPasswordEntry.IsPassword ? "ojonegro_cerrado.png" : "ojonegro_abierto.png";
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ActualizarDiseñoSegunTema();
    }
}
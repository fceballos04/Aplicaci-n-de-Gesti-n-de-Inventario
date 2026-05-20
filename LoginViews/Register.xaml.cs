using AntHiveStock.Models;
using AntHiveStock.Services;

namespace AntHiveStock.LoginViews;

public partial class Register : ContentPage
{
    public Register()
    {
        InitializeComponent();
        ActualizarDiseñoSegunTema();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(animated: true);
    }

    private void OnToggleRegisterPasswordClicked(object sender, EventArgs e)
    {
        RegisterPasswordEntry.IsPassword = !RegisterPasswordEntry.IsPassword;
        bool esOscuro = Application.Current!.Resources["AppTextColor"].Equals(Colors.White);

        ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword
            ? (esOscuro ? "ojo_cerrado.png" : "ojonegro_cerrado.png")
            : (esOscuro ? "ojo_abierto.png" : "ojonegro_abierto.png");
    }

    private async void OnSubmitRegisterClicked(object sender, EventArgs e)
    {
        ErrorEmpresa.IsVisible = false;
        ErrorEmail.IsVisible = false;
        ErrorPassword.IsVisible = false;

        string nombreEmpresa = TxtEmpresa.Text?.Trim() ?? string.Empty;
        string correo = TxtEmail.Text?.Trim() ?? string.Empty;
        string contraseña = RegisterPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(nombreEmpresa))
        {
            ErrorEmpresa.IsVisible = true;
            return;
        }

        if (string.IsNullOrWhiteSpace(correo))
        {
            ErrorEmail.IsVisible = true;
            return;
        }

        if (string.IsNullOrWhiteSpace(contraseña))
        {
            ErrorPassword.IsVisible = true;
            return;
        }

        var nuevoUsuario = new Usuario
        {
            NombreEmpresa = nombreEmpresa,
            Correo = correo,
            Password = contraseña
        };

        try
        {
            UserService.RegistrarUsuario(nuevoUsuario);
            await DisplayAlert("ANTHIVE STOCK", "¡Cuenta creada con éxito!", "OK");
            await Navigation.PopModalAsync(animated: true);
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo guardar: " + ex.Message, "OK");
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

            ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword ? "ojonegro_cerrado.png" : "ojonegro_abierto.png";
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

            ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
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
            ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword ? "ojo_cerrado.png" : "ojo_abierto.png";
        }
        else
        {
            BackgroundImage.Source = "inventario_claro.png";
            ThemeToggleButton.Source = "luna_simbolo.png";
            DarkOverlay.Opacity = 0.1;
            ToggleRegisterPasswordButton.Source = RegisterPasswordEntry.IsPassword ? "ojonegro_cerrado.png" : "ojonegro_abierto.png";
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ActualizarDiseñoSegunTema();
    }
}
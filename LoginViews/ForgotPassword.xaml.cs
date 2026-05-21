namespace AntHiveStock.LoginViews;

public partial class ForgotPassword : ContentPage
{
    public ForgotPassword()
    {
        InitializeComponent();
        ActualizarDiseñoSegunTema();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(true);
    }

    private async void OnRecuperarContraseñaClicked(object sender, EventArgs e)
    {
        ErrorEmail.IsVisible = false;
        string email = TxtEmailRecuperar.Text?.Trim();

        if (string.IsNullOrWhiteSpace(email))
        {
            ErrorEmail.IsVisible = true;
            return;
        }
        await DisplayAlert("ANTHIVE STOCK", "Los datos son correctos. Se ha enviado información a su correo.", "OK");
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
        }
        else
        {
            BackgroundImage.Source = "inventario_claro.png";
            ThemeToggleButton.Source = "luna_simbolo.png";
            DarkOverlay.Opacity = 0.1;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ActualizarDiseñoSegunTema();
    }
}
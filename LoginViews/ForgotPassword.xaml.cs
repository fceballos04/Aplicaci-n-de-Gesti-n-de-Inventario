namespace Invex_App.LoginViews;

public partial class ForgotPassword : ContentPage
{
	public ForgotPassword()
	{
		InitializeComponent();
        ActualizarDiseñoSegunTema();
    }
    //NAVEGACIÓN

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopModalAsync(true); // El PopToRootAsync limpia todo y te deja en la raiz (Login)
    }

 //ACCIONES (POR EL MOMENTO)


        // Espacio para guardar los datos en un JSON (INVESTIGAR COMO)
    private async void OnRecuperarContraseñaClicked(object sender, EventArgs e)
    {
        await DisplayAlert("ANTHIVE STOCK", "Los datos son correctos", "OK");
    }

    private void OnThemeToggleButtonClicked(object sender, EventArgs e)
    {
    
        bool esModoOscuroActualmente = Application.Current.Resources["AppTextColor"].Equals(Colors.White);

        if (esModoOscuroActualmente)
        {
            // MODO CLARO
            BackgroundImage.Source = "inventario_claro.png";
            ThemeToggleButton.Source = "luna_simbolo.png"; // 
            DarkOverlay.Opacity = 0.1;

            Application.Current.Resources["AppTextColor"] = Colors.Black;
            Application.Current.Resources["AppSubTitleColor"] = Color.FromArgb("#707070");
            Application.Current.Resources["AppButtonBorder"] = Colors.Black;
            Application.Current.Resources["AppEntryTextColor"] = Colors.Black;
        }
        else
        {
            // MODO OSCURO
            BackgroundImage.Source = "inventario.png";
            ThemeToggleButton.Source = "sol_simbolo.png"; // 
            DarkOverlay.Opacity = 0.5;

            Application.Current.Resources["AppTextColor"] = Colors.White;
            Application.Current.Resources["AppSubTitleColor"] = Color.FromArgb("#D1D1D1");
            Application.Current.Resources["AppButtonBorder"] = Colors.White;
            Application.Current.Resources["AppEntryTextColor"] = Colors.White;
        }
    }

    private void ActualizarDiseñoSegunTema()
    {
        // Revisamos si el color actual es blanco para saber si estamos en modo oscuro
        bool esOscuro = Application.Current.Resources["AppTextColor"].Equals(Colors.White);

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


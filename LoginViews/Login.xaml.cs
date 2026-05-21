namespace AntHiveStock.LoginViews
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
            ActualizarDiseñoSegunTema();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new SigIn(), animated: true);
        }

        private async void OnCreateAccountClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Register(), animated: true);
        }

        private async void OnGoogleLoginTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Google", "Conectandose a Google...", "OK");
        }



        private void OnThemeToggleButtonClicked(object sender, EventArgs e)
        {
            if (Application.Current?.Resources == null) return;

            // Detectamos dinámicamente si el texto actual es blanco (Modo Oscuro)
            bool esModoOscuroActualmente = Application.Current.Resources["AppTextColor"].Equals(Colors.White);

            if (esModoOscuroActualmente)
            {
                // CAMBIAR A MODO CLARO
                BackgroundImage.Source = "inventario_claro.png";
                ThemeToggleButton.Source = "luna_simbolo.png";
                DarkOverlay.Opacity = 0.1;

                Application.Current.Resources["AppTextColor"] = Color.FromArgb("#0F172A");
                Application.Current.Resources["AppSubTitleColor"] = Color.FromArgb("#64748B");
                Application.Current.Resources["AppButtonBorder"] = Color.FromArgb("#0F172A");
                Application.Current.Resources["AppEntryTextColor"] = Color.FromArgb("#0F172A");
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
            }
        }

        private void ActualizarDiseñoSegunTema()
        {
            if (Application.Current?.Resources == null) return;

            bool esOscuro = Application.Current.Resources.TryGetValue("AppTextColor", out var color) && color.Equals(Colors.White);

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
}
using Microsoft.Maui.Controls;
using Invex_App.Views; // CORRECCIÓN 1: Agregar el namespace de la carpeta Views

namespace Invex_App.LoginViews
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            ActualizarDiseñoSegunTema();

        }

        // --- NAVEGACIÓN ENTRE CONTENEDORES (VISTAS INTERNAS) ---

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

        bool esModoOscuro = true;

        private void OnThemeToggleButtonClicked(object sender, EventArgs e)
        {
            esModoOscuro = !esModoOscuro;

            if (esModoOscuro)
            {
                // MODO OSCURO
                BackgroundImage.Source = "inventario.png";
                ThemeToggleButton.Source = "sol_simbolo.png";
                DarkOverlay.Opacity = 0.5;

                Application.Current.Resources["AppTextColor"] = Colors.White;
                Application.Current.Resources["AppSubTitleColor"] = Color.FromArgb("#D1D1D1");
                Application.Current.Resources["AppButtonBorder"] = Colors.White;
                Application.Current.Resources["AppEntryTextColor"] = Colors.White;
            }
            else
            {
                // MODO CLARO
                BackgroundImage.Source = "inventario_claro.png";
                ThemeToggleButton.Source = "luna_simbolo.png";
                DarkOverlay.Opacity = 0.1;

                Application.Current.Resources["AppTextColor"] = Colors.Black;
                Application.Current.Resources["AppSubTitleColor"] = Color.FromArgb("#707070");
                Application.Current.Resources["AppButtonBorder"] = Colors.Black;
                Application.Current.Resources["AppEntryTextColor"] = Colors.Black;
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
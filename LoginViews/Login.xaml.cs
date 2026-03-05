using Microsoft.Maui.Controls;
using Invex_App.Views; // CORRECCIÓN 1: Agregar el namespace de la carpeta Views

namespace Invex_App.LoginViews
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        
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
<<<<<<< HEAD
        bool esModoOscuro = true;

        private void OnThemeToggleButtonClicked(object sender, EventArgs e)
        {
            esModoOscuro = !esModoOscuro;

            if (esModoOscuro)
            {
                // MODO OSCURO
                BackgroundImage.Source = "inventario.png";
                ThemeToggleButton.Source = "simbolo_oscuro.png";
                DarkOverlay.Opacity = 0.5; // Oscurece el fondo

                Application.Current.Resources["AppTextColor"] = Color.FromArgb("#FFFFFF");
                Application.Current.Resources["AppButtonBorder"] = Color.FromArgb("#FFFFFF");
            }
            else
            {
                // MODO CLARO
                BackgroundImage.Source = "inventario_claro.png";
                ThemeToggleButton.Source = "google.png"; // Puedes cambiar a un icono de sol luego
                DarkOverlay.Opacity = 0.1; // Hace el fondo más brillante

                Application.Current.Resources["AppTextColor"] = Color.FromArgb("#444444");
                Application.Current.Resources["AppButtonBorder"] = Color.FromArgb("#1A56A6");
            }
        }
=======


>>>>>>> e58e13cdc81d60d44622f06811da2e3ede58ac83
    }
}
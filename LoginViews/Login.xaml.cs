using Microsoft.Maui.Controls;

namespace Invex_App.LoginViews
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        
        }

        //NAVEGACIÓN

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
    }
}
namespace Invex_App.LoginViews;

public partial class ForgotPassword : ContentPage
{
	public ForgotPassword()
	{
		InitializeComponent();
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
        await DisplayAlert("AntHive Stock", "Los datos son correctos", "OK");
    }
}


namespace Invex_App.Views;

public partial class DashboardPage : ContentPage
{
	public DashboardPage()
	{
		InitializeComponent();
	}

    // --- EVENTOS DE LAS TARJETAS ---

    private async void OnVentasClicked(object sender, EventArgs e)
    {
        // Por ahora solo mostramos un mensaje, luego nos llevará a la carpeta Modules
        await Shell.Current.GoToAsync("Ventas");
    }
    private async void OnInventarioClicked(object sender, EventArgs e)
    {
        // Por ahora solo mostramos un mensaje, luego nos llevará a la carpeta Modules
        await DisplayAlert("AntHive Stock", "Abriendo el módulo de Inventario...", "OK");
    }

    private async void OnAddProductClicked(object sender, EventArgs e)
    {
        await DisplayAlert("AntHive Stock", "Abriendo formulario de Nuevo Producto", "OK");
    }

    private async void OnInformesClicked(object sender, EventArgs e)
    {
        await DisplayAlert("AntHive Stock", "Abriendo informes", "OK");
    }

}
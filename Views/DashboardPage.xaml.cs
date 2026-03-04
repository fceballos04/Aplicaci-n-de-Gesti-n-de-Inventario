namespace Invex_App.Views;

public partial class DashboardPage : ContentPage
{
    public DashboardPage()
    {
        InitializeComponent();
    }

    // --- EVENTOS DE LAS TARJETAS ---

    private async void OnInventarioTapped(object sender, TappedEventArgs e)
    {
        // Por ahora solo mostramos un mensaje, luego nos llevará a la carpeta Modules
        await DisplayAlert("Invex", "Abriendo el módulo de Inventario...", "OK");
    }

    private async void OnVentasTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Invex", "Cargando reportes de Ventas...", "OK");
    }

    private async void OnAddProductTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Invex", "Abriendo formulario de Nuevo Producto", "OK");
    }

    private async void OnSettingsTapped(object sender, TappedEventArgs e)
    {
        await DisplayAlert("Invex", "Configuración del Perfil", "OK");
    }

    // --- BOTÓN CERRAR SESIÓN ---

    private async void OnLogoutClicked(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Salir", "¿Estás seguro de que quieres cerrar sesión?", "Sí", "No");

        if (answer)
        {
            // Regresamos al Login y limpiamos el historial (usando //)
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
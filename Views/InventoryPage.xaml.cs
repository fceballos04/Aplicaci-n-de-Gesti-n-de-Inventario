using AntHiveStock.ViewModels;

namespace AntHiveStock.Views;

public partial class InventoryPage : ContentPage
{
	public InventoryPage(InventoryViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

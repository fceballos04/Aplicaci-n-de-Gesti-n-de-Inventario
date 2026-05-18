using AntHiveStock.ViewModels;

namespace AntHiveStock.Views;

public partial class ProductFormPage : ContentPage
{
	public ProductFormPage(ProductFormViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

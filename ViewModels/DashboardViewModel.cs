using System.Collections.ObjectModel;
using AntHiveStock.Messages;
using AntHiveStock.Models;
using AntHiveStock.Services;
using AntHiveStock.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;

namespace AntHiveStock.ViewModels;

public partial class DashboardViewModel : ObservableObject
{
	private readonly DatabaseService databaseService;
	private List<Product> allProducts = [];

	[ObservableProperty]
	public partial ObservableCollection<Product> FilteredProducts { get; set; } = [];

	[ObservableProperty]
	public partial string SearchText { get; set; } = string.Empty;

	[ObservableProperty]
	public partial string StatusMessage { get; set; } = "Productos disponibles para venta.";

	[ObservableProperty]
	public partial bool IsBusy { get; set; }

	[ObservableProperty]
	public partial bool ShowInStockOnly { get; set; }

	[ObservableProperty]
	public partial bool SortAscending { get; set; } = true;

	[ObservableProperty]
	public partial int TotalProducts { get; set; }

	[ObservableProperty]
	public partial int TotalStock { get; set; }

	[ObservableProperty]
	public partial decimal InventoryValue { get; set; }

	public DashboardViewModel(DatabaseService databaseService)
	{
		this.databaseService = databaseService;

		WeakReferenceMessenger.Default.Register<ProductSavedMessage>(this, (_, _) =>
		{
			_ = MainThread.InvokeOnMainThreadAsync(LoadAsync);
		});

		WeakReferenceMessenger.Default.Register<ProductDeletedMessage>(this, (_, _) =>
		{
			_ = MainThread.InvokeOnMainThreadAsync(LoadAsync);
		});

		_ = LoadAsync();
	}

	partial void OnSearchTextChanged(string value)
	{
		ApplySearch();
		StatusMessage = $"{FilteredProducts.Count} productos encontrados.";
	}

	partial void OnShowInStockOnlyChanged(bool value)
	{
		ApplySearch();
		StatusMessage = value
			? $"{FilteredProducts.Count} productos en stock."
			: $"{FilteredProducts.Count} productos encontrados.";
	}

	[RelayCommand]
	private async Task LoadAsync()
	{
		if (IsBusy)
		{
			return;
		}

		try
		{
			IsBusy = true;
			allProducts = await databaseService.GetProductsAsync();
			UpdateSummary();
			ApplySearch();
			StatusMessage = $"{FilteredProducts.Count} productos encontrados.";
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	private async Task AddProductAsync()
	{
		await Shell.Current.GoToAsync(nameof(ProductFormPage));
	}

	[RelayCommand]
	private void ToggleStockFilter()
	{
		ShowInStockOnly = !ShowInStockOnly;
	}

	[RelayCommand]
	private void ToggleSort()
	{
		SortAscending = !SortAscending;
		ApplySearch();
		StatusMessage = SortAscending
			? "Productos ordenados A-Z."
			: "Productos ordenados Z-A.";
	}

	[RelayCommand]
	private async Task SellProductAsync(Product? product)
	{
		if (product is null)
		{
			StatusMessage = "Selecciona un producto para vender.";
			return;
		}

		if (product.Quantity <= 0)
		{
			StatusMessage = $"{product.Name} no tiene stock disponible.";
			return;
		}

		product.Quantity--;
		await databaseService.SaveProductAsync(product);

		allProducts = await databaseService.GetProductsAsync();
		UpdateSummary();
		ApplySearch();

		StatusMessage = $"Venta registrada: {product.Name}. Stock actual: {product.Quantity}.";
		WeakReferenceMessenger.Default.Send(new ProductSavedMessage(product.Id));
	}

	private void ApplySearch()
	{
		var query = SearchText.Trim();

		IEnumerable<Product> products = string.IsNullOrWhiteSpace(query)
			? allProducts
			: allProducts.Where(product => product.Name.Contains(query, StringComparison.OrdinalIgnoreCase));

		if (ShowInStockOnly)
		{
			products = products.Where(product => product.Quantity > 0);
		}

		products = SortAscending
			? products.OrderBy(product => product.Name)
			: products.OrderByDescending(product => product.Name);

		FilteredProducts = new ObservableCollection<Product>(products.ToList());
	}

	private void UpdateSummary()
	{
		TotalProducts = allProducts.Count;
		TotalStock = allProducts.Sum(product => product.Quantity);
		InventoryValue = allProducts.Sum(product => product.Quantity * product.Price);
	}
}

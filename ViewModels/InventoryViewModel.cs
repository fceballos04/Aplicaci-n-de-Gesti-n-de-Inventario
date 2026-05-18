using System.Collections.ObjectModel;
using AntHiveStock.Messages;
using AntHiveStock.Models;
using AntHiveStock.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Media;
using AntHiveStock.Views;

namespace AntHiveStock.ViewModels;

public partial class InventoryViewModel : ObservableObject
{
	private readonly DatabaseService databaseService;

	[ObservableProperty]
	public partial ObservableCollection<Product> Products { get; set; } = [];

	[ObservableProperty]
	public partial Product? SelectedProduct { get; set; }

	[ObservableProperty]
	public partial bool IsBusy { get; set; }

	[ObservableProperty]
	public partial string StatusMessage { get; set; } = "Inventario listo para gestionar.";

	public InventoryViewModel(DatabaseService databaseService)
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
			var storedProducts = await databaseService.GetProductsAsync();

			Products = storedProducts.Count == 0
				? new ObservableCollection<Product>(GetSeedProducts())
				: new ObservableCollection<Product>(storedProducts);

			if (storedProducts.Count == 0)
			{
				foreach (var product in Products)
				{
					await databaseService.SaveProductAsync(product);
				}
			}

			StatusMessage = $"{Products.Count} productos cargados.";
		}
		finally
		{
			IsBusy = false;
		}
	}

	[RelayCommand]
	private async Task AddAsync()
	{
		await Shell.Current.GoToAsync(nameof(ProductFormPage));
	}

	[RelayCommand]
	private async Task EditAsync(Product? product)
	{
		product ??= SelectedProduct;

		if (product is null)
		{
			StatusMessage = "Selecciona un producto para editar.";
			return;
		}

		await Shell.Current.GoToAsync($"{nameof(ProductFormPage)}?productId={product.Id}");
	}

	[RelayCommand]
	private async Task DeleteAsync(Product? product)
	{
		product ??= SelectedProduct;

		if (product is null)
		{
			StatusMessage = "Selecciona un producto para eliminar.";
			return;
		}

		await databaseService.DeleteProductAsync(product);
		Products.Remove(product);
		SelectedProduct = null;
		StatusMessage = $"{product.Name} eliminado.";
		WeakReferenceMessenger.Default.Send(new ProductDeletedMessage(product.Id));
	}

	[RelayCommand]
	private async Task ScanCodeAsync()
	{
		try
		{
			if (!MediaPicker.Default.IsCaptureSupported)
			{
				StatusMessage = "Camara no disponible. Escaneo simulado correctamente.";
				return;
			}

			var photo = await MediaPicker.Default.CapturePhotoAsync(new MediaPickerOptions
			{
				Title = "Escanear codigo"
			});

			StatusMessage = photo is null
				? "Escaneo cancelado."
				: "Camara abierta. Imagen capturada para el flujo de escaneo.";
		}
		catch (FeatureNotSupportedException)
		{
			StatusMessage = "Este dispositivo no soporta captura con camara.";
		}
		catch (PermissionException)
		{
			StatusMessage = "Permiso de camara denegado.";
		}
		catch (Exception)
		{
			StatusMessage = "No fue posible abrir la camara. Escaneo simulado.";
		}
	}

	private static IEnumerable<Product> GetSeedProducts()
	{
		return
		[
			new Product
			{
				Name = "Teclado inalambrico",
				Quantity = 18,
				Category = "Perifericos",
				ImageSource = "dotnet_bot.png",
				Price = 549.90m
			},
			new Product
			{
				Name = "Monitor 24 pulgadas",
				Quantity = 7,
				Category = "Pantallas",
				ImageSource = "dotnet_bot.png",
				Price = 2899.00m
			},
			new Product
			{
				Name = "Cable USB-C",
				Quantity = 42,
				Category = "Accesorios",
				ImageSource = "dotnet_bot.png",
				Price = 129.50m
			}
		];
	}
}

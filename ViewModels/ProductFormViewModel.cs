using System.Globalization;
using AntHiveStock.Messages;
using AntHiveStock.Models;
using AntHiveStock.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Media;
using Microsoft.Maui.Storage;

namespace AntHiveStock.ViewModels;

public partial class ProductFormViewModel : ObservableObject, IQueryAttributable
{
	private const string DefaultProductImageSource = "dotnet_bot.png";
	private const string ProductImagesFolderName = "ProductImages";

	private readonly DatabaseService databaseService;
	private int productId;

	[ObservableProperty]
	public partial string PageTitle { get; set; } = "Agregar producto";

	[ObservableProperty]
	public partial string Name { get; set; } = string.Empty;

	[ObservableProperty]
	public partial string Quantity { get; set; } = string.Empty;

	[ObservableProperty]
	public partial string Price { get; set; } = string.Empty;

	[ObservableProperty]
	public partial string ProductImageSource { get; set; } = DefaultProductImageSource;

	[ObservableProperty]
	public partial string ImageMessage { get; set; } = "Imagen predeterminada.";

	[ObservableProperty]
	public partial string ValidationMessage { get; set; } = string.Empty;

	public ProductFormViewModel(DatabaseService databaseService)
	{
		this.databaseService = databaseService;
	}

	public void ApplyQueryAttributes(IDictionary<string, object> query)
	{
		if (query.TryGetValue("productId", out var value) &&
			int.TryParse(value?.ToString(), out var id) &&
			id > 0)
		{
			_ = LoadProductAsync(id);
			return;
		}

		productId = 0;
		PageTitle = "Agregar producto";
		Name = string.Empty;
		Quantity = string.Empty;
		Price = string.Empty;
		ProductImageSource = DefaultProductImageSource;
		ImageMessage = "Imagen predeterminada.";
		ValidationMessage = string.Empty;
	}

	private async Task LoadProductAsync(int id)
	{
		var product = await databaseService.GetProductByIdAsync(id);

		if (product is null)
		{
			ValidationMessage = "No se encontro el producto seleccionado.";
			return;
		}

		productId = product.Id;
		PageTitle = "Editar producto";
		Name = product.Name;
		Quantity = product.Quantity.ToString(CultureInfo.InvariantCulture);
		Price = product.Price.ToString("0.##", CultureInfo.InvariantCulture);
		ProductImageSource = string.IsNullOrWhiteSpace(product.ImageSource)
			? DefaultProductImageSource
			: product.ImageSource;
		ImageMessage = product.ImageSource == DefaultProductImageSource
			? "Imagen predeterminada."
			: "Imagen del producto cargada.";
		ValidationMessage = string.Empty;
	}

	[RelayCommand]
	private async Task PickProductImageAsync()
	{
		try
		{
			var images = await MediaPicker.Default.PickPhotosAsync(new MediaPickerOptions
			{
				Title = "Selecciona una imagen del producto"
			});
			var image = images?.FirstOrDefault();

			if (image is null)
			{
				ImageMessage = "Seleccion de imagen cancelada.";
				return;
			}

			ProductImageSource = await CopyImageToAppDataAsync(image);
			ImageMessage = "Imagen agregada desde galeria.";
			ValidationMessage = string.Empty;
		}
		catch (FeatureNotSupportedException)
		{
			ValidationMessage = "Este dispositivo no permite seleccionar imagenes.";
		}
		catch (PermissionException)
		{
			ValidationMessage = "Permiso para galeria denegado.";
		}
		catch (Exception)
		{
			ValidationMessage = "No fue posible agregar la imagen.";
		}
	}

	[RelayCommand]
	private async Task SaveAsync()
	{
		if (!TryBuildProduct(out var product))
		{
			return;
		}

		await databaseService.SaveProductAsync(product);
		WeakReferenceMessenger.Default.Send(new ProductSavedMessage(product.Id));
		await Shell.Current.GoToAsync("..");
	}

	[RelayCommand]
	private async Task CancelAsync()
	{
		await Shell.Current.GoToAsync("..");
	}

	private bool TryBuildProduct(out Product product)
	{
		product = new Product();

		if (string.IsNullOrWhiteSpace(Name))
		{
			ValidationMessage = "Ingresa el nombre del producto.";
			return false;
		}

		if (!int.TryParse(Quantity, NumberStyles.Integer, CultureInfo.InvariantCulture, out var quantity) || quantity < 0)
		{
			ValidationMessage = "Ingresa una cantidad valida mayor o igual a 0.";
			return false;
		}

		if (!decimal.TryParse(Price, NumberStyles.Number, CultureInfo.InvariantCulture, out var price) || price < 0)
		{
			ValidationMessage = "Ingresa un precio valido mayor o igual a 0.";
			return false;
		}

		product = new Product
		{
			Id = productId,
			Name = Name.Trim(),
			Quantity = quantity,
			Category = "General",
			ImageSource = string.IsNullOrWhiteSpace(ProductImageSource)
				? DefaultProductImageSource
				: ProductImageSource,
			Price = price
		};

		ValidationMessage = string.Empty;
		return true;
	}

	private static async Task<string> CopyImageToAppDataAsync(FileResult image)
	{
		var imagesDirectory = Path.Combine(FileSystem.AppDataDirectory, ProductImagesFolderName);
		Directory.CreateDirectory(imagesDirectory);

		var extension = Path.GetExtension(image.FileName);
		if (string.IsNullOrWhiteSpace(extension))
		{
			extension = ".jpg";
		}

		var destinationPath = Path.Combine(imagesDirectory, $"{Guid.NewGuid():N}{extension}");

		await using var sourceStream = await image.OpenReadAsync();
		await using var destinationStream = File.Create(destinationPath);
		await sourceStream.CopyToAsync(destinationStream);

		return destinationPath;
	}
}

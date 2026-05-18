using AntHiveStock.Services;
using AntHiveStock.ViewModels;
using AntHiveStock.Views;
using Microsoft.Extensions.Logging;
using SQLitePCL;

namespace AntHiveStock;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		Batteries_V2.Init();

		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<AppShell>();
		builder.Services.AddSingleton<DatabaseService>();

		builder.Services.AddSingleton<DashboardPage>();
		builder.Services.AddTransient<InventoryPage>();
		builder.Services.AddTransient<ProductFormPage>();
		builder.Services.AddSingleton<SettingsPage>();

		builder.Services.AddSingleton<DashboardViewModel>();
		builder.Services.AddTransient<InventoryViewModel>();
		builder.Services.AddTransient<ProductFormViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

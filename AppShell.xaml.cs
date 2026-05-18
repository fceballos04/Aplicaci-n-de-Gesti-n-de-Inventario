using AntHiveStock.Services;
using AntHiveStock.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AntHiveStock;

public partial class AppShell : Shell
{
	public AppShell(IServiceProvider serviceProvider)
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(ProductFormPage), new ServiceProviderRouteFactory<ProductFormPage>(serviceProvider));

		DashboardContent.ContentTemplate = new DataTemplate(() => serviceProvider.GetRequiredService<DashboardPage>());
		InventoryContent.ContentTemplate = new DataTemplate(() => serviceProvider.GetRequiredService<InventoryPage>());
		SettingsContent.ContentTemplate = new DataTemplate(() => serviceProvider.GetRequiredService<SettingsPage>());
	}
}

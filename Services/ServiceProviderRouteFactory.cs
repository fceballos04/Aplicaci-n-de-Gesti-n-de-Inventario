using Microsoft.Extensions.DependencyInjection;

namespace AntHiveStock.Services;

public sealed class ServiceProviderRouteFactory<TPage> : RouteFactory
	where TPage : Element
{
	private readonly IServiceProvider serviceProvider;

	public ServiceProviderRouteFactory(IServiceProvider serviceProvider)
	{
		this.serviceProvider = serviceProvider;
	}

	public override Element GetOrCreate()
	{
		return serviceProvider.GetRequiredService<TPage>();
	}

	public override Element GetOrCreate(IServiceProvider services)
	{
		return serviceProvider.GetRequiredService<TPage>();
	}
}

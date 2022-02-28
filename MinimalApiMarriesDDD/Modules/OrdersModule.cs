namespace MinimalApiMarriesDDD.Modules;

public sealed class OrdersModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("v1/orders", () => "Hello from Orders")
            .WithName("GetOrders")
            .WithTags("Orders");

        return endpoints;
    }
}
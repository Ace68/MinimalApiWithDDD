namespace MinimalApiMarriesDDD.Modules;

public sealed class CustomersModule : IModule
{
    public IServiceCollection RegisterModule(IServiceCollection services)
    {
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("v1/customers", () => "Hello from Customers")
            .WithName("GetCustomers")
            .WithTags("Customers");

        return endpoints;
    }
}
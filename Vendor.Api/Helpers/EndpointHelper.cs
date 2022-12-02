using Vendor.Api.Interfaces;
using System.Reflection;

namespace Vendor.Api.Helpers;

public static class EndpointHelper
{
    public static void RegisterEndpoints(this IServiceCollection services)
    {
        var endpointTypes = Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(type => typeof(IEndpoint).IsAssignableFrom(type) && !type.IsInterface);

        foreach(var type in endpointTypes)
        {
            try
            {
                services.AddScoped(typeof(IEndpoint), type);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }

    public static void AddEndpoints(this WebApplication app)
    {
        IServiceScope scope = app.Services.CreateScope();
        var endpoints = scope.ServiceProvider.GetServices<IEndpoint>();

        foreach(var instance in endpoints)
        {
            try
            {
                instance.MapEndpoints(app);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

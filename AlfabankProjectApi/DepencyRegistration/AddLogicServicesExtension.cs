using AlfabankProjectApi.App.Services;
using AlfabankProjectApi.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Net;
using System.Runtime.ConstrainedExecution;

namespace AlfabankProjectApi.App.DepencyRegistration;
public static class AddLogicServicesExtension
{
    public static void AddLogicServices(this IServiceCollection services)
    {
        //services.AddTransient<ILocationsService, ApiService>();
        services.AddTransient<ApiService>();
        services.TryAddScoped<HttpClient>();
        services.TryAddScoped<WebClient>();
    }
}

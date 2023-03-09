using Microsoft.OpenApi.Models;
using PackagesServer.Core.RepositoryContracts;
using PackagesServer.Core.ServiceContracts;
using PackagesServer.Core.Services;
using PackagesServer.Infrastructure.Repository;

namespace PackagesServer.StartupExtention;

public static class ExtentionIoCServices
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddScoped<IRecipientsService, RecipientsService>();
        services.AddScoped<IPackagesService, PackagesService>();
        services.AddSingleton<IPackagesRepository, PackagesRepository>();
        services.AddSingleton<IRecipientsRepository, RecipientsRepository>();
        services.AddTransient<MapperService>();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Packages API", Version = "v1" });
        });
    }
}

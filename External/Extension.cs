using Core.Interfaces.Repository;
using External.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace External;

public static class Extension
{
    public static IServiceCollection AddExternal(this IServiceCollection services)
    {
        IConfiguration configuration;
        using (ServiceProvider provider = services.BuildServiceProvider())
            configuration = provider.GetRequiredService<IConfiguration>();

        // Aquí se registrarían HttpClients tipados hacia otros microservicios
        // ej: services.AddHttpClient<IPatientServiceClient, PatientServiceClient>(...)
        services.AddScoped(typeof(IRepository<>), typeof(RepositoryGeneric<>));

        return services;
    }
}

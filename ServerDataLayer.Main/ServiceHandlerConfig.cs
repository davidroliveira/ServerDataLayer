using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using ServerDataLayer.Application.Contracts;
using ServerDataLayer.Domain.Connection;
using ServerDataLayer.Persistence.SqlServer.Connection;
using ServerDataLayer.Persistence.SqlServer.Repositories;

namespace ServerDataLayer.Main;

public static class ServiceHandlerConfig
{
    public static IServiceCollection AddHandlerConfig(this IServiceCollection services)
    {
        Handler.CurrentProvider = services
            .AddScoped<IDbSettings, DbSettings>()
            .AddScoped<IDbSession, DbSession>()
            .AddTransient<IDbChangeset, DbChangeset>()
            .AddUseCases()
            .AddRepositories()
            .BuildServiceProvider();
        return services;
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        RegisterUseCases(services);
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        RegisterRepositories(services);
        return services;
    }

    private static void RegisterRepositories(IServiceCollection services) => Assembly
        .GetAssembly(typeof(BaseRepository))!
        .GetTypes()
        .Where(type => type.IsSealed && type.IsSubclassOf(typeof(BaseRepository)))
        .ToList()
        .ForEach(type => services.AddTransient(type.GetInterfaces()
            .ToList()
            .FirstOrDefault(typeInterfaced => typeInterfaced.GetInterfaces().Any())!, type));

    private static void RegisterUseCases(IServiceCollection services) => Assembly
        .GetAssembly(typeof(IUseCase<IRequest, IResponse>))!
        .GetTypes()
        .Where(type =>
            type.IsSealed &&
            type.GetInterfaces().ToList().Any(typeInterfaced =>
                (typeInterfaced.Namespace?.Equals(typeof(IUseCase<IRequest, IResponse>).Namespace) ?? false) &&
                typeInterfaced.Name.Equals(typeof(IUseCase<IRequest, IResponse>).Name)))
        .ToList()
        .ForEach(type => services.AddTransient(type));
}
using Microsoft.Extensions.DependencyInjection;

namespace ServerDataLayer.Main;

public static class Handler
{
    public static IServiceProvider CurrentProvider { private get; set; } = null!;

    public static Task<T> HandleAsync<T>() => Task.FromResult(CurrentProvider.GetService<T>()!);
}
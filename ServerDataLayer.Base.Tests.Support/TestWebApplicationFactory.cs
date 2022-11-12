﻿using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServerDataLayer.Domain.Connection;
using ServerDataLayer.Main;
using ServerDataLayer.Persistence.SqlServer.Connection;

namespace ServerDataLayer.Base.Tests.Support;

public sealed class TestWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint>
    where TEntryPoint : class
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddScoped<IDbSettings, DbSettingsFromTest>();
            Handler.CurrentProvider = services.BuildServiceProvider();
        });

        return base.CreateHost(builder);
    }
}
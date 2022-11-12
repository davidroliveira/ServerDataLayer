using ServerDataLayer.Domain.Connection;
using ServerDataLayer.Main;

namespace ServerDataLayer.Web.Api.Configurations.WebApplication;

public static class WebApplicationConfig
{
    public static Microsoft.AspNetCore.Builder.WebApplication AddChangesets(this Microsoft.AspNetCore.Builder.WebApplication app)
    {
        using var changeset = Handler.Handle<IDbChangeset>();
        changeset.Apply();
        return app;
    }
}
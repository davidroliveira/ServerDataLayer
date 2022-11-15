using Server.Domain.Connection;
using Server.Main;

namespace Server.Web.Api.Configurations.WebApplication;

public static class WebApplicationConfig
{
    public static void AddChangesets(this Microsoft.AspNetCore.Builder.WebApplication app)
    {
        using var changeset = Handler.HandleAsync<IDbChangeset>().GetAwaiter().GetResult();
        changeset.Apply();
    }
}
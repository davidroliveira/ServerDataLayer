namespace ServerDataLayer.Web.Api.Configurations.WebApplication;

public static class CorsConfig
{
    public static Microsoft.AspNetCore.Builder.WebApplication AddCors(this Microsoft.AspNetCore.Builder.WebApplication app)
    {
        app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        return app;
    }
}
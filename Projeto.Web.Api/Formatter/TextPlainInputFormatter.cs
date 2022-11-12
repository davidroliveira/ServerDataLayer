using Microsoft.AspNetCore.Mvc.Formatters;

namespace Projeto.Web.Api.Formatter;

public class TextPlainInputFormatter : InputFormatter
{
    private const string CONTENT_TYPE = "text/plain";

    public TextPlainInputFormatter()
    {
        SupportedMediaTypes.Add(CONTENT_TYPE);
    }

    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    {
        var request = context.HttpContext.Request;
        using (var reader = new StreamReader(request.Body))
        {
            var content = await reader.ReadToEndAsync();
            return await InputFormatterResult.SuccessAsync(content);
        }
    }

    public override bool CanRead(InputFormatterContext context)
    {
        var contentType = context.HttpContext.Request.ContentType!;
        return contentType.StartsWith(CONTENT_TYPE);
    }
}
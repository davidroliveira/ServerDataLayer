using Microsoft.AspNetCore.Mvc;
using Server.Application.UseCases;
using Server.Application.ViewModel;
using Server.Base.Common;
using Server.Main;
using System.Text.Json;

namespace Server.Web.Api;

[ApiController]
[Route("[controller]/[action]")]
public sealed class MainController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Query(QueryViewModel query)
    {
        try
        {
            query.Parameters = query.Parameters?
                .Select(parameter => new QueryParametersViewModel
                {
                    Name = parameter.Name,
                    Value = parameter.Value is JsonElement element ? element.ToObject() : null
                });

            var handle = await Handler.HandleAsync<QueryUseCase>();
            var response = await handle.ExecuteAsync(new QueryRequest(query));
            return Ok(response.Content);
        }
        catch (Exception exception)
        {
            return await Task.FromResult(new ObjectResult(new { Erro = exception.Message }) { StatusCode = StatusCodes.Status400BadRequest });
        }
    }
}
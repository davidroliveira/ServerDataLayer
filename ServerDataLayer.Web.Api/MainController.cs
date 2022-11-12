using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ServerDataLayer.Application.UseCases;
using ServerDataLayer.Application.ViewModel;
using ServerDataLayer.Base.Common;
using ServerDataLayer.Main;

namespace ServerDataLayer.Web.Api;

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
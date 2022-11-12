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
    //[Consumes("text/plain")]
    //public object /*Task<IActionResult>*/ Query(/*[FromBody]*/ [FromBody] string command, [FromQuery] IDictionary<string, object?>? param = null)
    public object /*Task<IActionResult>*/ Query(/*[FromBody]*/ QueryViewModel query)
    {
        //try
        {
            //IDictionary<string, object?>? param = null;

            //param?.Keys.ToList().ForEach(key => param[key] = param[key] is null ? null : JsonConvert.DeserializeObject(param[key]?.ToString()!));
            query.Parameters = query.Parameters?
                .Select(parameter => new QueryParametersViewModel
                    {
                        Name = parameter.Name,
                        Value = parameter.Value is JsonElement element ? element.ToObject() : null
                    });

            var response = Handler.Handle<QueryUseCase>().Execute(new QueryRequest(query));
            //return Ok(await response.Content);
            return response.Content;
        }
        //catch (Exception exception)
        {
            //return await Task.FromResult(new ObjectResult(new { Erro = exception.Message }) { StatusCode = StatusCodes.Status400BadRequest });
            //return exception.Message;
        }
    }
}
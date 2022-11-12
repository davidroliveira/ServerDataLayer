﻿using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Dtos;
using Projeto.Application.UseCases;
using Projeto.Base.Common;
using Projeto.Main;
using System.Text.Json;

namespace Projeto.Web.Api;

[ApiController]
[Route("[controller]/[action]")]
public sealed class ApiController : ControllerBase
{
    [HttpPost]
    //[Consumes("text/plain")]
    //public object /*Task<IActionResult>*/ Query(/*[FromBody]*/ [FromBody] string command, [FromQuery] IDictionary<string, object?>? param = null)
    public object /*Task<IActionResult>*/ Query(/*[FromBody]*/ QueryDto query)
    {
        //try
        {
            //IDictionary<string, object?>? param = null;

            //param?.Keys.ToList().ForEach(key => param[key] = param[key] is null ? null : JsonConvert.DeserializeObject(param[key]?.ToString()!));
            query.Parameters = query.Parameters?
                .Select(dto => new QueryParametersDto
                {
                    Name = dto.Name,
                    Value = dto.Value is JsonElement element ? element.ToObject() : null
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
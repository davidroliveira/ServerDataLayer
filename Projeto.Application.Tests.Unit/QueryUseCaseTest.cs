using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Projeto.Application.Dtos;
using Projeto.Application.UseCases;
using Projeto.Base.Common;
using Projeto.Base.Tests.Support;
using Projeto.Domain.Repositories;
using Xunit;

namespace Projeto.Application.Tests.Unit;

public sealed class QueryUseCaseTest
{
    [Fact]
    public async void Execute_SeSelectExecutadoComSucesso_EntaoRetornaResponse()
    {
        //Arrange
        await using var app = new TestWebApplicationFactory<Program>();
        using var scope = app.Server.Services.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IRepository>();

        const string SQL = @"
          set transaction isolation level read uncommitted; 
          select * from pessoas where codigo_local = @codigo_local";

        var queryDto = new QueryDto
        {
            Command = SQL,
            Parameters = new List<QueryParametersDto>
            {
                new()
                {
                    Name = "@codigo_local", 
                    Value = 1
                }
            }
        };

        var expected = repository.Query(SQL, queryDto.ToDictionary());
        var useCase = new QueryUseCase(repository);

        //Act
        var response = useCase.Execute(new QueryRequest(queryDto));

        //Assert
        var result = response.Content;
        Assert.True(result.Compare(expected));
    }

    [Fact]
    public async void Execute_SeUpsertExecutadoComSucesso_EntaoRetornaResponse()
    {
        //Arrange
        await using var app = new TestWebApplicationFactory<Program>();
        using var scope = app.Server.Services.CreateScope();
        var repository = scope.ServiceProvider.GetRequiredService<IRepository>();
        var faker = new Faker("pt_BR");

        var sql = $@"
           with cte
             as (select @codigo_universal codigo_universal,
                        @nome nome)
            merge 
              pessoas as Destino
            using 
              cte AS Origem on (Origem.codigo_universal = Destino.codigo_universal)
            when matched then
              update set Destino.codigo_universal = Origem.codigo_universal, 
                         Destino.nome = Origem.nome
            when not matched then
              insert (codigo_universal, 
                      nome)
              values (Origem.codigo_universal, 
                      Origem.nome)
            output inserted.codigo_local, 
                   inserted.codigo_universal, 
                   inserted.nome;";

        var queryDto = new QueryDto
        {
            Command = sql,
            Parameters = new List<QueryParametersDto>
            {
                new()
                {
                    Name = "@codigo_universal",
                    Value = faker.Random.Guid()
                },
                new()
                {
                    Name = "@nome",
                    Value = faker.Person.FirstName
                }
            }
        };

        var expected = repository.Query(sql, queryDto.ToDictionary());
        var useCase = new QueryUseCase(repository);

        //Act
        var response = useCase.Execute(new QueryRequest(queryDto));

        //Assert
        var result = response.Content;
        Assert.True(result.Compare(expected));
    }
}
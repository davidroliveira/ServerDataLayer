using System.Net;
using System.Net.Mime;
using System.Text;
using Bogus;
using Newtonsoft.Json;
using ServerDataLayer.Application.ViewModel;
using ServerDataLayer.Base.Common;
using ServerDataLayer.Base.Tests.Support;
using Xunit;

namespace ServerDataLayer.Web.Api.Tests.Unit;

public sealed class QueryControllerTest
{
    [Fact]
    public async void Get_SeSelectExecutadoComSucesso_EntaoRetornaStatus200()
    {
        //Arrange
        await using var apiFactory = new TestWebApplicationFactory<Program>();
        using var client = apiFactory.CreateClient();

        const string SQL = @"
          set transaction isolation level read uncommitted; 
          select * from pessoas where codigo_local = @codigo_local";

        var queryViewModel = new QueryViewModel()
        {
            Command = SQL,
            Parameters = new List<QueryParametersViewModel>
            {
                new()
                {
                    Name = "@codigo_local",
                    Value = 1
                }
            }
        };

        //Act
        var response = await client
            .PostAsync("/Api/Query",
                new StringContent(queryViewModel.SerializeObject(),
                    Encoding.UTF8,
                    MediaTypeNames.Application.Json));

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var result = JsonConvert.DeserializeObject<IEnumerable<object>>(await response.Content.ReadAsStringAsync())!;
        Assert.NotEmpty(result);
    }

    [Fact]
    public async void Get_SeUpsertExecutadoComSucesso_EntaoRetornaStatus200()
    {
        //Arrange
        await using var apiFactory = new TestWebApplicationFactory<Program>();
        using var client = apiFactory.CreateClient();
        var faker = new Faker("pt_BR");

        var sql = @"
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

        var queryViewModel = new QueryViewModel() 
        {
            Command = sql,
            Parameters = new List<QueryParametersViewModel>()
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

        //Act
        var response = await client
            .PostAsync("/Api/Query",
                new StringContent(queryViewModel.SerializeObject(),
                    Encoding.UTF8,
                    MediaTypeNames.Application.Json));

        //Assert
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        var retorno = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<IEnumerable<object>>(retorno)!;
        Assert.NotEmpty(result);
    }
}
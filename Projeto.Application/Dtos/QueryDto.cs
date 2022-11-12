namespace Projeto.Application.Dtos;

public sealed class QueryParametersDto
{
    public string Name { get; set; } = string.Empty;
    public object? Value { get; set; }
}

public sealed class QueryDto
{
    public string Command { get; set; } = string.Empty;
    public IEnumerable<QueryParametersDto>? Parameters { get; set; }

    public Dictionary<string, object?>? ToDictionary() => Parameters?
        .ToDictionary(
            dto => dto.Name,
            dto => dto.Value);
}
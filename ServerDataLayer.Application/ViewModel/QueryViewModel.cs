namespace ServerDataLayer.Application.ViewModel;

public sealed class QueryViewModel
{
    public string Command { get; set; } = string.Empty;
    public IEnumerable<QueryParametersViewModel>? Parameters { get; set; }

    public Task<Dictionary<string, object?>?> ToDictionaryAsync() => Task.FromResult(Parameters?
        .ToDictionary(
            parameter => parameter.Name,
            parameter => parameter.Value));
}
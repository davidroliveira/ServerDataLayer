namespace ServerDataLayer.Application.ViewModel;

public sealed class QueryViewModel
{
    public string Command { get; set; } = string.Empty;
    public IEnumerable<QueryParametersViewModel>? Parameters { get; set; }

    public Dictionary<string, object?>? ToDictionary() => Parameters?
        .ToDictionary(
            parameter => parameter.Name,
            parameter => parameter.Value);
}
using System.Text.Json.Serialization;

namespace Scaffold.Domain.Seedwork;

public class FieldProblemDetail
{
    [JsonPropertyName("code")] public string Code { get; set; }
    [JsonPropertyName("name")] public string Name { get; set; }

    [JsonPropertyName("message")] public string Message { get; set; }
    [JsonPropertyName("info")] public string Info { get; set; }
}
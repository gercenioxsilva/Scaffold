using System.Text.Json.Serialization;

namespace Scaffold.Domain.Seedwork;

public class CustomProblemDetail
{
    [JsonPropertyName("detail")] public string Detail { get; set; }

    [JsonPropertyName("fields")] public IList<FieldProblemDetail> Fields { get; set; } = new List<FieldProblemDetail>();


    public void AddField(string name, string message)
    {
        Fields.Add(new FieldProblemDetail()
        {
            Name = name,
            Message = message
        });
    }
}
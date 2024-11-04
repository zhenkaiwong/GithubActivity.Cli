using System.Text.Json;
using System.Text.Json.Serialization;
using GithubActivity.Cli.Json.Mappers;
using GithubActivity.Cli.Logging;
using GithubActivity.Cli.Models.Events;

namespace GithubActivity.Cli.Json;

public class GithubApiJsonConverter : JsonConverter<List<BaseEvent>>
{
  protected BaseLogger _logger = new ConsoleLogger();
  public override List<BaseEvent> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
  {
    List<BaseEvent> events = new();
    using JsonDocument document = JsonDocument.ParseValue(ref reader);
    JsonElement root = document.RootElement;
    if (root.ValueKind != JsonValueKind.Array)
    {
      return events;
    }

    var _mapper = new AggregatedMapper();

    foreach (JsonElement eventElement in root.EnumerateArray())
    {
      var mapFromJsonSuccess = _mapper.TryMapFromJsonElement(eventElement, out BaseEvent? result, out string error);
      if (!mapFromJsonSuccess || result is null)
      {
        _logger.Error(error);
        continue;
      }

      events.Add(result);
    }

    return events;
  }

  public override void Write(Utf8JsonWriter writer, List<BaseEvent> value, JsonSerializerOptions options)
  {
    _logger.Error("This converter isn't designed to deseralize object to JSON");
    throw new NotImplementedException();
  }
}

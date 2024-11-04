using System.Text.Json;
using GithubActivity.Cli.Models.Events;

namespace GithubActivity.Cli.Json.Mappers;

public class AggregatedMapper : BaseMapper
{
  protected Dictionary<string, BaseMapper> MapperDictionary { get; set; } = new();

  public AggregatedMapper()
  {
    MapperDictionary = new Dictionary<string, BaseMapper>();
    MapperDictionary.Add("PushEvent", new PushEventMapper());
  }

  protected bool TryGetMapper(string eventType, out BaseMapper? result, out string error)
  {
    if (!MapperDictionary.ContainsKey(eventType))
    {
      error = $"Unable to find a mapper for event with type: {eventType}";
      result = null;
      return false;
    }

    result = MapperDictionary[eventType];
    error = string.Empty;
    return true;
  }

  public override bool TryMapFromJsonElement(JsonElement jsonElement, out BaseEvent? result, out string error)
  {
    string? eventType = jsonElement.GetProperty("type").GetString();
    if (string.IsNullOrEmpty(eventType))
    {
      error = "Unable to find type property from json element";
      result = null;
      return false;
    }

    var getMapperSuccess = TryGetMapper(eventType, out BaseMapper? mapper, out error);
    if (!getMapperSuccess || mapper is null)
    {
      result = null;
      return false;
    }

    return mapper.TryMapFromJsonElement(jsonElement, out result, out error);
  }
}

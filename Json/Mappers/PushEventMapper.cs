using System.Text.Json;
using GithubActivity.Cli.Models.Events;
using GithubActivity.Cli.Models.Events.Payloads;

namespace GithubActivity.Cli.Json.Mappers;

public class PushEventMapper : BaseMapper
{
  public override bool TryMapFromJsonElement(JsonElement jsonElement, out BaseEvent? result, out string error)
  {
    JsonElement payloadElement = jsonElement.GetProperty("payload");

    var payload = new PushEventPayload()
    {
      Size = payloadElement.GetProperty("size").GetInt32()
    };

    result = new PushEvent();

    bool baseMapFromJsonElementSuccess = base.TryGetBaseEventFromJsonElement(jsonElement, ref result, out error);

    if (!baseMapFromJsonElementSuccess || result is null)
    {
      return false;
    }

    result.Payload = payload;

    error = string.Empty;
    return true;
  }
}

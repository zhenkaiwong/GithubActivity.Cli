using System.Text.Json;
using GithubActivity.Cli.Models.Events;
using GithubActivity.Cli.Models.Events.Payloads;

namespace GithubActivity.Cli.Json.Mappers;

public class CreateEventMapper : BaseMapper
{
  public override bool TryMapFromJsonElement(JsonElement jsonElement, out BaseEvent? result, out string error)
  {
    JsonElement payloadElement = jsonElement.GetProperty("payload");
    var payload = new CreateEventPayload()
    {
      Ref = payloadElement.GetProperty("ref").GetString(),
      RefType = payloadElement.GetProperty("ref_type").GetString(),
    };

    result = new CreateEvent();

    var baseMapFromJsonElementSuccess = base.TryGetBaseEventFromJsonElement(jsonElement, ref result, out error);

    if (!baseMapFromJsonElementSuccess || result is null)
    {
      return false;
    }

    result.Payload = payload;
    return true;
  }
}

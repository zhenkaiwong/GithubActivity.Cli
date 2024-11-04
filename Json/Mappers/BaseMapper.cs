using System.Text.Json;
using GithubActivity.Cli.Models.Events;

namespace GithubActivity.Cli.Json.Mappers;

public abstract class BaseMapper
{
  public abstract bool TryMapFromJsonElement(JsonElement jsonElement, out BaseEvent? result, out string error);
}

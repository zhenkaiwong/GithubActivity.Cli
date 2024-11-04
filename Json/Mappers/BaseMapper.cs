using System.Text.Json;
using GithubActivity.Cli.Models;
using GithubActivity.Cli.Models.Events;

namespace GithubActivity.Cli.Json.Mappers;

public abstract class BaseMapper
{
  public abstract bool TryMapFromJsonElement(JsonElement jsonElement, out BaseEvent? result, out string error);
  protected virtual bool TryGetBaseEventFromJsonElement(JsonElement jsonElement, ref BaseEvent result, out string error)
  {
    JsonElement actorElement = jsonElement.GetProperty("actor");
    JsonElement repositoryElement = jsonElement.GetProperty("repo");
    JsonElement payloadElement = jsonElement.GetProperty("payload");

    var actor = new Actor()
    {
      Id = actorElement.GetProperty("id").GetInt32(),
      Login = actorElement.GetProperty("login").GetString() ?? string.Empty
    };

    var repository = new Repository()
    {
      Id = repositoryElement.GetProperty("id").GetInt32(),
      Name = repositoryElement.GetProperty("name").GetString() ?? string.Empty,
      Url = repositoryElement.GetProperty("url").GetString() ?? string.Empty,
    };

    result.Type = jsonElement.GetProperty("type").GetString() ?? string.Empty;
    result.Actor = actor;
    result.Repository = repository;

    error = string.Empty;
    return true;
  }
}

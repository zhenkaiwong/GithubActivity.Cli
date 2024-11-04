using System;
using System.Text.Json;
using GithubActivity.Cli.Models;
using GithubActivity.Cli.Models.Events;
using GithubActivity.Cli.Models.Events.Payloads;

namespace GithubActivity.Cli.Json.Mappers;

public class PushEventMapper : BaseMapper
{
  public override bool TryMapFromJsonElement(JsonElement jsonElement, out BaseEvent? result, out string error)
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

    var payload = new PushEventPayload()
    {
      Size = payloadElement.GetProperty("size").GetInt32()
    };

    result = new PushEvent()
    {
      Type = jsonElement.GetProperty("type").GetString() ?? string.Empty,
      Actor = actor,
      Repository = repository,
      Payload = payload
    };

    error = string.Empty;
    return true;
  }
}

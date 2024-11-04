using System;
using GithubActivity.Cli.Models.Events.Payloads;

namespace GithubActivity.Cli.Models.Events;

public class PushEvent : BaseEvent
{
  public override string? GetActivityString()
  {
    PushEventPayload? payload = Payload as PushEventPayload;

    if (payload is null || Repository is null)
    {
      return null;
    }

    return $"Pushed {payload.Size} commits to {Repository.Name}";
  }
}

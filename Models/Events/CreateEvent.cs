using GithubActivity.Cli.Models.Events.Payloads;

namespace GithubActivity.Cli.Models.Events;

public class CreateEvent : BaseEvent
{
  public override string? GetActivityString()
  {
    CreateEventPayload? payload = Payload as CreateEventPayload;
    if (payload is null || payload.RefType is null || (payload.Ref is null && !payload.RefType.Equals("repository")))
    {
      return null;
    }

    if (Repository is null)
    {
      return null;
    }

    if (payload.Ref is null && payload.RefType.Equals("repository"))
    {
      return $"Created repository with name [{Repository.Name}]";
    }

    return $"Created {payload.RefType} with name [{payload.Ref}] under repository [{Repository.Name}]";
  }
}

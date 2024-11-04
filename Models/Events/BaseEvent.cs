using GithubActivity.Cli.Models.Events.Payloads;

namespace GithubActivity.Cli.Models.Events;

public abstract class BaseEvent
{
  public string Type { get; set; } = string.Empty;
  public Actor? Actor { get; set; }
  public Repository? Repository { get; set; }
  public BasePayload? Payload { get; set; }

  public abstract string? GetActivityString();
}

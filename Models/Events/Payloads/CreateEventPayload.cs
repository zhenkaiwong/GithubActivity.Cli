namespace GithubActivity.Cli.Models.Events.Payloads;

public class CreateEventPayload : BasePayload
{
  public string? Ref { get; set; }
  public string? RefType { get; set; }
}

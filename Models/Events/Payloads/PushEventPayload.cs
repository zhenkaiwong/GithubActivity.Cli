using System;

namespace GithubActivity.Cli.Models.Events.Payloads;

public class PushEventPayload : BasePayload
{

  public int Size { get; set; }
}

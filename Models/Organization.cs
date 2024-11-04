using System;

namespace GithubActivity.Cli.Models;

public class Organization
{
  public int Id { get; set; }
  public string Login { get; set; } = string.Empty;
  public string GravatarId { get; set; } = string.Empty;
  public string Url { get; set; } = string.Empty;
  public string AvatarUrl { get; set; } = string.Empty;
}

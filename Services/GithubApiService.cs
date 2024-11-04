using System.Net;
using System.Text.Json;
using GithubActivity.Cli.Json;
using GithubActivity.Cli.Logging;
using GithubActivity.Cli.Models.Events;

namespace GithubActivity.Cli.Services;

public class GithubApiService
{
  protected BaseLogger _logger;
  public string Username { get; private set; } = string.Empty;

  protected bool TryGetApiEndpointWithUsername(string username, out string result, out string error)
  {
    if (string.IsNullOrEmpty(username))
    {
      error = "Invalid user name, username shouldn't be empty or null";
      result = string.Empty;
      return false;
    }
    error = string.Empty;
    result = $"https://api.github.com/users/{username}/events";
    return true;
  }
  public GithubApiService(string username, BaseLogger logger)
  {
    Username = username;
    _logger = logger;
  }

  public async Task<List<BaseEvent>> GetEventsAsync()
  {
    var getEndpointSuccess = TryGetApiEndpointWithUsername(Username, out string endpoint, out string error);
    if (!getEndpointSuccess)
    {
      return new List<BaseEvent>();
    }

    var httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Add("User-Agent", "GithubActivity project");
    string rawJsonFromApiResponse = await httpClient.GetStringAsync(endpoint);

    var serializerOption = new JsonSerializerOptions()
    {
      Converters = {
        new GithubApiJsonConverter()
      }
    };
    var events = JsonSerializer.Deserialize<List<BaseEvent>>(rawJsonFromApiResponse, serializerOption) ?? new List<BaseEvent>();
    return events;
  }
}

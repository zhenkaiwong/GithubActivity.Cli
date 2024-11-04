using GithubActivity.Cli.Logging;
using GithubActivity.Cli.Models.Events;
using GithubActivity.Cli.Services;

namespace GithubActivity.Cli;

class Program
{
    static async Task Main(string[] args)
    {
        BaseLogger _logger = new ConsoleLogger();
        if (!args.Length.Equals(1))
        {
            _logger.Error("Unexpected parameters found. You must pass a GitHub username as args");
            return;
        }

        // if program args pass the check, we assume the only param is username
        // api service should fail if the only param is not a valid username
        string username = args[0];
        var apiService = new GithubApiService(username, _logger);
        List<BaseEvent> events = new();


        try
        {
            events = await apiService.GetEventsAsync();
        }
        catch (HttpRequestException hrex)
        {
            _logger.Error($"{hrex.Message}");
            _logger.Error($"Fail to find events for user {username}, user might not exist");
            return;
        }

        if (events.Count == 0)
        {
            _logger.Error($"Unable to find events for user: {username}");
            return;
        }

        foreach (BaseEvent @event in events)
        {
            string? activityString = @event.GetActivityString();
            if (activityString != null)
            {
                _logger.Info(activityString);
            }
        }
    }
}

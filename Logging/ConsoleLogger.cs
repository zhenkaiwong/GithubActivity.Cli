namespace GithubActivity.Cli.Logging;

public class ConsoleLogger : BaseLogger
{
  public override void Debug(string message)
  {
    if (!IsDebugMode())
    {
      return;
    }

    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"DEBUG: {message}");
    Console.ResetColor();
  }

  public override void Error(string message)
  {

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"ERROR: {message}");
    Console.ResetColor();
  }

  public override void Info(string message)
  {
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine($"INFO: {message}");
    Console.ResetColor();
  }
}

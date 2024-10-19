namespace GithubActivity.Cli.Logging;

public abstract class BaseLogger
{
  protected bool IsDebugMode()
  {
    return true;
  }
  public abstract void Info(string message);
  public abstract void Error(string message);
  public abstract void Debug(string message);
}

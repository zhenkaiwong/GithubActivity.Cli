# GithubActivity.Cli

A repository for Roadmap.sh Backend Developer project: Github User Activity CLI (https://roadmap.sh/projects/github-user-activity)

# How to use this?

1. Clone this project to local
2. Run the following commands

## Commands

```
dotnet run <username>
```

## Output:

```
- Pushed 3 commits to kamranahmedse/developer-roadmap
- Opened a new issue in kamranahmedse/developer-roadmap
- Starred kamranahmedse/developer-roadmap
- ...
```

**Note**: Not all events are support. For now only supports `CreateEvent` and `PushEvent`

#load "utils/logger.csx"

Logger.LogError("Hotfix finish command is blocked. use `git flow hotfix publish` to push changes to remote and then create pull request");
return -1;  
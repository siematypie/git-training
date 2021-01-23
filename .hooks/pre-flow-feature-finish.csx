#load "utils/logger.csx"

Logger.LogError("Feature finish command is blocked. use `git flow feature publish` to push changes to remote and then create pull request");
return -1;
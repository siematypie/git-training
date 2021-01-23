#load "logger.csx"
public static class CommandLine
{
    public static CommandResult Execute(string command, string commandDescription = null)
    {
        if (commandDescription != null)
        {
            Logger.LogInfo(commandDescription);
        }
        command = command.Replace("\"", "\"\"");
        using var proc = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "cmd.exe",
                Arguments = "/C " + command,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                CreateNoWindow = true
            }
        };
        proc.Start();
        proc.WaitForExit();

        var output = proc.ExitCode != 0 ? proc.StandardError.ReadToEnd() : proc.StandardOutput.ReadToEnd();
        return new CommandResult(proc.ExitCode, output);
    }
}

public struct CommandResult
{
    public int Code { get; }
    public bool IsError => Code != 0;
    public bool IsSuccess => Code == 0;
    public string Output { get; }

    public CommandResult(int code, string stdout = null)
    {
        Code = code;
        Output = stdout ?? string.Empty;
    }

    public CommandResult ShowOutput() {
      if (IsSuccess) {
        Logger.LogInfo(Output);
      } else {
        Logger.LogError(Output);
      }
      return this;
    }

    public static implicit operator int(CommandResult c) => c.Code;
}
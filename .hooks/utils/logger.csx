public class Logger {
 public static void LogInfo(string message) {
  Console.ForegroundColor  = ConsoleColor.White;
  Console.Error.WriteLine(message);
 }
public static void LogError(string message)
{
  Console.ForegroundColor = ConsoleColor.Red;
  Console.Error.WriteLine(message);
  Console.ForegroundColor  = ConsoleColor.White;
 }

 public static void LogSuccess(string message)
{
  Console.ForegroundColor = ConsoleColor.Green;
  Console.Error.WriteLine(message);
  Console.ForegroundColor  = ConsoleColor.White;
 }
}

namespace ExportProgram.Error
{
    public class LogWriter
    {
        public static async Task WriteToLogFile(string message)
        {
            using StreamWriter file = new(@"Data\Log.txt", append: true);
            await file.WriteLineAsync(message);
        }
    }
}

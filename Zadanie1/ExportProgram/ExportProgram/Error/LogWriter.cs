
namespace ExportProgram.Error
{
    public class LogWriter
    {
        public static async Task WriteToLogFile(string message)
        {
            using StreamWriter file = new(@".\Log.txt", append: true);
            await file.WriteLineAsync(message);
            file.Close();
        }
    }
}

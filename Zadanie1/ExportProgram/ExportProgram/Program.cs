
using ExportProgram.Error;
using ExportProgram.Model;

namespace ExportProgram
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if(args.Length != 3)
            {
                _ = LogWriter.WriteToLogFile("Nieodpowiednia liczba argumentów");
                throw new ArgumentException("Nieodpowiednia liczba argumentów");
            }
            
            string jsonPath = args[0];
            string csvFilePath = args[1];
            string format = args[2];

            University uni = new()
            {
                CreatedAt = DateTime.Now.ToString(),
                Author = "Kamila Jastrzebska"
            };
            ExportedData doc = new CsvFileParser().ParseCsv(csvFilePath, new ExportedData(uni));

            IDataFromatter formatter = IDataFromatter.getFormatter(format);
            var output = formatter.FormatData(doc);
            File.WriteAllText(args[0], output);
        }
    }
}

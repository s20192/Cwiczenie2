using ExportProgram.Model;
using System.Text.Json;

namespace ExportProgram
{
    public class JsonFormatter : IDataFromatter
    {
        public string name { get; }

        public JsonFormatter()
        {
            this.name = "json";
        }

        public string FormatData(ExportedData data)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            return JsonSerializer.Serialize(data, options);
        }
    }
}

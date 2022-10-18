using System.Text.Json.Serialization;

namespace ExportProgram.Model
{
    public class ExportedData
    {
        [JsonPropertyName("uczelnia")]
        public University University { get; set; }

        public ExportedData(University u)
        {
            this.University= u;
        }   
    }
}

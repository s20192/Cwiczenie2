using ExportProgram.Model;

namespace ExportProgram
{
    internal interface IDataFromatter
    {
        public string name { get;}
        public string FormatData(ExportedData data);

        public static IDataFromatter getFormatter(string name)
        {
            if(name == "json")
            {
                return new JsonFormatter();
            } else
            {
                throw new ArgumentException("Format " + name + " nie jest obsługiwany");
            }
        }
    }
}

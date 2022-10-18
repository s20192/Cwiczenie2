
namespace ExportProgram.Error
{
    public class MissingStudentDataException : Exception
    {
        public MissingStudentDataException() { }
        public MissingStudentDataException(string message) : base(message) { }
        public MissingStudentDataException(string message, Exception inner) : base(message, inner) { }
    }
}

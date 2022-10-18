
namespace ExportProgram.Model
{
    public class ActiveStudies
    {
        public string Name { get; set; }
        public int NumberOfStudents { get; set; }

        public ActiveStudies(Studies name)
        {
            this.Name = name.Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name);
        }

        public override bool Equals(object? obj)
        {
            return obj is ActiveStudies studies &&
                   Name == studies.Name;
        }
    }
}

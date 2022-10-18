
namespace ExportProgram.Students
{
    public class Student
    {
        public string IndexNumber { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

        private string _dateBirth;

        public string DateBirth
        {
            get { return _dateBirth; }
            set {
                DateTime oDate = Convert.ToDateTime(value);
                _dateBirth = oDate.Date.ToString("MM.dd.yyyy"); }
        }

        public string Email { get; set; }
        public string MothersName { get; set; }
        public string FathersName { get; set; }

        public Model.Studies Studies { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is Student student &&
                   FName == student.FName &&
                   LName == student.LName &&
                   IndexNumber == student.IndexNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(FName, LName, IndexNumber);   
        }
        
    }
}

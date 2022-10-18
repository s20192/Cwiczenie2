
using ExportProgram.Students;

namespace ExportProgram.Model
{
    public class University
    {
        private string _createdAt;

        public string CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = value; }
        }

        public string Author { get; set; }

        public HashSet<Student> Studenci { get;}

        public HashSet<ActiveStudies> ActiveStudies { get; }


        public University()
        {
            Studenci = new HashSet<Student>();
            ActiveStudies = new HashSet<ActiveStudies>();
        }

        public HashSet<Student> GetStudenci()
        {
            return Studenci;
        }
        public void AddStudent(Student st)
        {
            if (Studenci.Add(st))
            {
                ActiveStudies ast = new(st.Studies);
                if (!ActiveStudies.Contains(ast))
                {
                    ActiveStudies.Add(ast);
                    ast.NumberOfStudents++;
                } else
                {
                    foreach( ActiveStudies i in ActiveStudies)
                    {
                        if(i.Name == ast.Name)
                        {
                            i.NumberOfStudents++;
                        }
                    }
                }
                
            }
        }
    }
}

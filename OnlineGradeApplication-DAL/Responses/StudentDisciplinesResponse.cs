using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Responses
{
    public class StudentDisciplinesResponse
    {
        public Person? Student { get; set; }
        public Person Teacher { get; set; }
        public Group Group { get; set; }
        public Discipline Discipline { get; set; }
        public int TeacherGroupDbId { get; set; }
    }
}

using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Responses
{
    public class StudentDisciplinesResponse
    {
        public PersonDTO? Student { get; set; }
        public PersonDTO Teacher { get; set; }
        public GroupDTO Group { get; set; }
        public DisciplineDTO Discipline { get; set; }
        public int TeacherGroupDbId { get; set; }
}
}

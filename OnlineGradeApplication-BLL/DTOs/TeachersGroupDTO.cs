namespace OnlineGradeApplication_BLL.DTOs
{
    public class TeachersGroupDTO
    {
        public int Id { get; set; }

        public int? GroupId { get; set; }

        public int? DisciplineId { get; set; }

        public int? TeacherId { get; set; }

        public int? TeacherGroupDisciplineYear { get; set; }

        public virtual DisciplineDTO? Discipline { get; set; }

        public virtual GroupDTO? Group { get; set; }

        public virtual PersonDTO? Teacher { get; set; }
    }
}

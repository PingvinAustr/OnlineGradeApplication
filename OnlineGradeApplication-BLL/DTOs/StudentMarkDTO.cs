namespace OnlineGradeApplication_BLL.DTOs
{
    public class StudentMarkDTO
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }

        public int? AssignmentId { get; set; }

        public int? AssignmentMark { get; set; }

        public virtual StudentAssignmentDTO? Assignment { get; set; }

        public virtual PersonDTO? Student { get; set; }
    }
}

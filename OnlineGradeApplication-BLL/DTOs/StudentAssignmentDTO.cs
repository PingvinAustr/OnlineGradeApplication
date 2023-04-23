namespace OnlineGradeApplication_BLL.DTOs
{
    public class StudentAssignmentDTO
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }

        public int? CreatedByTeacherId { get; set; }

        public int? ResponsibleTeacherId { get; set; }

        public int? AssignmentTypeId { get; set; }

        public DateOnly? CreatedOnDate { get; set; }

        public DateOnly? DueDate { get; set; }

        public virtual AssignmentTypeDTO? AssignmentType { get; set; }

        public virtual PersonDTO? CreatedByTeacher { get; set; }

        public virtual PersonDTO? ResponsibleTeacher { get; set; }

        public virtual PersonDTO? Student { get; set; }

        public virtual ICollection<StudentMarkDTO> StudentMarks { get; set; } = new List<StudentMarkDTO>();
    }
}

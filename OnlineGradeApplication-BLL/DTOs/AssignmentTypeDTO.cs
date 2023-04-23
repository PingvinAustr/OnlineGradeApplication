namespace OnlineGradeApplication_BLL.DTOs
{
    public class AssignmentTypeDTO
    {
        public int Id { get; set; }

        public string? AssignmentName { get; set; }

        public int? AssignmentWeightPercent { get; set; }

        public virtual ICollection<StudentAssignmentDTO> StudentAssignments { get; set; } = new List<StudentAssignmentDTO>();
    }
}

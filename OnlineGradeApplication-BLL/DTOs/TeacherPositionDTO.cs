namespace OnlineGradeApplication_BLL.DTOs
{
    public class TeacherPositionDTO
    {
        public int Id { get; set; }

        public string? PositionName { get; set; }

        public virtual ICollection<TeacherCardDTO> TeacherCards { get; set; } = new List<TeacherCardDTO>();
    }
}

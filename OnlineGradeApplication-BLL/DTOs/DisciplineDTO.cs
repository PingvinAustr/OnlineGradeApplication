namespace OnlineGradeApplication_BLL.DTOs
{
    public class DisciplineDTO
    {
        public int Id { get; set; }

        public string? DisciplineName { get; set; }

        public virtual ICollection<TeachersGroupDTO> TeachersGroups { get; set; } = new List<TeachersGroupDTO>();
    }
}

namespace OnlineGradeApplication_BLL.DTOs
{
    public class CafedraDTO
    {
        public int CafedraId { get; set; }

        public string? CafedraName { get; set; }

        public virtual ICollection<GroupDTO> Groups { get; set; } = new List<GroupDTO>();

        public virtual ICollection<TeacherCardDTO> TeacherCards { get; set; } = new List<TeacherCardDTO>();
    }
}

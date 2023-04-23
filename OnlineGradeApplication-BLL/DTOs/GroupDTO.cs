namespace OnlineGradeApplication_BLL.DTOs
{
    public class GroupDTO
    {
        public int GroupId { get; set; }

        public string? GroupName { get; set; }

        public int? GroupCafedraId { get; set; }

        public int? GroupYear { get; set; }

        public virtual CafedraDTO? GroupCafedra { get; set; }

        public virtual ICollection<StudentsGroupDTO> StudentsGroups { get; set; } = new List<StudentsGroupDTO>();

        public virtual ICollection<TeachersGroupDTO> TeachersGroups { get; set; } = new List<TeachersGroupDTO>();
    }
}

namespace OnlineGradeApplication_BLL.DTOs
{
    public class RoleDTO
    {
        public int RoleId { get; set; }
        public string? RoleName { get; set; }
        public virtual ICollection<PersonDTO> People { get; set; } = new List<PersonDTO>();
    }
}

namespace OnlineGradeApplication_BLL.DTOs
{
    public class SystemAccessDTO
    {
        public int Id { get; set; }

        public string? Username { get; set; }

        public string? UserPassword { get; set; }

        public virtual ICollection<PersonDTO> People { get; set; } = new List<PersonDTO>();
    }
}

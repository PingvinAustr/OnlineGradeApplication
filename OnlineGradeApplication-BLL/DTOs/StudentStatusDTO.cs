namespace OnlineGradeApplication_BLL.DTOs
{
    public class StudentStatusDTO
    {
        public int Id { get; set; }

        public string? StatusName { get; set; }

        public virtual ICollection<StudentCardDTO> StudentCards { get; set; } = new List<StudentCardDTO>();
    }
}

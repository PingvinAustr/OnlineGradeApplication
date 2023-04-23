namespace OnlineGradeApplication_BLL.DTOs
{
    public class StudentsGroupDTO
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }

        public int? GroupId { get; set; }

        public virtual GroupDTO? Group { get; set; }

        public virtual PersonDTO? Student { get; set; }
    }
}

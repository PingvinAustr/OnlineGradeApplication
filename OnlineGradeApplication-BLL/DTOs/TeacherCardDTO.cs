namespace OnlineGradeApplication_BLL.DTOs
{
    public class TeacherCardDTO
    {
        public int Id { get; set; }

        public int? TeacherId { get; set; }

        public DateOnly? BeganWorkDate { get; set; }

        public int? CafedraId { get; set; }

        public int? PositionId { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public virtual CafedraDTO? Cafedra { get; set; }

        public virtual TeacherPositionDTO? Position { get; set; }

        public virtual PersonDTO? Teacher { get; set; }
    }
}

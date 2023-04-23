namespace OnlineGradeApplication_DAL.Entities;

public partial class TeacherCard
{
    public int Id { get; set; }

    public int? TeacherId { get; set; }

    public DateOnly? BeganWorkDate { get; set; }

    public int? CafedraId { get; set; }

    public int? PositionId { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public virtual Cafedra? Cafedra { get; set; }

    public virtual TeacherPosition? Position { get; set; }

    public virtual Person? Teacher { get; set; }
}

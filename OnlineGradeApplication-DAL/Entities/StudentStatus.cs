namespace OnlineGradeApplication_DAL.Entities;

public partial class StudentStatus
{
    public int Id { get; set; }

    public string? StatusName { get; set; }

    public virtual ICollection<StudentCard> StudentCards { get; set; } = new List<StudentCard>();
}

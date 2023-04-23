namespace OnlineGradeApplication_DAL.Entities;

public partial class StudentMark
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? AssignmentId { get; set; }

    public int? AssignmentMark { get; set; }

    public virtual StudentAssignment? Assignment { get; set; }

    public virtual Person? Student { get; set; }
}

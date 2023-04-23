namespace OnlineGradeApplication_DAL.Entities;

public partial class StudentsGroup
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual Person? Student { get; set; }
}

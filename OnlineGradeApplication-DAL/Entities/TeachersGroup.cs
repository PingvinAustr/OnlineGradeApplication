namespace OnlineGradeApplication_DAL.Entities;

public partial class TeachersGroup
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int? DisciplineId { get; set; }

    public int? TeacherId { get; set; }

    public int? TeacherGroupDisciplineYear { get; set; }

    public virtual Discipline? Discipline { get; set; }

    public virtual Group? Group { get; set; }

    public virtual Person? Teacher { get; set; }
}

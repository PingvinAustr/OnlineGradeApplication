namespace OnlineGradeApplication_DAL.Entities;
public partial class Discipline
{
    public int Id { get; set; }

    public string? DisciplineName { get; set; }

    public virtual ICollection<TeachersGroup> TeachersGroups { get; set; } = new List<TeachersGroup>();
}

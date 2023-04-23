namespace OnlineGradeApplication_DAL.Entities;

public partial class SystemAccess
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? UserPassword { get; set; }

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}

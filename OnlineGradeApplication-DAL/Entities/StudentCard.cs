namespace OnlineGradeApplication_DAL.Entities;
public partial class StudentCard
{
    public int StudentCardId { get; set; }

    public int? StudentId { get; set; }

    public DateOnly? EnrollmentYear { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Gender { get; set; }

    public int? StudentStatusId { get; set; }

    public string? Email { get; set; }

    public string? MotherName { get; set; }

    public string? FatherName { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CourseWorkTopicBachelor { get; set; }

    public int? CourseWorkLeaderBachelor { get; set; }

    public string? CourseWorkTopicMaster { get; set; }

    public int? CourseWorkLeaderMaster { get; set; }

    public DateOnly? ContractDate { get; set; }

    public virtual Person? CourseWorkLeaderBachelorNavigation { get; set; }

    public virtual Person? CourseWorkLeaderMasterNavigation { get; set; }

    public virtual StudentStatus? StudentStatus { get; set; }
}

using System;
using System.Collections.Generic;

namespace OnlineGradeApplication_DAL.Entities;

public partial class Group
{
    public int GroupId { get; set; }

    public string? GroupName { get; set; }

    public int? GroupCafedraId { get; set; }

    public int? GroupYear { get; set; }

    public virtual Cafedra? GroupCafedra { get; set; }

    public virtual ICollection<StudentsGroup> StudentsGroups { get; set; } = new List<StudentsGroup>();

    public virtual ICollection<TeachersGroup> TeachersGroups { get; set; } = new List<TeachersGroup>();
}

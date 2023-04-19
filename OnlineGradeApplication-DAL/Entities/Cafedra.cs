using System;
using System.Collections.Generic;

namespace OnlineGradeApplication_DAL.Entities;

public partial class Cafedra
{
    public int CafedraId { get; set; }

    public string? CafedraName { get; set; }

    public virtual ICollection<Group> Groups { get; set; } = new List<Group>();

    public virtual ICollection<TeacherCard> TeacherCards { get; set; } = new List<TeacherCard>();
}

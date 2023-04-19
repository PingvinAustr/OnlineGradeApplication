using System;
using System.Collections.Generic;

namespace OnlineGradeApplication_DAL.Entities;

public partial class TeacherPosition
{
    public int Id { get; set; }

    public string? PositionName { get; set; }

    public virtual ICollection<TeacherCard> TeacherCards { get; set; } = new List<TeacherCard>();
}

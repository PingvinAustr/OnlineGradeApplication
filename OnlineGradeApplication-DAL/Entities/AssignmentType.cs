using System;
using System.Collections.Generic;

namespace OnlineGradeApplication_DAL.Entities;

public partial class AssignmentType
{
    public int Id { get; set; }

    public string? AssignmentName { get; set; }

    public int? AssignmentWeightPercent { get; set; }

    public virtual ICollection<StudentAssignment> StudentAssignments { get; set; } = new List<StudentAssignment>();
}

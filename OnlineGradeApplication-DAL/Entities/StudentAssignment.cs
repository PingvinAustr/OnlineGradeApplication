using System;
using System.Collections.Generic;

namespace OnlineGradeApplication_DAL.Entities;

public partial class StudentAssignment
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? CreatedByTeacherId { get; set; }

    public int? ResponsibleTeacherId { get; set; }

    public int? AssignmentTypeId { get; set; }

    public DateOnly? CreatedOnDate { get; set; }

    public DateOnly? DueDate { get; set; }

    public virtual AssignmentType? AssignmentType { get; set; }

    public virtual Person? CreatedByTeacher { get; set; }

    public virtual Person? ResponsibleTeacher { get; set; }

    public virtual Person? Student { get; set; }

    public virtual ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();
}

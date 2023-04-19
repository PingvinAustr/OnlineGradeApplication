using System;
using System.Collections.Generic;

namespace OnlineGradeApplication_DAL.Entities;

public partial class Person
{
    public int Id { get; set; }

    public string? FirstName { get; set; }

    public string? SecondName { get; set; }

    public string? LastName { get; set; }

    public int? Age { get; set; }

    public int? RoleId { get; set; }

    public int? SystemAccessId { get; set; }

    public virtual Role? Role { get; set; }

    public virtual ICollection<StudentAssignment> StudentAssignmentCreatedByTeachers { get; set; } = new List<StudentAssignment>();

    public virtual ICollection<StudentAssignment> StudentAssignmentResponsibleTeachers { get; set; } = new List<StudentAssignment>();

    public virtual ICollection<StudentAssignment> StudentAssignmentStudents { get; set; } = new List<StudentAssignment>();

    public virtual ICollection<StudentCard> StudentCardCourseWorkLeaderBachelorNavigations { get; set; } = new List<StudentCard>();

    public virtual ICollection<StudentCard> StudentCardCourseWorkLeaderMasterNavigations { get; set; } = new List<StudentCard>();

    public virtual ICollection<StudentMark> StudentMarks { get; set; } = new List<StudentMark>();

    public virtual ICollection<StudentsGroup> StudentsGroups { get; set; } = new List<StudentsGroup>();

    public virtual SystemAccess? SystemAccess { get; set; }

    public virtual ICollection<TeacherCard> TeacherCards { get; set; } = new List<TeacherCard>();

    public virtual ICollection<TeachersGroup> TeachersGroups { get; set; } = new List<TeachersGroup>();
}

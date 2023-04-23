namespace OnlineGradeApplication_BLL.DTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? SecondName { get; set; }

        public string? LastName { get; set; }

        public int? Age { get; set; }

        public int? RoleId { get; set; }

        public int? SystemAccessId { get; set; }

        public virtual RoleDTO? Role { get; set; }

        public virtual ICollection<StudentAssignmentDTO> StudentAssignmentCreatedByTeachers { get; set; } = new List<StudentAssignmentDTO>();

        public virtual ICollection<StudentAssignmentDTO> StudentAssignmentResponsibleTeachers { get; set; } = new List<StudentAssignmentDTO>();

        public virtual ICollection<StudentAssignmentDTO> StudentAssignmentStudents { get; set; } = new List<StudentAssignmentDTO>();

        public virtual ICollection<StudentCardDTO> StudentCardCourseWorkLeaderBachelorNavigations { get; set; } = new List<StudentCardDTO>();

        public virtual ICollection<StudentCardDTO> StudentCardCourseWorkLeaderMasterNavigations { get; set; } = new List<StudentCardDTO>();

        public virtual ICollection<StudentMarkDTO> StudentMarks { get; set; } = new List<StudentMarkDTO>();

        public virtual ICollection<StudentsGroupDTO> StudentsGroups { get; set; } = new List<StudentsGroupDTO>();

        public virtual SystemAccessDTO? SystemAccess { get; set; }

        public virtual ICollection<TeacherCardDTO> TeacherCards { get; set; } = new List<TeacherCardDTO>();

        public virtual ICollection<TeachersGroupDTO> TeachersGroups { get; set; } = new List<TeachersGroupDTO>();
    }
}

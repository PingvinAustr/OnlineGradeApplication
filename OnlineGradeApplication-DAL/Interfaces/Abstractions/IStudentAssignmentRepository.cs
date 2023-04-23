using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IStudentAssignmentRepository
    {
        List<StudentAssignment> GetStudentAssignmentsAsync();
        StudentAssignment GetStudentAssignmentAsync(int id);
        /*
        Task<StudentAssignment> AddStudentAssignmentAsync(StudentAssignment studentAssignment);
        Task<StudentAssignment> UpdateStudentAssignmentAsync(StudentAssignment studentAssignment);
        Task DeleteStudentAssignmentAsync(int id);
        */
    }
}

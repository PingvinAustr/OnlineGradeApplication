using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IStudentAssignmentRepository
    {
        List<StudentAssignment> GetStudentAssignmentsAsync();
        StudentAssignment GetStudentAssignmentAsync(int id);
        List<StudentAssignmentResponse> GetStudentAssignmentsByStudentId(int studentId);
        List<TeacherAssignmentResponse> GetTeacherAssignmentsByStudentId(int teacherId);
    }
}

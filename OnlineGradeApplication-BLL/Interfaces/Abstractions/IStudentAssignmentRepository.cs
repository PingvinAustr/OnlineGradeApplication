using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Responses;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IStudentAssignmentRepository
    {
        List<StudentAssignmentDTO> GetStudentAssignmentsAsync();
        StudentAssignmentDTO GetStudentAssignmentAsync(int id);
        List<StudentAssignmentResponse> GetStudentAssignmentsByStudentId(int studentId);
        List<TeacherAssignmentResponse> GetTeacherAssignmentsByStudentId(int teacherId);
    }
}

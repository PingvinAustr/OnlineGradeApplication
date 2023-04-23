using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IStudentAssignmentRepository
    {
        List<StudentAssignmentDTO> GetStudentAssignmentsAsync();
        StudentAssignmentDTO GetStudentAssignmentAsync(int id);
    }
}

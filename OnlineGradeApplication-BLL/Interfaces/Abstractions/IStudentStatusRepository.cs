using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IStudentStatusRepository
    {
        List<StudentStatusDTO> GetStudentStatusesAsync();
        StudentStatusDTO GetStudentStatusAsync(int id);
    }
}

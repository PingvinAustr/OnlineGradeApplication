using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IStudentMarkRepository
    {
        List<StudentMarkDTO> GetStudentMarksAsync();
        StudentMarkDTO GetStudentMarkAsync(int id);
    }
}

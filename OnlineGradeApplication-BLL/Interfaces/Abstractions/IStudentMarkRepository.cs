using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Responses;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IStudentMarkRepository
    {
        List<StudentMarkDTO> GetStudentMarksAsync();
        StudentMarkDTO GetStudentMarkAsync(int id);
        List<GetMarksStudent> GetStudentMarksByStudentId(int studentId);
        List<GetMarksStudent> GetMarksByTeacherId(int teacherId);
    }
}

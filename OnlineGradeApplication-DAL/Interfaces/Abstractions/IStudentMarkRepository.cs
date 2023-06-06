using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IStudentMarkRepository
    {
        List<StudentMark> GetStudentMarksAsync();
        StudentMark GetStudentMarkAsync(int id);
        List<GetMarksStudent> GetStudentMarksByStudentId(int studentId);
        List<GetMarksStudent> GetMarksByTeacherId(int teacherId);
    }
}

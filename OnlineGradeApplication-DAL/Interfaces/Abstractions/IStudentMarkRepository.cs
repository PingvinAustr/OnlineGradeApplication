using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IStudentMarkRepository
    {
        Task<List<StudentMark>> GetStudentMarksAsync();
        Task<StudentMark> GetStudentMarkAsync(int id);
        Task<StudentMark> AddStudentMarkAsync(StudentMark studentMark);
        Task<StudentMark> UpdateStudentMarkAsync(StudentMark studentMark);
        Task DeleteStudentMarkAsync(int id);
    }
}

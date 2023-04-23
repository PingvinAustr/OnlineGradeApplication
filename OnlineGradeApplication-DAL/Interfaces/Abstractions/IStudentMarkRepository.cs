using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IStudentMarkRepository
    {
        List<StudentMark> GetStudentMarksAsync();
        StudentMark GetStudentMarkAsync(int id);
        /*
        Task<StudentMark> AddStudentMarkAsync(StudentMark studentMark);
        Task<StudentMark> UpdateStudentMarkAsync(StudentMark studentMark);
        Task DeleteStudentMarkAsync(int id);
        */
    }
}

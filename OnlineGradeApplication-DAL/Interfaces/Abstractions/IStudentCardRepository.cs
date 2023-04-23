using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IStudentCardRepository
    {
        List<StudentCard> GetStudentCardsAsync();
        StudentCard GetStudentCardAsync(int id);
        /*
        Task<StudentCard> AddStudentCardAsync(StudentCard studentCard);
        Task<StudentCard> UpdateStudentCardAsync(StudentCard studentCard);
        Task DeleteStudentCardAsync(int id);
        */
    }
}

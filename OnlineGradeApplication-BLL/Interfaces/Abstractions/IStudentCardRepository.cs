using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IStudentCardRepository
    {
        List<StudentCardDTO> GetStudentCardsAsync();
        StudentCardDTO GetStudentCardAsync(int id);
    }
}

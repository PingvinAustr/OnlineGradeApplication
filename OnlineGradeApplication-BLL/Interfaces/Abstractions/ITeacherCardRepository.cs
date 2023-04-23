using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface ITeacherCardRepository
    {
        List<TeacherCardDTO> GetTeacherCardsAsync();
        TeacherCardDTO GetTeacherCardAsync(int id);
    }
}

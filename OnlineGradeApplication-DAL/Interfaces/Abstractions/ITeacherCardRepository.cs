using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface ITeacherCardRepository
    {
        Task<List<TeacherCard>> GetTeacherCardsAsync();
        Task<TeacherCard> GetTeacherCardAsync(int id);
        Task<TeacherCard> AddTeacherCardAsync(TeacherCard teacherCard);
        Task<TeacherCard> UpdateTeacherCardAsync(TeacherCard teacherCard);
        Task DeleteTeacherCardAsync(int id);
    }
}

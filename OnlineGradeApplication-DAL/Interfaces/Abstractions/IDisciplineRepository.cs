using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IDisciplineRepository
    {
        List<Discipline> GetDisciplinesAsync();
        Discipline GetDisciplineAsync(int id);
        
        List<StudentDisciplinesResponse> GetDisciplinesForUser(int userId);

        bool DeleteGroupTeacherDisciplineEntry(int id);
    }
}

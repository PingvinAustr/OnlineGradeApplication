using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Responses;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IDisciplineRepository
    {
        List<DisciplineDTO> GetDisciplinesAsync();
        DisciplineDTO GetDisciplineAsync(int id);
        List<StudentDisciplinesResponse> GetDisciplinesForUser(int userId);
        bool DeleteGroupTeacherDisciplineEntry(int id);
    }
}

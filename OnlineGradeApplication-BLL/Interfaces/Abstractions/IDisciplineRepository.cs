using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IDisciplineRepository
    {
        List<DisciplineDTO> GetDisciplinesAsync();
        DisciplineDTO GetDisciplineAsync(int id);
    }
}

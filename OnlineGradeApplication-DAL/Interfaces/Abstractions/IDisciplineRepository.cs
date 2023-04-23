using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IDisciplineRepository
    {
        List<Discipline> GetDisciplinesAsync();
        Discipline GetDisciplineAsync(int id);
        /*
        Task<Discipline> AddDisciplineAsync(Discipline discipline);
        Task<Discipline> UpdateDisciplineAsync(Discipline discipline);
        Task DeleteDisciplineAsync(int id);
        */
    }
}

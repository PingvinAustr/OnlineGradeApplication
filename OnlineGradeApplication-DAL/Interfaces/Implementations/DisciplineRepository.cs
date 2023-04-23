using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class DisciplineRepository : IDisciplineRepository
    {

        public List<Discipline> GetDisciplinesAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.Disciplines.ToList();
        }
        public Discipline GetDisciplineAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var discipline = _context.Disciplines.FirstOrDefault(x => x.Id == id);
            return discipline;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}

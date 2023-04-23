using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class TeachersGroupRepository : ITeachersGroupRepository
    {

        public List<TeachersGroup> GetTeachersGroupsAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.TeachersGroups.ToList();
        }
        public TeachersGroup GetTeachersGroupAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var teachersGroup = _context.TeachersGroups.FirstOrDefault(x => x.Id == id);
            return teachersGroup;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}

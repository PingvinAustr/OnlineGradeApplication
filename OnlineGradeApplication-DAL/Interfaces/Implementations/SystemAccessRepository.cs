using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class SystemAccessRepository : ISystemAccessRepository
    {

        public List<SystemAccess> GetSystemAccessesAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.SystemAccesses.ToList();
        }
        public SystemAccess GetSystemAccessAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var systemAccess = _context.SystemAccesses.FirstOrDefault(x => x.Id == id);
            return systemAccess;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}

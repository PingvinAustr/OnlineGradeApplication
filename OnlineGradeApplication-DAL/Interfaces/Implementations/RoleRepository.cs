using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class RoleRepository : IRoleRepository
    {

        public List<Role> GetRolesAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.Roles.ToList();
        }
        public Role GetRoleAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var role = _context.Roles.FirstOrDefault(x=>x.RoleId == id);
            return role;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}

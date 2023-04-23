using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class GroupRepository : IGroupRepository
    {

        public List<Group> GetGroupsAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.Groups.ToList();
        }
        public Group GetGroupAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var group = _context.Groups.FirstOrDefault(x => x.GroupId == id);
            return group;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}

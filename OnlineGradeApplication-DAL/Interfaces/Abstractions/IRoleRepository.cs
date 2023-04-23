using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IRoleRepository
    {
        List<Role> GetRolesAsync();
        Role GetRoleAsync(int id);
        Role AddRoleAsync(Role role);
        /*
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}

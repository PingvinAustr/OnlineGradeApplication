using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IRoleRepository
    {
        List<RoleDTO> GetRolesAsync();
        RoleDTO GetRoleAsync(int id);

        RoleDTO AddRoleAsync(RoleDTO role);
    }
}

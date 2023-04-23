using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IMapper _RoleMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.IRoleRepository _role;

        public RoleRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.IRoleRepository role)
        {
            _role = role;
            _RoleMapper = mapper;
        }

        public List<RoleDTO> GetRolesAsync()
        {
            List<Role> rolesFromDB = _role.GetRolesAsync();
            List<RoleDTO> roles = _RoleMapper.Map<List<Role>, List<RoleDTO>>(rolesFromDB);
            return roles;
        }
        public RoleDTO GetRoleAsync(int id)
        {
            var data = _role.GetRoleAsync(id);
            RoleDTO role = _RoleMapper.Map<Role,RoleDTO>(data);
            return role;
        }

        public RoleDTO AddRoleAsync(RoleDTO role)
        {
            Role data = _RoleMapper.Map<RoleDTO, Role>(role);
            _role.AddRoleAsync(data);
            return role;
        }
    }
}

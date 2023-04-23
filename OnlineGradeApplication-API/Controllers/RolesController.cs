using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository role)
        {
            _roleRepository = role;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.RoleDTO>> GetRoles()
        {
            return _roleRepository.GetRolesAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.RoleDTO> GetRole(int id)
        {
            var role = _roleRepository.GetRoleAsync(id);
            if (role == null)
            {
                return NotFound();
            }
            return Ok(role);

        }

        [HttpPost]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.RoleDTO> AddRole(OnlineGradeApplication_BLL.DTOs.RoleDTO role)
        {
            _roleRepository.AddRoleAsync(role);
            return Ok(role);
        }
    }
}

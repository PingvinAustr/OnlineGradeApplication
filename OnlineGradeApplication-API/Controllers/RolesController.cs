using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

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
                Log.Warning($"[API][Role][UserId:{CurrentUser.currentUserId}] - GetRole - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][Role][UserId:{CurrentUser.currentUserId}] - GetRole - Success");
            return Ok(role);

        }

        [HttpPost]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.RoleDTO> AddRole(OnlineGradeApplication_BLL.DTOs.RoleDTO role)
        {
            try
            {
                _roleRepository.AddRoleAsync(role);
                Log.Information($"[API][Role][UserId:{CurrentUser.currentUserId}] - AddRole - Success");
                return Ok(role);
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Role][UserId:{CurrentUser.currentUserId}] - AddRole - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}

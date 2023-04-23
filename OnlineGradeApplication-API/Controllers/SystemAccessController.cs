using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemAccessController : ControllerBase
    {
        private readonly ISystemAccessRepository _systemAccessRepository;

        public SystemAccessController(ISystemAccessRepository systemAccess)
        {
            _systemAccessRepository = systemAccess;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.SystemAccessDTO>> GetSystemAccesses()
        {
            return _systemAccessRepository.GetSystemAccessesAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.SystemAccessDTO> GetSystemAccess(int id)
        {
            var systemAccess = _systemAccessRepository.GetSystemAccessAsync(id);
            if (systemAccess == null)
            {
                return NotFound();
            }
            return Ok(systemAccess);

        }
    }
}

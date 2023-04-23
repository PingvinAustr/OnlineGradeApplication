using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherGroupController : ControllerBase
    {
        private readonly ITeachersGroupRepository _teachersGroupRepository;

        public TeacherGroupController(ITeachersGroupRepository teachersGroup)
        {
            _teachersGroupRepository = teachersGroup;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.TeachersGroupDTO>> GetTeachersGroups()
        {
            return _teachersGroupRepository.GetTeachersGroupsAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.TeachersGroupDTO> GetTeachersGroups(int id)
        {
            var teachersGroup = _teachersGroupRepository.GetTeachersGroupAsync(id);
            if (teachersGroup == null)
            {
                return NotFound();
            }
            return Ok(teachersGroup);

        }
    }
}

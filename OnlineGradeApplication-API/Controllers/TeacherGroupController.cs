using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

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
            try
            {
                var data = _teachersGroupRepository.GetTeachersGroupsAsync();
                Log.Information($"[API][TeachersGroup][UserId:{CurrentUser.currentUserId}] - GetTeachersGroups - Success");
                return data;
            }
            catch (Exception ex)
            {
                Log.Error($"[API][TeachersGroup][UserId:{CurrentUser.currentUserId}] - GetTeachersGroups - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.TeachersGroupDTO> GetTeachersGroups(int id)
        {
            var teachersGroup = _teachersGroupRepository.GetTeachersGroupAsync(id);
            if (teachersGroup == null)
            {
                Log.Warning($"[API][TeachersGroup][UserId:{CurrentUser.currentUserId}] - GetTeachersGroups - NotFound");
                return NotFound();
            }
            Log.Information($"[API][TeachersGroup][UserId:{CurrentUser.currentUserId}] - GetTeachersGroups - Success");
            return Ok(teachersGroup);

        }

        [HttpPost]
        public ActionResult AddTeacherGroup(TeachersGroupDTO group)
        {
            try
            {
                _teachersGroupRepository.AddTeacherGroupEntry(group);
                Log.Information($"[API][TeachersGroup][UserId:{CurrentUser.currentUserId}] - AddTeacherGroup - Success");
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"[API][TeachersGroup][UserId:{CurrentUser.currentUserId}] - AddTeacherGroup - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        
    }
}

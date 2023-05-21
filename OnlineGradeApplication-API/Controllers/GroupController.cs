using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository group)
        {
            _groupRepository = group;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.GroupDTO>> GetGroups()
        {
            Log.Information($"[API][Group][UserId:{CurrentUser.currentUserId}] - GetGroups - Success");
            return _groupRepository.GetGroupsAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.GroupDTO> GetGroup(int id)
        {
            var group = _groupRepository.GetGroupAsync(id);
            if (group == null)
            {
                Log.Warning($"[API][Group][UserId:{CurrentUser.currentUserId}] - GetGroup - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][Group][UserId:{CurrentUser.currentUserId}] - GetGroup - Success");
            return Ok(group);

        }

        [HttpGet("GetGroupsInfo")]
        public ActionResult<int> GetGroupsInfo()
        {
            try
            {
                var data = _groupRepository.GetGroups();
                Request.Cookies.TryGetValue("userId", out string userId);
                Log.Information($"[API][Group][UserId:{CurrentUser.currentUserId}] - GetGroups - Success [{userId}]");
                return Ok(data);
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Group][UserId:{CurrentUser.currentUserId}] - GetGroups - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddGroup")]
        public ActionResult<int> AddGroup(GroupDTO group)
        {
            try
            {
                _groupRepository.AddGroup(group);
                Log.Information($"[API][Group][UserId:{CurrentUser.currentUserId}] - AddGroup - Success");
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Group][UserId:{CurrentUser.currentUserId}] - AddGroup - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("EditGroup")]
        public ActionResult<int> EditGroup(int id, string name, int year, int cafedraId)
        {
            try
            {
                _groupRepository.EditGroup(id, name, year, cafedraId);
                Log.Information($"[API][Group][UserId:{CurrentUser.currentUserId}] - EditGroup - Success");
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Group][UserId:{CurrentUser.currentUserId}] - EditGroup - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteGroup")]
        public ActionResult<int> DeleteGroup(int id)
        {
            try
            {
                _groupRepository.DeleteGroup(id);
                Log.Information($"[API][Group][UserId:{CurrentUser.currentUserId}] - DeleteGroup - Success");
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Group][UserId:{CurrentUser.currentUserId}] - DeleteGroup - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetGroupIdByStudentId")]
        public ActionResult<int> GetGroupByStudentId(int studentId)
        {
            try
            {      
                return Ok(_groupRepository.GetGroupIdByPersonId(studentId));
                Log.Information($"[API][Group][UserId:{CurrentUser.currentUserId}] - GetGroupIdByPersonId - Success. StudentId={studentId}");
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Group][UserId:{CurrentUser.currentUserId}] - GetGroupIdByPersonId - Fail - {ex.Message}, studentId={studentId}");
                return BadRequest(ex.Message);
            }
        }
    }
}

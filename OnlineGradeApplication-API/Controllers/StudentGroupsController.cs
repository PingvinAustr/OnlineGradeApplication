using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGroupsController : ControllerBase
    {
        private readonly IStudentGroupsRepository _studentGroupsRepository;

        public StudentGroupsController(IStudentGroupsRepository studentGroups)
        {
            _studentGroupsRepository = studentGroups;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.StudentsGroupDTO>> GetStudentsGroups()
        {
            try
            {
                var data = _studentGroupsRepository.GetStudentsGroupsAsync();
                Log.Information($"[API][StudentsGroup][UserId:{CurrentUser.currentUserId}] - GetStudentsGroups - Success");
                return data;
            }
            catch (Exception ex)
            {
                Log.Error($"[API][StudentsGroup][UserId:{CurrentUser.currentUserId}] - GetStudentsGroups - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.StudentsGroupDTO> GetStudentsGroup(int id)
        {
            var studentGroups = _studentGroupsRepository.GetStudentsGroupAsync(id);
            if (studentGroups == null)
            {
                Log.Warning($"[API][StudentsGroup][UserId:{CurrentUser.currentUserId}] - GetStudentsGroup - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][StudentsGroup][UserId:{CurrentUser.currentUserId}] - GetStudentsGroup - Success");
            return Ok(studentGroups);

        }
    }
}

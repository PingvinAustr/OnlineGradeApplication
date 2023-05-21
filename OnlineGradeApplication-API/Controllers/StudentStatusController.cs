using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentStatusController : ControllerBase
    {
        private readonly IStudentStatusRepository _studentStatusRepository;

        public StudentStatusController(IStudentStatusRepository studentStatus)
        {
            _studentStatusRepository = studentStatus;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.StudentStatusDTO>> GetStudentStatuses()
        {
            try
            {
                var data = _studentStatusRepository.GetStudentStatusesAsync();
                Log.Information($"[API][StudentStatus][UserId:{CurrentUser.currentUserId}] - GetStudentStatuses - Success");
                return data;
            }
            catch (Exception ex)
            {
                Log.Error($"[API][StudentStatus][UserId:{CurrentUser.currentUserId}] - GetStudentStatuses - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.StudentStatusDTO> GetStudentStatus(int id)
        {
            var studentStatus = _studentStatusRepository.GetStudentStatusAsync(id);
            if (studentStatus == null)
            {
                Log.Warning($"[API][StudentStatus][UserId:{CurrentUser.currentUserId}] - GetStudentStatus - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][StudentStatus][UserId:{CurrentUser.currentUserId}] - GetStudentStatus - Success");
            return Ok(studentStatus);

        }
    }
}

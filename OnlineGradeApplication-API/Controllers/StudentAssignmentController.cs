using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentAssignmentController : ControllerBase
    {
        private readonly IStudentAssignmentRepository _studentAssignmentRepository;

        public StudentAssignmentController(IStudentAssignmentRepository studentAssignment)
        {
            _studentAssignmentRepository = studentAssignment;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.StudentAssignmentDTO>> GetStudentAssignments()
        {
            try
            {
                var data = _studentAssignmentRepository.GetStudentAssignmentsAsync();
                Log.Information($"[API][StudentAssignment][UserId:{CurrentUser.currentUserId}] - GetStudentAssignmentsAsync - Success");
                return data;
            }
            catch (Exception ex)
            {
                Log.Error($"[API][StudentAssignment][UserId:{CurrentUser.currentUserId}] - GetStudentAssignmentsAsync - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.StudentAssignmentDTO> GetStudentAssignment(int id)
        {
            var studentAssignment = _studentAssignmentRepository.GetStudentAssignmentAsync(id);
            if (studentAssignment == null)
            {
                Log.Warning($"[API][StudentAssignment][UserId:{CurrentUser.currentUserId}] - GetStudentAssignment - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][StudentAssignment][UserId:{CurrentUser.currentUserId}] - GetStudentAssignment - Success");
            return Ok(studentAssignment);

        }
    }
}

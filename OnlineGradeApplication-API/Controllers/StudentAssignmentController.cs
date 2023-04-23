using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

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
            return _studentAssignmentRepository.GetStudentAssignmentsAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.StudentAssignmentDTO> GetStudentAssignment(int id)
        {
            var studentAssignment = _studentAssignmentRepository.GetStudentAssignmentAsync(id);
            if (studentAssignment == null)
            {
                return NotFound();
            }
            return Ok(studentAssignment);

        }
    }
}

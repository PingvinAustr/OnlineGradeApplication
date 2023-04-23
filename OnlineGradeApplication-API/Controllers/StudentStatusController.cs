using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

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
            return _studentStatusRepository.GetStudentStatusesAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.StudentStatusDTO> GetStudentStatus(int id)
        {
            var studentStatus = _studentStatusRepository.GetStudentStatusAsync(id);
            if (studentStatus == null)
            {
                return NotFound();
            }
            return Ok(studentStatus);

        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentMarkController : ControllerBase
    {
        private readonly IStudentMarkRepository _studentMarkRepository;

        public StudentMarkController(IStudentMarkRepository studentMark)
        {
            _studentMarkRepository = studentMark;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.StudentMarkDTO>> GetStudentMarksAsync()
        {
            return _studentMarkRepository.GetStudentMarksAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.StudentMarkDTO> GetStudentMarkAsync(int id)
        {
            var studentMark = _studentMarkRepository.GetStudentMarkAsync(id);
            if (studentMark == null)
            {
                return NotFound();
            }
            return Ok(studentMark);

        }
    }
}

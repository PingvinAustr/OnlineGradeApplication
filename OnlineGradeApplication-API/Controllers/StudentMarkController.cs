using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

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
            try
            {
                var data = _studentMarkRepository.GetStudentMarksAsync();
                Log.Information($"[API][StudentMark][UserId:{CurrentUser.currentUserId}] - GetStudentMarksAsync - Success");
                return data;
            }
            catch (Exception ex)
            {
                Log.Error($"[API][StudentMark][UserId:{CurrentUser.currentUserId}] - GetStudentMarksAsync - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.StudentMarkDTO> GetStudentMarkAsync(int id)
        {
            var studentMark = _studentMarkRepository.GetStudentMarkAsync(id);
            if (studentMark == null)
            {
                Log.Warning($"[API][StudentMark][UserId:{CurrentUser.currentUserId}] - GetStudentMarkAsync - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][StudentMark][UserId:{CurrentUser.currentUserId}] - GetStudentMarkAsync - Success");
            return Ok(studentMark);
        }

        [HttpGet("GetMarksByStudentId")]
        public ActionResult<OnlineGradeApplication_BLL.Responses.GetMarksStudent> GetMarksByStudentId(int id)
        {
            try
            {
                var data = _studentMarkRepository.GetStudentMarksByStudentId(id);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetMarksByTeacherId")]
        public ActionResult<OnlineGradeApplication_BLL.Responses.GetMarksStudent> GetMarksByTeacherId(int teacherId)
        {
            try
            {
                var data = _studentMarkRepository.GetMarksByTeacherId(teacherId);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

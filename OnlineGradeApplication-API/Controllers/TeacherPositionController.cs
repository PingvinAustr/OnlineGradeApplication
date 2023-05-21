using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherPositionController : ControllerBase
    {
        private readonly ITeacherPositionRepository _teacherPositionRepository;

        public TeacherPositionController(ITeacherPositionRepository role)
        {
            _teacherPositionRepository = role;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.TeacherPositionDTO>> GetTeacherPositions()
        {
            try
            {
                var data = _teacherPositionRepository.GetTeacherPositionsAsync();
                Log.Information($"[API][TeacherPosition][UserId:{CurrentUser.currentUserId}] - GetTeacherPositions - Success");
                return data;
            }
            catch (Exception ex)
            {
                Log.Error($"[API][TeacherPosition][UserId:{CurrentUser.currentUserId}] - GetTeacherPositions - Fail");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.TeacherPositionDTO> GetTeacherPosition(int id)
        {
            var teacherPosition = _teacherPositionRepository.GetTeacherPositionAsync(id);
            if (teacherPosition == null)
            {
                Log.Warning($"[API][TeacherPosition][UserId:{CurrentUser.currentUserId}] - GetTeacherPosition - NotFound");
                return NotFound();
            }
            Log.Information($"[API][TeacherPosition][UserId:{CurrentUser.currentUserId}] - GetTeacherPosition - Success");
            return Ok(teacherPosition);

        }
    }
}

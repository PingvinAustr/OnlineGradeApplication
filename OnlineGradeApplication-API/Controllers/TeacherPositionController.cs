using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

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
            return _teacherPositionRepository.GetTeacherPositionsAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.TeacherPositionDTO> GetTeacherPosition(int id)
        {
            var teacherPosition = _teacherPositionRepository.GetTeacherPositionAsync(id);
            if (teacherPosition == null)
            {
                return NotFound();
            }
            return Ok(teacherPosition);

        }
    }
}

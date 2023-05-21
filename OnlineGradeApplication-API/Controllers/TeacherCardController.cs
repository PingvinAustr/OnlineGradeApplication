using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherCardController : ControllerBase
    {
        private readonly ITeacherCardRepository _teacherCardRepository;

        public TeacherCardController(ITeacherCardRepository teacherCard)
        {
            _teacherCardRepository = teacherCard;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.TeacherCardDTO>> GetTeacherCardsAsync()
        {
            try
            {
                var data = _teacherCardRepository.GetTeacherCardsAsync();
                Log.Information($"[API][TeacherCard][UserId:{CurrentUser.currentUserId}] - GetTeacherCardsAsync - Success");
                return data;
            }
            catch (Exception ex)
            {
                Log.Error($"[API][TeacherCard][UserId:{CurrentUser.currentUserId}] - GetTeacherCardsAsync - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.TeacherCardDTO> GetTeacherCardAsync(int id)
        {
            var teacherCard = _teacherCardRepository.GetTeacherCardAsync(id);
            if (teacherCard == null)
            {
                Log.Warning($"[API][TeacherCard][UserId:{CurrentUser.currentUserId}] - GetTeacherCardAsync - NotFound");
                return NotFound();
            }
            Log.Information($"[API][TeacherCard][UserId:{CurrentUser.currentUserId}] - GetTeacherCardAsync - Success");
            return Ok(teacherCard);

        }
    }
}

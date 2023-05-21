using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentCardController : ControllerBase
    {
        private readonly IStudentCardRepository _studentCardRepository;

        public StudentCardController(IStudentCardRepository studentCard)
        {
            _studentCardRepository = studentCard;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.StudentCardDTO>> GetStudentCards()
        {
            try
            {
                var data = _studentCardRepository.GetStudentCardsAsync();
                Log.Information($"[API][StudentCard][UserId:{CurrentUser.currentUserId}] - GetStudentCards - Success");
                return data;
            }
            catch (Exception ex)
            {
                Log.Error($"[API][StudentCard][UserId:{CurrentUser.currentUserId}] - GetStudentCards - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.StudentCardDTO> GetStudentCard(int id)
        {
            var studentCard = _studentCardRepository.GetStudentCardAsync(id);
            if (studentCard == null)
            {
                Log.Warning($"[API][StudentCard][UserId:{CurrentUser.currentUserId}] - GetStudentCard - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][StudentCard][UserId:{CurrentUser.currentUserId}] - GetStudentCard - Success");
            return Ok(studentCard);

        }
    }
}

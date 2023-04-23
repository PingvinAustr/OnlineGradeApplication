using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

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
            return _studentCardRepository.GetStudentCardsAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.StudentCardDTO> GetStudentCard(int id)
        {
            var studentCard = _studentCardRepository.GetStudentCardAsync(id);
            if (studentCard == null)
            {
                return NotFound();
            }
            return Ok(studentCard);

        }
    }
}

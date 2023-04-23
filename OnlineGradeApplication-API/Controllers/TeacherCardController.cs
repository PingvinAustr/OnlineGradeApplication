using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

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
            return _teacherCardRepository.GetTeacherCardsAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.TeacherCardDTO> GetTeacherCardAsync(int id)
        {
            var teacherCard = _teacherCardRepository.GetTeacherCardAsync(id);
            if (teacherCard == null)
            {
                return NotFound();
            }
            return Ok(teacherCard);

        }
    }
}

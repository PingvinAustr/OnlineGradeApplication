using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CafedraController : ControllerBase
    {
        private readonly ICafedraRepository _cafedraRepository;

        public CafedraController(ICafedraRepository cafedra)
        {
            _cafedraRepository = cafedra;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.CafedraDTO>> GetCafedrasAsync()
        {
            return _cafedraRepository.GetCafedrasAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.CafedraDTO> GetCafedraAsync(int id)
        {
            var cafedra = _cafedraRepository.GetCafedraAsync(id);
            if (cafedra == null)
            {
                return NotFound();
            }
            return Ok(cafedra);

        }
    }
}

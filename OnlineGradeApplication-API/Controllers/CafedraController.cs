using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

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
            try
            {
                var data = _cafedraRepository.GetCafedrasAsync();
                Log.Information($"[API][Cafedra][UserId:{CurrentUser.currentUserId}] - GetCafedrasAsync - Success");
                return Ok(data);
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Cafedra][UserId:{CurrentUser.currentUserId}] - GetCafedrasAsync - Fail");
                return BadRequest(ex.Message);
            }         
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.CafedraDTO> GetCafedraAsync(int id)
        {
            try
            {
                var cafedra = _cafedraRepository.GetCafedraAsync(id);
                if (cafedra == null)
                {
                    Log.Warning($"[API][Cafedra][UserId:{CurrentUser.currentUserId}] - GetCafedraAsync - Not found with id={id}");
                    return NotFound();
                }
                Log.Information($"[API][Cafedra][UserId:{CurrentUser.currentUserId}] - GetCafedraAsync - Success");
                return Ok(cafedra);
            }
            catch
            {
                Log.Information($"[API][Cafedra][UserId:{CurrentUser.currentUserId}] - GetCafedraAsync - Fail");
                return NotFound();
            }
        }
    }
}

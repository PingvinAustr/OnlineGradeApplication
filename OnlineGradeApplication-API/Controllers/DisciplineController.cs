using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        private readonly IDisciplineRepository _disciplineRepository;

        public DisciplineController(IDisciplineRepository discipline)
        {
            _disciplineRepository = discipline;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.DisciplineDTO>> GetDisciplinesAsync()
        {
            return _disciplineRepository.GetDisciplinesAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.DisciplineDTO> GetDisciplineAsync(int id)
        {
            var discipline = _disciplineRepository.GetDisciplineAsync(id);
            if (discipline == null)
            {
                return NotFound();
            }
            return Ok(discipline);

        }

        [HttpGet("/GetDisciplinesByRoleIdForUser")]
        public ActionResult<OnlineGradeApplication_BLL.Responses.StudentDisciplinesResponse> GetDisciplinesForUser(int userId)
        {
            var disciplines = _disciplineRepository.GetDisciplinesForUser(userId);

            if (disciplines == null)
            {
                return NotFound();
            }
            return Ok(disciplines);

        }

        [HttpPost("/DeleteDisciplines")]
        public ActionResult<bool> DeleteDisciplines(int id)
        {
            var result = _disciplineRepository.DeleteGroupTeacherDisciplineEntry(id);
            if (result) return Ok(result);
            else return NoContent();

        }

        [HttpPost("/EditDisciplineInSchedule")]
        public ActionResult<bool> EditDisciplineInSchedule(int id, int teacherId, int groupId, int disciplineId)
        {
            var result = _disciplineRepository.EditDisciplineInSchedule(id, teacherId, groupId, disciplineId);
            if (result) return Ok(result);
            else return NoContent();
        }
    }
}

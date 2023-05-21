using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

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
                Log.Warning($"[API][Discipline][UserId:{CurrentUser.currentUserId}] - GetDisciplineAsync - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][Discipline][UserId:{CurrentUser.currentUserId}] - GetDisciplineAsync - Success");
            return Ok(discipline);

        }

        [HttpGet("/GetDisciplinesByRoleIdForUser")]
        public ActionResult<OnlineGradeApplication_BLL.Responses.StudentDisciplinesResponse> GetDisciplinesForUser(int userId)
        {
            var disciplines = _disciplineRepository.GetDisciplinesForUser(userId);

            if (disciplines == null)
            {
                Log.Warning($"[API][Discipline][UserId:{CurrentUser.currentUserId}] - GetDisciplinesForUser - NotFound with id={userId}");
                return NotFound();
            }
            Log.Information($"[API][Discipline][UserId:{CurrentUser.currentUserId}] - GetDisciplinesForUser - Success");
            return Ok(disciplines);

        }

        [HttpPost("/DeleteDisciplines")]
        public ActionResult<bool> DeleteDisciplines(int id)
        {
            var result = _disciplineRepository.DeleteGroupTeacherDisciplineEntry(id);
            if (result)
            {
                Log.Information($"[API][Discipline][UserId:{CurrentUser.currentUserId}] - DeleteGroupTeacherDisciplineEntry - Success - deleted with id={id}");
                return Ok(result);
            }
            else
            {
                Log.Warning($"[API][Discipline][UserId:{CurrentUser.currentUserId}] - DeleteGroupTeacherDisciplineEntry - Failed to delete with id={id}");
                return NoContent();
            }

        }

        [HttpPost("/EditDisciplineInSchedule")]
        public ActionResult<bool> EditDisciplineInSchedule(int id, int teacherId, int groupId, int disciplineId)
        {
            var result = _disciplineRepository.EditDisciplineInSchedule(id, teacherId, groupId, disciplineId);
            if (result)
            {
                Log.Information($"[API][Discipline][UserId:{CurrentUser.currentUserId}] - EditDisciplineInSchedule - Success");
                return Ok(result);
            }
            else
            {
                Log.Warning($"[API][Discipline][UserId:{CurrentUser.currentUserId}] - EditDisciplineInSchedule - Fail");
                return NoContent();
            }
        }
    }
}

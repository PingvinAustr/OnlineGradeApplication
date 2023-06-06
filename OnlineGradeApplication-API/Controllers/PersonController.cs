using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.Responses;
using Serilog;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPersonRepository _personRepository;

        public PersonController(IPersonRepository person, IHttpContextAccessor httpContextAccessor)
        {
            _personRepository = person;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.PersonDTO>> GetPeople()
        {
            return _personRepository.GetPeopleAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.PersonDTO> GetPerson(int id)
        {
            var person = _personRepository.GetPersonAsync(id);
            if (person == null)
            {
                Log.Warning($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetPerson - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetPerson - Success");
            return Ok(person);
        }

        [HttpGet("GetPersonRoleById")]
        public ActionResult<int> GetPersonRoleById(int userId)
        {
            try
            {
                var person = _personRepository.GetPersonAsync(userId);
                Log.Information($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetPersonRoleById - Success");
                return Ok(person.RoleId);
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetPersonRoleById - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("GetTeachers")]
        public ActionResult<int> GetTeachers()
        {
            try
            {
                var teachers = _personRepository.GetPeopleAsync().Where(x => x.RoleId == 1002);
                Log.Information($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetTeachers - Success");
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetTeachers - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStudents")]
        public ActionResult<int> GetStudents()
        {
            try
            {
                var students = _personRepository.GetStudents();
                Log.Information($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetStudents - Success");
                return Ok(students);
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetStudents - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
           
        }

        [HttpPost("AddPerson")]
        public ActionResult AddPerson(PersonDTO person)
        {
            try
            {
                _personRepository.AddStudent(person);
                Log.Information($"[API][Person][UserId:{CurrentUser.currentUserId}] - AddPerson - Success");
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Person][UserId:{CurrentUser.currentUserId}] - AddPerson - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("EditPerson")]
        public ActionResult EditPerson(int id, string firstName, string lastName, int age, int role, int systemAccess)
        {
            try
            {
                _personRepository.EditPerson(id, firstName, lastName, age, role, systemAccess);
                Log.Information($"[API][Person][UserId:{CurrentUser.currentUserId}] - EditPerson - Success");
                return Ok();
            }
            catch(Exception ex)
            {
                Log.Error($"[API][Person][UserId:{CurrentUser.currentUserId}] - EditPerson - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetStudentByGroupId")]
        public ActionResult GetStudentByGroupId(int groupId)
        {
            try
            {
                var students = _personRepository.GetStudentByGroupId(groupId);
                Log.Information($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetStudentByGroupId - Success");
                return Ok(students);
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetStudentByGroupId - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetTeachersByGroupId")]
        public ActionResult GetTeachersByGroupId(int personId)
        {
            try
            {
                var teachers = _personRepository.GetTeachersByPersonId(personId);
                Log.Information($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetTeachersByGroupId - Success");
                return Ok(teachers);
            }
            catch (Exception ex)
            {
                Log.Error($"[API][Person][UserId:{CurrentUser.currentUserId}] - GetTeachersByGroupId - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentGroupsController : ControllerBase
    {
        private readonly IStudentGroupsRepository _studentGroupsRepository;

        public StudentGroupsController(IStudentGroupsRepository studentGroups)
        {
            _studentGroupsRepository = studentGroups;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.StudentsGroupDTO>> GetStudentsGroups()
        {
            return _studentGroupsRepository.GetStudentsGroupsAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.StudentsGroupDTO> GetStudentsGroup(int id)
        {
            var studentGroups = _studentGroupsRepository.GetStudentsGroupAsync(id);
            if (studentGroups == null)
            {
                return NotFound();
            }
            return Ok(studentGroups);

        }
    }
}

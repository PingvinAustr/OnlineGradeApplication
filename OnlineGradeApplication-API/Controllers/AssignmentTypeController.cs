using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentTypeController : ControllerBase
    {
        private readonly IAssignmentTypeRepository _assignmentType;

        public AssignmentTypeController(IAssignmentTypeRepository assignmentType)
        {
            _assignmentType = assignmentType;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.AssignmentTypeDTO>> GetAssignmentTypesAsync()
        {
            return _assignmentType.GetAssignmentTypesAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.AssignmentTypeDTO> GetAssignmentTypeAsync(int id)
        {
            var assignmentType = _assignmentType.GetAssignmentTypeAsync(id);
            if (assignmentType == null)
            {
                return NotFound();
            }
            return Ok(assignmentType);

        }
    }
}

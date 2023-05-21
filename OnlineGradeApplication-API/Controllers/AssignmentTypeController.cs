using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

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
            try
            {
                var data = _assignmentType.GetAssignmentTypesAsync();
                Log.Information($"[API][AssignmentType][UserId:{CurrentUser.currentUserId}] - GetAssignmentTypesAsync - Success. Received {data.Count} rows");
                return data;
            }
            catch (Exception ex)
            {
                Log.Error($"[API][AssignmentType][UserId:{CurrentUser.currentUserId}] - GetAssignmentTypesAsync - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
           
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.AssignmentTypeDTO> GetAssignmentTypeAsync(int id)
        {
            var assignmentType = _assignmentType.GetAssignmentTypeAsync(id);
            if (assignmentType == null)
            {
                Log.Warning($"[API][AssignmentType][UserId:{CurrentUser.currentUserId}] - GetAssignmentTypeAsync - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][AssignmentType][UserId:{CurrentUser.currentUserId}] - GetAssignmentTypeAsync - Success");
            return Ok(assignmentType);

        }
    }
}

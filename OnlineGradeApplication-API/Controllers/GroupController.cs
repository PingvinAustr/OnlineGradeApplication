using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupRepository _groupRepository;

        public GroupController(IGroupRepository group)
        {
            _groupRepository = group;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.GroupDTO>> GetGroups()
        {
            return _groupRepository.GetGroupsAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.GroupDTO> GetGroup(int id)
        {
            var group = _groupRepository.GetGroupAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            return Ok(group);

        }
    }
}

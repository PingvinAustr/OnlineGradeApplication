using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using Serilog;

namespace OnlineGradeApplication_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SystemAccessController : ControllerBase
    {
        private readonly ISystemAccessRepository _systemAccessRepository;

        public SystemAccessController(ISystemAccessRepository systemAccess)
        {
            _systemAccessRepository = systemAccess;
        }

        [HttpGet]
        public ActionResult<List<OnlineGradeApplication_BLL.DTOs.SystemAccessDTO>> GetSystemAccesses()
        {
            try
            {
                var data = _systemAccessRepository.GetSystemAccessesAsync();
                Log.Information($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - GetSystemAccesses - Success");
                return data;
            }
            catch (Exception ex)
            {
                Log.Error($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - GetSystemAccesses - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<OnlineGradeApplication_BLL.DTOs.SystemAccessDTO> GetSystemAccess(int id)
        {
            var systemAccess = _systemAccessRepository.GetSystemAccessAsync(id);
            if (systemAccess == null)
            {
                Log.Warning($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - GetSystemAccess - NotFound with id={id}");
                return NotFound();
            }
            Log.Information($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - GetSystemAccess - Success");
            return Ok(systemAccess);

        }

        [HttpPost("/loginUser")]
        public ActionResult<int> LoginUser(string username, string password)
        {
            List<OnlineGradeApplication_BLL.DTOs.SystemAccessDTO> systemAccesses = _systemAccessRepository.GetSystemAccessesAsync();
            var existingUser = systemAccesses.Find(x => x.Username == username && x.UserPassword == password);
            if (existingUser == null)
            {
                Log.Warning($"[API][SystemAccess] - LoginUser - NotFound");
                return NotFound();
            }
            else
            {
                Log.Information($"[API][SystemAccess] - LoginUser - Success");
                CurrentUser.currentUserId = existingUser.Id;
                return existingUser.Id;
            }
        }

            [HttpPost("/setCurrentUser")]
            public ActionResult<int> SetCurrentUser(int id)
            {
                CurrentUser.currentUserId = id;
                return CurrentUser.currentUserId;
            }

        [HttpGet("GetSystemUserAccesses")]
        public ActionResult<int> GetResponseSystemAccesses()
        {
            try
            {
                var data = _systemAccessRepository.GetResponseSystemAccesses();
                Log.Information($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - GetResponseSystemAccesses - Success");
                return Ok(data);
            }
            catch (Exception ex)
            {
                Log.Error($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - GetResponseSystemAccesses - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddSystemUser")]
        public ActionResult<int> AddSystemAccess(string username, string password)
        {
            try
            {
                _systemAccessRepository.AddSystemAccess(username, password);
                Log.Information($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - AddSystemAccess - Success");
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - AddSystemAccess - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("DeleteSystemUser")]
        public ActionResult<int> DeleteSystemUser(int id)
        {
            try
            {
                _systemAccessRepository.DeleteSystemAccess(id);
                Log.Information($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - DeleteSystemAccess - Success");
                return Ok();
            }
            catch (Exception ex)
            {
                Log.Error($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - DeleteSystemAccess - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("EditSystemUser")]
        public ActionResult<int> EditSystemUser(int id, string username, string password)
        {
            try
            {
                _systemAccessRepository.EditSystemAccess(id, username, password);
                Log.Information($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - EditSystemAccess - Success");
                return Ok();
            }
            catch(Exception ex)
            {
                Log.Error($"[API][SystemAccess][UserId:{CurrentUser.currentUserId}] - EditSystemAccess - Fail - {ex.Message}");
                return BadRequest(ex.Message);
            }
        }
    }
}

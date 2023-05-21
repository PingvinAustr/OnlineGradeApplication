using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;
using OnlineGradeApplication_BLL.Responses;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class SystemAccessRepository : ISystemAccessRepository
    {
        private readonly IMapper _SystemAccessMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.ISystemAccessRepository _systemAccess;

        public SystemAccessRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.ISystemAccessRepository systemAccess)
        {
            _systemAccess = systemAccess;
            _SystemAccessMapper = mapper;
        }

        public List<SystemAccessDTO> GetSystemAccessesAsync()
        {
            List<SystemAccess> systemAccessesFromDB = _systemAccess.GetSystemAccessesAsync();
            List<SystemAccessDTO> systemAccesses = _SystemAccessMapper.Map<List<SystemAccess>, List<SystemAccessDTO>>(systemAccessesFromDB);
            return systemAccesses;
        }
        public SystemAccessDTO GetSystemAccessAsync(int id)
        {
            var data = _systemAccess.GetSystemAccessAsync(id);
            SystemAccessDTO systemAccess = _SystemAccessMapper.Map<SystemAccess, SystemAccessDTO>(data);
            return systemAccess;
        }

        public List<GetSystemUsers> GetResponseSystemAccesses()
        {
            var data = _systemAccess.GetResponseSystemAccesses();
            List<GetSystemUsers> sysAccesses = _SystemAccessMapper.Map<List<OnlineGradeApplication_DAL.Responses.GetSystemUsers>, List<OnlineGradeApplication_BLL.Responses.GetSystemUsers>>(data);
            return sysAccesses;
        }

        public void AddSystemAccess(string username, string password)
        {
            _systemAccess.AddSystemAccess(username, password);
        }

        public void DeleteSystemAccess(int id)
        {
            _systemAccess.DeleteSystemAccess(id);
        }

        public void EditSystemAccess(int id, string username, string password)
        {
            _systemAccess.EditSystemAccess(id, username, password);
        }
    }
}

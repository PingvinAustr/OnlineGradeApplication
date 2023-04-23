using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

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
    }
}

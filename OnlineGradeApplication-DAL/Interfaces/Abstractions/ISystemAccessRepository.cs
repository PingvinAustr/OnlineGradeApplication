using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface ISystemAccessRepository
    {
        List<SystemAccess> GetSystemAccessesAsync();
        SystemAccess GetSystemAccessAsync(int id);
        /*
        Task<SystemAccess> AddSystemAccessAsync(SystemAccess systemAccess);
        Task<SystemAccess> UpdateSystemAccessAsync(SystemAccess systemAccess);
        Task DeleteSystemAccessAsync(int id);
        */
    }
}

using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface ISystemAccessRepository
    {
        List<SystemAccess> GetSystemAccessesAsync();
        SystemAccess GetSystemAccessAsync(int id);

        List<GetSystemUsers> GetResponseSystemAccesses();
        void AddSystemAccess(string username, string password);
        void DeleteSystemAccess(int id);
        void EditSystemAccess(int id, string username, string password);
        /*
        Task<SystemAccess> AddSystemAccessAsync(SystemAccess systemAccess);
        Task<SystemAccess> UpdateSystemAccessAsync(SystemAccess systemAccess);
        Task DeleteSystemAccessAsync(int id);
        */
    }
}

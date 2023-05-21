using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Responses;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface ISystemAccessRepository
    {
        List<SystemAccessDTO> GetSystemAccessesAsync();
        SystemAccessDTO GetSystemAccessAsync(int id);
        List<GetSystemUsers> GetResponseSystemAccesses();
        void AddSystemAccess(string username, string password);
        void DeleteSystemAccess(int id);
        public void EditSystemAccess(int id, string username, string password);
    }
}

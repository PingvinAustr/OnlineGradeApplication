using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface ISystemAccessRepository
    {
        List<SystemAccessDTO> GetSystemAccessesAsync();
        SystemAccessDTO GetSystemAccessAsync(int id);
    }
}

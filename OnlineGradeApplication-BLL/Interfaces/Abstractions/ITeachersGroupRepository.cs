using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface ITeachersGroupRepository
    {
        List<TeachersGroupDTO> GetTeachersGroupsAsync();
        TeachersGroupDTO GetTeachersGroupAsync(int id);
    }
}

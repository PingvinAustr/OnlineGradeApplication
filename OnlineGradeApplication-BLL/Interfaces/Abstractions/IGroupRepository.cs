using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IGroupRepository
    {
        List<GroupDTO> GetGroupsAsync();
        GroupDTO GetGroupAsync(int id);
    }
}

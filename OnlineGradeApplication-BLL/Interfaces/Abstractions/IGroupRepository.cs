using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Responses;

namespace OnlineGradeApplication_BLL.Interfaces.Abstractions
{
    public interface IGroupRepository
    {
        List<GroupDTO> GetGroupsAsync();
        GroupDTO GetGroupAsync(int id);
        List<GetGroups> GetGroups();

        void AddGroup(GroupDTO group);
        void EditGroup(int id, string name, int year, int cafedraId);
        void DeleteGroup(int id);
        int? GetGroupIdByPersonId(int personId);
    }
}

using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IGroupRepository
    {
        List<Group> GetGroupsAsync();
        Group GetGroupAsync(int id);
        List<GetGroups> GetGroupsInfo();

        void AddGroup(Group group);
        void EditGroup(int id, string name, int year, int cafedraId);
        void DeleteGroup(int id);
        int? GetGroupIdByPersonId(int personId);

        /*
        Task<Group> AddGroupAsync(Group group);
        Task<Group> UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(int id);
        */
    }
}

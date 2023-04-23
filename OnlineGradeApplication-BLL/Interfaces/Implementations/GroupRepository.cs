using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class GroupRepository : IGroupRepository
    {
        private readonly IMapper _GroupMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.IGroupRepository _group;

        public GroupRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.IGroupRepository group)
        {
            _group = group;
            _GroupMapper = mapper;
        }

        public List<GroupDTO> GetGroupsAsync()
        {
            List<Group> groupsFromDB = _group.GetGroupsAsync();
            List<GroupDTO> groups = _GroupMapper.Map<List<Group>, List<GroupDTO>>(groupsFromDB);
            return groups;
        }
        public GroupDTO GetGroupAsync(int id)
        {
            var data = _group.GetGroupAsync(id);
            GroupDTO group = _GroupMapper.Map<Group, GroupDTO>(data);
            return group;
        }
    }
}

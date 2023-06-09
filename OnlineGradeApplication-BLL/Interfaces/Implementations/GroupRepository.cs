﻿using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;
using OnlineGradeApplication_BLL.Responses;

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

        public List<GetGroups> GetGroups()
        {
            var data = _group.GetGroupsInfo();
            List<GetGroups> groups = _GroupMapper.Map<List<OnlineGradeApplication_DAL.Responses.GetGroups>, List<OnlineGradeApplication_BLL.Responses.GetGroups>>(data);
            return groups;
        }

        public void AddGroup(GroupDTO group)
        {
            _group.AddGroup(_GroupMapper.Map<GroupDTO, Group>(group));
        }

        public void EditGroup(int id, string name, int year, int cafedraId)
        {
            _group.EditGroup(id, name, year, cafedraId);
        }
        public void DeleteGroup(int id)
        {
            _group.DeleteGroup(id);
        }
        public int? GetGroupIdByPersonId(int personId)
        {
            return _group.GetGroupIdByPersonId(personId);
        }
    }
}

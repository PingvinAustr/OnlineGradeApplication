﻿using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IGroupRepository
    {
        Task<List<Group>> GetGroupsAsync();
        Task<Group> GetGroupAsync(int id);
        Task<Group> AddGroupAsync(Group group);
        Task<Group> UpdateGroupAsync(Group group);
        Task DeleteGroupAsync(int id);
    }
}

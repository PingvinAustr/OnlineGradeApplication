using Moq;
using AutoMapper;
using Xunit;
using OnlineGradeApplication_BLL.Interfaces.Implementations;
using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_BLL.DTOs;
using System.Collections.Generic;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.Responses;

namespace OnlineGradeApplication_XUnit.BLL
{
    public class GroupRepositoryTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<IGroupRepository> _groupRepositoryMock;
        private readonly GroupRepository _groupRepository;

        public GroupRepositoryTests()
        {
            _mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile());
            }).CreateMapper();

            _groupRepositoryMock = new Mock<IGroupRepository>();

            _groupRepository = new GroupRepository(_mapperMock, _groupRepositoryMock.Object);
        }

        [Fact]
        public void GetGroupsAsync_ReturnsListOfGroupDTOs()
        {
            // Arrange
            List<Group> groupsFromDB = new List<Group>()
            {
                new Group { GroupId = 1, GroupName = "Group 1" },
                new Group { GroupId = 2, GroupName = "Group 2" }
            };
            _groupRepositoryMock.Setup(mock => mock.GetGroupsAsync()).Returns(groupsFromDB);

            // Act
            List<GroupDTO> result = _groupRepository.GetGroupsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Group 1", result[0].GroupName);
            Assert.Equal("Group 2", result[1].GroupName);
        }

        [Fact]
        public void GetGroupAsync_WithValidId_ReturnsGroupDTO()
        {
            // Arrange
            int groupId = 1;
            Group groupFromDB = new Group { GroupId = groupId, GroupName = "Group 1" };
            _groupRepositoryMock.Setup(mock => mock.GetGroupAsync(groupId)).Returns(groupFromDB);

            // Act
            GroupDTO result = _groupRepository.GetGroupAsync(groupId);

            // Assert
            Assert.Equal(groupId, result.GroupId);
            Assert.Equal("Group 1", result.GroupName);
        }

        [Fact]
        public void GetGroups_WithValidUserId_ReturnsListOfGetGroupsResponse()
        {
            // Arrange
            List<OnlineGradeApplication_DAL.Responses.GetGroups> getGroupsFromDB = new List<OnlineGradeApplication_DAL.Responses.GetGroups>()
            {
                new OnlineGradeApplication_DAL.Responses.GetGroups { Id = 1, GroupName = "Group 1" },
                new OnlineGradeApplication_DAL.Responses.GetGroups { Id = 2, GroupName = "Group 2" }
            };
            _groupRepositoryMock.Setup(mock => mock.GetGroupsInfo()).Returns(getGroupsFromDB);

            // Act
            List<OnlineGradeApplication_BLL.Responses.GetGroups> result = _groupRepository.GetGroups();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Group 1", result[0].GroupName);
            Assert.Equal("Group 2", result[1].GroupName);
        }

        [Fact]
        public void AddGroup_WithValidGroupDTO_CallsAddGroupOnRepository()
        {
            // Arrange
            GroupDTO group = new GroupDTO { GroupName = "Group 1", GroupYear = 2023, GroupCafedraId = 1 };

            // Act
            _groupRepository.AddGroup(group);

            // Assert
            _groupRepositoryMock.Verify(mock => mock.AddGroup(It.Is<Group>(g => g.GroupName == group.GroupName && g.GroupYear == group.GroupYear && g.GroupCafedraId == group.GroupCafedraId)), Times.Once);
        }

        [Fact]
        public void EditGroup_WithValidParameters_CallsEditGroupOnRepository()
        {
            // Arrange
            int id = 1;
            string name = "Updated Group";
            int year = 2023;
            int cafedraId = 2;

            // Act
            _groupRepository.EditGroup(id, name, year, cafedraId);

            // Assert
            _groupRepositoryMock.Verify(mock => mock.EditGroup(id, name, year, cafedraId), Times.Once);
        }

        [Fact]
        public void DeleteGroup_WithValidId_CallsDeleteGroupOnRepository()
        {
            // Arrange
            int id = 1;

            // Act
            _groupRepository.DeleteGroup(id);

            // Assert
            _groupRepositoryMock.Verify(mock => mock.DeleteGroup(id), Times.Once);
        }

        [Fact]
        public void GetGroupIdByPersonId_WithValidPersonId_ReturnsGroupId()
        {
            // Arrange
            int personId = 1;
            int? groupIdFromDB = 2;
            _groupRepositoryMock.Setup(mock => mock.GetGroupIdByPersonId(personId)).Returns(groupIdFromDB);

            // Act
            int? result = _groupRepository.GetGroupIdByPersonId(personId);

            // Assert
            Assert.Equal(groupIdFromDB, result);
        }
    }
}

using Moq;
using Xunit;
using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using System.Collections.Generic;
using System.Linq;
using OnlineGradeApplication_BLL.Interfaces.Implementations;
using AutoMapper;
using OnlineGradeApplication_BLL.DTOs;

namespace OnlineGradeApplication_XUnit.BLL
{
    public class TeachersGroupRepositoryTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<ITeachersGroupRepository> _teacherGroupRepositoryMock;
        private readonly TeacherGroupRepository _teacherGroupRepository;

        public TeachersGroupRepositoryTests()
        {
            _mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile());
            }).CreateMapper();

            _teacherGroupRepositoryMock = new Mock<ITeachersGroupRepository>();

            _teacherGroupRepository = new TeacherGroupRepository(_mapperMock, _teacherGroupRepositoryMock.Object);
        }

        [Fact]
        public void GetTeacherGroupsAsync_ReturnsList()
        {
            // Arrange
            List<TeachersGroup> teacherGroupsFromDB = new List<TeachersGroup>()
            {
                new TeachersGroup { Id = 1 },
                new TeachersGroup { Id = 2 }
            };

            _teacherGroupRepositoryMock.Setup(mock => mock.GetTeachersGroupsAsync()).Returns(teacherGroupsFromDB);

            // Act
            List<TeachersGroupDTO> result = _teacherGroupRepository.GetTeachersGroupsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
        }

        [Fact]
        public void GetTeacherGroupAsync_WithValidId_ReturnsTeacherGroup()
        {
            // Arrange
            int teacherGroupId = 1;
            TeachersGroup teacherGroupsFromDb = new TeachersGroup { Id = teacherGroupId };
            _teacherGroupRepositoryMock.Setup(mock => mock.GetTeachersGroupAsync(teacherGroupId)).Returns(teacherGroupsFromDb);

            // Act
            TeachersGroupDTO result = _teacherGroupRepository.GetTeachersGroupAsync(teacherGroupId);

            // Assert
            Assert.Equal(teacherGroupId, result.Id);
            Assert.Equal(1, result.Id);
        }
    }
}

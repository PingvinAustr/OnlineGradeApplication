using Moq;
using AutoMapper;
using Xunit;
using OnlineGradeApplication_BLL.Interfaces.Implementations;
using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_BLL.DTOs;
using System.Collections.Generic;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_XUnit.BLL
{
    public class AssignmentTypeRepositoryTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<IAssignmentTypeRepository> _assignmentTypeRepositoryMock;
        private readonly AssignmentTypeRepository _assignmentTypeRepository;

        public AssignmentTypeRepositoryTests()
        {
            _mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile());
            }).CreateMapper();

            _assignmentTypeRepositoryMock = new Mock<IAssignmentTypeRepository>();

            _assignmentTypeRepository = new AssignmentTypeRepository(_mapperMock, _assignmentTypeRepositoryMock.Object);
        }

        [Fact]
        public void GetAssignmentTypesAsync_ReturnsListOfAssignmentTypeDTOs()
        {
            // Arrange
            List<AssignmentType> assignmentTypesFromDB = new List<AssignmentType>()
            {
                new AssignmentType { Id = 1, AssignmentName = "Assignment Type 1" },
                new AssignmentType { Id = 2, AssignmentName = "Assignment Type 2" }
            };
            _assignmentTypeRepositoryMock.Setup(mock => mock.GetAssignmentTypesAsync()).Returns(assignmentTypesFromDB);

            // Act
            List<AssignmentTypeDTO> result = _assignmentTypeRepository.GetAssignmentTypesAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Assignment Type 1", result[0].AssignmentName);
            Assert.Equal("Assignment Type 2", result[1].AssignmentName);
        }

        [Fact]
        public void GetAssignmentTypeAsync_WithValidId_ReturnsAssignmentTypeDTO()
        {
            // Arrange
            int assignmentTypeId = 1;
            AssignmentType assignmentTypeFromDB = new AssignmentType { Id = assignmentTypeId, AssignmentName = "Assignment Type 1" };
            _assignmentTypeRepositoryMock.Setup(mock => mock.GetAssignmentTypeAsync(assignmentTypeId)).Returns(assignmentTypeFromDB);

            // Act
            AssignmentTypeDTO result = _assignmentTypeRepository.GetAssignmentTypeAsync(assignmentTypeId);

            // Assert
            Assert.Equal(assignmentTypeId, result.Id);
            Assert.Equal("Assignment Type 1", result.AssignmentName);
        }
    }
}

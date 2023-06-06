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
    public class StudentAssignmentRepositoryTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<IStudentAssignmentRepository> _studentAssignmentRepositoryMock;
        private readonly StudentAssignmentRepository _studentAssignmentRepository;

        public StudentAssignmentRepositoryTests()
        {
            _mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile()); // Add your mapping profile here
            }).CreateMapper();

            _studentAssignmentRepositoryMock = new Mock<IStudentAssignmentRepository>();

            _studentAssignmentRepository = new StudentAssignmentRepository(_mapperMock, _studentAssignmentRepositoryMock.Object);
        }

        [Fact]
        public void GetStudentAssignmentsAsync_ReturnsListOfStudentAssignmentDTOs()
        {
            // Arrange
            List<StudentAssignment> studentAssignmentsFromDB = new List<StudentAssignment>()
            {
                new StudentAssignment { Id = 1, StudentId = 1, AssignmentTypeId = 1},
                new StudentAssignment { Id = 2, StudentId = 2, AssignmentTypeId = 2}
            };
            _studentAssignmentRepositoryMock.Setup(mock => mock.GetStudentAssignmentsAsync()).Returns(studentAssignmentsFromDB);

            // Act
            List<StudentAssignmentDTO> result = _studentAssignmentRepository.GetStudentAssignmentsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal(1, result[0].StudentId);
            Assert.Equal(1, result[0].AssignmentTypeId);
            Assert.Equal(2, result[1].Id);
            Assert.Equal(2, result[1].StudentId);
            Assert.Equal(2, result[1].AssignmentTypeId);
        }

        [Fact]
        public void GetStudentAssignmentAsync_WithValidId_ReturnsStudentAssignmentDTO()
        {
            // Arrange
            int studentAssignmentId = 1;
            StudentAssignment studentAssignmentFromDB = new StudentAssignment { Id = studentAssignmentId, StudentId = 1, AssignmentTypeId = 1};
            _studentAssignmentRepositoryMock.Setup(mock => mock.GetStudentAssignmentAsync(studentAssignmentId)).Returns(studentAssignmentFromDB);

            // Act
            StudentAssignmentDTO result = _studentAssignmentRepository.GetStudentAssignmentAsync(studentAssignmentId);

            // Assert
            Assert.Equal(studentAssignmentId, result.Id);
            Assert.Equal(1, result.StudentId);
            Assert.Equal(1, result.AssignmentTypeId);
        }
    }
}

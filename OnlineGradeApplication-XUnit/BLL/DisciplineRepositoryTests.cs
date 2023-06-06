using Moq;
using AutoMapper;
using Xunit;
using OnlineGradeApplication_BLL.Interfaces.Implementations;
using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_BLL.DTOs;
using System.Collections.Generic;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.Responses;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_XUnit.BLL
{
    public class DisciplineRepositoryTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<IDisciplineRepository> _disciplineRepositoryMock;
        private readonly DisciplineRepository _disciplineRepository;

        public DisciplineRepositoryTests()
        {
            _mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile()); // Add your mapping profile here
            }).CreateMapper();

            _disciplineRepositoryMock = new Mock<IDisciplineRepository>();

            _disciplineRepository = new DisciplineRepository(_mapperMock, _disciplineRepositoryMock.Object);
        }

        [Fact]
        public void GetDisciplinesAsync_ReturnsListOfDisciplineDTOs()
        {
            // Arrange
            List<Discipline> disciplinesFromDB = new List<Discipline>()
            {
                new Discipline { Id = 1, DisciplineName = "Discipline 1" },
                new Discipline { Id = 2, DisciplineName = "Discipline 2" }
            };
            _disciplineRepositoryMock.Setup(mock => mock.GetDisciplinesAsync()).Returns(disciplinesFromDB);

            // Act
            List<DisciplineDTO> result = _disciplineRepository.GetDisciplinesAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Discipline 1", result[0].DisciplineName);
            Assert.Equal("Discipline 2", result[1].DisciplineName);
        }

        [Fact]
        public void GetDisciplineAsync_WithValidId_ReturnsDisciplineDTO()
        {
            // Arrange
            int disciplineId = 1;
            Discipline disciplineFromDB = new Discipline { Id = disciplineId, DisciplineName = "Discipline 1" };
            _disciplineRepositoryMock.Setup(mock => mock.GetDisciplineAsync(disciplineId)).Returns(disciplineFromDB);

            // Act
            DisciplineDTO result = _disciplineRepository.GetDisciplineAsync(disciplineId);

            // Assert
            Assert.Equal(disciplineId, result.Id);
            Assert.Equal("Discipline 1", result.DisciplineName);
        }

        [Fact]
        public void GetDisciplinesForUser_WithValidUserId_ReturnsListOfStudentDisciplinesResponse()
        {
            // Arrange
            int userId = 1;
            List<OnlineGradeApplication_DAL.Responses.StudentDisciplinesResponse> studentDisciplinesFromDB = new List<OnlineGradeApplication_DAL.Responses.StudentDisciplinesResponse>()
            {
                new OnlineGradeApplication_DAL.Responses.StudentDisciplinesResponse { Discipline = new Discipline(){ DisciplineName = "Discipline 1"} },
                new OnlineGradeApplication_DAL.Responses.StudentDisciplinesResponse { Discipline = new Discipline(){ DisciplineName = "Discipline 2"} }
            };
            _disciplineRepositoryMock.Setup(mock => mock.GetDisciplinesForUser(userId)).Returns(studentDisciplinesFromDB);

            // Act
            List<OnlineGradeApplication_BLL.Responses.StudentDisciplinesResponse> result = _disciplineRepository.GetDisciplinesForUser(userId);
            
            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Discipline 1", result[0].Discipline.DisciplineName);
            Assert.Equal("Discipline 2", result[1].Discipline.DisciplineName);
        }

        [Fact]
        public void DeleteGroupTeacherDisciplineEntry_WithValidId_ReturnsTrue()
        {
            // Arrange
            int id = 1;
            _disciplineRepositoryMock.Setup(mock => mock.DeleteGroupTeacherDisciplineEntry(id)).Returns(true);

            // Act
            bool result = _disciplineRepository.DeleteGroupTeacherDisciplineEntry(id);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void EditDisciplineInSchedule_WithValidParameters_ReturnsTrue()
        {
            // Arrange
            int id = 1;
            int teacherId = 2;
            int groupId = 3;
            int disciplineId = 4;
            _disciplineRepositoryMock.Setup(mock => mock.EditDisciplineInSchedule(id, teacherId, groupId, disciplineId)).Returns(true);

            // Act
            bool result = _disciplineRepository.EditDisciplineInSchedule(id, teacherId, groupId, disciplineId);

            // Assert
            Assert.True(result);
        }
    }
}

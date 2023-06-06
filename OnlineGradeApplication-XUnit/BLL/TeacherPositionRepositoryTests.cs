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
    public class TeacherPositionRepositoryTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<ITeacherPositionRepository> _teacherPositionRepositoryMock;
        private readonly TeacherPositionRepository _teacherPositionRepository;

        public TeacherPositionRepositoryTests()
        {
            _mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile());
            }).CreateMapper();

            _teacherPositionRepositoryMock = new Mock<ITeacherPositionRepository>();

            _teacherPositionRepository = new TeacherPositionRepository(_mapperMock, _teacherPositionRepositoryMock.Object);
        }

        [Fact]
        public void GetTeacherPositionsAsync_ReturnsList()
        {
            // Arrange
            List<TeacherPosition> teacherPositionsFromDB = new List<TeacherPosition>()
            {
                new TeacherPosition { Id = 1 },
                new TeacherPosition { Id = 2 }
            };

            _teacherPositionRepositoryMock.Setup(mock => mock.GetTeacherPositionsAsync()).Returns(teacherPositionsFromDB);

            // Act
            List<TeacherPositionDTO> result = _teacherPositionRepository.GetTeacherPositionsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].Id);
            Assert.Equal(2, result[1].Id);
        }

        [Fact]
        public void GetTeacherPositionAsync_WithValidId_ReturnsTeacherPosition()
        {
            // Arrange
            int teacherPositionId = 1;
            TeacherPosition teacherPositionsFromDb = new TeacherPosition { Id = teacherPositionId };
            _teacherPositionRepositoryMock.Setup(mock => mock.GetTeacherPositionAsync(teacherPositionId)).Returns(teacherPositionsFromDb);

            // Act
            TeacherPositionDTO result = _teacherPositionRepository.GetTeacherPositionAsync(teacherPositionId);

            // Assert
            Assert.Equal(teacherPositionId, result.Id);
            Assert.Equal(1, result.Id);
        }

        private static IQueryable<T> MockDbSet<T>(List<T> list) where T : class
        {
            return list.AsQueryable();
        }
    }
}
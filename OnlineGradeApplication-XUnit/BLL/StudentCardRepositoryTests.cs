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
    public class StudentCardRepositoryTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<IStudentCardRepository> _studentCardRepositoryMock;
        private readonly StudentCardRepository _studentCardRepository;

        public StudentCardRepositoryTests()
        {
            _mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile()); // Add your mapping profile here
            }).CreateMapper();

            _studentCardRepositoryMock = new Mock<IStudentCardRepository>();

            _studentCardRepository = new StudentCardRepository(_mapperMock, _studentCardRepositoryMock.Object);
        }

        [Fact]
        public void GetStudentCardsAsync_ReturnsListOfStudentCardDTOs()
        {
            // Arrange
            List<StudentCard> studentCardsFromDB = new List<StudentCard>()
            {
                new StudentCard { StudentCardId = 1, StudentId = 1 },
                new StudentCard { StudentCardId = 2, StudentId = 2 }
            };
            _studentCardRepositoryMock.Setup(mock => mock.GetStudentCardsAsync()).Returns(studentCardsFromDB);

            // Act
            List<StudentCardDTO> result = _studentCardRepository.GetStudentCardsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal(1, result[0].StudentCardId);
            Assert.Equal(1, result[0].StudentId);
            Assert.Equal(2, result[1].StudentCardId);
            Assert.Equal(2, result[1].StudentId);
        }

        [Fact]
        public void GetStudentCardAsync_WithValidId_ReturnsStudentCardDTO()
        {
            // Arrange
            int studentCardId = 1;
            StudentCard studentCardFromDB = new StudentCard { StudentCardId = studentCardId, StudentId = 1 };
            _studentCardRepositoryMock.Setup(mock => mock.GetStudentCardAsync(studentCardId)).Returns(studentCardFromDB);

            // Act
            StudentCardDTO result = _studentCardRepository.GetStudentCardAsync(studentCardId);

            // Assert
            Assert.Equal(studentCardId, result.StudentCardId);
            Assert.Equal(1, result.StudentId);
        }
    }
}

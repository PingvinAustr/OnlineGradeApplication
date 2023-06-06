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
    public class TeacherCardRepositoryTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<ITeacherCardRepository> _teacherCardRepositoryMock;
        private readonly TeacherCardRepository _teacherCardRepository;

        public TeacherCardRepositoryTests()
        {
            _mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile());
            }).CreateMapper();

            _teacherCardRepositoryMock = new Mock<ITeacherCardRepository>();

            _teacherCardRepository = new TeacherCardRepository(_mapperMock, _teacherCardRepositoryMock.Object);
        }

        [Fact]
        public void GetTeacherCardsAsync_ReturnsListOfTeacherCards()
        {
            // Arrange
            List<TeacherCard> teacherCardsFromDB = new List<TeacherCard>()
            {
                new TeacherCard { Id = 1, PhoneNumber = "+380111111111" },
                new TeacherCard { Id = 2, PhoneNumber = "+380111111112" }
            };

            _teacherCardRepositoryMock.Setup(mock => mock.GetTeacherCardsAsync()).Returns(teacherCardsFromDB);

            // Act
            List<TeacherCardDTO> result = _teacherCardRepository.GetTeacherCardsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("+380111111111", result[0].PhoneNumber);
            Assert.Equal("+380111111112", result[1].PhoneNumber);
        }

        [Fact]
        public void GetTeacherCardAsync_WithValidId_ReturnsTeacherCard()
        {
            // Arrange
            int teacherCardId = 1;
            TeacherCard teacherCardsFromDb = new TeacherCard { Id = teacherCardId, PhoneNumber = "+380111111111" };
            _teacherCardRepositoryMock.Setup(mock => mock.GetTeacherCardAsync(teacherCardId)).Returns(teacherCardsFromDb);

            // Act
            TeacherCardDTO result = _teacherCardRepository.GetTeacherCardAsync(teacherCardId);

            // Assert
            Assert.Equal(teacherCardId, result.Id);
            Assert.Equal("+380111111111", result.PhoneNumber);
        }

        private static IQueryable<T> MockDbSet<T>(List<T> list) where T : class
        {
            return list.AsQueryable();
        }
    }
}

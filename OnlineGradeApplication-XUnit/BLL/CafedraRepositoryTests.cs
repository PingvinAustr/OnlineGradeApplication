using AutoMapper;
using Moq;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_BLL.Interfaces.Implementations;
using OnlineGradeApplication_DAL.Entities;
using System.Collections.Generic;
using Xunit;

namespace OnlineGradeApplication_XUnit.BLL
{
    public class CafedraRepositoryTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<OnlineGradeApplication_DAL.Interfaces.Abstractions.ICafedraRepository> _cafedraRepositoryMock;
        private readonly CafedraRepository _cafedraRepository;

        public CafedraRepositoryTests()
        {
            _mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile());
            }).CreateMapper();

            _cafedraRepositoryMock = new Mock<OnlineGradeApplication_DAL.Interfaces.Abstractions.ICafedraRepository>();

            _cafedraRepository = new CafedraRepository(_mapperMock, _cafedraRepositoryMock.Object);
        }

        [Fact]
        public void GetCafedrasAsync_ReturnsListOfCafedraDTOs()
        {
            // Arrange
            List<Cafedra> cafedrasFromDB = new List<Cafedra>()
            {
                 new Cafedra { CafedraId = 1, CafedraName = "Cafedra 1" },
                 new Cafedra { CafedraId = 2, CafedraName = "Cafedra 2" }
            };
            _cafedraRepositoryMock.Setup(mock => mock.GetCafedrasAsync()).Returns(cafedrasFromDB);

            // Act
            List<CafedraDTO> result = _cafedraRepository.GetCafedrasAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Cafedra 1", result[0].CafedraName);
            Assert.Equal("Cafedra 2", result[1].CafedraName);
        }

        [Fact]
        public void GetCafedraAsync_WithValidId_ReturnsCafedraDTO()
        {
            // Arrange
            int cafedraId = 1;
            Cafedra cafedraFromDB = new Cafedra { CafedraId = cafedraId, CafedraName = "Cafedra 1" };
            _cafedraRepositoryMock.Setup(mock => mock.GetCafedraAsync(cafedraId)).Returns(cafedraFromDB);

            // Act
            CafedraDTO result = _cafedraRepository.GetCafedraAsync(cafedraId);

            // Assert
            Assert.Equal(cafedraId, result.CafedraId);
            Assert.Equal("Cafedra 1", result.CafedraName);
        }


    }

}

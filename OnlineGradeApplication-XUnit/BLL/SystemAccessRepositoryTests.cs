using Moq;
using Xunit;
using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_DAL.Interfaces.Implementations;
using System.Collections.Generic;
using System.Linq;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_XUnit.BLL
{
    public class SystemAccessRepositoryTests
    {
        private readonly SystemAccessRepository _systemAccessRepository;
        private readonly Mock<OnlineGradesDbContext> _dbContextMock;

        public SystemAccessRepositoryTests()
        {
            _dbContextMock = new Mock<OnlineGradesDbContext>();
            _systemAccessRepository = new SystemAccessRepository();
        }

        [Fact]
        public void GetSystemAccessesAsync_ReturnsListOfSystemAccesses()
        {
            // Act
            List<SystemAccess> result = _systemAccessRepository.GetSystemAccessesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetSystemAccessAsync_WithValidId_ReturnsSystemAccess()
        {
            // Arrange
            int systemAccessId = 1;

            // Act
            SystemAccess result = _systemAccessRepository.GetSystemAccessAsync(systemAccessId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(systemAccessId, result.Id);
        }

        [Fact]
        public void GetSystemAccessAsync_WithInvalidId_ReturnsNull()
        {
            // Arrange
            int systemAccessId = -1;

            // Act
            SystemAccess result = _systemAccessRepository.GetSystemAccessAsync(systemAccessId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetResponseSystemAccesses_ReturnsListOfGetSystemUsers()
        {
            // Act
            List<GetSystemUsers> result = _systemAccessRepository.GetResponseSystemAccesses();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }
    }
}

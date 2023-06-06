using Moq;
using Xunit;
using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_DAL.Interfaces.Implementations;
using System.Collections.Generic;
using System.Linq;

namespace OnlineGradeApplication_XUnit.BLL
{
    public class StudentStatusRepositoryTests
    {
        private readonly StudentStatusRepository _studentStatusRepository;

        public StudentStatusRepositoryTests()
        {
            _studentStatusRepository = new StudentStatusRepository();
        }

        [Fact]
        public void GetStudentStatusesAsync_ReturnsListOfStudentStatuses()
        {
            // Act
            List<StudentStatus> result = _studentStatusRepository.GetStudentStatusesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetStudentStatusAsync_WithValidId_ReturnsStudentStatus()
        {
            // Arrange
            int studentStatusId = 1;

            // Act
            StudentStatus result = _studentStatusRepository.GetStudentStatusAsync(studentStatusId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(studentStatusId, result.Id);
        }

        [Fact]
        public void GetStudentStatusAsync_WithInvalidId_ReturnsNull()
        {
            // Arrange
            int studentStatusId = -1;

            // Act
            StudentStatus result = _studentStatusRepository.GetStudentStatusAsync(studentStatusId);

            // Assert
            Assert.Null(result);
        }
    }
}

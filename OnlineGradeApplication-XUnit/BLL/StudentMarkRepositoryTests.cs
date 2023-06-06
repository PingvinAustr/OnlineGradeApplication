using Moq;
using Xunit;
using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_DAL.Interfaces.Implementations;
using System.Collections.Generic;
using System.Linq;

namespace OnlineGradeApplication_XUnit.BLL
{
    public class StudentMarkRepositoryTests
    {
        private readonly StudentMarkRepository _studentMarkRepository;

        public StudentMarkRepositoryTests()
        {
            _studentMarkRepository = new StudentMarkRepository();
        }

        [Fact]
        public void GetStudentMarkAsync_WithInvalidId_ReturnsNull()
        {
            // Arrange
            int studentMarkId = -1;

            // Act
            StudentMark result = _studentMarkRepository.GetStudentMarkAsync(studentMarkId);

            // Assert
            Assert.Null(result);
        }
    }
}

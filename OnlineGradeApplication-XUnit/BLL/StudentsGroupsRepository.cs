using Moq;
using Xunit;
using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_DAL.Interfaces.Implementations;
using System.Collections.Generic;
using System.Linq;

namespace OnlineGradeApplication_XUnit.BLL
{
    public class StudentsGroupsRepositoryTests
    {
        private readonly StudentsGroupsRepository _studentsGroupsRepository;

        public StudentsGroupsRepositoryTests()
        {
            _studentsGroupsRepository = new StudentsGroupsRepository();
        }

        [Fact]
        public void GetStudentsGroupsAsync_ReturnsListOfStudentsGroups()
        {
            // Act
            List<StudentsGroup> result = _studentsGroupsRepository.GetStudentsGroupsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public void GetStudentsGroupAsync_WithValidId_ReturnsStudentsGroup()
        {
            // Arrange
            int studentsGroupId = 1;

            // Act
            StudentsGroup result = _studentsGroupsRepository.GetStudentsGroupAsync(studentsGroupId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(studentsGroupId, result.Id);
        }

        [Fact]
        public void GetStudentsGroupAsync_WithInvalidId_ReturnsNull()
        {
            // Arrange
            int studentsGroupId = -1;

            // Act
            StudentsGroup result = _studentsGroupsRepository.GetStudentsGroupAsync(studentsGroupId);

            // Assert
            Assert.Null(result);
        }
    }
}

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
    public class RoleRepositoryTests
    {
        private readonly IMapper _mapperMock;
        private readonly Mock<IRoleRepository> _roleRepositoryMock;
        private readonly RoleRepository _roleRepository;

        public RoleRepositoryTests()
        {
            _mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile()); // Add your mapping profile here
            }).CreateMapper();

            _roleRepositoryMock = new Mock<IRoleRepository>();

            _roleRepository = new RoleRepository(_mapperMock, _roleRepositoryMock.Object);
        }

        [Fact]
        public void GetRolesAsync_ReturnsListOfRoleDTOs()
        {
            // Arrange
            List<Role> rolesFromDB = new List<Role>()
            {
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "User" }
            };
            _roleRepositoryMock.Setup(mock => mock.GetRolesAsync()).Returns(rolesFromDB);

            // Act
            List<RoleDTO> result = _roleRepository.GetRolesAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Admin", result[0].RoleName);
            Assert.Equal("User", result[1].RoleName);
        }

        [Fact]
        public void GetRoleAsync_WithValidId_ReturnsRoleDTO()
        {
            // Arrange
            int roleId = 1;
            Role roleFromDB = new Role { RoleId = roleId, RoleName = "Admin" };
            _roleRepositoryMock.Setup(mock => mock.GetRoleAsync(roleId)).Returns(roleFromDB);

            // Act
            RoleDTO result = _roleRepository.GetRoleAsync(roleId);

            // Assert
            Assert.Equal(roleId, result.RoleId);
            Assert.Equal("Admin", result.RoleName);
        }

        [Fact]
        public void AddRoleAsync_WithValidRoleDTO_CallsAddRoleAsyncOnRepository()
        {
            // Arrange
            RoleDTO role = new RoleDTO { RoleName = "Admin" };

            // Act
            RoleDTO result = _roleRepository.AddRoleAsync(role);

            // Assert
            _roleRepositoryMock.Verify(mock => mock.AddRoleAsync(It.Is<Role>(r => r.RoleName == role.RoleName)), Times.Once);
            Assert.Equal(role, result);
        }
    }
}

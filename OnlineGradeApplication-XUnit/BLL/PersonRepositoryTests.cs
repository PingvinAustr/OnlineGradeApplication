namespace OnlineGradeApplication_XUnit.BLL
{
    using Moq;
    using AutoMapper;
    using Xunit;
    using OnlineGradeApplication_BLL.Interfaces.Implementations;
    using OnlineGradeApplication_DAL.Entities;
    using OnlineGradeApplication_BLL.DTOs;
    using System.Collections.Generic;
    using OnlineGradeApplication_DAL.Interfaces.Abstractions;
    using OnlineGradeApplication_BLL.Responses;


        public class PersonRepositoryTests
        {
            private readonly IMapper _mapperMock;
            private readonly Mock<IPersonRepository> _personRepositoryMock;
            private readonly PersonRepository _personRepository;

            public PersonRepositoryTests()
            {
                _mapperMock = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new OnlineGradeApplication_BLL.Mapper.MappingProfile());
                }).CreateMapper();

                _personRepositoryMock = new Mock<IPersonRepository>();

                _personRepository = new PersonRepository(_mapperMock, _personRepositoryMock.Object);
            }

            [Fact]
            public void GetPeopleAsync_ReturnsListOfPersonDTOs()
            {
                // Arrange
                List<Person> peopleFromDB = new List<Person>()
            {
                new Person { Id = 1, FirstName = "John", LastName = "Doe" },
                new Person { Id = 2, FirstName = "Jane", LastName = "Smith" }
            };
                _personRepositoryMock.Setup(mock => mock.GetPeopleAsync()).Returns(peopleFromDB);

                // Act
                List<PersonDTO> result = _personRepository.GetPeopleAsync();

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Equal("John", result[0].FirstName);
                Assert.Equal("Doe", result[0].LastName);
                Assert.Equal("Jane", result[1].FirstName);
                Assert.Equal("Smith", result[1].LastName);
            }

            [Fact]
            public void GetPersonAsync_WithValidId_ReturnsPersonDTO()
            {
                // Arrange
                int personId = 1;
                Person personFromDB = new Person { Id = personId, FirstName = "John", LastName = "Doe" };
                _personRepositoryMock.Setup(mock => mock.GetPersonAsync(personId)).Returns(personFromDB);

                // Act
                PersonDTO result = _personRepository.GetPersonAsync(personId);

                // Assert
                Assert.Equal(personId, result.Id);
                Assert.Equal("John", result.FirstName);
                Assert.Equal("Doe", result.LastName);
            }

            [Fact]
            public void AddStudent_WithValidPersonDTO_CallsAddStudentOnRepository()
            {
                // Arrange
                PersonDTO person = new PersonDTO { FirstName = "John", LastName = "Doe" };

                // Act
                _personRepository.AddStudent(person);

                // Assert
                _personRepositoryMock.Verify(mock => mock.AddStudent(It.Is<Person>(p => p.FirstName == person.FirstName && p.LastName == person.LastName)), Times.Once);
            }

            [Fact]
            public void EditPerson_WithValidParameters_CallsEditPersonOnRepository()
            {
                // Arrange
                int id = 1;
                string firstName = "Updated First Name";
                string lastName = "Updated Last Name";
                int age = 25;
                int role = 2;
                int systemAccess = 1;

                // Act
                _personRepository.EditPerson(id, firstName, lastName, age, role, systemAccess);

                // Assert
                _personRepositoryMock.Verify(mock => mock.EditPerson(id, firstName, lastName, age, role, systemAccess), Times.Once);
            }

            [Fact]
            public void GetStudents_ReturnsListOfGetStudentsResponse()
            {
                // Arrange
                List<OnlineGradeApplication_DAL.Responses.GetStudentsResponse> studentsFromDB = new List<OnlineGradeApplication_DAL.Responses.GetStudentsResponse>()
            {
                new OnlineGradeApplication_DAL.Responses.GetStudentsResponse { Id = 1, FirstName = "John", LastName = "Doe" },
                new OnlineGradeApplication_DAL.Responses.GetStudentsResponse { Id = 2, FirstName = "Jane", LastName = "Smith" }
            };
                _personRepositoryMock.Setup(mock => mock.GetStudents()).Returns(studentsFromDB);

                // Act
                List<OnlineGradeApplication_BLL.Responses.GetStudentsResponse> result = _personRepository.GetStudents();

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Equal("John", result[0].FirstName);
                Assert.Equal("Doe", result[0].LastName);
                Assert.Equal("Jane", result[1].FirstName);
                Assert.Equal("Smith", result[1].LastName);
            }

            [Fact]
            public void GetStudentByGroupId_WithValidGroupId_ReturnsListOfGetStudentsResponse()
            {
                // Arrange
                int groupId = 1;
                List<OnlineGradeApplication_DAL.Responses.GetStudentsResponse> studentsFromDB = new List<OnlineGradeApplication_DAL.Responses.GetStudentsResponse>()
            {
                new OnlineGradeApplication_DAL.Responses.GetStudentsResponse { Id = 1, FirstName = "John", LastName = "Doe" },
                new OnlineGradeApplication_DAL.Responses.GetStudentsResponse { Id = 2, FirstName = "Jane", LastName = "Smith" }
            };
                _personRepositoryMock.Setup(mock => mock.GetStudentByGroupId(groupId)).Returns(studentsFromDB);

                // Act
                List<OnlineGradeApplication_BLL.Responses.GetStudentsResponse> result = _personRepository.GetStudentByGroupId(groupId);

                // Assert
                Assert.Equal(2, result.Count);
                Assert.Equal("John", result[0].FirstName);
                Assert.Equal("Doe", result[0].LastName);
                Assert.Equal("Jane", result[1].FirstName);
                Assert.Equal("Smith", result[1].LastName);
            }
        }
    }

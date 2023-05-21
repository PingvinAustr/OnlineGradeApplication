using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;
using OnlineGradeApplication_BLL.Responses;

namespace OnlineGradeApplication_BLL.Interfaces.Implementations
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IMapper _PersonMapper;
        private readonly OnlineGradeApplication_DAL.Interfaces.Abstractions.IPersonRepository _person;

        public PersonRepository(IMapper mapper, OnlineGradeApplication_DAL.Interfaces.Abstractions.IPersonRepository person)
        {
            _person = person;
            _PersonMapper = mapper;
        }

        public List<PersonDTO> GetPeopleAsync()
        {
            List<Person> peopleFromDB = _person.GetPeopleAsync();
            List<PersonDTO> people = _PersonMapper.Map<List<Person>, List<PersonDTO>>(peopleFromDB);
            return people;
        }
        public PersonDTO GetPersonAsync(int id)
        {
            var data = _person.GetPersonAsync(id);
            PersonDTO person = _PersonMapper.Map<Person, PersonDTO>(data);
            return person;
        }

        public void AddStudent(PersonDTO person)
        {
            _person.AddStudent(_PersonMapper.Map<PersonDTO,Person>(person));
        }

        public void EditPerson(int id, string firstName, string lastName, int age, int role, int systemAccess)
        {
            _person.EditPerson(id, firstName, lastName, age, role, systemAccess);
        }

        public List<GetStudentsResponse> GetStudents()
        {
            var data = _person.GetStudents();
            List<GetStudentsResponse> list = _PersonMapper.Map<List<OnlineGradeApplication_DAL.Responses.GetStudentsResponse>,List<GetStudentsResponse>>(data);
            return list;
        }

        public List<GetStudentsResponse> GetStudentByGroupId(int groupId)
        {
            var data = _person.GetStudentByGroupId(groupId);
            List<GetStudentsResponse> list = _PersonMapper.Map<List<OnlineGradeApplication_DAL.Responses.GetStudentsResponse>, List<GetStudentsResponse>>(data);
            return list;
        }
    }
}

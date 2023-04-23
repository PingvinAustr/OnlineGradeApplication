using OnlineGradeApplication_BLL.Interfaces.Abstractions;
using OnlineGradeApplication_BLL.DTOs;
using OnlineGradeApplication_DAL.Entities;
using AutoMapper;

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
    }
}

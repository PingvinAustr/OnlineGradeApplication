using OnlineGradeApplication_DAL.Entities;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetPeopleAsync();
        Task<Person> GetPersonAsync(int id);
        Task<Person> AddPersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
    }
}

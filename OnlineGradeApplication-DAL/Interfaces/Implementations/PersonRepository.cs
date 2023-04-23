using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;

namespace OnlineGradeApplication_DAL.Interfaces.Implementations
{
    public class PersonRepository : IPersonRepository
    {

        public List<Person> GetPeopleAsync()
        {
            var _context = new OnlineGradesDbContext();
            return _context.Persons.ToList();
        }
        public Person GetPersonAsync(int id)
        {
            var _context = new OnlineGradesDbContext();
            var person = _context.Persons.FirstOrDefault(x => x.Id == id);
            return person;
        }
        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}

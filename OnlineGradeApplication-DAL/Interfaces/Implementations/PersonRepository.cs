using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Interfaces.Abstractions;
using OnlineGradeApplication_DAL.Responses;

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

        public void AddStudent(Person person)
        {
            var _context = new OnlineGradesDbContext();
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public void EditPerson(int id, string firstName, string lastName, int age, int role, int systemAccess)
        {
            var _context = new OnlineGradesDbContext();
            _context.Persons.Where(x => x.Id == id).FirstOrDefault().FirstName = firstName;
            _context.Persons.Where(x => x.Id == id).FirstOrDefault().LastName = lastName;
            _context.Persons.Where(x => x.Id == id).FirstOrDefault().Age = age;
            _context.Persons.Where(x => x.Id == id).FirstOrDefault().RoleId = role;
            _context.Persons.Where(x => x.Id == id).FirstOrDefault().SystemAccessId = systemAccess;

            _context.SaveChanges();
        }

        public List<GetStudentsResponse> GetStudents()
        {
            var _context = new OnlineGradesDbContext();
            List<GetStudentsResponse> getStudentsResponses = new List<GetStudentsResponse>();
            foreach (var student in _context.Persons.Where(x => x.RoleId == 1003).ToList())
            {
                GetStudentsResponse response = new GetStudentsResponse() { Age = student.Age, FirstName = student.FirstName, LastName = student.LastName, Id = student.Id };
                int? groupId = _context.StudentsGroups.Where(x => x.StudentId == student.Id)?.FirstOrDefault()?.GroupId;
                response.Group = _context.Groups.Where(x=>x.GroupId == groupId).FirstOrDefault();
                getStudentsResponses.Add(response);
            }
            return getStudentsResponses;
        }

        public List<GetStudentsResponse> GetStudentByGroupId(int groupId)
        {
            var _context = new OnlineGradesDbContext();
            List<GetStudentsResponse> getStudentsResponses = new List<GetStudentsResponse>();
            foreach (var student in _context.Persons.Where(x => x.RoleId == 1003).ToList())
            {
                int? currentStudentGroupId = _context.StudentsGroups.Where(x=>x.StudentId==student.Id).FirstOrDefault()?.GroupId;
                if (groupId == currentStudentGroupId)
                {
                    GetStudentsResponse response = new GetStudentsResponse() { Age = student.Age, FirstName = student.FirstName, LastName = student.LastName, Id = student.Id };
                    response.Group = _context.Groups.Where(x => x.GroupId == groupId).FirstOrDefault();
                    getStudentsResponses.Add(response);
                }
            }
            return getStudentsResponses;
        }

        /*
        Task<Role> AddRoleAsync(Role role);
        Task<Role> UpdateRoleAsync(Role role);
        Task DeleteRoleAsync(int id);
        */
    }
}

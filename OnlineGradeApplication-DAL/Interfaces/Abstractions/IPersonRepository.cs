using OnlineGradeApplication_DAL.Entities;
using OnlineGradeApplication_DAL.Responses;

namespace OnlineGradeApplication_DAL.Interfaces.Abstractions
{
    public interface IPersonRepository
    {
        List<Person> GetPeopleAsync();
        Person GetPersonAsync(int id);
        void AddStudent(Person person);
        void EditPerson(int id, string firstName, string lastName, int age, int role, int systemAccess);
        List<GetStudentsResponse> GetStudents();
        List<GetStudentsResponse> GetStudentByGroupId(int groupId);
        /*
        Task<Person> AddPersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
        */
    }
}
